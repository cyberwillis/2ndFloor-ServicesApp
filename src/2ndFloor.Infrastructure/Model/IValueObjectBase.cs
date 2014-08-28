using System.Collections.Generic;

namespace _2ndFloor.Infrastructure
{
    public interface IValueObjectBase
    {
        IList<BusinessRule> GetBrokenRules();
        void AddBrokenRule(BusinessRule businessRule);
    }
}