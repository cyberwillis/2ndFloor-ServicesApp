using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages.Produto
{
    [MessageContract(WrapperNamespace = "messages.am.fiap.com.br")]
    public class CadastrarProdutoRequest
    {
        [MessageBodyMember]
        public ProdutoDto Produto { get; set; }

        [MessageBodyMember]
        public string AnuncianteId { get; set; }
    }
}