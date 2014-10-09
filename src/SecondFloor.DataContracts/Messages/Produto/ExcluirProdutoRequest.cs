using System.ServiceModel;

namespace SecondFloor.DataContracts.Messages.Produto
{
    [MessageContract(WrapperNamespace = "messages.am.fiap.com.br")]
    public class ExcluirProdutoRequest
    {
        [MessageBodyMember]
        public string Id { get; set; }
    }
}