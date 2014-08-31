using System.Collections.Generic;
using SecondFloor.Infrastructure.Model;

namespace SecondFloor.Model
{
    public static class OfertaSpecification
    {
        public static IList<BusinessRule> GetBrokenBusinessRules(this Oferta anunciante)
        {

            return anunciante.BrokenRules;
        }
    }
}