using System;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Practices.ObjectBuilder2;
using SecondFloor.DataContracts.Messages.Produto;
using SecondFloor.Model;
using SecondFloor.Model.Rules;
using SecondFloor.Model.Rules.Specifications;
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
                    response.Message = "Os dados deste Anunciante não foram encontrados";
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                response.Message = string.Format("Encontrado {0} anunciantes", anunciante.Produtos);
                response.MessageType = "alert-info";
                response.Success = true;
                response.Produtos = anunciante.Produtos.ConvertToListaProdutoDto();
            }
            catch (Exception ex)
            {
                response.Message = "Ocorreu um erro\n" + ex.Message;
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
                    response.Message = "Produto não encontrado!";
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                response.Message = "Produto encontrado!";
                response.MessageType = "alert-info";
                response.Success = true;
                response.Produto = produto.ConvertToProdutoDto();

            }
            catch (Exception ex)
            {
                response.Message = "Ocorreu um erro\n" + ex.Message;
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
                    response.Message = "Anunciante não encontrado para inclusão do novo Endereço";
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }


                anunciante.Produtos.Add(produto);
                produto.Anunciante = anunciante;

                _produtoRepository.InserirProduto(produto);
                _produtoRepository.Persist();

                response.Message = "Produto cadastrado com sucesso.";
                response.MessageType = "alert-info";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = "Ocorreu um erro:\n" + ex.Message;
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
                    response.Message = "Produto não encontrado!";
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

                response.Message = "Produto atualizado com sucesso!";
                response.MessageType = "alert-info";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = "Ocorreu um erro\n" + ex.Message;
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
                    response.Message = "Produto não encontrado!";
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                _produtoRepository.ExcluirProduto(produto);
                _produtoRepository.Persist();

                response.Message = "Produto excluido com sucesso!";
                response.MessageType = "alert-info";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = "Ocorreu um erro\n" + ex.Message;
                response.MessageType = "alert-danger";
                response.Success = false;
            }

            return response;
        }
    }
}