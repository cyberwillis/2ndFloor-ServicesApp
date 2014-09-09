using System.ServiceModel;
using SecondFloor.DataContracts.Messages;

namespace SecondFloor.ServiceContracts
{
    [ServiceContract]
    public interface IAnuncioService
    {
        [OperationContract]
        CadastrarAnuncioResponse CadastrarAnuncio( CadastrarAnuncioRequest request );

        [OperationContract]
        CadastroAnuncianteResponse CadastrarAnunciante( CadastroAnuncianteRequest request );
    }
}