using System.Collections.Generic;
using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages.Estado
{
    [MessageContract(WrapperNamespace = "messages.secondfloor.com")]
    public class EncontrarTodosEstadosResponse : ResponseBase
    {
        [MessageBodyMember]
        public IList<EstadoDto> Estados { get; set; }
    }
}