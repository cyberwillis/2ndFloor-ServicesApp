using System.ServiceModel;

namespace SecondFloor.DataContracts.Messages.ConsumidorOfertas
{
    [MessageContract(WrapperNamespace = "messages.secondfloor.com")]
    public class AtribuirRatingOfertaRequest
    {
        [MessageBodyMember(Name = "rating")]
        public string Rating { get; set; }

        [MessageBodyMember(Name = "consumidorId")] 
        public string Consumidor { get; set; }

        [MessageBodyMember(Name = "produtoId")]
        public string Produto { get; set; }
    }
}