using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecondFloor.DataContracts.Messages.Endereco;
using SecondFloor.ServiceContracts;
using SecondFloor.Web.Mvc.Models;
using SecondFloor.Web.Mvc.Services;

namespace SecondFloor.Web.Mvc.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet]
        public PartialViewResult List(string id)
        {
            var request = new EncontrarTodosEnderecosRequest() {AnuncianteId = id};
            var response = _enderecoService.EncontrarTodosEnderecos(request);

            ViewBag.Title = "Lista de Endereços";
            ViewBag.AnuncianteId = id;

            if (response.Success)
            {
                return PartialView("ListaEnderecoPartialView", response.Enderecos.ConvertToListaEnderecosViewModel());
            }

            return PartialView("ListaEnderecoPartialView", new List<EnderecoViewModels>());
        }
        
        [HttpGet]
        public PartialViewResult Create(string id)
        {
            ViewBag.Excluir = false;
            ViewBag.Title = "Cadastro Endereço";

            var endereco = new EnderecoViewModels()
            {
                AnuncianteId = id,
                Logradouro = "Av Teste",
                Numero = 101,
                Complemento = "",
                Bairro = "Bairro Teste",
                Cidade = "Cidade Teste",
                Estado = "UF Testes",
                Cep = "00000-000"
            };

            return PartialView("EnderecoPartialView", endereco);
        }
        
        [HttpPost]
        public PartialViewResult Create([Bind(Exclude = "Id")]EnderecoViewModels endereco)
        {
            if (! ModelState.IsValid)
            {
                return PartialView("EnderecoPartialView", endereco);
            }

            var request = new CadastroEnderecoRequest() {Endereco = endereco.ConvertToEnderecoDto(), AnuncianteId = endereco.AnuncianteId};
            var response = _enderecoService.CadastroEndereco(request);

            ViewBag.Excluir = false;
            ViewBag.Title = "Cadastro Endereço";
            ViewBag.Message = response.Message;
            ViewBag.MessageType = response.MessageType;

            if (!response.Success)
            {
                return PartialView("Error");
            }

            return PartialView("Sucesso");
        }

        
        [HttpGet]
        public PartialViewResult Edit(string id)
        {
            var request = new EncontrarEnderecoRequest() {Id = id};

            var response = _enderecoService.EncontrarEndereco(request);

            if (!response.Success)
            {
                return PartialView("Error");
            }

            ViewBag.Excluir = false;
            ViewBag.Title = "Alterar Endereço";

            var anunciante = response.Endereco.ConvertToEnderecoViewModel();

            return PartialView("EnderecoPartialView", anunciante);
        }
        
        [HttpPost]
        public PartialViewResult Edit(EnderecoViewModels endereco)
        {
            var request = new AlterarEnderecoRequest() {Endereco = endereco.ConvertToEnderecoDto()};

            var response = _enderecoService.AlterarEndereco(request);

            ViewBag.Excluir = false;
            ViewBag.Title = "Alterar Endereço";
            ViewBag.Message = response.Message;
            ViewBag.MessageType = response.MessageType;

            if (!response.Success)
            {
                return PartialView("EnderecoPartialView", endereco);
            }

            return PartialView("Sucesso");
        }

        [HttpGet]
        public PartialViewResult Delete(string id)
        {
            var request = new EncontrarEnderecoRequest() { Id = id };

            var response = _enderecoService.EncontrarEndereco(request);

            if (!response.Success)
            {
                return PartialView("Error");
            }

            ViewBag.Excluir = true;
            ViewBag.Title = "Excluir Endereço";
            ViewBag.Message = "Tem certeza que deseja excluit o Endereco abaixo ?";
            ViewBag.MessageType = "alert-danger";

            var endereco = response.Endereco.ConvertToEnderecoViewModel();

            return PartialView("EnderecoPartialView", endereco);
        }
        
        [HttpPost]
        public PartialViewResult Delete(EnderecoViewModels endereco)
        {
            var request = new ExcluirEnderecoRequest() {Id = endereco.Id};

            var response = _enderecoService.ExcluirEndereco(request);

            ViewBag.Excluir = true;
            ViewBag.Title = "Excluir Endereço";
            ViewBag.Message = response.Message;
            ViewBag.MessageType = response.MessageType;

            if (!response.Success)
            {
                return PartialView("Error");
            }

            return PartialView("Sucesso");
        }
    }
}