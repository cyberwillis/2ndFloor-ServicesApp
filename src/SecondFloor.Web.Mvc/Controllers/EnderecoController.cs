using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecondFloor.DataContracts.Messages.Endereco;
using SecondFloor.ServiceContracts;
using SecondFloor.Web.Mvc.Models;
using SecondFloor.Web.Mvc.Services;
using WebGrease.Css.Extensions;

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
            var request = new EncontrarTodosEnderecosRequest() { AnuncianteId = id };
            var response = _enderecoService.EncontrarTodosEnderecos(request);

            ViewBag.Title = "Lista de Endereços";
            ViewBag.AnuncianteId = id;

            if (!response.Success)
            {
                return PartialView("ListaEnderecoPartialView", new List<EnderecoViewModels>());
            }
            
            return PartialView("ListaEnderecoPartialView", response.Enderecos.ConvertToListaEnderecosViewModel());
        }
        
        [HttpGet]
        public PartialViewResult Create(string id)
        {
            ViewBag.Excluir = false;
            ViewBag.Title = "Cadastro de Endereço";

            var endereco = new EnderecoViewModels() {AnuncianteId = id};
            endereco = new EnderecoViewModels()
            {
                AnuncianteId = id,
                Logradouro = "Rua teste",
                Numero = 10,
                Complemento = "sei la",
                Bairro = "Jardim do Paraiso",
                Cidade = "Sao Paulo",
                Estado = "SP",
                Cep = "00000-000"
            };

            return PartialView("EnderecoPartialView", endereco);
        }
        
        [HttpPost]
        public PartialViewResult Create([Bind(Exclude = "Id")]EnderecoViewModels endereco)
        {
            var request = new CadastrarEnderecoRequest() { Endereco = endereco.ConvertToEnderecoDto(), AnuncianteId = endereco.AnuncianteId };
            var response = _enderecoService.CadastrarEndereco(request);

            ViewBag.Excluir = false;
            ViewBag.Title = "Cadastro de Endereço";
            ViewBag.Message = response.Message;
            ViewBag.MessageType = response.MessageType;

            if (!response.Success)
            {
                response.Rules.ForEach(x=>ModelState.AddModelError(x.Key,x.Value)); //hidratacao de erros no ModelState
                return PartialView("EnderecoPartialView", endereco);
            }

            return PartialView("Sucesso");
        }

        
        [HttpGet]
        public PartialViewResult Edit(string id)
        {
            var request = new EncontrarEnderecoRequest() {Id = id};
            var response = _enderecoService.EncontrarEnderecoPor(request);

            ViewBag.Excluir = false;
            ViewBag.Title = "Alterar Endereço";

            if (!response.Success)
            {
                return PartialView("Error");
            }

            return PartialView("EnderecoPartialView", response.Endereco.ConvertToEnderecoViewModel());
        }
        
        [HttpPost]
        public PartialViewResult Edit(EnderecoViewModels endereco)
        {
            var request = new AlterarEnderecoRequest() { Endereco = endereco.ConvertToEnderecoDto() };
            var response = _enderecoService.AlterarEndereco(request);

            ViewBag.Excluir = false;
            ViewBag.Title = "Alterar Endereço";
            ViewBag.Message = response.Message;
            ViewBag.MessageType = response.MessageType;

            if (!response.Success)
            {
                response.Rules.ForEach(x => ModelState.AddModelError(x.Key, x.Value)); //hidratacao de erros no ModelState
                return PartialView("EnderecoPartialView", endereco);
            }

            return PartialView("Sucesso");
        }

        [HttpGet]
        public PartialViewResult Delete(string id)
        {
            var request = new EncontrarEnderecoRequest() { Id = id };
            var response = _enderecoService.EncontrarEnderecoPor(request);

            ViewBag.Excluir = true;
            ViewBag.Title = "Excluir Endereço";
            ViewBag.Message = "Tem certeza que deseja excluit o Endereco abaixo ?";
            ViewBag.MessageType = "alert-danger";

            if (!response.Success)
            {
                return PartialView("Error");
            }

            return PartialView("EnderecoPartialView", response.Endereco.ConvertToEnderecoViewModel());
        }
        
        [HttpPost]
        public PartialViewResult Delete(EnderecoViewModels endereco)
        {
            var request = new ExcluirEnderecoRequest() { Id = endereco.Id };
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