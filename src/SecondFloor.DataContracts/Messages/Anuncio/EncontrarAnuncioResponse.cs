using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages.Anuncio
{
    [MessageContract(WrapperNamespace = "messages.am.fiap.com.br")]
    public class EncontrarAnuncioResponse : ResponseBase
    {
        [MessageBodyMember]
        public AnuncioDto Anuncio { get; set; }
    }
}