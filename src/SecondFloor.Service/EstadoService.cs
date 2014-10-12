using System;
using SecondFloor.DataContracts.Messages.Estado;
using SecondFloor.Model;
using SecondFloor.Service.ExtensionMethods;
using SecondFloor.ServiceContracts;

namespace SecondFloor.Service
{
    public class EstadoService : IEstadoService
    {
        private readonly IEstadoRepository _estadoRepository;

        public EstadoService(IEstadoRepository estadoRepository)
        {
            _estadoRepository = estadoRepository;
        }

        public EncontrarTodosEstadosResponse EncontrarTodosEstados()
        {
            var response = new EncontrarTodosEstadosResponse();

            try
            {
                var estados = _estadoRepository.EncontrarTodosEstados();
                if (estados == null)
                {
                    response.Message = "Nenhum estado encontrado!";
                    response.Success = false; 
                }

                response.Estados = estados.ConvertToListaDeEstadosDto();
                response.Message = string.Format("Encontrado {0} Estado(s)", estados.Count);
                response.Success = true;

            }
            catch (Exception ex)
            {
                response.Message = "Erro ao encontrar estados.";
                response.Success = false;
            }

            return response;
        }
    }
}