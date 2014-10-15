using System.Collections.Generic;
using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages.Anunciante
{
    [MessageContract(WrapperNamespace = "messages.secondfloor.com")]
    public class EncontrarTodosAnunciantesResponse : ResponseBase
    {
        public EncontrarTodosAnunciantesResponse()
        {
            Anunciantes = new List<AnuncianteDto>();
        }

        [MessageBodyMember]
        public IList<AnuncianteDto> Anunciantes { get; set; }
    }
}