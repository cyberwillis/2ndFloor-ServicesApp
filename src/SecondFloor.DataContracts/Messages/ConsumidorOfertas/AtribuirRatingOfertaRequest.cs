using System.ServiceModel;

namespace SecondFloor.DataContracts.Messages.ConsumidorOfertas
{
    [MessageContract(WrapperNamespace = "messages.secondfloor.com")]
    public class AtribuirRatingOfertaRequest
    {
        [MessageBodyMember(Name = "rating")]
        public string Rating { get; set; }
    }
}