using System.Collections.Generic;
using SecondFloor.Infrastructure;
using SecondFloor.Infrastructure.Model;

namespace SecondFloor.Model
{
    public static class ConsumidorSpecification
    {
        public static IList<BusinessRule> GetBrokenBusinessRules(this Consumidor consumidor)
        {
            //Nome
            if (string.IsNullOrEmpty(consumidor.Nome))
            {
                consumidor.AddBrokenRule(new BusinessRule("Nome", "O nome do consumidor não foi especificado."));
            }
            else if (consumidor.Nome.Length < 4)
            {
                consumidor.AddBrokenRule(new BusinessRule("Nome", "O nome do consumidor deve possuir no mínimo (4) caracteres."));
            }
            else if (consumidor.Nome.Length > 50)
            {
                consumidor.AddBrokenRule(new BusinessRule("Nome", "O nome do consumidor deve conter no máximo (50) caracteres."));
            }

            //Email
            if (string.IsNullOrEmpty(consumidor.Email))
            {
                consumidor.AddBrokenRule(new BusinessRule("Email", "O email do consumidor não foi especificado."));
            }
            else if (!DocumentosUtil.ValidaEmail(consumidor.Email))
            {
                consumidor.AddBrokenRule(new BusinessRule("Email", "O email do consumidor está inválido."));
            }

            //Email é enum

            return consumidor.BrokenRules;
        }
    }
}