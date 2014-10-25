using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages.Usuario
{
    [MessageContract(WrapperNamespace = "messages.secondfloor.com")]
    public class EncontrarUsuarioResponse : ResponseBase
    {
        [MessageBodyMember]
        public UsuarioDto Usuario { get; set; }
    }
}