using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages.Endereco
{
    [MessageContract(WrapperNamespace = "messages.secondfloor.com")]
    public class AlterarEnderecoRequest
    {
        [MessageBodyMember]
        public EnderecoDto Endereco { get; set; }
        
        [MessageBodyMember]
        public string EstadoSigla { get; set; }
    }
}