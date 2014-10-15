using System.ServiceModel;

namespace SecondFloor.DataContracts.Messages.Anuncio
{
    [MessageContract(WrapperNamespace = "messages.secondfloor.com")]
    public class PublicarAnuncioRequest
    {
        [MessageBodyMember]
        public string Id { get; set; }
    }
}