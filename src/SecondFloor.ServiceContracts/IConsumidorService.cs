using System.Collections.Generic;
using System.ServiceModel;
using SecondFloor.DataContracts.DTO;
using SecondFloor.DataContracts.Messages.ConsumidorOfertas;

namespace SecondFloor.ServiceContracts
{
    [ServiceContract(Namespace = "services.am.fiap.com.br",Name = "ConsumidorService")] //compatibilidade de nome de interface no Java
    public interface IConsumidorService
    {
        EncontrarOfertaResponse EncontrarOfertaPor(EncontrarOfertaRequest request);
    }
}