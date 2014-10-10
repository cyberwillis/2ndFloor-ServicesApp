﻿using System.ServiceModel;

namespace SecondFloor.DataContracts.Messages.Produto
{
    [MessageContract(WrapperNamespace = "messages.am.fiap.com.br")]
    public class EncontrarTodosProdutosRequest
    {
        [MessageBodyMember]
        public string AnuncianteId { get; set; }
    }
}