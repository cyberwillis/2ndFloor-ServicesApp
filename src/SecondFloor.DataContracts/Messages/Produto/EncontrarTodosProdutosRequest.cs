using System.ServiceModel;

namespace SecondFloor.DataContracts.Messages.Produto
{
    [MessageContract(WrapperNamespace = "messages.secondfloor.com")]
    public class EncontrarTodosProdutosRequest
    {
        [MessageBodyMember]
        public string AnuncianteId { get; set; }
    }
}