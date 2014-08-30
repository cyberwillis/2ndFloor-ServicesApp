using System.Collections.Generic;

namespace SecondFloor.Infrastructure.Model
{
    public interface IValueObjectBase
    {
        IList<BusinessRule> GetBrokenRules();
        void AddBrokenRule(BusinessRule businessRule);
    }
}