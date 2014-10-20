using System.Collections.Generic;
using SecondFloor.I18N;

namespace SecondFloor.Model.Rules.Specifications
{
    public static class EnderecoSpecification
    {
        public static IDictionary<string,string> Validate(this Endereco endereco)
        {
            endereco.ClearBrokenRules();

            //Logradouro
            if (string.IsNullOrEmpty(endereco.Logradouro))
            {
                endereco.BrokenRules.Add("Logradouro", Resources.Model_Rules_Specification_Endereco_Logradouro_NotNull);
            } else if((endereco.Logradouro.Trim()).Length > 250)
            {
                endereco.BrokenRules.Add("Logradouro", Resources.Model_Rules_Specification_Endereco_Logradouro_Long);
            }

            //Numero
            if (string.IsNullOrEmpty(endereco.Numero))
            {
                endereco.BrokenRules.Add("Numero", Resources.Model_Rules_Specification_Endereco_Numero_NotNull);
            }

            //Complemento (Opcional)
            if (!string.IsNullOrEmpty(endereco.Complemento))
            {
                if (endereco.Complemento.Length > 250)
                {
                    endereco.BrokenRules.Add("Complemento", Resources.Model_Rules_Specification_Endereco_Complemento_Long);
                }
            }

            //Bairro
            if (string.IsNullOrEmpty(endereco.Bairro))
            {
                endereco.BrokenRules.Add("Bairro", Resources.Model_Rules_Specification_Endereco_Bairro_NotNull);
            } else if (endereco.Bairro.Length > 50)
            {
                endereco.BrokenRules.Add("Bairro", Resources.Model_Rules_Specification_Endereco_Bairro_Long);
            }

            //Cidade
            if (string.IsNullOrEmpty(endereco.Cidade))
            {
                endereco.BrokenRules.Add("Cidade", Resources.Model_Rules_Specification_Endereco_Cidade_NotNull);
            }
            else if (endereco.Bairro.Length > 50)
            {
                endereco.BrokenRules.Add("Cidade", Resources.Model_Rules_Specification_Endereco_Cidade_Long);
            }

            //Estado
            /*if (string.IsNullOrEmpty(endereco.Estado))
            {
                endereco.BrokenRules.Add("Estado", "O estado não foi especificado.");
            } else if (endereco.Estado.Length > 10)
            {
                endereco.BrokenRules.Add("Estado", "O estado deve conter no máximo (10) caracteres.");   
            }*/

            if (string.IsNullOrEmpty(endereco.Cep))
            {
                endereco.BrokenRules.Add("CEP","O Cep não foi especificado");
            } 
            else if (endereco.Cep.Length > 9)
            {
                endereco.BrokenRules.Add("CEP", "O Cep deve conter no máximo (9) caracters.");
            }

            return endereco.BrokenRules;
        }
    }
}