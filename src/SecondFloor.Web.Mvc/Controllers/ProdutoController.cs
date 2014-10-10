using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecondFloor.DataContracts.Messages.Produto;
using SecondFloor.ServiceContracts;
using SecondFloor.Web.Mvc.Models;
using SecondFloor.Web.Mvc.Services;
using WebGrease.Css.Extensions;

namespace SecondFloor.Web.Mvc.Controllers
{
    public class ProdutoController : Controller
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

            ViewBag.Title = "Lista de Produtos";
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
            ViewBag.Title = "Cadastro de Produto";

            return PartialView("ProdutoPartialView", new ProdutoViewModels() { AnuncianteId = id });
        }

        [HttpPost]
        public PartialViewResult Create([Bind(Exclude = "Id")]ProdutoViewModels produto)
        {
            var request = new CadastrarProdutoRequest() { Produto = produto.ConvertToProdutoDto(), AnuncianteId = produto.AnuncianteId };
            var response = _produtoService.CadastroProduto(request);

            ViewBag.Excluir = false;
            ViewBag.Title = "Cadastro de Produto";
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
            ViewBag.Title = "Alterar Produto";

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
            ViewBag.Title = "Alterar Produto";
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
            ViewBag.Title = "Excluir Produto";
            ViewBag.Message = "Tem certeza que deseja excluit o Endereco abaixo ?";
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
            ViewBag.Title = "Excluir Produto";
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