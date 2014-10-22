using SecondFloor.Model.Rules.Specifications;

namespace SecondFloor.Model.Rules
{
    public static class ConsumidorServices
    {
        public static bool IsValid(this Consumidor consumidor)
        {
            ConsumidorSpecification.Validate(consumidor);

            return consumidor.BrokenRules.Count == 0;
        }
    }
}