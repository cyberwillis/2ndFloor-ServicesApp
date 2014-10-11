using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages.Anunciante
{
    [MessageContract(WrapperNamespace = "messages.am.fiap.com.br")]
    public class CadastrarAnuncioRequest
    {
        [MessageBodyMember]
        public AnuncioDto Anuncio;

        [MessageBodyMember] 
        public string AnuncianteId;
    }
}