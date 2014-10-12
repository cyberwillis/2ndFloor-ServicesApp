using SecondFloor.DataContracts.Messages.Estado;

namespace SecondFloor.ServiceContracts
{
    public interface IEstadoService
    {
        EncontrarTodosEstadosResponse EncontrarTodosEstados();
    }
}