using System.Collections.Generic;

namespace SecondFloor.Model.Rules.Specifications
{
    public static class OfertaSpecification
    {
        public static IDictionary<string,string> GetBrokenBusinessRules(this Oferta oferta)
        {
            oferta.ClearBrokenRules();

            /*//Titulo Oferta
            if (string.IsNullOrEmpty(oferta.Titulo))
            {
                oferta.BrokenRules.Add("Titulo", "A oferta não foi informada.");
            }
            else if (oferta.Titulo.Length > 100)
            {
                oferta.BrokenRules.Add("Titulo", "A oferta deve possuir no máximo (100) caracteres.");
            }

            //Descricao Oferta
            if (string.IsNullOrEmpty(oferta.Descricao))
            {
                oferta.BrokenRules.Add("Descricao", "A descrição não foi informada.");
            }
            else if (oferta.Descricao.Length > 200)
            {
                oferta.BrokenRules.Add("Descricao", "A descrição deve possui no máximo (200) caracteres.");
            }

            //Preco
            if (string.IsNullOrEmpty(oferta.Preco))
            {
                oferta.BrokenRules.Add("Preco", "O preço da oferta não foi informado.");
            }*/

            //Endereco
            /*if (oferta.Endereco == null)
            {
                oferta.BrokenRules.Add("Endereco", "A oferta deve conter um endereço.");
            }
            else if (oferta.Endereco != null)
            {
                oferta.AddRangeBrokenRules(oferta.Endereco.Validate());
            }*/

            return oferta.BrokenRules;
        }
    }
}