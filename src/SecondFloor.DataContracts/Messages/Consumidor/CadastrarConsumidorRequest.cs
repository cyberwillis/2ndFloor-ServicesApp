using System.ServiceModel;

namespace SecondFloor.DataContracts.Messages.Consumidor
{
    [MessageContract(WrapperNamespace = "messages.secondfloor.com")]
    public class CadastrarConsumidorRequest
    {
        [MessageBodyMember(Name = "nome")]
        public string Nome { get; set; }

        [MessageBodyMember(Name = "email")]
        public string Email { get; set; }
    }
}