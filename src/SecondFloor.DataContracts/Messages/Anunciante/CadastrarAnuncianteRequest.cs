using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages.Anunciante
{
    [MessageContract(WrapperNamespace = "messages.am.fiap.com.br")]
    public class CadastrarAnuncianteRequest
    {
        [MessageBodyMember]
        public AnuncianteDto Anunciante;

        //TODO: talvez criar um constructor para iniciar um AnuncioDTO vazio
    }
}