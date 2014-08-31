using System.Collections.Generic;
using SecondFloor.Infrastructure.Model;

namespace SecondFloor.Model
{
    public static class EnderecoSpecification
    {
        public static IList<BusinessRule> GetBrokenBusinessRules(this Endereco anunciante)
        {

            return anunciante.BrokenRules;
        }
    }
}