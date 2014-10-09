using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SecondFloor.Model.Specifications
{
    public static class ProdutoSpecification
    {
        public static IDictionary<string, string> GetBrokenBusinessRules(this Produto produto)
        {
            produto.ClearBrokenRules();

            
            //NomeProduto
            if (string.IsNullOrEmpty(produto.NomeProduto))
            {
                produto.BrokenRules.Add("NomeProduto","O nome do produto não foi especificado.");
            } else if (produto.NomeProduto.Length > 150)
            {
                produto.BrokenRules.Add("NomeProduto","O prodtuo deve conter no máximo(150) caracteres.");
            }
            
            //Descricao
            if (string.IsNullOrEmpty(produto.Descricao))
            {
                produto.BrokenRules.Add("Descricao", "A descrição do produto não foi especificada.");
            }
            else if (produto.Descricao.Length > 1000)
            {
                produto.BrokenRules.Add("Descricao", "A descrição do produto deve conter no máximo(1000) caracteres.");
            }

            //Referencia (opcional)

            //Fabricante (opcional)

            //Valor

            return produto.BrokenRules;
        }
    }
}