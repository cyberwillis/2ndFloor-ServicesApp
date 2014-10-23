using System;
using Microsoft.Practices.ObjectBuilder2;
using SecondFloor.DataContracts.Messages.Produto;
using SecondFloor.I18n;
using SecondFloor.Model;
using SecondFloor.Model.Rules;
using SecondFloor.Service.ExtensionMethods;
using SecondFloor.ServiceContracts;

namespace SecondFloor.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IAnuncianteRepository _anuncianteRepository;

        public ProdutoService(IProdutoRepository produtoRepository, IAnuncianteRepository anuncianteRepository)
        {
            _produtoRepository = produtoRepository;
            _anuncianteRepository = anuncianteRepository;
        }

        public EncontrarTodosProdutosResponse EncontrarTodosProdutos(EncontrarTodosProdutosRequest request)
        {
            var response = new EncontrarTodosProdutosResponse();

            try
            {
                var id = Guid.Parse(request.AnuncianteId);
                var anunciante = _anuncianteRepository.EncontrarAnunciantePor(id);
                if (anunciante == null)
                {
                    response.Message = Resources.ProdutoServices_EncontrarTodosProdutos_NotFound;
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                response.Message = string.Format(Resources.ProdutoServices_EncontrarTodosProdutos_Success, anunciante.Produtos);
                response.MessageType = "alert-info";
                response.Success = true;
                response.Produtos = anunciante.Produtos.ConvertToListaProdutoDto();
            }
            catch (Exception ex)
            {
                response.Message = Resources.ProdutoServices_EncontrarTodosProdutos_Error + "\n" + ex.Message;
                response.MessageType = "alert-danger";
                response.Success = false;
            }

            return response;
        }

        public EncontrarProdutoResponse EncontrarProdutoPor(EncontrarProdutoRequest request)
        {
            var response = new EncontrarProdutoResponse();

            try
            {
                var id = Guid.Parse(request.Id);
                var produto = _produtoRepository.EncontrarProdutoPor(id);
                if (produto == null)
                {
                    response.Message = Resources.ProdutoServices_EncontrarProdutoPor_NotFound;
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                response.Message = Resources.ProdutoServices_EncontrarProdutoPor_Success;
                response.MessageType = "alert-info";
                response.Success = true;
                response.Produto = produto.ConvertToProdutoDto();

            }
            catch (Exception ex)
            {
                response.Message = Resources.ProdutoServices_EncontrarProdutoPor_Error + "\n" + ex.Message;
                response.MessageType = "alert-danger";
                response.Success = false;
            }

            return response;
        }

        public CadastrarProdutoResponse CadastrarProduto(CadastrarProdutoRequest request)
        {
            var response = new CadastrarProdutoResponse();

            var produto = request.Produto.ConvertToProduto();
            if (!produto.IsValid())
            {
                produto.BrokenRules.ForEach(x=> response.Rules.Add(x.Key,x.Value));

                response.Message = produto.GetErrorMessages().ToString();
                response.MessageType = "alert-warning";
                response.Success = false;
                return response;
            }
            
            try
            {
                var anuncianteId = Guid.Parse(request.AnuncianteId);
                var anunciante = _anuncianteRepository.FindBy(anuncianteId);
                if (anunciante == null)
                {
                    response.Message = Resources.ProdutoServices_CadastrarProduto_Anunciante_NotFound;
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }


                anunciante.Produtos.Add(produto);
                //produto.Anunciante = anunciante;

                _produtoRepository.InserirProduto(produto);
                _produtoRepository.Persist();

                response.Message = Resources.ProdutoServices_CadastrarProduto_Success;
                response.MessageType = "alert-info";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = Resources.ProdutoServices_CadastrarProduto_Error +"\n" + ex.Message;
                response.MessageType = "alert-danger";
                response.Success = false;
            }

            return response;
        }

        public AlterarProdutoResponse AlterarProduto(AlterarProdutoRequest request)
        {
            var response = new AlterarProdutoResponse();

            try
            {
                var id = Guid.Parse(request.Produto.Id);
                var produto = _produtoRepository.EncontrarProdutoPor(id);
                if (produto == null)
                {
                    response.Message = Resources.ProdutoServices_AlterarProduto_NotFound;
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                var novoProduto = request.Produto.ConvertToProduto();
                produto.NomeProduto = novoProduto.NomeProduto;
                produto.Descricao = novoProduto.Descricao;
                produto.Referencia = novoProduto.Referencia;
                produto.Fabricante = novoProduto.Fabricante;
                produto.Valor = novoProduto.Valor;
                if (!produto.IsValid())
                {
                    produto.BrokenRules.ForEach(x => response.Rules.Add(x.Key, x.Value));

                    response.Message = produto.GetErrorMessages().ToString();
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                _produtoRepository.AtualizarProduto(produto);
                _produtoRepository.Persist();

                response.Message = Resources.ProdutoServices_AlterarProduto_Success;
                response.MessageType = "alert-info";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = Resources.ProdutoServices_AlterarProduto_Error + "\n" + ex.Message;
                response.MessageType = "alert-danger";
                response.Success = false;
            }

            return response;
        }

        public ExcluirProdutoResponse ExcluirProduto(ExcluirProdutoRequest request)
        {
            var response = new ExcluirProdutoResponse();

            try
            {
                var id = Guid.Parse(request.Id);
                var produto = _produtoRepository.EncontrarProdutoPor(id);
                if (produto == null)
                {
                    response.Message = Resources.ProdutoServices_ExcluirProduto_NotFound;
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                _produtoRepository.ExcluirProduto(produto);
                _produtoRepository.Persist();

                response.Message = Resources.ProdutoServices_ExcluirProduto_Success;
                response.MessageType = "alert-info";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = Resources.ProdutoServices_ExcluirProduto_Error + "\n" + ex.Message;
                response.MessageType = "alert-danger";
                response.Success = false;
            }

            return response;
        }
    }
}