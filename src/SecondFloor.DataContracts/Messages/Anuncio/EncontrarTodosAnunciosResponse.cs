using System.Collections.Generic;
using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages.Anuncio
{
    [MessageContract(WrapperNamespace = "messages.secondfloor.com")]
    public class EncontrarTodosAnunciosResponse : ResponseBase
    {
        [MessageBodyMember]
        public IList<AnuncioDto> Anuncios { get; set; }
    }
}