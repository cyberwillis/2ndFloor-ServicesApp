using System.Collections.Generic;
using SecondFloor.Infrastructure.Model;

namespace SecondFloor.Model
{
    public static class ComentarioSpecification
    {
        public static IList<BusinessRule> GetBrokenBusinessRules(this Comentario anunciante)
        {

            return anunciante.BrokenRules;
        }
    }
}