using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages.Anunciante
{
    [MessageContract(WrapperNamespace = "messages.secondfloor.com")]
    public class CadastrarAnuncioRequest
    {
        [MessageBodyMember]
        public AnuncioDto Anuncio;

        [MessageBodyMember] 
        public string AnuncianteId;

        [MessageBodyMember] 
        public string EnderecoId;
    }
}