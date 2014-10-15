using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages.Produto
{
    [MessageContract(WrapperNamespace = "messages.secondfloor.com")]
    public class CadastrarProdutoRequest
    {
        [MessageBodyMember]
        public ProdutoDto Produto { get; set; }

        [MessageBodyMember]
        public string AnuncianteId { get; set; }
    }
}