using System.Collections.Generic;
using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages.Produto
{
    [MessageContract(WrapperNamespace = "messages.secondfloor.com")]
    public class EncontrarTodosProdutosResponse:ResponseBase
    {
        [MessageBodyMember]
        public IList<ProdutoDto> Produtos { get; set; }
    }
}