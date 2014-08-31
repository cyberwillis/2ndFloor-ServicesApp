using System.Collections.Generic;
using SecondFloor.Infrastructure.Model;

namespace SecondFloor.Model
{
    public static class AnuncioSpecification
    {
        public static IList<BusinessRule> GetBrokenBusinessRules(this Anuncio anunciante)
        {
            
            return anunciante.BrokenRules;
        }
    }
}