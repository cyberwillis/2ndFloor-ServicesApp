using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages
{
    [MessageContract(WrapperNamespace = "messages.am.fiap.com.br")]
    public class AlterarAnuncianteRequest
    {
        [MessageBodyMember]
        public AnuncianteDto Anunciante { get; set; }
    }
}