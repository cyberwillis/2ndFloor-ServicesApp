using System.Collections.Generic;
using SecondFloor.Infrastructure;

namespace SecondFloor.Model.Specifications
{
    public static class ConsumidorSpecification
    {
        public static IDictionary<string,string> GetBrokenBusinessRules(this Consumidor consumidor)
        {
            consumidor.ClearBrokenRules();

            //Nome
            if (string.IsNullOrEmpty(consumidor.Nome))
            {
                consumidor.AddBrokenRule("Nome", "O nome do consumidor não foi especificado.");
            }
            else if (consumidor.Nome.Length < 4)
            {
                consumidor.AddBrokenRule("Nome", "O nome do consumidor deve possuir no mínimo (4) caracteres.");
            }
            else if (consumidor.Nome.Length > 50)
            {
                consumidor.AddBrokenRule("Nome", "O nome do consumidor deve conter no máximo (50) caracteres.");
            }

            //Email
            if (string.IsNullOrEmpty(consumidor.Email))
            {
                consumidor.AddBrokenRule("Email", "O email do consumidor não foi especificado.");
            }
            else if (!DocumentosUtil.ValidaEmail(consumidor.Email))
            {
                consumidor.AddBrokenRule("Email", "O email do consumidor está inválido.");
            }

            //Email é enum

            return consumidor.BrokenRules;
        }
    }
}