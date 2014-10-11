using System.Collections.Generic;
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

            //TODO: conversao de dados

            return anuncioDto;
        }

        public static AnuncioViewModels ConvertToAnuncioViewModels(this AnuncioDto anuncioDto)
        {
            var anuncioView = new AnuncioViewModels();

            //TODO: conversao de dados

            return anuncioView;
        }

        public static IList<AnuncioViewModels> ConverttoListaAnunciosViewModel(this IList<AnuncioDto> anunciosDto)
        {
            var anunciosView = anunciosDto.Select(x => x.ConvertToAnuncioViewModels()).ToList();

            return anunciosView;
        }
    }
}