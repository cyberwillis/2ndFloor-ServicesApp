using System.ServiceModel;

namespace SecondFloor.DataContracts.Messages.Consumidor
{
    [MessageContract(WrapperNamespace = "messages.secondfloor.com")]
    public class CadastrarConsumidorResponse :ResponseBase
    {
        [MessageBodyMember(Name = "token")] 
        public string Token { get; set; }
    }
}