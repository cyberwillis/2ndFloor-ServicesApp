using SecondFloor.Model.Rules.Specifications;

namespace SecondFloor.Model.Rules
{
    public static class ProdutoServices
    {
        public static bool IsValid(this Produto produto)
        {
            ProdutoSpecification.Validate(produto);

            return produto.BrokenRules.Count == 0;
        }
    }
}