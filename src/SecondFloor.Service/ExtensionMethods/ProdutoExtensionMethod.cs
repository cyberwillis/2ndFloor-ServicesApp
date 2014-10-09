using System;
using System.Collections.Generic;
using System.Linq;
using SecondFloor.DataContracts.DTO;
using SecondFloor.Model;

namespace SecondFloor.Service.ExtensionMethods
{
    public static class ProdutoExtensionMethod
    {
        public static Produto ConvertToProduto(this ProdutoDto produtoDto)
        {
            var produto = new Produto();

            if (string.IsNullOrEmpty(produtoDto.Id) || produtoDto.Id == default(Guid).ToString())
            {
                produto.Id = Guid.NewGuid();
            }
            else
            {
                produto.Id = new Guid(produtoDto.Id);
            }

            produto.NomeProduto = produtoDto.NomeProduto;
            produto.Descricao = produtoDto.Descricao;
            produto.Fabricante = produtoDto.Fabricante;
            produto.Referencia = produtoDto.Referencia;
            produto.Valor = decimal.Parse(produtoDto.Valor);

            return produto;

        }

        public static ProdutoDto ConvertToProdutoDto(this Produto produto)
        {
            var produtoDto = new ProdutoDto();

            produtoDto.Id = produto.Id.ToString();
            produtoDto.NomeProduto = produto.NomeProduto;
            produtoDto.Fabricante = produto.Fabricante;
            produtoDto.Descricao = produto.Descricao;
            produtoDto.Referencia = produto.Referencia;
            produtoDto.Valor = produto.Valor.ToString();
            produtoDto.AnuncianteId = produto.Anunciante.Id.ToString(); //AnuncianteId

            return produtoDto;
        }

        public static IList<ProdutoDto> ConvertToListaProdutoDto(this IList<Produto> produtos)
        {
            var produtosDto = produtos.Select(x => x.ConvertToProdutoDto()).ToList();

            return produtosDto;
        }
    }
}