using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using SecondFloor.DataContracts.DTO;
using SecondFloor.Model;

namespace SecondFloor.Service.ExtensionMethods
{
    public static class OfertaExtensionMethod
    {
        public static Oferta ConvertToOferta(this OfertaDto ofertaDto)
        {
            var oferta = new Oferta();

            if (string.IsNullOrEmpty(ofertaDto.Id) || ofertaDto.Id == default(Guid).ToString())
            {
                oferta.Id = Guid.NewGuid();
            }
            else
            {
                oferta.Id = new Guid(ofertaDto.Id);
            }

            oferta.NomeProduto = ofertaDto.NomeProduto;
            oferta.Descricao = ofertaDto.Descricao;
            oferta.Fabricante = ofertaDto.Fabricante;
            oferta.Referencia = ofertaDto.Referencia;
            if ( !string.IsNullOrEmpty(ofertaDto.Valor) )
                oferta.Valor = decimal.Parse( ofertaDto.ConvertToValorNormal(), new CultureInfo("pt-BR") );
            else
                oferta.Valor = decimal.Parse("0.00");
            
            return oferta;
        }

        public static OfertaDto ConvertToOfertaDto(this Oferta oferta)
        {
            var ofertaDto = new OfertaDto();

            ofertaDto.Id = oferta.Id.ToString();
            ofertaDto.NomeProduto = oferta.NomeProduto;
            ofertaDto.Fabricante = oferta.Fabricante;
            ofertaDto.Descricao = oferta.Descricao;
            ofertaDto.Referencia = oferta.Referencia;
            ofertaDto.Valor = oferta.Valor.ToString("c", new CultureInfo("pt-BR"));

            return ofertaDto;
        }

        public static IEnumerable<Oferta> ConvertToListaDeOfertas(this IEnumerable<OfertaDto> ofertasDtos)
        {
            var ofertas = ofertasDtos.Select(ofertasDto => ofertasDto.ConvertToOferta()).ToList();

            return ofertas;
        }

        public static IEnumerable<OfertaDto> ConvertToListaDeOfertasDtos(this IEnumerable<Oferta> ofertas)
        {
            var ofertasDtos = ofertas.Select(oferta => oferta.ConvertToOfertaDto()).ToList();

            return ofertasDtos;
        }

        public static string ConvertToValorNormal(this OfertaDto ofertaDto)
        {
            var pattern = new Regex(@"\d+\,\d{2}"); //xxxxxx,xx ou x.xxx,xx
            var valor = Regex.Replace(ofertaDto.Valor, @"[^0-9\,]", string.Empty);

            if (pattern.IsMatch(valor))
            {
                ofertaDto.Valor = valor;
            }
            else
            {
                ofertaDto.Valor = "0,00"; //caso nao tenha sigo valor valido ignora e seta um valor basico
            }
            return ofertaDto.Valor;
        }
    }
}