using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using SecondFloor.DataContracts.Messages;
using SecondFloor.ServiceContracts;
using SecondFloor.Web.Mvc.Models;
using SecondFloor.Web.Mvc.Services;

namespace SecondFloor.Web.Mvc.Controllers
{
    public class AnuncianteController : Controller
    {
        private readonly IAnuncianteService _anuncianteService;

        public AnuncianteController(IAnuncianteService anuncianteService)
        {
            _anuncianteService = anuncianteService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("Cadastro");
        }

        [HttpGet]
        public ActionResult Cadastro()
        {
            ViewBag.Excluir = false;
            ViewBag.Title = "Cadastro Anunciante";

            var anunciante = new AnuncianteViewModels()
            {
                RazaoSocial = "Oficina de entretenimento adulto do tio careca",
                NomeResponsavel = "Fulano de Tal",
                Email = "careca@careca.com.br",
                Cnpj = "40.123.456.0001-63",
            };

            //anunciante.Enderecos = new List<EnderecoViewModels>();

            return View(anunciante);
        }

        [HttpPost]
        public ActionResult Cadastro([Bind(Exclude = "Id")] AnuncianteViewModels anunciante)
        {
            if (!ModelState.IsValid)
            {
                return View("Cadastro",anunciante); //erro de cadastro
            }

            var request = new CadastroAnuncianteRequest() { Anunciante = anunciante.ConvertToAnuncianteDto() };
            var response = _anuncianteService.CadastrarAnunciante(request);
            if (!response.Success)
            {
                RedirectToAction("Erro");
            }

            //TODO: Caso Anunciante (aproveitando o usuario salvo na sessao)
            //ViewBag.Title = "Detalhes";
            //return RedirectToAction("Detalhes", new { Id = response.Id });

            //TODO: Caso Administrador listar todos anunciantes
            ViewBag.Title = "Lista de Anunciantes";
            return RedirectToAction("ListaAnunciante");
        }

        [HttpGet]
        public ActionResult ListaAnunciante()
        {
            ViewBag.Title = "Lista de Anunciantes";

            var response = _anuncianteService.EncontrarTodosAnunciantes();
            if (response.Success)
            {
                return View("Lista", response.Anunciantes.ConvertToListaListaAnunciantesViewModel());
            }
            
            return View("Error");
        }

        [HttpGet]
        public PartialViewResult Lista()
        {
            ViewBag.Title = "Lista de Anunciantes";

            var response = _anuncianteService.EncontrarTodosAnunciantes();
            if (response.Success)
            {
                return PartialView("ListaAnunciantePartialView", response.Anunciantes.ConvertToListaListaAnunciantesViewModel());
            }

            return PartialView("ListaAnunciantePartialView", new List<AnuncianteViewModels>());
        }

        [HttpGet]
        public ActionResult Detalhes(string id)
        {
            var request = new EncontrarAnuncianteRequest() {Id = id};
            var response = _anuncianteService.EncontrarAnunciantePor(request);
            if (response.Success)
            {
                ViewBag.Title = "Detalhes de Anunciante";

                return View("Detalhes",response.Anunciante.ConvertAnuncianteViewModels());
            }
            
            return View("Error");
        }

        [HttpGet]
        public PartialViewResult Edit(string id)
        {
            var request = new EncontrarAnuncianteRequest() { Id = id };

            var response = _anuncianteService.EncontrarAnunciantePor(request);

            if (!response.Success)
            {
                RedirectToAction("Erro");
            }

            ViewBag.Excluir = false;
            ViewBag.Title = "Alterar Anunciante";

            var anunciante = response.Anunciante.ConvertAnuncianteViewModels();
            
            return PartialView("AnunciantePartialView", anunciante);
        }

        [HttpPost]
        public PartialViewResult Edit(AnuncianteViewModels anunciante)
        {
            var request = new AlterarAnuncianteRequest() {Anunciante = anunciante.ConvertToAnuncianteDto()};
            
            var response = _anuncianteService.AlterarAnunciante(request);

            ViewBag.Excluir = false;
            ViewBag.Title = "Alterar Anunciante";
            ViewBag.Message = response.Message;
            ViewBag.MessageType = response.MessageType;

            if (!response.Success)
            {
                return PartialView("AnunciantePartialView", anunciante);
            }

            return PartialView("Sucesso");
        }

        [HttpGet]
        public PartialViewResult Create()
        {
            ViewBag.Excluir = false;
            ViewBag.Title = "Cadastro Anunciante";

            //TODO: remover dados default do formulario e impedir cadastro com mesmo CNPJ
            var anunciante = new AnuncianteViewModels();

            //anunciante.Enderecos = new List<EnderecoViewModels>();

            return PartialView("AnunciantePartialView", anunciante);
        }

        [HttpPost]
        public PartialViewResult Create(AnuncianteViewModels anunciante)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Excluir = false;
                ViewBag.Title = "Cadastro Anunciante";
                return PartialView("AnunciantePartialView", anunciante); //erro de cadastro
            }

            var request = new CadastroAnuncianteRequest() { Anunciante = anunciante.ConvertToAnuncianteDto() };
            var response = _anuncianteService.CadastrarAnunciante(request);
            if (!response.Success)
            {
                RedirectToAction("Erro");
            }

            return PartialView("Sucesso");
        }

        [HttpGet]
        public ViewResult Erro()
        {
            return View("Error");
        }
    }
}