using System;
using System.Collections.Generic;
using System.Linq;

namespace SecondFloor.Model.Specifications
{
    public static class AnuncioSpecification
    {
        public static IDictionary<string,string> GetBrokenBusinessRules(this Anuncio anuncio)
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
            if (!(anuncio.DataInicio.Date.CompareTo(dataHoje.Date) >= 0))
            {
                anuncio.AddBrokenRule("Data Inicio","Estas ofertas devem possuir uma data de inicio posterior a de hoje.");
            }

            //Data inicio e fim
            if (anuncio.DataFim.Date == anuncio.DataInicio.Date)
            {
                anuncio.AddBrokenRule("Data Inicio", "Estas ofertas devem possuir uma data de inicio diferente da data de fim.");
                anuncio.AddBrokenRule("Data Fim", "Estas ofertas devem possuir uma data de fim diferente da data de inicio.");
            }

            //Data Fim 
            else if (!(anuncio.DataFim.Date.CompareTo(dataHoje.Date) > 0))
            {
                anuncio.AddBrokenRule("Data Fim", "Estas ofertas devem possuir uma data de fim posterior a de hoje.");
            }
            //Data Fim 
            else if (!(anuncio.DataFim.Date.CompareTo(anuncio.DataInicio.Date) > 0))
            {
                anuncio.AddBrokenRule("Data Fim", "Estas ofertas devem possuir uma data de fim posterior a de inicio.");
            }

            //Ofertas
            if (anuncio.Ofertas == null || anuncio.Ofertas.Count == 0)
            {
                anuncio.AddBrokenRule("Oferas", "A publicação da oferta precisa conter produtos ou serviços.");
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