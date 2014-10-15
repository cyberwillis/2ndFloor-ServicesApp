using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages.Anuncio
{
    [MessageContract(WrapperNamespace = "messages.secondfloor.com")]
    public class EncontrarAnuncioResponse : ResponseBase
    {
        [MessageBodyMember]
        public AnuncioDto Anuncio { get; set; }
    }
}