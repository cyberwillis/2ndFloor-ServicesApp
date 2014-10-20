using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using SecondFloor.DataContracts.Messages;
using SecondFloor.DataContracts.Messages.Anunciante;
using SecondFloor.I18N;
using SecondFloor.ServiceContracts;
using SecondFloor.Web.Mvc.Models;
using SecondFloor.Web.Mvc.Services;
using WebGrease.Css.Extensions;

namespace SecondFloor.Web.Mvc.Controllers
{
    public class AnuncianteController : BaseController
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

            ViewBag.Title = Resources.AnuncianteController_HttpGet_List_Action_ViewBagTitle;

            if (!response.Success)
            {
                return PartialView("ListaAnunciantePartialView", new List<AnuncianteViewModels>());
            }

            return PartialView("ListaAnunciantePartialView", response.Anunciantes.ConvertToListaListaAnunciantesViewModel());
        }

        [HttpGet]
        public PartialViewResult Detail(string id)
        {

            var request = new EncontrarAnuncianteRequest() { Id = id };
            var response = _anuncianteService.EncontrarAnunciantePor(request);

            ViewBag.Title = Resources.AnuncianteController_HttpGet_Detail_Action_ViewBagTitle;

            if (!response.Success)
            {
                return PartialView("Error");
            }
            
            return PartialView("AnuncianteDetalhesPartialView", response.Anunciante.ConvertAnuncianteViewModels());
        }

        [HttpGet]
        public PartialViewResult Create()
        {
            ViewBag.Excluir = false;
            ViewBag.Title = Resources.AnuncianteController_HttpGet_Create_Action_ViewBagTitle;

            //TODO: remover dados default do formulario e impedir cadastro com mesmo CNPJ
            var anunciante = new AnuncianteViewModels();
            anunciante = new AnuncianteViewModels()
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
            ViewBag.Title = Resources.AnuncianteController_HttpPost_Create_Action_ViewBagTitle;
            ViewBag.Message = response.Message;
            ViewBag.MessageType = response.MessageType;

            if (!response.Success)
            {
                response.Rules.ForEach(x => ModelState.AddModelError(x.Key,x.Value));
                return PartialView("AnunciantePartialView", anunciante); //erro de cadastro
            }

            return PartialView("Sucesso");
        }     

        [HttpGet]
        public PartialViewResult Edit(string id)
        {
            var request = new EncontrarAnuncianteRequest() { Id = id };
            var response = _anuncianteService.EncontrarAnunciantePor(request);

            ViewBag.Excluir = false;
            ViewBag.Title = Resources.AnuncianteController_HttpGet_Edit_Action_ViewBagTitle;

            if (!response.Success)
            {
                return PartialView("Error");
            }
            
            var anunciante = response.Anunciante.ConvertAnuncianteViewModels();
            
            return PartialView("AnunciantePartialView", anunciante);
        }

        [HttpPost]
        public PartialViewResult Edit(AnuncianteViewModels anunciante)
        {
            var request = new AlterarAnuncianteRequest() {Anunciante = anunciante.ConvertToAnuncianteDto()};
            var response = _anuncianteService.AlterarAnunciante(request);

            ViewBag.Excluir = false;
            ViewBag.Title = Resources.AnuncianteController_HttpPost_Edit_Action_ViewBagTitle;
            ViewBag.Message = response.Message;
            ViewBag.MessageType = response.MessageType;

            if (!response.Success)
            {
                response.Rules.ForEach(x => ModelState.AddModelError(x.Key,x.Value));
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
            ViewBag.Title = Resources.AnuncianteController_HttpGet_Delete_Action_ViewBagTitle;
            ViewBag.Message = Resources.AnuncianteController_HttpGet_Delete_Action_ViewBagMessage;
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
            ViewBag.Title = Resources.AnuncianteController_HttpPost_Delete_Action_ViewBagTitle;
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
            ViewBag.Title = Resources.AnuncianteController_HttpGet_Cadastro_Action_ViewBagTitle;

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
            ViewBag.Title = Resources.AnuncianteController_HttpPost_Cadastro_Action_ViewBagTitle;

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
            ViewBag.Title = Resources.AnuncianteController_HttpPost_Cadastro_Action_ViewBagTitle_Adm;
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Listar()
        {
            ViewBag.Title = Resources.AnuncianteController_HttpGet_Listar_Action_ViewBagTitle;

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
                ViewBag.Title = Resources.AnuncianteController_HttpGet_Detalhes_Action_ViewBagTitle;

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