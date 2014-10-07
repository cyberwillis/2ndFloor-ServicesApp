using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages.Anunciante
{
    [MessageContract(WrapperNamespace = "messages.am.fiap.com.br")]
    public class EncontrarAnuncianteResponse : ResponseBase
    {
        [MessageBodyMember]
        public AnuncianteDto Anunciante { get; set; }
    }
}