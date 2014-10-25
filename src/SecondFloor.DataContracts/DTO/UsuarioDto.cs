using System.Runtime.Serialization;

namespace SecondFloor.DataContracts.DTO
{
    [DataContract(Name = "UsuarioDTO", Namespace = "dto.secondfloor.com")]
    public class UsuarioDto
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}