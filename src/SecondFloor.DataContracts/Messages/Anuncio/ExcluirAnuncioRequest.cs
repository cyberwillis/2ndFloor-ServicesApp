using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages.Anuncio
{
    [MessageContract(WrapperNamespace = "messages.am.fiap.com.br")]
    public class ExcluirAnuncioRequest
    {
        [MessageBodyMember]
        public string Id { get; set; }
    }
}