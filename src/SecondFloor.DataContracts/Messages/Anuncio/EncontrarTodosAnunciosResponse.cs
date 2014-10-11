using System.Collections.Generic;
using System.ServiceModel;
using SecondFloor.DataContracts.DTO;

namespace SecondFloor.DataContracts.Messages.Anuncio
{
    [MessageContract(WrapperNamespace = "messages.am.fiap.com.br")]
    public class EncontrarTodosAnunciosResponse : ResponseBase
    {
        [MessageBodyMember]
        public IList<AnuncioDto> Anuncios { get; set; }
    }
}