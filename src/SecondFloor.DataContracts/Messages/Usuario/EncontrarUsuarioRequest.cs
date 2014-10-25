using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages.Usuario
{
    [MessageContract(WrapperNamespace = "messages.secondfloor.com")]
    public class EncontrarUsuarioRequest
    {
        [MessageBodyMember] 
        public UsuarioDto Usuario;
    }
}