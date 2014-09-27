using System.Collections.Generic;
using System.Text;

namespace SecondFloor.Infrastructure.Model
{
    public interface IEntityBase<TId> : IAggregateRoot
    {
        TId Id { get; set; }
        //IDictionary<string,string> BrokenRules { get; }
        void AddBrokenRule(string key, string message);
        StringBuilder GetErrorMessages();
        void ClearBrokenRules();
    }
}