using System.Collections.Generic;
using System.Text;

namespace SecondFloor.Infrastructure.Model
{
    public interface IEntityBase<TId> : IAggregateRoot
    {
        TId Id { get; set; }
        //IList<BusinessRule> GetBrokenRules();
        void AddBrokenRule(BusinessRule businessRule);
        StringBuilder GetErrorMessages();
    }
}