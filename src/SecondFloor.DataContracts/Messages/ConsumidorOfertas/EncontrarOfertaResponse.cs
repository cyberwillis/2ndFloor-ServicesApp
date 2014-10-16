using System.Collections.Generic;
using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages.ConsumidorOfertas
{
    [MessageContract(WrapperNamespace = "messages.secondfloor.com")]
    public class EncontrarOfertaResponse : ResponseBase
    {
        [MessageBodyMember(Name = "ofertas")]
        public IList<ConsumidorOfertaDto> Ofertas { get; set; }
    }
}