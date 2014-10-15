using System.ServiceModel;

namespace SecondFloor.DataContracts.Messages.Produto
{
    [MessageContract(WrapperNamespace = "messages.secondfloor.com")]
    public class ExcluirProdutoRequest
    {
        [MessageBodyMember]
        public string Id { get; set; }
    }
}