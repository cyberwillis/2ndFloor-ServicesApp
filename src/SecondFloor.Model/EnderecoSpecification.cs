using System.Collections.Generic;
using SecondFloor.Infrastructure.Model;

namespace SecondFloor.Model
{
    public static class EnderecoSpecification
    {
        public static IList<BusinessRule> GetBrokenBusinessRules(this Endereco endereco)
        {
            //Logradouro
            if (string.IsNullOrEmpty(endereco.Logradouro))
            {
                endereco.BrokenRules.Add(new BusinessRule("Logradouro","O logradouro não foi especificado."));
            } else if((endereco.Logradouro.Trim()).Length > 50)
            {
                endereco.BrokenRules.Add(new BusinessRule("Logradouro", "O logradouro deve conter no máximo (50) caracteres."));
            }

            //Numero
            if (string.IsNullOrEmpty(endereco.Numero))
            {
                endereco.BrokenRules.Add(new BusinessRule("Numero", "O número do logradouro não foi especificado."));
            }

            //Complemento (Opcional)

            //Bairro
            if (string.IsNullOrEmpty(endereco.Bairro))
            {
                endereco.BrokenRules.Add(new BusinessRule("Bairro","O bairro não foi especificado."));
            } else if (endereco.Bairro.Length > 20)
            {
                endereco.BrokenRules.Add(new BusinessRule("Bairro", "O bairro deve conter no máximo (20) caracteres."));
            }

            //Cidade
            if (string.IsNullOrEmpty(endereco.Cidade))
            {
                endereco.BrokenRules.Add(new BusinessRule("Cidade", "A cidade não foi especificada."));
            }

            //Estado
            if (string.IsNullOrEmpty(endereco.Estado))
            {
                endereco.BrokenRules.Add(new BusinessRule("Estado", "O estado não foi especificado."));
            }else if (endereco.Estado.Length > 10)
            {
                endereco.BrokenRules.Add(new BusinessRule("Estado", "O estado deve conter no máximo (10) caracteres."));   
            }

            return endereco.BrokenRules;
        }
    }
}