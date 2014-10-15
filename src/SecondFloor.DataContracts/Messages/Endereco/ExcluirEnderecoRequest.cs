using System.ServiceModel;

namespace SecondFloor.DataContracts.Messages.Endereco
{
    [MessageContract(WrapperNamespace = "messages.secondfloor.com")]
    public class ExcluirEnderecoRequest
    {
        [MessageBodyMember]
        public string Id { get; set; }
    }
}