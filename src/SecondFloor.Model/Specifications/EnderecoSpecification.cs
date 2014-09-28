﻿using System.Collections.Generic;

namespace SecondFloor.Model.Specifications
{
    public static class EnderecoSpecification
    {
        public static IDictionary<string,string> GetBrokenBusinessRules(this Endereco endereco)
        {
            endereco.ClearBrokenRules();

            //Logradouro
            if (string.IsNullOrEmpty(endereco.Logradouro))
            {
                endereco.BrokenRules.Add("Logradouro","O logradouro não foi especificado.");
            } else if((endereco.Logradouro.Trim()).Length > 50)
            {
                endereco.BrokenRules.Add("Logradouro", "O logradouro deve conter no máximo (50) caracteres.");
            }

            //Numero
            if (string.IsNullOrEmpty(endereco.Numero))
            {
                endereco.BrokenRules.Add("Numero", "O número do logradouro não foi especificado.");
            }

            //Complemento (Opcional)

            //Bairro
            if (string.IsNullOrEmpty(endereco.Bairro))
            {
                endereco.BrokenRules.Add("Bairro","O bairro não foi especificado.");
            } else if (endereco.Bairro.Length > 20)
            {
                endereco.BrokenRules.Add("Bairro", "O bairro deve conter no máximo (20) caracteres.");
            }

            //Cidade
            if (string.IsNullOrEmpty(endereco.Cidade))
            {
                endereco.BrokenRules.Add("Cidade", "A cidade não foi especificada.");
            }

            //Estado
            if (string.IsNullOrEmpty(endereco.Estado))
            {
                endereco.BrokenRules.Add("Estado", "O estado não foi especificado.");
            }else if (endereco.Estado.Length > 10)
            {
                endereco.BrokenRules.Add("Estado", "O estado deve conter no máximo (10) caracteres.");   
            }

            return endereco.BrokenRules;
        }
    }
}