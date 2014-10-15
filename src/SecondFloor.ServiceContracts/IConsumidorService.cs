using System.Collections.Generic;
using System.ServiceModel;
using SecondFloor.DataContracts.DTO;
using SecondFloor.DataContracts.Messages.ConsumidorOfertas;

namespace SecondFloor.ServiceContracts
{
    [ServiceContract(Namespace = "services.secondfloor.com",Name = "ConsumidorService")] //compatibilidade de nome de interface no Java
    public interface IConsumidorService
    {
        [OperationContract]
        EncontrarOfertaResponse EncontrarOfertaPor(EncontrarOfertaRequest request);

        [OperationContract]
        AtribuirRatingOfertaResponse AtribuirRatingPara(AtribuirRatingOfertaRequest request);
    }
}