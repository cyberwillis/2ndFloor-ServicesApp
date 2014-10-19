using System;
using System.Collections.Generic;
using System.Linq;
using SecondFloor.DataContracts.DTO;
using SecondFloor.Web.Mvc.Models;

namespace SecondFloor.Web.Mvc.Services
{
    public static class OfertaViewModelExtensionMethods
    {
        public static OfertaViewModels ConvertToOfertaViewModels(this ProdutoViewModels produtoView)
        {
            var ofertaView = new OfertaViewModels();
            ofertaView.Id = produtoView.Id;
            ofertaView.NomeProduto = produtoView.NomeProduto;
            ofertaView.Fabricante = produtoView.Fabricante;
            ofertaView.Descricao = produtoView.Descricao;
            ofertaView.Referencia = produtoView.Referencia;
            ofertaView.Valor = produtoView.Valor;

            return ofertaView;
        }

        //Nunca sera usado!!!
        public static ProdutoViewModels ConvertToProdutoViewModels(this OfertaViewModels ofertaView)
        {
            var produtoView = new ProdutoViewModels();
            produtoView.Id = ofertaView.Id;
            produtoView.NomeProduto = ofertaView.NomeProduto;
            produtoView.Fabricante = ofertaView.Fabricante;
            produtoView.Descricao = ofertaView.Descricao;
            produtoView.Referencia = ofertaView.Referencia;
            produtoView.Valor = ofertaView.Valor;
            return produtoView;
        }
        
        public static IList<OfertaViewModels> ConvertListaProdutosViewModelToListaOfertasViewModel(this IList<ProdutoViewModels> produtosView)
        {
            var ofertas = produtosView.Select(oferta => oferta.ConvertToOfertaViewModels()).ToList();

            return ofertas;
        }

        //===========================================================================================

        public static OfertaDto ConvertToOfertaDto(this OfertaViewModels ofertaView)
        {
            var ofertaDto = new OfertaDto();
            //ofertaDto.Id = new Guid().ToString();
            ofertaDto.Id = ofertaView.Id;
            ofertaDto.Descricao = ofertaView.Descricao;
            ofertaDto.Fabricante = ofertaView.Fabricante;
            ofertaDto.Referencia = ofertaView.Referencia;
            ofertaDto.NomeProduto = ofertaView.NomeProduto;
            ofertaDto.Valor = ofertaView.Valor;

            if (ofertaView.Endereco != null)
                ofertaDto.Endereco = ofertaView.Endereco.ConvertToEnderecoDto();

            return ofertaDto;
        }

        public static IList<OfertaDto> ConvertToListaOfertasDto(this IList<OfertaViewModels> ofertasView)
        {
            var ofertasDto = ofertasView.Select(x=>x.ConvertToOfertaDto()).ToList();

            return ofertasDto;
        }

        public static OfertaViewModels ConvertToOfertasViewModel(this OfertaDto ofertaDto)
        {
            var ofertasViewModel = new OfertaViewModels();
            ofertasViewModel.Id = ofertaDto.Id;
            ofertasViewModel.Descricao = ofertaDto.Descricao;
            ofertasViewModel.Fabricante = ofertaDto.Fabricante;
            ofertasViewModel.Referencia = ofertaDto.Referencia;
            ofertasViewModel.NomeProduto = ofertaDto.NomeProduto;
            ofertasViewModel.Valor = ofertaDto.Valor;

            if (ofertaDto.Endereco != null)
                ofertaDto.Endereco.ConvertToEnderecoViewModel();

            return ofertasViewModel;
        }

        public static IList<OfertaViewModels> ConvertToListaOfertasViewModel(this IList<OfertaDto> ofertasDto)
        {
            var ofertasViewModel = ofertasDto.Select(oferta => oferta.ConvertToOfertasViewModel()).ToList();

            return ofertasViewModel;
        }
    }
}