using System.ServiceModel;
using SecondFloor.DataContracts.Messages;

namespace SecondFloor.ServiceContracts
{
    [ServiceContract]
    public interface IAnuncianteService
    {
        [OperationContract]
        CadastrarAnuncioResponse CadastrarAnuncio( CadastrarAnuncioRequest request );

        [OperationContract]
        CadastroAnuncianteResponse CadastrarAnunciante( CadastroAnuncianteRequest request );
    }
}