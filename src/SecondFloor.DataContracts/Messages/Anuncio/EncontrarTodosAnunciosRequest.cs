using System.ServiceModel;

namespace SecondFloor.DataContracts.Messages.Anuncio
{
    [MessageContract(WrapperNamespace = "messages.secondfloor.com")]
    public class EncontrarTodosAnunciosRequest
    {
        [MessageBodyMember]
        public string AnuncianteId { get; set; }
    }
}