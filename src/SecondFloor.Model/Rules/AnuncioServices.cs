using SecondFloor.Model.Rules.Specifications;

namespace SecondFloor.Model.Rules
{
    public static class AnuncioServices
    {
        public static bool IsValid(this Anuncio anuncio)
        {
            AnuncioSpecification.Validate(anuncio);

            return anuncio.BrokenRules.Count == 0;
        }
    }
}