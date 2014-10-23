using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Practices.ObjectBuilder2;
using SecondFloor.DataContracts.Messages.Anunciante;
using SecondFloor.DataContracts.Messages.Anuncio;
using SecondFloor.DataContracts.Messages.Endereco;
using SecondFloor.DataContracts.Messages.Produto;
using SecondFloor.I18n;
using SecondFloor.ServiceContracts;
using SecondFloor.Web.Mvc.Models;
using SecondFloor.Web.Mvc.Services;

namespace SecondFloor.Web.Mvc.Controllers
{
    public class AnuncioController : BaseController
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

            ViewBag.Title = Resources.AnuncioController_HttpGet_List_Action_ViewBagTitle;
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
            ViewBag.Title = Resources.AnuncioController_HttpGet_Create_Action_ViewBagTitle;

            var enderecos = GetEnderecosPorAnunciante(id);
            var ofertas = GetProdutosPorAnunciante(id);
            var anuncio = new AnuncioViewModels()
            {
                AnuncianteId = id, 
                Enderecos = enderecos, 
                Ofertas = ofertas.ConvertListaProdutosViewModelToListaOfertasViewModel(),
            };
            
            return PartialView("AnuncioPartialView", anuncio);
        }

        [HttpPost]
        public PartialViewResult Create([Bind(Exclude = "Id")] AnuncioViewModels anuncio, FormCollection forms)
        {
            //Enderecos do Anunciante // ????
            var enderecos = GetEnderecosPorAnunciante(anuncio.AnuncianteId);
            anuncio.Enderecos = enderecos;

            //Produtos Marcados
            var produtos = GetProdutosPorAnunciante(anuncio.AnuncianteId);

            string[] ofertasCheckboxes = Request.Form["item.Checked"].Split(',');
            IList<string> ofertasChecadas = ofertasCheckboxes.Where(oferta => oferta != "false").ToList();
            IList<OfertaViewModels> produtosDisponiveis = produtos.ConvertListaProdutosViewModelToListaOfertasViewModel();
            IList<OfertaViewModels> ofertasParaPersistencia = produtosDisponiveis.Where(oferta => ofertasChecadas.Contains(oferta.Id)).ToList();
            anuncio.Ofertas = ofertasParaPersistencia;

            //Endereco Selecionado
            var endereco = GetEnderecoPorId(anuncio.EnderecoId);
            anuncio.Endereco = endereco;
            anuncio.Ofertas.ForEach(o=> o.Endereco = endereco);

            //Request
            var request = new CadastrarAnuncioRequest(){ Anuncio = anuncio.ConvertToAnuncioDto(),  AnuncianteId = anuncio.AnuncianteId };
            var response = _anuncioService.CadastrarAnuncio(request);

            ViewBag.Excluir = false;
            ViewBag.Title = Resources.AnuncioController_HttpPost_Create_Action_ViewBagTitle;
            ViewBag.Message = response.Message;
            ViewBag.MessageType = response.MessageType;

            if (!response.Success)
            {
                //Lista de endereco para devolver a view
                

                response.Rules.ForEach(x => ModelState.AddModelError(x.Key, x.Value));

                //marcar as ofertas como checked
                produtosDisponiveis = GetProdutosPorAnunciante(anuncio.AnuncianteId).ConvertListaProdutosViewModelToListaOfertasViewModel();
                produtosDisponiveis.ForEach(oferta => oferta.Checked = ofertasChecadas.Contains(oferta.Id));
                //ofertas.ForEach(oferta => oferta.Id = Guid.NewGuid().ToString()); //Trocar os IDs de todas ofertas, porem perco o tracking da variacao de produto NH eh melhor !
                anuncio.Ofertas = produtosDisponiveis; //setar os itens previamente marcados

                return PartialView("AnuncioPartialView", anuncio);
            }

            return PartialView("Sucesso");
        }

        [HttpGet]
        public PartialViewResult Edit(string id)
        {
            var request = new EncontrarAnuncioRequest(){ Id = id};
            var response = _anuncioService.EncontrarAnuncioPor(request);

            ViewBag.Excluir = false;
            ViewBag.Title = "Alterar Anuncio";

            if (!response.Success)
            {
                return PartialView("Error");
            }

            var anuncio = response.Anuncio.ConvertToAnuncioViewModels();
            var ofertasDoAnuncio = response.Anuncio.Ofertas.ConvertToListaOfertasViewModel(); 
            IList<string> ofertasIds = new List<string>();
            ofertasDoAnuncio.ForEach(oferta => ofertasIds.Add(oferta.Id)); //ids dos produtos que meu anuncio tem (3)

            IList<OfertaViewModels> ofertasDisponiveis = GetProdutosPorAnunciante(anuncio.AnuncianteId).ConvertListaProdutosViewModelToListaOfertasViewModel(); //produtos disponiveis (10)
            foreach (var oferta in ofertasDisponiveis)
            {
                oferta.Checked = ofertasIds.Contains(oferta.Id);
            }
            //ofertasDisponiveis.ForEach(oferta => oferta.Checked = ofertasIds.Contains(oferta.Id));
            //var enderecos = GetEnderecosPorAnunciante(anuncio.AnuncianteId);
            //anuncio.Enderecos = enderecos;
            anuncio.Ofertas = ofertasDisponiveis;

            return PartialView("AnuncioAlterarPartialView", anuncio);
        }

        [HttpPost]
        public PartialViewResult Edit(AnuncioViewModels anuncio, FormCollection forms)
        {
            //Enderecos do Anunciante // ????
            var enderecos = GetEnderecosPorAnunciante(anuncio.AnuncianteId);
            anuncio.Enderecos = enderecos;

            //Produtos Marcados
            var produtos = GetProdutosPorAnunciante(anuncio.AnuncianteId);

            string[] ofertasCheckboxes = Request.Form["item.Checked"].Split(',');
            IList<string> ofertasChecadas = ofertasCheckboxes.Where(oferta => oferta != "false").ToList();
            IList<OfertaViewModels> produtosDisponiveis = produtos.ConvertListaProdutosViewModelToListaOfertasViewModel();
            IList<OfertaViewModels> ofertasParaPersistencia = produtosDisponiveis.Where(oferta => ofertasChecadas.Contains(oferta.Id)).ToList();
            anuncio.Ofertas = ofertasParaPersistencia;

            //Endereco Selecionado
            var endereco = GetEnderecoPorId(anuncio.EnderecoId);
            anuncio.Endereco = endereco;
            anuncio.Ofertas.ForEach(o => o.Endereco = endereco);

            var request = new AlterarAnuncioRequest(){ AnuncianteId = anuncio.AnuncianteId, Anuncio = anuncio.ConvertToAnuncioDto() };
            var response = _anuncioService.AlterarAnuncio(request);

            ViewBag.Excluir = false;
            ViewBag.Title = "Alterar Anuncio";
            ViewBag.Message = response.Message;
            ViewBag.MessageType = response.MessageType;

            if (!response.Success)
            {
                //Lista de endereco para devolver a view


                response.Rules.ForEach(x => ModelState.AddModelError(x.Key, x.Value));

                //marcar as ofertas como checked
                produtosDisponiveis = GetProdutosPorAnunciante(anuncio.AnuncianteId).ConvertListaProdutosViewModelToListaOfertasViewModel();
                produtosDisponiveis.ForEach(oferta => oferta.Checked = ofertasChecadas.Contains(oferta.Id));
                //ofertas.ForEach(oferta => oferta.Id = Guid.NewGuid().ToString()); //Trocar os IDs de todas ofertas, porem perco o tracking da variacao de produto NH eh melhor !
                anuncio.Ofertas = produtosDisponiveis; //setar os itens previamente marcados

                return PartialView("AnuncioAlterarPartialView", anuncio);
            }

            return PartialView("Sucesso");
        }

        public IList<ProdutoViewModels> GetProdutosPorAnunciante(string id)
        {
            var request = new EncontrarTodosProdutosRequest(){AnuncianteId = id};
            var response = _produtoService.EncontrarTodosProdutos(request);
            if (!response.Success)
            {
                //TODO: o que devolver em caso de falha
            }

            return response.Produtos.ConvertToListaProdutosViewModel();
        }

        public IList<EnderecoViewModels> GetEnderecosPorAnunciante(string id)
        {
            var request = new EncontrarTodosEnderecosRequest() { AnuncianteId = id };
            var response = _enderecoService.EncontrarTodosEnderecos(request);
            if (!response.Success)
            {
                //TODO: o que devolver em caso de falha
            }

            return response.Enderecos.ConvertToListaEnderecosViewModel();
        }

        public EnderecoViewModels GetEnderecoPorId(string id)
        {
            //Endereco selecionado para o Anuncio
            var request = new EncontrarEnderecoRequest() { Id = id };
            var response = _enderecoService.EncontrarEnderecoPor(request);
            if (!response.Success)
            {
                //TODO: retornar para a view de Novo Anuncio
            }

            return response.Endereco.ConvertToEnderecoViewModel();
        }
    }
}