using System.ServiceModel;

namespace SecondFloor.DataContracts.Messages.Endereco
{
    [MessageContract(WrapperNamespace = "messages.secondfloor.com")]
    public class EncontrarTodosEnderecosRequest
    {
        [MessageBodyMember]
        public string AnuncianteId { get; set; }
    }
}