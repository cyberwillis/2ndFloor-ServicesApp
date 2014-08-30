using System.Collections.Generic;
using SecondFloor.Infrastructure.Model;

namespace SecondFloor.Model
{
    public static class AnuncianteSpecification
    {
        public static IList<BusinessRule> GetBrokenBusinessRules(this Anunciante anunciante)
        {
            if (string.IsNullOrEmpty(anunciante.RazaoSocial))
            {
                anunciante.AddBrokenRule(new BusinessRule("Razao Social","A razão social não pode ser nula"));
            }

            //demais estados de teste

            return anunciante.BrokenRules;
        }
    }
}