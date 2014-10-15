using System.ServiceModel;

namespace SecondFloor.DataContracts.Messages.Endereco
{
    [MessageContract(WrapperNamespace = "messages.secondfloor.com")]
    public class EncontrarEnderecoRequest
    {
        [MessageBodyMember]
        public string Id { get; set; }
    }
}