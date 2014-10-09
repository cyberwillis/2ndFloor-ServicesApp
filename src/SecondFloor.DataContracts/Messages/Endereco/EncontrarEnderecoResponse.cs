using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages.Endereco
{
    [MessageContract(WrapperNamespace = "messages.am.fiap.com.br")]
    public class EncontrarEnderecoResponse : ResponseBase
    {
        [MessageBodyMember]
        public EnderecoDto Endereco { get; set; }
    }
}