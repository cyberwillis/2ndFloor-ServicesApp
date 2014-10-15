using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages.Anuncio
{
    [MessageContract(WrapperNamespace = "messages.secondfloor.com")]
    public class ExcluirAnuncioRequest
    {
        [MessageBodyMember]
        public string Id { get; set; }
    }
}