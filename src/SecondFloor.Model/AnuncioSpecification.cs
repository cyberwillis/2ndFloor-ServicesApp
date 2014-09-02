using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SecondFloor.Infrastructure.Model;

namespace SecondFloor.Model
{
    public static class AnuncioSpecification
    {
        public static IList<BusinessRule> GetBrokenBusinessRules(this Anuncio anuncio)
        {
            var dataHoje = DateTime.Now.Date;

            //Titulo
            if (string.IsNullOrEmpty(anuncio.Titulo))
            {
                anuncio.AddBrokenRule(new BusinessRule("Titulo", "O titulo do anúncio não foi especificado."));
            }
            else if(anuncio.Titulo.Length > 50)
            {
                anuncio.AddBrokenRule(new BusinessRule("Titulo", "O titulo do anúncio deve conter no máximo (50) caracteres."));
            }

            //Data inicio
            if (!(anuncio.DataInicio.Date.CompareTo(dataHoje.Date) >= 0))
            {
                anuncio.AddBrokenRule(new BusinessRule("Data Inicio","Estas ofertas devem possuir uma data de inicio posterior a de hoje."));
            }

            //Data Fim
            if (!(anuncio.DataFim.Date.CompareTo(dataHoje.Date) > 0))
            {
                anuncio.AddBrokenRule(new BusinessRule("Data Fim", "Estas ofertas devem possuir uma data de fim posterior a de hoje."));
            }

            //Data inicio e fim
            if (!( anuncio.DataFim.Date.CompareTo(anuncio.DataInicio.Date) > 0 ))
            {
                anuncio.AddBrokenRule(new BusinessRule("Data Inicio", "Estas ofertas devem possuir uma data de inicio diferente da data de fim."));
                anuncio.AddBrokenRule(new BusinessRule("Data Fim", "Estas ofertas devem possuir uma data de fim diferente da data de inicio."));
            }

            //Ofertas
            if (anuncio.Ofertas == null )
            {
                anuncio.AddBrokenRule(new BusinessRule("Data Inicio", "A publicação da oferta precisa conter produtos ou serviços."));
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