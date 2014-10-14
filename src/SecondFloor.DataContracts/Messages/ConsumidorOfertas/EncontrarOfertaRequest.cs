using System.Runtime.Serialization;
using System.ServiceModel;

namespace SecondFloor.DataContracts.Messages.ConsumidorOfertas
{
    [MessageContract(WrapperNamespace = "messages.am.fiap.com.br")]
    public class EncontrarOfertaRequest
    {
        [DataMember]
        public string Bairro { get; set; } //implicito
        [DataMember]
        public string Produto { get; set; }
        [DataMember]
        public string TipoProduto { get; set; }
    }
}