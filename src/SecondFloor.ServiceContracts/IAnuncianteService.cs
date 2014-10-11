using System.ServiceModel;
using SecondFloor.DataContracts.Messages;
using SecondFloor.DataContracts.Messages.Anunciante;

namespace SecondFloor.ServiceContracts
{
    [ServiceContract(Namespace = "services.am.fiap.com.br",Name = "AnuncianteService")]
    public interface IAnuncianteService
    {
        EncontrarTodosAnunciantesResponse EncontrarTodosAnunciantes();
        EncontrarAnuncianteResponse EncontrarAnunciantePor(EncontrarAnuncianteRequest request);
        CadastrarAnuncianteResponse CadastrarAnunciante( CadastrarAnuncianteRequest request );
        AlterarAnuncianteResponse AlterarAnunciante(AlterarAnuncianteRequest request);
        ExcluirAnuncianteResponse ExcluirAnunciante(ExcluirAnuncianteRequest request);
    }
}