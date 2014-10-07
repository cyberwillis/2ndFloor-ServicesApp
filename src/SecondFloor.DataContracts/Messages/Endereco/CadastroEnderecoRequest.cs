using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages.Endereco
{
    [MessageContract(WrapperNamespace = "messages.am.fiap.com.br")]
    public class CadastroEnderecoRequest
    {
        public EnderecoDto Endereco { get; set; }
        public string AnuncianteId { get; set; }
    }
}