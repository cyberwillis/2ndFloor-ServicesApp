using System.Collections.Generic;
using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages.ConsumidorOfertas
{
    [MessageContract(WrapperNamespace = "messages.am.fiap.com.br")]
    public class EncontrarOfertaResponse : ResponseBase
    {
        public IList<ConsumidorOfertaDto> Ofertas { get; set; }
    }
}