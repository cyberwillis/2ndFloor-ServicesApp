using System.Collections.Generic;
using System.Text;

namespace SecondFloor.Infrastructure.Model
{
    public class EntityBase<TId> : IEntityBase<TId>
    {
        public TId Id { get; set; }

        private IList<BusinessRule> _brokenRules= new List<BusinessRule>();

        public IList<BusinessRule> BrokenRules
        {
            get { return _brokenRules; }
        }

        //protected abstract void Validate();

        /*public virtual IList<BusinessRule> GetBrokenRules()
        {
            return brokenRules;
        }*/

        public void AddBrokenRule(BusinessRule businessRule)
        {
            this._brokenRules.Add(businessRule);
        }

        public void AddRangeBrokenRules(IList<BusinessRule> businessRules)
        {
            foreach (var businessRule in businessRules)
            {
                this._brokenRules.Add(businessRule);
            }
        }

        public StringBuilder GetErrorMessages()
        {
            var sb = new StringBuilder();
            sb.Append("Erros encontrados:");
            foreach (var error in this._brokenRules)
            {
                sb.AppendLine(error.Rule + "<br/>");
            }
            return sb;
        }
    }
}