using System.ServiceModel;

namespace SecondFloor.DataContracts.Messages.Anunciante
{
    [MessageContract(WrapperNamespace = "messages.secondfloor.com")]
    public class EncontrarAnuncianteRequest
    {
        [MessageBodyMember]
        public string Id { get; set; }
    }
}