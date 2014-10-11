using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SecondFloor.DataContracts.DTO;
using SecondFloor.Web.Mvc.Models;

namespace SecondFloor.Web.Mvc.Services
{
    public static class AnuncioViewModelExtensionMethods
    {
        public static AnuncioDto ConvertToAnuncioDto(this AnuncioViewModels anuncioView)
        {
            var anuncioDto = new AnuncioDto();

            anuncioDto.Titulo = anuncioView.Titulo;
            
            if (!string.IsNullOrEmpty(anuncioView.DataFim))
            {
                string[] data = anuncioView.DataFim.Split('/'); //dd/mm/yyyy

                anuncioDto.AnoFim = int.Parse(data[2]);
                anuncioDto.MesFim = int.Parse(data[1]);
                anuncioDto.DiaFim = int.Parse(data[0]);
            }

            if (!string.IsNullOrEmpty(anuncioView.DataInicio))
            {
                string[] data = anuncioView.DataFim.Split('/'); //dd/mm/yyyy

                anuncioDto.AnoInicio = int.Parse(data[2]);
                anuncioDto.MesInicio = int.Parse(data[1]);
                anuncioDto.DiaInicio = int.Parse(data[0]);
            }

            return anuncioDto;
        }

        public static AnuncioViewModels ConvertToAnuncioViewModels(this AnuncioDto anuncioDto)
        {
            var anuncioView = new AnuncioViewModels();

            //TODO: conversao de dados
            anuncioView.Titulo = anuncioDto.Titulo;
            anuncioView.DataFim = anuncioDto.AnoFim + "/" + anuncioDto.MesFim + "/" + anuncioDto.DiaFim;
            anuncioView.DataInicio = anuncioDto.AnoInicio + "/" + anuncioDto.MesInicio + "/" + anuncioDto.DiaInicio;
            anuncioView.Status = anuncioDto.Status;

            return anuncioView;
        }

        public static IList<AnuncioViewModels> ConverttoListaAnunciosViewModel(this IList<AnuncioDto> anunciosDto)
        {
            var anunciosView = anunciosDto.Select(x => x.ConvertToAnuncioViewModels()).ToList();

            return anunciosView;
        }
    }
}