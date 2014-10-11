using System;
using System.Collections.Generic;
using System.Linq;

namespace SecondFloor.Model.Rules.Specifications
{
    public static class AnuncioSpecification
    {
        public static IDictionary<string,string> Validate(this Anuncio anuncio)
        {
            anuncio.ClearBrokenRules();

            var dataHoje = DateTime.Now.Date;

            //Titulo
            if (string.IsNullOrEmpty(anuncio.Titulo))
            {
                anuncio.AddBrokenRule("Titulo", "O titulo do anúncio não foi especificado.");
            }
            else if(anuncio.Titulo.Length > 50)
            {
                anuncio.AddBrokenRule("Titulo", "O titulo do anúncio deve conter no máximo (50) caracteres.");
            }

            //Data inicio
            if (!(anuncio.DataInicio.Date.CompareTo(dataHoje.Date) > 0))
            {
                anuncio.AddBrokenRule("DataInicio","O anuncio deve possuir uma data de inicio posterior a de hoje.");
            }

            //Data inicio e fim
            if (anuncio.DataFim.Date == anuncio.DataInicio.Date)
            {
                anuncio.AddBrokenRule("DataInicio", "O anuncio deve possuir uma data de inicio diferente da data de fim.");
                anuncio.AddBrokenRule("DataFim", "O anuncio deve possuir uma data de término diferente da data de inicio.");
            } 
            else if (!(anuncio.DataFim.Date.CompareTo(dataHoje.Date) > 0))
            {
                anuncio.AddBrokenRule("DataFim", "O anuncio deve possuir uma data de término posterior a de hoje.");
            }
            else if (!(anuncio.DataFim.Date.CompareTo(anuncio.DataInicio.Date) > 0))
            {
                anuncio.AddBrokenRule("DataFim", "O anuncio deve possuir uma data de término posterior a de inicio.");
            }

            //Ofertas
            if (anuncio.Ofertas == null || anuncio.Ofertas.Count == 0)
            {
                anuncio.AddBrokenRule("Ofertas", "O anuncio deve possuir ofertas para publicação.");
            } 
            else if ( anuncio.Ofertas.Any())
            {
                foreach (var oferta in anuncio.Ofertas)
                {
                    anuncio.AddRangeBrokenRules(oferta.GetBrokenBusinessRules());
                }
            }

            return anuncio.BrokenRules;
        }
    }
}