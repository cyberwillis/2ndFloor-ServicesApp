using System.Collections.Generic;
using System.Web.Mvc;
using SecondFloor.DataContracts.Messages.Produto;
using SecondFloor.I18n;
using SecondFloor.ServiceContracts;
using SecondFloor.Web.Mvc.Models;
using SecondFloor.Web.Mvc.Services;
using WebGrease.Css.Extensions;

namespace SecondFloor.Web.Mvc.Controllers
{
    public class ProdutoController : BaseController
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public PartialViewResult List(string id)
        {
            var request = new EncontrarTodosProdutosRequest() { AnuncianteId = id };
            var response = _produtoService.EncontrarTodosProdutos(request);

            ViewBag.Title = Resources.ProdutoController_HttpGet_List_Action_ViewBagTitle;
            ViewBag.AnuncianteId = id;

            if (!response.Success)
            {
                return PartialView("ListaProdutoPartialView", new List<ProdutoViewModels>());
            }

            return PartialView("ListaProdutoPartialView", response.Produtos.ConvertToListaProdutosViewModel());
        }
                
        [HttpGet]
        public PartialViewResult Create(string id)
        {
            ViewBag.Excluir = false;
            ViewBag.Title = Resources.ProdutoController_HttpGet_Create_Action_ViewBagTitle;

            var produto = new ProdutoViewModels() {AnuncianteId = id};
            produto = new ProdutoViewModels()
            {
                AnuncianteId = id,
                NomeProduto = "Esponja de Aço",
                Fabricante = "BomBrill",
                Descricao = "Lavar panelas",
                Referencia = "0001",
                Valor = "3.40"
            };

            return PartialView("ProdutoPartialView", produto);
        }

        [HttpPost]
        public PartialViewResult Create([Bind(Exclude = "Id")]ProdutoViewModels produto)
        {
            var request = new CadastrarProdutoRequest() { Produto = produto.ConvertToProdutoDto(), AnuncianteId = produto.AnuncianteId };
            var response = _produtoService.CadastrarProduto(request);

            ViewBag.Excluir = false;
            ViewBag.Title = Resources.ProdutoController_HttpPost_Create_Action_ViewBagTitle;
            ViewBag.Message = response.Message;
            ViewBag.MessageType = response.MessageType;

            if (!response.Success)
            {
                response.Rules.ForEach(x=>ModelState.AddModelError(x.Key,x.Value));
                return PartialView("ProdutoPartialView", produto);
            }

            return PartialView("Sucesso");
        }

        
        [HttpGet]
        public PartialViewResult Edit(string id)
        {
            var request = new EncontrarProdutoRequest() {Id = id};
            var response = _produtoService.EncontrarProdutoPor(request);

            ViewBag.Excluir = false;
            ViewBag.Title = Resources.ProdutoController_HttpGet_Edit_Action_ViewBagTitle;

            if (!response.Success)
            {
                return PartialView("Error");
            }

            return PartialView("ProdutoPartialView", response.Produto.ConvertToProdutoViewModel());
        }
        
        [HttpPost]
        public PartialViewResult Edit(ProdutoViewModels produto)
        {
            var request = new AlterarProdutoRequest() {Produto = produto.ConvertToProdutoDto()};
            var response = _produtoService.AlterarProduto(request);

            ViewBag.Excluir = false;
            ViewBag.Title = Resources.ProdutoController_HttpPost_Edit_Action_ViewBagTitle;
            ViewBag.Message = response.Message;
            ViewBag.MessageType = response.MessageType;

            if (!response.Success)
            {
                return PartialView("ProdutoPartialView", produto);
            }

            return PartialView("Sucesso");
        }

        [HttpGet]
        public PartialViewResult Delete(string id)
        {
            var request = new EncontrarProdutoRequest() {Id = id};
            var response = _produtoService.EncontrarProdutoPor(request);

            ViewBag.Excluir = true;
            ViewBag.Title = Resources.ProdutoController_HttpGet_Delete_Action_ViewBagTitle;
            ViewBag.Message = Resources.ProdutoController_HttpGet_Delete_Action_ViewBagMessage;
            ViewBag.MessageType = "alert-danger";

            if (!response.Success)
            {
                return PartialView("Error");
            }
            
            return PartialView("ProdutoPartialView", response.Produto.ConvertToProdutoViewModel());
        }

        [HttpPost]
        public PartialViewResult Delete(ProdutoViewModels produto)
        {
            var request = new ExcluirProdutoRequest() { Id = produto.Id };
            var response = _produtoService.ExcluirProduto(request);

            ViewBag.Excluir = true;
            ViewBag.Title = Resources.ProdutoController_HttpPost_Delete_Action_ViewBagTitle;
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