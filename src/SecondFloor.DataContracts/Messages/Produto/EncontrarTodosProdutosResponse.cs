using System.Collections.Generic;
using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages.Produto
{
    [MessageContract(WrapperNamespace = "messages.am.fiap.com.br")]
    public class EncontrarTodosProdutosResponse:ResponseBase
    {
        [MessageBodyMember]
        public IList<ProdutoDto> Produtos { get; set; }
    }
}