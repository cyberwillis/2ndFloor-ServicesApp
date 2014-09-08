﻿using System.Collections.Generic;
using System.Security.Cryptography;
using SecondFloor.Infrastructure;
using SecondFloor.Infrastructure.Model;

namespace SecondFloor.Model
{
    public static class AnuncianteSpecification
    {
        public static IList<BusinessRule> GetBrokenBusinessRules(this Anunciante anunciante)
        {
            //Razao Social
            if (string.IsNullOrEmpty(anunciante.RazaoSocial))
            {
                anunciante.AddBrokenRule(new BusinessRule("Razao Social","A razão social não pode ser nula."));
            }
            else if (anunciante.RazaoSocial.Length < 4)
            {
                anunciante.AddBrokenRule(new BusinessRule("Razao Social", "A razão social deve possuir no mínimo 4 caracteres."));
            }
            else if (anunciante.RazaoSocial.Length > 50)
            {
                anunciante.AddBrokenRule(new BusinessRule("Razao Social", "A razão social deve possuir no maximo 50 caracteres."));
            }

            //Cnpj
            if (string.IsNullOrEmpty(anunciante.Cnpj))
            {
                anunciante.AddBrokenRule(new BusinessRule("Cnpj", "O Cnpj não pode ser nulo."));
            }
            else if (!DocumentosUtil.ValidaCnpj(anunciante.Cnpj))
            {
                anunciante.AddBrokenRule(new BusinessRule("Cnpj", "O Cnpj está invalido"));
            }

            //Email
            /*if (string.IsNullOrEmpty(anunciante.Email))
            {
                anunciante.AddBrokenRule(new BusinessRule("Email", "O Email não pode ser nulo."));
            }
            else if (!DocumentosUtil.ValidaEmail(anunciante.Email))
            {
                anunciante.AddBrokenRule(new BusinessRule("Email", "O Email está invalido"));
            }*/

            //Token
            if (string.IsNullOrEmpty(anunciante.Token))
            {
                anunciante.AddBrokenRule(new BusinessRule("Token","Erro no cadastro do Anunciante, ficará impossibilitado de publicar ofertas"));
                //cantactar Admin do portal por email
            } else if (anunciante.Token != GetToken(anunciante) )
            {
                anunciante.AddBrokenRule(new BusinessRule("Token", "O Token do anunciante não confere"));
            }

            return anunciante.BrokenRules;
        }

        public static string GetToken(this Anunciante anunciante)
        {
            string parametroChave = anunciante.Cnpj + anunciante.RazaoSocial;

            return Sha1Util.SHA1HashStringForUTF8String(parametroChave);
        }
        
    }
}