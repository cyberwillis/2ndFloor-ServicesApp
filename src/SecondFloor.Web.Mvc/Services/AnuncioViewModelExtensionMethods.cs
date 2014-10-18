using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SecondFloor.DataContracts.DTO;
using SecondFloor.Service.ExtensionMethods;
using SecondFloor.Web.Mvc.Models;

namespace SecondFloor.Web.Mvc.Services
{
    public static class AnuncioViewModelExtensionMethods
    {
        public static AnuncioDto ConvertToAnuncioDto(this AnuncioViewModels anuncioView)
        {
            var anuncioDto = new AnuncioDto();

            anuncioDto.Titulo = anuncioView.Titulo;

            if (!string.IsNullOrEmpty(anuncioView.DataInicio))
            {
                string[] data = anuncioView.DataInicio.Split('/'); //dd/mm/yyyy

                anuncioDto.AnoInicio = int.Parse(data[2]);
                anuncioDto.MesInicio = int.Parse(data[1]);
                anuncioDto.DiaInicio = int.Parse(data[0]);
            }

            if (!string.IsNullOrEmpty(anuncioView.DataFim))
            {
                string[] data = anuncioView.DataFim.Split('/'); //dd/mm/yyyy

                anuncioDto.AnoFim = int.Parse(data[2]);
                anuncioDto.MesFim = int.Parse(data[1]);
                anuncioDto.DiaFim = int.Parse(data[0]);
            }

            //enderecos
            anuncioDto.Logradouro = anuncioView.Logradouro;
            anuncioDto.Numero = anuncioView.Numero;
            anuncioDto.Complemento = anuncioView.Complemento;
            anuncioDto.Bairro = anuncioView.Bairro;
            anuncioDto.Cidade = anuncioView.Cidade;
            anuncioDto.Estado = anuncioView.Estado;

            //Conversao de Ofertas para insercao e alteracao
            if (anuncioView.Ofertas != null)
                anuncioDto.Ofertas = anuncioView.Ofertas.ConvertToListaOfertasDto();

            return anuncioDto;
        }

        public static AnuncioViewModels ConvertToAnuncioViewModels(this AnuncioDto anuncioDto)
        {
            var anuncioView = new AnuncioViewModels();

            anuncioView.Titulo = anuncioDto.Titulo;
            anuncioView.DataFim = anuncioDto.AnoFim + "/" + anuncioDto.MesFim + "/" + anuncioDto.DiaFim;
            anuncioView.DataInicio = anuncioDto.AnoInicio + "/" + anuncioDto.MesInicio + "/" + anuncioDto.DiaInicio;
            anuncioView.Status = anuncioDto.Status;

            anuncioView.Logradouro = anuncioDto.Logradouro;
            anuncioView.Numero = anuncioDto.Numero;
            anuncioView.Complemento = anuncioDto.Complemento;
            anuncioView.Bairro = anuncioDto.Bairro;
            anuncioView.Cidade = anuncioDto.Cidade;
            anuncioView.Estado = anuncioDto.Estado;
            //anuncioView.Cep = anuncioDto.Cep;

            return anuncioView;
        }

        public static IList<AnuncioViewModels> ConverttoListaAnunciosViewModel(this IList<AnuncioDto> anunciosDto)
        {
            var anunciosView = anunciosDto.Select(x => x.ConvertToAnuncioViewModels()).ToList();

            return anunciosView;
        }
    }
}