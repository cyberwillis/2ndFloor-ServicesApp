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

        public static OfertaDto ConvertTOofertaDto(this OfertaViewModels ofertaView)
        {
            var ofertaDto = new OfertaDto()
            {
                Id = new Guid().ToString(),//ofertaView.Id, //Novo Id
                Descricao = ofertaView.Descricao,
                Fabricante = ofertaView.Fabricante,
                Referencia = ofertaView.Referencia,
                NomeProduto = ofertaView.NomeProduto,
                Valor = ofertaView.Valor
            };

            return ofertaDto;
        }

        public static IList<OfertaDto> ConvertToListaOfertasDto(this IList<OfertaViewModels> ofertasView)
        {
            var ofertasDto = ofertasView.Select(x=>x.ConvertTOofertaDto()).ToList();

            return ofertasDto;
        }
    }
}