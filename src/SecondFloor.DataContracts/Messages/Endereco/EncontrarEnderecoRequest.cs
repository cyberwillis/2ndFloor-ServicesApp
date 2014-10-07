using System.ServiceModel;

namespace SecondFloor.DataContracts.Messages.Endereco
{
    [MessageContract(WrapperNamespace = "messages.am.fiap.com.br")]
    public class EncontrarEnderecoRequest
    {
        public string Id { get; set; }
    }
}