using System.Collections.Generic;
using System.Linq;
using SecondFloor.DataContracts.DTO;
using SecondFloor.Web.Mvc.Models;

namespace SecondFloor.Web.Mvc.Services
{
    public static class ProdutoViewModelExtensionMethod
    {
        public static ProdutoViewModels ConvertToProdutoViewModel(this ProdutoDto produtoDto)
        {
            var produtoViewModel = new ProdutoViewModels();

            produtoViewModel.Id = produtoDto.Id;
            produtoViewModel.NomeProduto = produtoDto.NomeProduto;
            produtoViewModel.Descricao = produtoDto.Descricao;
            produtoViewModel.RefProduto = produtoDto.Referencia;
            produtoViewModel.Fabricante = produtoDto.Fabricante;
            produtoViewModel.Valor = decimal.Parse(produtoDto.Valor);
            produtoViewModel.AnuncianteId = produtoDto.AnuncianteId;

            return produtoViewModel;
        }

        public static ProdutoDto ConvertToProdutoDto(this ProdutoViewModels produtoViewModel)
        {
            var produtoDto = new ProdutoDto();

            produtoDto.Id = produtoViewModel.Id;
            produtoDto.NomeProduto = produtoViewModel.NomeProduto;
            produtoDto.Descricao = produtoViewModel.Descricao;
            produtoDto.Referencia = produtoViewModel.RefProduto;
            produtoDto.Fabricante = produtoViewModel.Fabricante;
            produtoDto.Valor = produtoViewModel.Valor.ToString();

            return produtoDto;
        }

        public static IList<ProdutoViewModels> ConvertToListaProdutosViewModel(this IList<ProdutoDto> produtosDto)
        {
            var produtosViewModel = produtosDto.Select(x => x.ConvertToProdutoViewModel()).ToList();

            return produtosViewModel;
        }
    }
}