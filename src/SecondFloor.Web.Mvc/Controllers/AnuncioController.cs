using System.Collections.Generic;
using System.Web.Mvc;
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
    }
}