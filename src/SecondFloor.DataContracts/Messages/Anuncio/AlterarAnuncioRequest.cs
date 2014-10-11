using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages.Anuncio
{
    [MessageContract(WrapperNamespace = "messages.am.fiap.com.br")]
    public class AlterarAnuncioRequest
    {
        [MessageBodyMember]
        public AnuncioDto Anuncio { get; set; }
        [MessageBodyMember]
        public string AnuncianteId { get; set; }
    }
}