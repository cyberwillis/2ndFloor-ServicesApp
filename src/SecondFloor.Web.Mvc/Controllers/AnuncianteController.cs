using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SecondFloor.DataContracts.DTO;
using SecondFloor.DataContracts.Messages.Anunciante;
using SecondFloor.DataContracts.Messages.Usuario;
using SecondFloor.I18n;
using SecondFloor.Infrastructure;
using SecondFloor.Service.ExtensionMethods;
using SecondFloor.ServiceContracts;
using SecondFloor.Web.Mvc.Models;
using SecondFloor.Web.Mvc.Security;
using SecondFloor.Web.Mvc.Services;
using WebGrease.Css.Extensions;

namespace SecondFloor.Web.Mvc.Controllers
{
    
    public class AnuncianteController : BaseController
    {
        private readonly IAnuncianteService _anuncianteService;
        private readonly IUsuarioService _usuarioService;

        public AnuncianteController(IAnuncianteService anuncianteService, IUsuarioService usuarioService)
        {
            _anuncianteService = anuncianteService;
            _usuarioService = usuarioService;
        }

        #region For Ajax Action

        [HttpGet]
        [CustomAuthorize("Anunciante", "List")]
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
        public PartialViewResult Create(AnuncianteViewModels anunciante)
        {
            //Cadastro Anunciante
            var cadastroAnuncianteRequest = new CadastrarAnuncianteRequest() { Anunciante = anunciante.ConvertToAnuncianteDto() };
            var cadastrarAnuncianteResponse = _anuncianteService.CadastrarAnunciante(cadastroAnuncianteRequest);

            ViewBag.Excluir = false;
            ViewBag.Title = Resources.AnuncianteController_HttpPost_Create_Action_ViewBagTitle;
            ViewBag.Message = cadastrarAnuncianteResponse.Message;
            ViewBag.MessageType = cadastrarAnuncianteResponse.MessageType;

            if (!cadastrarAnuncianteResponse.Success)
            {
                cadastrarAnuncianteResponse.Rules.ForEach(x => ModelState.AddModelError(x.Key,x.Value));
                return PartialView("AnunciantePartialView", anunciante); //erro de cadastro
            }

            //Usando account manager infrastructure
            var password = new PasswordGenerator().Generate(); //enviar por email
            var registerView = new RegisterViewModel()
            {
                Email = anunciante.Email,
                Password = password,
                ConfirmPassword = password
            };
            
            //Cadastro de Usuario customizado
            /*var usuarioId = cadastrarAnuncianteResponse.Id;
            var cadastroUsuarioRequest = new CadastrarUsuarioRequest() {
                Usuario = new UsuarioDto()
                {
                    Id = usuarioId,
                    Login = anunciante.Email,
                    Password = new PasswordGenerator().Generate()
                }
            };

            var cadastrarUsuarioResponse = _usuarioService.CadastrarUsuario(cadastroUsuarioRequest);

            if (cadastrarUsuarioResponse.Success)
            {
                //TODO: Enviar email
            }*/

            return PartialView("Sucesso");
        }     

        [HttpGet]
        [Authorize]
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
        [Authorize]
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
        [CustomAuthorize("Anunciante", "Delete")]
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
        [CustomAuthorize("Anunciante", "Delete")]
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
        [AllowAnonymous]
        public ActionResult Index()
        {
            return RedirectToAction("Cadastro");
        }

        [HttpGet]
        [AllowAnonymous]
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
        [AllowAnonymous]
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
                ViewBag.Message = response.Message;
                ViewBag.MessageType = response.MessageType;

                return View("Cadastro", anunciante);
            }

            //Usando account manager infrastructure
            /*var password = new PasswordGenerator().Generate(); //enviar por email
            var registerView = new RegisterViewModel()
            {
                Email = anunciante.Email,
                Password = password,
                ConfirmPassword = password
            };*/

            //Cadastro de Usuario customizado
            var usuarioId = response.Id;
            var cadastroUsuarioRequest = new CadastrarUsuarioRequest() {
                Usuario = new UsuarioDto()
                {
                    Id = usuarioId,
                    Login = anunciante.Email,
                    Password = "1234567890" //new PasswordGenerator().Generate()
                }
            };

            var cadastrarUsuarioResponse = _usuarioService.CadastrarUsuario(cadastroUsuarioRequest);

            if (cadastrarUsuarioResponse.Success)
            {
                //TODO: Enviar email
            }
            
            //TODO: Caso Anunciante (aproveitando o usuario salvo na sessao)
            //ViewBag.Title = "Detalhes";
            //return RedirectToAction("Detalhes", new { Id = response.Id });

            //TODO: Caso Administrador listar todos anunciantes
            ViewBag.Title = Resources.AnuncianteController_HttpPost_Cadastro_Action_ViewBagTitle_Adm;
            return RedirectToAction("Listar");
        }

        [HttpGet]
        //[CustomAuthorize("Anunciante", "Listar")]
        [Authorize]
        public ActionResult Listar()
        {
            //TODO: caso seja anuncinte manda para Detalhes
            //var principal = ClaimsPrincipal.Current;
            //var userid = principal.FindFirst(ClaimTypes.NameIdentifier).Value;
            //if (!principal.HasClaim(ClaimTypes.NameIdentifier,default(Guid).ToString()))
            //{
            //    return Redirect("Anunciante/Detalhes/" + userid); //View("Detalhes", new {id = userid});
            //}

            ViewBag.Title = Resources.AnuncianteController_HttpGet_Listar_Action_ViewBagTitle;

            var response = _anuncianteService.EncontrarTodosAnunciantes();
            if (response.Success)
            {
                return View("Lista", response.Anunciantes.ConvertToListaListaAnunciantesViewModel());
            }

            return View("Error");
        }
        
        [HttpGet]
        [Authorize]
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