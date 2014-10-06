using System.ServiceModel;
using SecondFloor.DataContracts.Messages;

namespace SecondFloor.ServiceContracts
{
    [ServiceContract(Namespace = "services.am.fiap.com.br",Name = "AnuncianteService")]
    public interface IAnuncianteService
    {
        [OperationContract]
        CadastrarAnuncioResponse CadastrarAnuncio( CadastrarAnuncioRequest request );

        [OperationContract]
        CadastroAnuncianteResponse CadastrarAnunciante( CadastroAnuncianteRequest request );

        //TODO: tornar oculto para o publico quando eu jultar que devo...
        [OperationContract]
        EncontrarTodosAnunciantesResponse EncontrarTodosAnunciantes();

        //Oculto para o publico
        EncontrarAnuncianteResponse EncontrarAnunciantePor( EncontrarAnuncianteRequest request );
        AlterarAnuncianteResponse AlterarAnunciante(AlterarAnuncianteRequest request);

    }
}