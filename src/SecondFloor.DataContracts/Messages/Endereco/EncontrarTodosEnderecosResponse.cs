using System.Collections.Generic;
using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages.Endereco
{
    [MessageContract(WrapperNamespace = "messages.am.fiap.com.br")]
    public class EncontrarTodosEnderecosResponse : ResponseBase
    {
        [MessageBodyMember]
        public IList<EnderecoDto> Enderecos { get; set; }
    }
}