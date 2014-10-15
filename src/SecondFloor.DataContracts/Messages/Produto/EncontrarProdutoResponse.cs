using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages.Produto
{
    [MessageContract(WrapperNamespace = "messages.secondfloor.com")]
    public class EncontrarProdutoResponse : ResponseBase
    {
        [MessageBodyMember]
        public ProdutoDto Produto { get; set; }
    }
}