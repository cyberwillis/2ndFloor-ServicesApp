using System.ServiceModel;

namespace SecondFloor.DataContracts.Messages
{
    [MessageContract(WrapperNamespace = "messages.am.fiap.com.br")]
    public class CadastroAnuncianteResponse : ResponseBase
    {
        public string Id { get; set; }
    }
}