using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages.Endereco
{
    [MessageContract(WrapperNamespace = "messages.secondfloor.com")]
    public class EncontrarEnderecoResponse : ResponseBase
    {
        [MessageBodyMember]
        public EnderecoDto Endereco { get; set; }
    }
}