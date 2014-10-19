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
        public static AnuncioViewModels ConvertToAnuncioViewModels(this AnuncioDto anuncioDto)
        {
            var anuncioView = new AnuncioViewModels();

            anuncioView.Id = anuncioDto.Id;
            anuncioView.Titulo = anuncioDto.Titulo;
            anuncioView.DataFim = anuncioDto.AnoFim + "/" + anuncioDto.MesFim + "/" + anuncioDto.DiaFim;
            anuncioView.DataInicio = anuncioDto.AnoInicio + "/" + anuncioDto.MesInicio + "/" + anuncioDto.DiaInicio;
            anuncioView.Status = anuncioDto.Status;

            if (anuncioDto.Ofertas != null)
            {
                anuncioView.Ofertas = anuncioDto.Ofertas.ConvertToListaOfertasViewModel();

                if (anuncioDto.Ofertas.Any())
                {
                    anuncioView.Endereco.Logradouro = anuncioDto.Ofertas[0].Endereco.Logradouro;
                    anuncioView.Endereco.Numero = int.Parse(anuncioDto.Ofertas[0].Endereco.Numero);
                    anuncioView.Endereco.Complemento = anuncioDto.Ofertas[0].Endereco.Complemento;
                    anuncioView.Endereco.Bairro = anuncioDto.Ofertas[0].Endereco.Bairro;
                    anuncioView.Endereco.Cidade = anuncioDto.Ofertas[0].Endereco.Cidade;
                    anuncioView.Endereco.Estado = anuncioDto.Ofertas[0].Endereco.Estado;
                    anuncioView.Endereco.Cep = anuncioDto.Ofertas[0].Endereco.Cep;
                }
            }

            anuncioView.AnuncianteId = anuncioDto.AnuncianteId;
            return anuncioView;
        }

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

            //Conversao de Ofertas para insercao e alteracao
            if (anuncioView.Ofertas != null)
                anuncioDto.Ofertas = anuncioView.Ofertas.ConvertToListaOfertasDto();

            return anuncioDto;
        }



        public static IList<AnuncioViewModels> ConverttoListaAnunciosViewModel(this IList<AnuncioDto> anunciosDto)
        {
            var anunciosView = anunciosDto.Select(x => x.ConvertToAnuncioViewModels()).ToList();

            return anunciosView;
        }
    }
}