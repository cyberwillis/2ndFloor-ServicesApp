using System.Collections.Generic;
using System.Web.Mvc;
using SecondFloor.DataContracts.Messages.Endereco;
using SecondFloor.I18n;
using SecondFloor.ServiceContracts;
using SecondFloor.Web.Mvc.Models;
using SecondFloor.Web.Mvc.Services;
using WebGrease.Css.Extensions;

namespace SecondFloor.Web.Mvc.Controllers
{
    public class EnderecoController : BaseController
    {
        private readonly IEnderecoService _enderecoService;
        private readonly IEstadoService _estadoService;

        public EnderecoController(IEnderecoService enderecoService, IEstadoService estadoService)
        {
            _enderecoService = enderecoService;
            _estadoService = estadoService;
        }

        [HttpGet]
        public PartialViewResult List(string id)
        {
            var request = new EncontrarTodosEnderecosRequest() { AnuncianteId = id };
            var response = _enderecoService.EncontrarTodosEnderecos(request);

            ViewBag.Title = Resources.EnderecoController_HttpGet_List_Action_ViewBagTitle;
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
            ViewBag.Title = Resources.EnderecoController_HttpGet_Create_Action_ViewBagTitle;

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
            endereco.Estados = GetEstados(); //TODO: verificar caso retorne null

            return PartialView("EnderecoPartialView", endereco);
        }
        
        [HttpPost]
        public PartialViewResult Create([Bind(Exclude = "Id")]EnderecoViewModels endereco)
        {
            var request = new CadastrarEnderecoRequest()
            {
                AnuncianteId = endereco.AnuncianteId,
                Endereco = endereco.ConvertToEnderecoDto(), 
                EstadoSigla = endereco.Estado //TODO: ficar de olho na sigla de estados passada por fora
            };
            var response = _enderecoService.CadastrarEndereco(request);

            ViewBag.Excluir = false;
            ViewBag.Title = Resources.EnderecoController_HttpPost_Create_Action_ViewBagTitle;
            ViewBag.Message = response.Message;
            ViewBag.MessageType = response.MessageType;

            if (!response.Success)
            {
                response.Rules.ForEach(x=>ModelState.AddModelError(x.Key,x.Value)); //hidratacao de erros no ModelState

                endereco.Estados = GetEstados(); 

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
            ViewBag.Title = Resources.EnderecoController_HttpGet_Edit_Action_ViewBagTitle;

            if (!response.Success)
            {
                return PartialView("Error");
            }

            var endereco = response.Endereco.ConvertToEnderecoViewModel();
            endereco.Estados = GetEstados();

            return PartialView("EnderecoPartialView", endereco );
        }
        
        [HttpPost]
        public PartialViewResult Edit(EnderecoViewModels endereco)
        {
            var request = new AlterarEnderecoRequest()
            {
                Endereco = endereco.ConvertToEnderecoDto(),
                EstadoSigla = endereco.Estado
            };

            var response = _enderecoService.AlterarEndereco(request);

            ViewBag.Excluir = false;
            ViewBag.Title = Resources.EnderecoController_HttpPost_Edit_Action_ViewBagTitle;
            ViewBag.Message = response.Message;
            ViewBag.MessageType = response.MessageType;

            if (!response.Success)
            {
                response.Rules.ForEach(x => ModelState.AddModelError(x.Key, x.Value)); //hidratacao de erros no ModelState
                
                endereco.Estados = GetEstados(); 

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
            ViewBag.Title = Resources.EnderecoController_HttpGet_Delete_Action_ViewBagTitle;
            ViewBag.Message = Resources.EnderecoController_HttpGet_Delete_Action_ViewBagMessage;
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
            ViewBag.Title = Resources.EnderecoController_HttpPost_Delete_Action_ViewBagTitle;
            ViewBag.Message = response.Message;
            ViewBag.MessageType = response.MessageType;

            if (!response.Success)
            {
                return PartialView("Error");
            }

            return PartialView("Sucesso");
        }

        private IList<EstadoViewModel> GetEstados()
        {
            var response = _estadoService.EncontrarTodosEstados();

            if (response.Success)
                return response.Estados.ConvertToListaDeEstadoViewModel();

            return null;
        }
    }
}