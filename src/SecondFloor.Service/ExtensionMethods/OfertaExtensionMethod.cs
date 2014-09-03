using System.Collections.Generic;
using System.Linq;
using SecondFloor.DataContracts.DTO;
using SecondFloor.Model;

namespace SecondFloor.Service.ExtensionMethods
{
    public static class OfertaExtensionMethod
    {
        public static Oferta ConvertToOderta(this OfertaDto ofertaDto)
        {
            var oferta = new Oferta();
            oferta.Titulo = ofertaDto.Titulo;
            oferta.Preco = ofertaDto.Preco;

            if( ofertaDto.Endereco != null )
                oferta.Endereco = ofertaDto.Endereco.ConvertToEndereco();

            oferta.Descricao = ofertaDto.Descricao;

            return oferta;
        }

        public static OfertaDto ConvertToOfertaDto(this Oferta oferta)
        {
            var ofertaDto = new OfertaDto();

            ofertaDto.Titulo = oferta.Titulo;
            ofertaDto.Descricao = oferta.Descricao;
            ofertaDto.Preco = oferta.Preco;
            ofertaDto.Endereco = oferta.Endereco.ConvertToEnderecoDto();

            return ofertaDto;
        }

        public static IEnumerable<Oferta> ConvertToListaDeOfertas(this IEnumerable<OfertaDto> ofertasDtos)
        {
            var ofertas = ofertasDtos.Select(ofertasDto => ofertasDto.ConvertToOderta()).ToList();

            return ofertas;
        }

        public static IEnumerable<OfertaDto> ConvertToListaDeOfertasDtos(this IEnumerable<Oferta> ofertas)
        {
            var ofertasDtos = ofertas.Select(oferta => oferta.ConvertToOfertaDto()).ToList();

            return ofertasDtos;
        }
    }
}