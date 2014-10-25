using System;
using System.Collections;
using System.Collections.Generic;
using SecondFloor.I18n;

namespace SecondFloor.Model.Rules.Specifications
{
    public static class UsuarioSpecification
    {
        public static IDictionary<string, string> Validade(this Usuario usuario)
        {
            usuario.ClearBrokenRules();

            //Usuario
            if (string.IsNullOrEmpty(usuario.Login))
            {
                usuario.AddBrokenRule("Email", Resources.Model_Rules_Specification_Usuario_Login_NotNull);
            }
            /* tamanho ja foi validado no campo de email em cadastro do usuario */

            //Senha
            if (string.IsNullOrEmpty(usuario.Password))
            {
                usuario.AddBrokenRule("Password", Resources.Model_Rules_Specification_Usuario_Password_NotNoll);
            }
            
            return usuario.BrokenRules;
        }
    }
}