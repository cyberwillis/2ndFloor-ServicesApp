using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages.Endereco
{
    [MessageContract(WrapperNamespace = "messages.am.fiap.com.br")]
    public class AlterarEnderecoRequest
    {
        [MessageBodyMember]
        public EnderecoDto Endereco { get; set; }
        
        [MessageBodyMember]
        public string EstadoSigla { get; set; }
    }
}