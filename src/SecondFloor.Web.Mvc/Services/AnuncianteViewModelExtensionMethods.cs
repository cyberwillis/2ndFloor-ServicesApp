using System.Collections.Generic;
using System.Linq;
using SecondFloor.DataContracts.DTO;
using SecondFloor.Service.ExtensionMethods;
using SecondFloor.Web.Mvc.Models;

namespace SecondFloor.Web.Mvc.Services
{
    public static class AnuncianteViewModelExtensionMethods
    {
        public static AnuncianteDto ConvertToAnuncianteDto(this AnuncianteViewModels anuncianteView)
        {
            var anuncianteDto = new AnuncianteDto();
            anuncianteDto.Id = anuncianteView.Id;
            anuncianteDto.Responsavel = anuncianteView.NomeResponsavel;
            anuncianteDto.Email = anuncianteView.Email;
            anuncianteDto.RazaoSocial = anuncianteView.RazaoSocial;
            anuncianteDto.Cnpj = anuncianteView.Cnpj;

            return anuncianteDto;
        }

        public static AnuncianteViewModels ConvertAnuncianteViewModels(this AnuncianteDto anuncianteDto)
        {
            var anuncianteView = new AnuncianteViewModels();
            anuncianteView.Id = anuncianteDto.Id;
            anuncianteView.NomeResponsavel = anuncianteDto.Responsavel;
            anuncianteView.Email = anuncianteDto.Email;
            anuncianteView.RazaoSocial = anuncianteDto.RazaoSocial;
            anuncianteView.Cnpj = anuncianteDto.Cnpj;
            //anuncianteView.Enderecos = anuncianteDto.Enderecos.ConvertToListaEnderecosViewModel();

            return anuncianteView;
        }

        public static IList<AnuncianteViewModels> ConvertToListaListaAnunciantesViewModel( this IList<AnuncianteDto> anunciantesDto )
        {
            var anunciantesView = anunciantesDto.Select(x => x.ConvertAnuncianteViewModels()).ToList();

            return anunciantesView;
        }
    }
}