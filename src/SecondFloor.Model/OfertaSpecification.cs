using System.Collections.Generic;
using SecondFloor.Infrastructure.Model;

namespace SecondFloor.Model
{
    public static class OfertaSpecification
    {
        public static IList<BusinessRule> GetBrokenBusinessRules(this Oferta oferta)
        {
            //Titulo Oferta
            if (string.IsNullOrEmpty(oferta.Titulo))
            {
                oferta.BrokenRules.Add(new BusinessRule("Titulo","A oferta não foi informada."));
            } else if (oferta.Titulo.Length > 20)
            {
                oferta.BrokenRules.Add(new BusinessRule("Titulo", "A oferta deve possuir no máximo (20) caracteres."));
            }

            //Descricao Oferta
            if (string.IsNullOrEmpty(oferta.Descricao))
            {
                oferta.BrokenRules.Add(new BusinessRule("Descricao", "A descrição não foi informada."));
            } else if (oferta.Descricao.Length > 200)
            {
                oferta.BrokenRules.Add(new BusinessRule("Descricao", "A descrição deve possui no máximo (200) caracteres."));
            }

            //Preco
            if (string.IsNullOrEmpty(oferta.Preco))
            {
                oferta.BrokenRules.Add(new BusinessRule("Preco", "O preço da oferta não foi informado."));
            }

            //Endereco
            if (oferta.Endereco == null)
            {
                oferta.BrokenRules.Add(new BusinessRule("Endereco", "A oferta deve conter um endereço."));
            }

            return oferta.BrokenRules;
        }
    }
}