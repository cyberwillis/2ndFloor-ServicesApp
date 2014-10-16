using System.Runtime.Serialization;
using System.ServiceModel;

namespace SecondFloor.DataContracts.Messages.ConsumidorOfertas
{
    [MessageContract(WrapperNamespace = "messages.secondfloor.com")]
    public class EncontrarOfertaRequest
    {
        [MessageBodyMember(Name = "bairro")]
        public string Bairro { get; set; } //implicito
        [MessageBodyMember(Name = "produto")]
        public string Produto { get; set; }
        [MessageBodyMember(Name = "tipoProduto")]
        public string TipoProduto { get; set; }
    }
}