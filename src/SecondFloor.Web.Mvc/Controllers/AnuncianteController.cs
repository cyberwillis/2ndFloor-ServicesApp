using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using SecondFloor.DataContracts.Messages;
using SecondFloor.DataContracts.Messages.Anunciante;
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

        #region For Ajax Action

        [HttpGet]
        public PartialViewResult List()
        {
            var response = _anuncianteService.EncontrarTodosAnunciantes();

            ViewBag.Title = "Lista de Anunciantes";

            if (response.Success)
            {
                return PartialView("ListaAnunciantePartialView", response.Anunciantes.ConvertToListaListaAnunciantesViewModel());
            }

            return PartialView("ListaAnunciantePartialView", new List<AnuncianteViewModels>());
        }

        [HttpGet]
        public PartialViewResult Detail(string id)
        {

            var request = new EncontrarAnuncianteRequest() { Id = id };

            var response = _anuncianteService.EncontrarAnunciantePor(request);

            ViewBag.Title = "Detalhes de Anunciante";

            if (response.Success)
            {
                return PartialView("AnuncianteDetalhesPartialView", response.Anunciante.ConvertAnuncianteViewModels());
            }

            return PartialView("Error");
        }

        [HttpGet]
        public PartialViewResult Create()
        {
            ViewBag.Excluir = false;
            ViewBag.Title = "Cadastro Anunciante";

            //TODO: remover dados default do formulario e impedir cadastro com mesmo CNPJ
            //var anunciante = new AnuncianteViewModels();
            var anunciante = new AnuncianteViewModels()
            {
                RazaoSocial = "Oficina de entretenimento adulto do tio careca",
                NomeResponsavel = "Fulano de Tal",
                Email = "careca@careca.com.br",
                Cnpj = "40.123.456.0001-63",
            };
            //anunciante.Enderecos = new List<EnderecoViewModels>();

            return PartialView("AnunciantePartialView", anunciante);
        }

        [HttpPost]
        public PartialViewResult Create(AnuncianteViewModels anunciante)
        {
            var request = new CadastrarAnuncianteRequest() { Anunciante = anunciante.ConvertToAnuncianteDto() };

            var response = _anuncianteService.CadastrarAnunciante(request);

            ViewBag.Excluir = false;
            ViewBag.Title = "Cadastro Anunciante";
            ViewBag.Message = response.Message;
            ViewBag.MessageType = response.MessageType;

            if (!ModelState.IsValid)
            {
                return PartialView("AnunciantePartialView", anunciante); //erro de cadastro
            }

            if (!response.Success)
            {
                return PartialView("Error");
            }

            return PartialView("Sucesso");
        }     

        [HttpGet]
        public PartialViewResult Edit(string id)
        {
            var request = new EncontrarAnuncianteRequest() { Id = id };

            var response = _anuncianteService.EncontrarAnunciantePor(request);

            if (!response.Success)
            {
                return PartialView("Error");
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
        public PartialViewResult Delete(string id)
        {
            var request = new EncontrarAnuncianteRequest() { Id = id };

            var response = _anuncianteService.EncontrarAnunciantePor(request);

            if (!response.Success)
            {
                return PartialView("Error");
            }

            ViewBag.Excluir = true;
            ViewBag.Title = "Excluir Anunciante";
            ViewBag.Message = "Tem certeza que deseja excluit o Anunciante abaixo ?";
            ViewBag.MessageType = "alert-danger";

            var anunciante = response.Anunciante.ConvertAnuncianteViewModels();

            return PartialView("AnunciantePartialView", anunciante);
        }

        [HttpPost]
        public PartialViewResult Delete(AnuncianteViewModels anunciante)
        {
            var request = new ExcluirAnuncianteRequest(){Id=anunciante.Id};

            var response = _anuncianteService.ExcluirAnunciante(request);

            ViewBag.Excluir = true;
            ViewBag.Title = "Excluir Anunciante";
            ViewBag.Message = response.Message;
            ViewBag.MessageType = response.MessageType;

            if (!response.Success)
            {
                return PartialView("Error");
            }
            
            return PartialView("Sucesso");
        }

        #endregion
        

        #region Friendly Actions
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

            return View("Cadastro",anunciante);
        }

        [HttpPost]
        public ActionResult Cadastro([Bind(Exclude = "Id")] AnuncianteViewModels anunciante)
        {
            ViewBag.Excluir = false;
            ViewBag.Title = "Cadastro Anunciante";

            if (!ModelState.IsValid)
            {
                return View("Cadastro", anunciante); //erro de cadastro
            }

            var request = new CadastrarAnuncianteRequest() { Anunciante = anunciante.ConvertToAnuncianteDto() };

            var response = _anuncianteService.CadastrarAnunciante(request);
            if (!response.Success)
            {
                return RedirectToAction("Erro");
            }

            //TODO: Caso Anunciante (aproveitando o usuario salvo na sessao)
            //ViewBag.Title = "Detalhes";
            //return RedirectToAction("Detalhes", new { Id = response.Id });

            //TODO: Caso Administrador listar todos anunciantes
            ViewBag.Title = "Lista de Anunciantes";
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Listar()
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
        public ActionResult Detalhes(string id)
        {
            var request = new EncontrarAnuncianteRequest() { Id = id };

            var response = _anuncianteService.EncontrarAnunciantePor(request);
            if (response.Success)
            {
                ViewBag.Title = "Detalhes de Anunciante";

                return View("Detalhes", response.Anunciante.ConvertAnuncianteViewModels());
            }

            return PartialView("Error");
        }

        [HttpGet]
        public ViewResult Erro()
        {
            return View("Error");
        }
        #endregion
    }
}