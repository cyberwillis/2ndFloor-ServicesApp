using System.Collections.Generic;
using System.Text;

namespace _2ndFloor.Infrastructure
{
    public class EntityBase<TId> : IEntityBase<TId>
    {
        public TId Id { get; set; }

        protected IList<BusinessRule> brokenRules = new List<BusinessRule>();

        //protected abstract void Validate();

        public virtual IList<BusinessRule> GetBrokenRules()
        {
            return brokenRules;
        }

        public virtual void AddBrokenRule(BusinessRule businessRule)
        {
            brokenRules.Add(businessRule);
        }

        public virtual StringBuilder GetErrorMessages()
        {
            var sb = new StringBuilder();
            sb.Append("Erros encontrados:");
            foreach (var error in brokenRules)
            {
                sb.AppendLine(error.Rule + "<br/>");
            }
            return sb;
        }
    }
}