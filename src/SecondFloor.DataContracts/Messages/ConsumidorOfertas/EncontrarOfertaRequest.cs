using System.Runtime.Serialization;
using System.ServiceModel;

namespace SecondFloor.DataContracts.Messages.ConsumidorOfertas
{
    [MessageContract(WrapperNamespace = "messages.secondfloor.com")]
    public class EncontrarOfertaRequest
    {
        [MessageBodyMember]
        public string Bairro { get; set; } //implicito
        [MessageBodyMember]
        public string Produto { get; set; }
        [MessageBodyMember]
        public string TipoProduto { get; set; }
    }
}