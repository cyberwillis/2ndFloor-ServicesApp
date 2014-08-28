using System.Collections.Generic;

namespace _2ndFloor.Infrastructure
{
    public class ValueObjectBase : IValueObjectBase
    {
        protected IList<BusinessRule> BrokenRules = new List<BusinessRule>();

        public IList<BusinessRule> GetBrokenRules()
        {
            return BrokenRules;
        }

        public void AddBrokenRule(BusinessRule businessRule)
        {
            BrokenRules.Add(businessRule);
        }
    }
}