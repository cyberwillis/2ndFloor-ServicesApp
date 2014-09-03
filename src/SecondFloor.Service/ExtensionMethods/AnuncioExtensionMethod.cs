﻿using System;
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

            if (anuncioDto.Ofertas.Any())
                anuncio.Ofertas = anuncioDto.Ofertas.ConvertToListaDeOfertas().ToList();

            if (anuncioDto.AnoInicio > 0 && anuncioDto.MesInicio > 0 && anuncioDto.DiaInicio > 0)
                anuncio.DataInicio = new DateTime(anuncioDto.AnoInicio, anuncioDto.MesInicio, anuncioDto.DiaInicio);

            if (anuncioDto.AnoFim > 0 && anuncioDto.MesFim > 0 && anuncioDto.DiaFim > 0)
                anuncio.DataFim = new DateTime(anuncioDto.AnoFim, anuncioDto.MesFim, anuncioDto.DiaFim);

            anuncio.Titulo = anuncioDto.Titulo;

            return anuncio;
        }

        public static AnuncioDto ConvertToAnuncioDto(this Anuncio anuncio)
        {
            var anuncioDto = new AnuncioDto();

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

            anuncioDto.Titulo = anuncio.Titulo;

            return anuncioDto;
        }
    }
}