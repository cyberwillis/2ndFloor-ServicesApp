using SecondFloor.Model.Rules.Specifications;

namespace SecondFloor.Model.Rules
{
    public static class EnderecoServices
    {
        public static bool IsValid(this Endereco endereco)
        {
            EnderecoSpecification.Validate(endereco);

            return endereco.BrokenRules.Count == 0;
        }
    }
}