using System.Collections.Generic;
using SecondFloor.I18n;

namespace SecondFloor.Model.Rules.Specifications
{
    public static class ProdutoSpecification
    {
        public static IDictionary<string, string> Validate(this Produto produto)
        {
            produto.ClearBrokenRules();

            //NomeProduto
            if (string.IsNullOrEmpty(produto.NomeProduto))
            {
                produto.BrokenRules.Add("NomeProduto", Resources.Model_Rules_Produto_Specification_NomeProduto_NotNull);
            } else if (produto.NomeProduto.Length > 150)
            {
                produto.BrokenRules.Add("NomeProduto", Resources.Model_Rules_Produto_Specification_NomeProduto_Long);
            }
            
            //Descricao
            if (string.IsNullOrEmpty(produto.Descricao))
            {
                produto.BrokenRules.Add("Descricao", Resources.Model_Rules_Produto_Specification_Descricao_NotNull);
            }
            else if (produto.Descricao.Length > 1000)
            {
                produto.BrokenRules.Add("Descricao", Resources.Model_Rules_Produto_Specification_Descricao_Long);
            }

            //Referencia (opcional)

            //Fabricante (opcional)

            //Valor

            return produto.BrokenRules;
        }
    }
}