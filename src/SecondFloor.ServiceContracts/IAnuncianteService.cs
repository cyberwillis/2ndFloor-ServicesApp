using System.ServiceModel;
using SecondFloor.DataContracts.Messages;
using SecondFloor.DataContracts.Messages.Anunciante;

namespace SecondFloor.ServiceContracts
{
    public interface IAnuncianteService
    {
        EncontrarTodosAnunciantesResponse EncontrarTodosAnunciantes();
        EncontrarAnuncianteResponse EncontrarAnunciantePor(EncontrarAnuncianteRequest request);
        CadastrarAnuncianteResponse CadastrarAnunciante( CadastrarAnuncianteRequest request );
        AlterarAnuncianteResponse AlterarAnunciante(AlterarAnuncianteRequest request);
        ExcluirAnuncianteResponse ExcluirAnunciante(ExcluirAnuncianteRequest request);
    }
}