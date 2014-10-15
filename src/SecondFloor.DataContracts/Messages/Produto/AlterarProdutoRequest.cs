using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages.Produto
{
    [MessageContract(WrapperNamespace = "messages.secondfloor.com")]
    public class AlterarProdutoRequest
    {
        [MessageBodyMember]
        public ProdutoDto Produto { get; set; }

    }
}