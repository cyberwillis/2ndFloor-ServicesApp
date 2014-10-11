using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
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

            if ( !string.IsNullOrEmpty(produtoDto.Valor) )
                produto.Valor = decimal.Parse( produtoDto.ConvertToValorNormal(), new CultureInfo("pt-BR") );
            else
                produto.Valor = decimal.Parse("0.00");

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
            produtoDto.Valor = produto.Valor.ToString("c", new CultureInfo("pt-BR"));
            produtoDto.AnuncianteId = produto.Anunciante.Id.ToString(); //facilitar a identificacao do Parent deste objeto

            return produtoDto;
        }

        public static IList<ProdutoDto> ConvertToListaProdutoDto(this IList<Produto> produtos)
        {
            var produtosDto = produtos.Select(x => x.ConvertToProdutoDto()).ToList();

            return produtosDto;
        }

        public static string ConvertToValorNormal(this ProdutoDto produtoDto)
        {
            var pattern = new Regex(@"\d+\,\d{2}"); //xxxxxx,xx ou x.xxx,xx
            var valor = Regex.Replace(produtoDto.Valor, @"[^0-9\,]", string.Empty);

            if (pattern.IsMatch(valor))
            {
                produtoDto.Valor = valor;
            }
            else
            {
                produtoDto.Valor = "0,00"; //caso nao tenha sigo valor valido ignora e seta um valor basico
            }
            return produtoDto.Valor;
        }
    }
}