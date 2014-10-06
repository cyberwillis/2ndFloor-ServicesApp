using SecondFloor.DataContracts.DTO;
using SecondFloor.WebUIMVC.Models;

namespace SecondFloor.WebUIMVC.Services
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
            anuncianteView.Enderecos = anuncianteDto.Enderecos.ConvertToListaEnderecosViewModel();

            return anuncianteView;
        }
    }
}