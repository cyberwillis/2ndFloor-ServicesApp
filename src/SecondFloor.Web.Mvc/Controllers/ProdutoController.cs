using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecondFloor.DataContracts.Messages.Produto;
using SecondFloor.ServiceContracts;
using SecondFloor.Web.Mvc.Models;
using SecondFloor.Web.Mvc.Services;

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
            var request = new EncontrarTodosProdutosRequest() {AnuncianteId = id};

            var response = _produtoService.EncontrarTodosProdutos(request);

            ViewBag.Title = "Lista de Produtos";
            ViewBag.AnuncianteId = id;

            if (response.Success)
            {
                return PartialView("ListaProdutoPartialView", response.Produtos.ConvertToListaProdutosViewModel());
            }

            return PartialView("ListaProdutoPartialView", new List<ProdutoViewModels>());
        }
                
        [HttpGet]
        public PartialViewResult Create(string id)
        {
            ViewBag.Excluir = false;
            ViewBag.Title = "Cadastro de Produto";

            var produto = new ProdutoViewModels()
            {
                AnuncianteId = id,
                NomeProduto = "Produto Teste",
                Descricao = "Descricao teste",
                Fabricante = "Fabricante teste",
                RefProduto = "0001",
                Valor = decimal.Parse("10.00"),
            };
            //var keys = ModelState.Keys;
            //var values = ModelState.Values;

            return PartialView("ProdutoPartialView", produto);
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

            if (!ModelState.IsValid)
            {
                return PartialView("ProdutoPartialView", produto);
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
            var request = new EncontrarProdutoRequest() {Id = id};

            var response = _produtoService.EncontrarProdutoPor(request);

            if (!response.Success)
            {
                return PartialView("Error");
            }

            ViewBag.Excluir = false;
            ViewBag.Title = "Alterar Produto";

            var produto = response.Produto.ConvertToProdutoViewModel();

            return PartialView("ProdutoPartialView", produto);
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

            if (!response.Success)
            {
                return PartialView("Error");
            }

            ViewBag.Excluir = true;
            ViewBag.Title = "Excluir Produto";
            ViewBag.Message = "Tem certeza que deseja excluit o Endereco abaixo ?";
            ViewBag.MessageType = "alert-danger";

            var produto = response.Produto.ConvertToProdutoViewModel();

            return PartialView("ProdutoPartialView", produto);
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