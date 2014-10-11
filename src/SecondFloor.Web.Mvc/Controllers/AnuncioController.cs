using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.Practices.ObjectBuilder2;
using SecondFloor.DataContracts.Messages.Anunciante;
using SecondFloor.DataContracts.Messages.Anuncio;
using SecondFloor.ServiceContracts;
using SecondFloor.Web.Mvc.Models;
using SecondFloor.Web.Mvc.Services;

namespace SecondFloor.Web.Mvc.Controllers
{
    public class AnuncioController : Controller
    {
        private readonly IAnuncioService _anuncioService;

        public AnuncioController(IAnuncioService anuncioService)
        {
            _anuncioService = anuncioService;
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

            var anuncio = new AnuncioViewModels() {AnuncianteId = id};

            return PartialView("AnuncioPartialView", anuncio);
        }

        [HttpPost]
        public PartialViewResult Create([Bind(Exclude = "Id")] AnuncioViewModels anuncio)
        {
            var request = new CadastrarAnuncioRequest() {Anuncio = anuncio.ConvertToAnuncioDto(), AnuncianteId = anuncio.AnuncianteId };
            var response = _anuncioService.CadastrarAnuncio(request);

            ViewBag.Excluir = false;
            ViewBag.Title = "Cadastro de Anuncio";
            ViewBag.Message = response.Message;
            ViewBag.MessageType = response.MessageType;

            if (!response.Success)
            {
                response.Rules.ForEach(x => ModelState.AddModelError(x.Key, x.Value));
                return PartialView("AnuncioPartialView", anuncio);
            }

            return PartialView("Sucesso");
        }


    }
}