using System.Collections.Generic;
using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages.Estado
{
    [MessageContract(WrapperNamespace = "messages.am.fiap.com.br")]
    public class EncontrarTodosEstadosResponse : ResponseBase
    {
        [MessageBodyMember]
        public IList<EstadoDto> Estados { get; set; }
    }
}