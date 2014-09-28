using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages
{
    [MessageContract(WrapperNamespace = "messages.am.fiap.com.br")]
    public class CadastrarAnuncioRequest
    {
        [MessageBodyMember]
        public AnuncioDto Anuncio;

        [MessageBodyMember]
        public string AnuncianteToken;

        //TODO: talvez criar um constructor para iniciar um AnuncioDTO vazio
    }
}