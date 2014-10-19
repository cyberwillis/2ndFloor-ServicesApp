using System.ServiceModel;

namespace SecondFloor.DataContracts.Messages.Consumidor
{
    [MessageContract(WrapperNamespace = "messages.secondfloor.com")]
    public class LogonConsumidorRequest
    {
        [MessageBodyMember(Name = "email")]
        public string Email { get; set; }

        [MessageBodyMember(Name = "senha")]
        public string Senha { get; set; }
    }
}