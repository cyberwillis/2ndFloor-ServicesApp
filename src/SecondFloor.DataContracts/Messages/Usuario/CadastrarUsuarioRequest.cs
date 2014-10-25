using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages.Usuario
{
    [MessageContract(WrapperNamespace = "messages.secondfloor.com")]
    public class CadastrarUsuarioRequest
    {
        [MessageBodyMember]
        public UsuarioDto Usuario { get; set; }
    }
}