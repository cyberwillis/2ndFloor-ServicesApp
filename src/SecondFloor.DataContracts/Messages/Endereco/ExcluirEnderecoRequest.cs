using System.ServiceModel;

namespace SecondFloor.DataContracts.Messages.Endereco
{
    [MessageContract(WrapperNamespace = "messages.am.fiap.com.br")]
    public class ExcluirEnderecoRequest
    {
        [MessageBodyMember]
        public string Id { get; set; }
    }
}