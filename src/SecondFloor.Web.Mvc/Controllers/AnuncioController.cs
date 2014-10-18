using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Practices.ObjectBuilder2;
using SecondFloor.DataContracts.DTO;
using SecondFloor.DataContracts.Messages.Anunciante;
using SecondFloor.DataContracts.Messages.Anuncio;
using SecondFloor.DataContracts.Messages.Endereco;
using SecondFloor.DataContracts.Messages.Produto;
using SecondFloor.ServiceContracts;
using SecondFloor.Web.Mvc.Models;
using SecondFloor.Web.Mvc.Services;

namespace SecondFloor.Web.Mvc.Controllers
{
    public class AnuncioController : Controller
    {
        private readonly IAnuncioService _anuncioService;
        private readonly IProdutoService _produtoService;
        private readonly IEnderecoService _enderecoService;

        public AnuncioController(IAnuncioService anuncioService,IProdutoService produtoService, IEnderecoService enderecoService)
        {
            _anuncioService = anuncioService;
            _produtoService = produtoService;
            _enderecoService = enderecoService;
        }

        [HttpGet]
        public PartialViewResult List(string id)
        {
            var request = new EncontrarTodosAnunciosRequest() {AnuncianteId = id};
            var response = _anuncioService.EncontrarTodosAnuncios(request);

            ViewBag.Title = "Lista de Anuncios";
            ViewBag.AnuncianteId = id;

            if (!response.Success)
            {
                return PartialView("ListaAnuncioPartialView", new List<AnuncioViewModels>());
            }

            return PartialView("ListaAnuncioPartialView", response.Anuncios.ConverttoListaAnunciosViewModel());
        }

        [HttpGet]
        public PartialViewResult Create(string id)
        {
            ViewBag.Excluir = false;
            ViewBag.Title = "Cadastro de Anuncio";

            var enderecosRequest = new EncontrarTodosEnderecosRequest() { AnuncianteId = id };
            var enderecosResponse = _enderecoService.EncontrarTodosEnderecos(enderecosRequest);
            if (!enderecosResponse.Success)
            {
                //TODO: nao encontrado enderecos para o anunciante, Direcionar para cadastro de endereco ???
            }

            var anuncio = new AnuncioViewModels() {AnuncianteId = id, Enderecos = enderecosResponse.Enderecos.ConvertToListaEnderecosViewModel()};
            anuncio.Ofertas = GetProdutos(id).ConvertListaProdutosViewModelToListaOfertasViewModel();
            
            return PartialView("AnuncioPartialView", anuncio);
        }

        [HttpPost]
        public PartialViewResult Create([Bind(Exclude = "Id")] AnuncioViewModels anuncio, FormCollection forms)
        {
            string[] strOfertas = Request.Form["item.Checked"].Split(',');
            IList<string> ofertasIds = strOfertas.Where(oferta => oferta != "false").ToList();

            IList<OfertaViewModels> ofertas = GetProdutos(anuncio.AnuncianteId).ConvertListaProdutosViewModelToListaOfertasViewModel();
            IList<OfertaViewModels> ofertasToPersist = ofertas.Where(oferta => ofertasIds.Contains(oferta.Id)).ToList();
            /*IList<OfertaViewModels> ofertasToPersist = new List<OfertaViewModels>();
            foreach (var oferta in ofertas)
            {
                if (ofertasIds.Contains(oferta.Id))
                {
                    ofertasToPersist.Add(oferta);
                }
            }*/
            anuncio.Ofertas = ofertasToPersist;
            var request = new CadastrarAnuncioRequest() {Anuncio = anuncio.ConvertToAnuncioDto(), AnuncianteId = anuncio.AnuncianteId, EnderecoId = anuncio.EnderecoId};
            var response = _anuncioService.CadastrarAnuncio(request);

            ViewBag.Excluir = false;
            ViewBag.Title = "Cadastro de Anuncio";
            ViewBag.Message = response.Message;
            ViewBag.MessageType = response.MessageType;

            if (!response.Success)
            {
                var enderecosRequest = new EncontrarTodosEnderecosRequest() { AnuncianteId = anuncio.AnuncianteId };
                var enderecosResponse = _enderecoService.EncontrarTodosEnderecos(enderecosRequest);
                if (!enderecosResponse.Success)
                {
                    //TODO: nao encontrado enderecos para o anunciante, Direcionar para cadastro de endereco ???
                }
                anuncio.Enderecos = enderecosResponse.Enderecos.ConvertToListaEnderecosViewModel();

                response.Rules.ForEach(x => ModelState.AddModelError(x.Key, x.Value));

                //marcar as ofertas como checked
                ofertas = GetProdutos(anuncio.AnuncianteId).ConvertListaProdutosViewModelToListaOfertasViewModel();
                ofertas.ForEach(oferta => oferta.Checked = ofertasIds.Contains(oferta.Id));
                //ofertas.ForEach(oferta => oferta.Id = Guid.NewGuid().ToString()); //Trocar os IDs de todas ofertas, porem perco o tracking da variacao de produto NH eh melhor !
                anuncio.Ofertas = ofertas; //setar os itens previamente marcados

                return PartialView("AnuncioPartialView", anuncio);
            }

            return PartialView("Sucesso");
        }

        public IList<ProdutoViewModels> GetProdutos(string id)
        {
            var request = new EncontrarTodosProdutosRequest(){AnuncianteId = id};
            var response = _produtoService.EncontrarTodosProdutos(request);
            if (!response.Success)
            {
                //TODO: o que devolver em caso de falha
            }

            return response.Produtos.ConvertToListaProdutosViewModel();
        }
    }
}