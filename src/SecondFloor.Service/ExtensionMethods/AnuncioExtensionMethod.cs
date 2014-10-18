using System;
using System.Collections.Generic;
using System.Linq;
using SecondFloor.DataContracts.DTO;
using SecondFloor.Model;

namespace SecondFloor.Service.ExtensionMethods
{
    public static class AnuncioExtensionMethod
    {
        public static Anuncio ConvertToAnuncio(this AnuncioDto anuncioDto)
        {
            var anuncio = new Anuncio();

            anuncio.Titulo = anuncioDto.Titulo;

            if (string.IsNullOrEmpty(anuncioDto.Id) || anuncioDto.Id == default(Guid).ToString())
            {
                anuncio.Id = Guid.NewGuid();
            }
            else
            {
                anuncio.Id = new Guid(anuncioDto.Id);
            }

            if(anuncioDto.Ofertas!= null)
                if (anuncioDto.Ofertas.Any())
                    anuncio.Ofertas = anuncioDto.Ofertas.ConvertToListaDeOfertas().ToList();

            if (anuncioDto.AnoInicio > 0 && anuncioDto.MesInicio > 0 && anuncioDto.DiaInicio > 0)
                anuncio.DataInicio = new DateTime(anuncioDto.AnoInicio, anuncioDto.MesInicio, anuncioDto.DiaInicio);

            if (anuncioDto.AnoFim > 0 && anuncioDto.MesFim > 0 && anuncioDto.DiaFim > 0)
                anuncio.DataFim = new DateTime(anuncioDto.AnoFim, anuncioDto.MesFim, anuncioDto.DiaFim);

            anuncio.Logradouro = anuncioDto.Logradouro;
            anuncio.Numero = anuncioDto.Numero;
            anuncio.Complemento = anuncioDto.Complemento;
            anuncio.Bairro = anuncioDto.Bairro;
            anuncio.Cidade = anuncioDto.Cidade;
            anuncio.Estado = anuncioDto.Estado;
            anuncio.Cep = anuncioDto.Cep;

            return anuncio;
        }

        public static IList<Anuncio> ConvertToListaAnuncio(this IList<AnuncioDto> anunciosDtos)
        {
            var anuncios = anunciosDtos.Select(anuncioDto => anuncioDto.ConvertToAnuncio()).ToList();

            return anuncios;
        }

        public static AnuncioDto ConvertToAnuncioDto(this Anuncio anuncio)
        {
            var anuncioDto = new AnuncioDto();

            anuncioDto.Id = anuncio.Id.ToString();

            anuncioDto.Titulo = anuncio.Titulo;

            var ofertas = anuncio.Ofertas.Select(oferta => oferta.ConvertToOfertaDto()).ToList();
            anuncioDto.Ofertas = ofertas;

            var inicio = anuncio.DataInicio;
            anuncioDto.AnoInicio = inicio.Year;
            anuncioDto.MesInicio = inicio.Month;
            anuncioDto.DiaInicio = inicio.Day;

            var fim = anuncio.DataFim;
            anuncioDto.AnoFim = fim.Year;
            anuncioDto.MesFim = fim.Month;
            anuncioDto.DiaFim = fim.Day;
            anuncioDto.Status = anuncio.Status.ToString();

            //endereco
            anuncioDto.Logradouro = anuncio.Logradouro;
            anuncioDto.Numero = anuncio.Numero;
            anuncioDto.Complemento = anuncio.Complemento;
            anuncioDto.Bairro = anuncio.Bairro;
            anuncioDto.Cidade = anuncio.Cidade;
            anuncioDto.Estado = anuncio.Estado;
            anuncioDto.Cep = anuncio.Cep;

            return anuncioDto;
        }

        public static IList<AnuncioDto> ConvertToListaAnunciosDtos(this IList<Anuncio> anuncios)
        {
            var anunciosDtos = anuncios.Select(anuncio => anuncio.ConvertToAnuncioDto()).ToList();

            return anunciosDtos;
        }
    }
}