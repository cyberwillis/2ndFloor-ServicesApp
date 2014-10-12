using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages.Endereco
{
    [MessageContract(WrapperNamespace = "messages.am.fiap.com.br")]
    public class CadastrarEnderecoRequest
    {
        [MessageBodyMember]
        public string AnuncianteId { get; set; }

        [MessageBodyMember]
        public EnderecoDto Endereco { get; set; }

        [MessageBodyMember]
        public string EstadoSigla { get; set; }
    }
}