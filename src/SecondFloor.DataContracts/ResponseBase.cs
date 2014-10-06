using System.ServiceModel;

namespace SecondFloor.DataContracts
{
    [MessageContract(WrapperNamespace = "messages.am.fiap.com.br")]
    public class ResponseBase
    {
        [MessageBodyMember]
        public bool Success { get; set; }

        [MessageBodyMember]
        public string Message { get; set; }

        public string MessageType { get; set; }
    }
}