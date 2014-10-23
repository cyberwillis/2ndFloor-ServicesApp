using System.Collections.Generic;
using SecondFloor.I18n;
using SecondFloor.Infrastructure;

namespace SecondFloor.Model.Rules.Specifications
{
    public static class ConsumidorSpecification
    {
        public static IDictionary<string,string> Validate(this Consumidor consumidor)
        {
            consumidor.ClearBrokenRules();

            //Nome
            if (string.IsNullOrEmpty(consumidor.Nome))
            {
                consumidor.AddBrokenRule("Nome", Resources.Model_Rules_Specification_Consumidor_Nome_NotNull);
            }
            else if (consumidor.Nome.Length < 4)
            {
                consumidor.AddBrokenRule("Nome", Resources.Model_Rules_Specification_Consumidor_Nome_Short);
            }
            else if (consumidor.Nome.Length > 50)
            {
                consumidor.AddBrokenRule("Nome", Resources.Model_Rules_Specification_Consumidor_Nome_Long);
            }

            //Email
            if (string.IsNullOrEmpty(consumidor.Email))
            {
                consumidor.AddBrokenRule("Email", Resources.Model_Rules_Specification_Consumidor_Email_NotNull);
            }
            else if (!DocumentosUtil.ValidaEmail(consumidor.Email))
            {
                consumidor.AddBrokenRule("Email", Resources.Model_Rules_Specification_Consumidor_Email_Invalid);
            }
            else if (consumidor.Email.Length > 250)
            {
                consumidor.AddBrokenRule("Email", Resources.Model_Rules_Specification_Consumidor_Email_Long);
            }

            //TipoAcesso
            
            //Token

            return consumidor.BrokenRules;
        }
    }
}