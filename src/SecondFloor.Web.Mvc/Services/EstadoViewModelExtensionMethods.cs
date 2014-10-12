using System.Collections.Generic;
using System.Linq;
using SecondFloor.DataContracts.DTO;
using SecondFloor.Web.Mvc.Models;

namespace SecondFloor.Web.Mvc.Services
{
    public static class EstadoViewModelExtensionMethods
    {
        public static EstadoViewModel ConvertToEstadoViewModel(this EstadoDto estadoDto)
        {
            var estado = new EstadoViewModel();

            estado.Id = estadoDto.Id;
            estado.Nome = estadoDto.Nome;
            estado.Sigla = estadoDto.Sigla;

            return estado;
        }

        public static IList<EstadoViewModel> ConvertToListaDeEstadoViewModel(this IList<EstadoDto> estadosDto)
        {
            var estados = estadosDto.Select(estadoDto => estadoDto.ConvertToEstadoViewModel()).ToList();

            return estados;
        }
    }
}