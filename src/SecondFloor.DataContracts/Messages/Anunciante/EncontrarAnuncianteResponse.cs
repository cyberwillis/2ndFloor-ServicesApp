using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages.Anunciante
{
    [MessageContract(WrapperNamespace = "messages.secondfloor.com")]
    public class EncontrarAnuncianteResponse : ResponseBase
    {
        [MessageBodyMember]
        public AnuncianteDto Anunciante { get; set; }
    }
}