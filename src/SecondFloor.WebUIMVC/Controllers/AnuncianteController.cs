using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SecondFloor.DataContracts.Messages;
using SecondFloor.ServiceContracts;
using SecondFloor.WebUIMVC.Models;
using SecondFloor.WebUIMVC.Services;

namespace SecondFloor.WebUIMVC.Controllers
{
    public class AnuncianteController : Controller
    {
        private IAnuncianteService _anuncianteService;

        public AnuncianteController(IAnuncianteService anuncianteService)
        {
            _anuncianteService = anuncianteService;
        }

        #region Anunciante
        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("Cadastro");
        }

        [HttpGet]
        public ActionResult Cadastro()
        {
            ViewBag.Title = "Cadastro Anunciante";

            var anunciante = new AnuncianteViewModels()
            {
                RazaoSocial = "Oficina de entretenimento adulto do tio careca",
                NomeResponsavel = "Fulano de Tal",
                Email = "careca@careca.com.br",
                Cnpj = "40.123.456.0001-63",
            };

            anunciante.Enderecos = new List<EnderecoViewModels>();

            return View(anunciante);
        }

        [HttpPost]
        public PartialViewResult Cadastro([Bind(Exclude = "Id")] AnuncianteViewModels anunciante)
        {
            return PartialView("AnunciantePartialView");

            /*if (!ModelState.IsValid)
            {
                return PartialView("",anunciante);
            }

            var request = new CadastroAnuncianteRequest() { Anunciante = anunciante.ConvertToAnuncianteDto() };
            var response = _anuncianteService.CadastrarAnunciante(request);
            if (response.Success)
            {
                //TODO: Caso Anunciante (aproveitando o usuario salvo)
                ViewBag.Title = "Detalhes";
                //return RedirectToAction("Detalhes", new { Id = response.Id });

                //TODO: Caso Administrador
                //ViewBag.Title = "Lista de Anunciantes";
                //return RedirectToAction("Lista");
            }

            return PartialView("Anunciante",anunciante);*/
        }

        [HttpGet]
        public ActionResult Detalhes(string id)
        {
            var request = new EncontrarAnuncianteRequest() {Id = id};
            var response = _anuncianteService.EncontrarAnunciantePor(request);
            if (response.Success)
            {
                return View(response.Anunciante.ConvertAnuncianteViewModels());
            }

            return View("Error");
        }

        [HttpGet]
        public ActionResult AlterarCadastro(string id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AlterarCadastro(AnuncianteViewModels anunciante)
        {
            return View();
        }
        #endregion


        #region Endereco
        [HttpGet]
        public ActionResult NovoEndereco()
        {
            var endereco = new EnderecoViewModels();

            return PartialView("EnderecoPartialView",endereco);
        }

        [HttpPost]
        public ActionResult NovoEndereco(EnderecoViewModels endereco)
        {
            return View();
        }

        [HttpGet]
        public ActionResult AlterarEndereco(string id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AlterarEndereco(EnderecoViewModels endereco)
        {
            return View();
        }

        #endregion

    }
}