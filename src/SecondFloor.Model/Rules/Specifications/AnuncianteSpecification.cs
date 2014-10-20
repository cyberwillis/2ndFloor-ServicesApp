using System.Collections.Generic;
using SecondFloor.I18N;
using SecondFloor.Infrastructure;

namespace SecondFloor.Model.Rules.Specifications
{
    public static class AnuncianteSpecification
    {
        public static IDictionary<string,string> Validate(this Anunciante anunciante)
        {
            anunciante.ClearBrokenRules();

            //Nome Responsavel
            if (string.IsNullOrEmpty(anunciante.Responsavel))
            {
                anunciante.AddBrokenRule("NomeResponsavel", Resources.Model_Rules_Specification_Anunciante_NomeResponsavel_NotNull);
            }
            else if (anunciante.Responsavel.Length < 2)
            {
                anunciante.AddBrokenRule("NomeResponsavel", Resources.Model_Rules_Specification_Anunciante_NomeResponsavel_Short);
            }
            else if (anunciante.Responsavel.Length > 250)
            {
                anunciante.AddBrokenRule("NomeResponsavel", Resources.Model_Rules_Specification_Anunciante_NomeResponsavel_Long);
            }

            //Razao Social
            if (string.IsNullOrEmpty(anunciante.RazaoSocial))
            {
                anunciante.AddBrokenRule("RazaoSocial", Resources.Model_Rules_Specification_Anunciante_RazaoSocial_NotNull);
            }
            else if (anunciante.RazaoSocial.Length < 10)
            {
                anunciante.AddBrokenRule("RazaoSocial", Resources.Model_Rules_Specification_Anunciante_RazaoSocial_Short);
            }
            else if (anunciante.RazaoSocial.Length > 250)
            {
                anunciante.AddBrokenRule("RazaoSocial", Resources.Model_Rules_Specification_Anunciante_RazaoSocial_Long);
            }

            //Cnpj
            if (string.IsNullOrEmpty(anunciante.Cnpj))
            {
                anunciante.AddBrokenRule("Cnpj", Resources.Model_Rules_Specification_Anunciante_Cnpj_NotNull);
            }
            else if (!DocumentosUtil.ValidaCnpj(anunciante.Cnpj))
            {
                anunciante.AddBrokenRule("Cnpj", Resources.Model_Rules_Specification_Anunciante_Cnpj_Invalid);
            }

            //Email
            if (string.IsNullOrEmpty(anunciante.Email))
            {
                anunciante.AddBrokenRule("Email", Resources.Model_Rules_Specification_Anunciante_Email_NotNull);
            }
            else if (!DocumentosUtil.ValidaEmail(anunciante.Email))
            {
                anunciante.AddBrokenRule("Email", Resources.Model_Rules_Specification_Anunciante_Email_Invalid);
            }

            //Token
            /*if (string.IsNullOrEmpty(anunciante.Token))
            {
                anunciante.AddBrokenRule("Token","Erro no cadastro do Anunciante, ficará impossibilitado de publicar ofertas");
                //cantactar Admin do portal por email
            } else if (anunciante.Token != GetToken(anunciante) )
            {
                anunciante.AddBrokenRule("Token", "O Token do anunciante não confere");
            }*/

            return anunciante.BrokenRules;
        }

        /*public static string GetToken(this Anunciante anunciante)
        {
            string parametroChave = anunciante.Cnpj + anunciante.RazaoSocial;

            return Sha1Util.SHA1HashStringForUTF8String(parametroChave);
        }*/
        
    }
}