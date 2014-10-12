using System.Collections.Generic;
using System.Linq;
using SecondFloor.DataContracts.DTO;
using SecondFloor.Model;

namespace SecondFloor.Service.ExtensionMethods
{
    public static class EstadoExtensionMethods
    {
        public static EstadoDto ConvertToEstadoDto(this Estado estado)
        {
            var estadoDto = new EstadoDto();

            estadoDto.Id = estado.Id.ToString();
            estadoDto.Nome = estado.Nome;
            estadoDto.Sigla = estado.Sigla;

            return estadoDto;
        }

        public static IList<EstadoDto> ConvertToListaDeEstadosDto(this IList<Estado> estados)
        {
            var estadosDto = estados.Select(estado => estado.ConvertToEstadoDto()).ToList();

            return estadosDto;
        }
    }
}