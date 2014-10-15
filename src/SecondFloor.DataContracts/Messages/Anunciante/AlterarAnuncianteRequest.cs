using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages.Anunciante
{
    [MessageContract(WrapperNamespace = "messages.secondfloor.com")]
    public class AlterarAnuncianteRequest
    {
        [MessageBodyMember]
        public AnuncianteDto Anunciante { get; set; }
    }
}