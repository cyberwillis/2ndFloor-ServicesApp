using System.ServiceModel;

namespace SecondFloor.DataContracts.Messages.Anuncio
{
    [MessageContract(WrapperNamespace = "messages.secondfloor.com")]
    public class EncontrarAnuncioRequest
    {
        [MessageBodyMember]
        public string Id { get; set; }
    }
}