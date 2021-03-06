﻿using System.Collections.Generic;
using System.ServiceModel;

namespace SecondFloor.DataContracts
{
    [MessageContract(WrapperNamespace = "messages.secondfloor.com")]
    public class ResponseBase
    {
        public ResponseBase()
        {
            this.Rules = new Dictionary<string, string>();
        }

        [MessageBodyMember(Name = "success")]
        public bool Success { get; set; }

        [MessageBodyMember(Name = "message")]
        public string Message { get; set; }

        public string MessageType { get; set; }

        //Experimental
        public IDictionary<string, string> Rules { get; set; }
    }
}