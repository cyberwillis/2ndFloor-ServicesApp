using SecondFloor.Model.Rules.Specifications;

namespace SecondFloor.Model.Rules
{
    public static class AnuncianteServices
    {
        public static bool IsValid(this Anunciante anunciante)
        {
            AnuncianteSpecification.Validate(anunciante);

            return anunciante.BrokenRules.Count == 0;
        }
    }
}