using System.ServiceModel;

namespace SecondFloor.DataContracts.Messages.Anunciante
{
    [MessageContract(WrapperNamespace = "messages.am.fiap.com.br")]
    public class EncontrarAnuncianteRequest
    {
        [MessageBodyMember]
        public string Id { get; set; }
    }
}