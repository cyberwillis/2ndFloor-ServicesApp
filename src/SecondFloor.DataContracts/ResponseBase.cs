using System.ServiceModel;

namespace SecondFloor.DataContracts
{
    [MessageContract]
    public class ResponseBase
    {
        [MessageBodyMember]
        public bool Success { get; set; }

        [MessageBodyMember]
        public string Message { get; set; }
    }
}