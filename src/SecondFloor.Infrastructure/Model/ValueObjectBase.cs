using System.Collections.Generic;

namespace SecondFloor.Infrastructure.Model
{
    public class ValueObjectBase : IValueObjectBase
    {
        protected IDictionary<string,string> _brokenRules = new Dictionary<string, string>();

        public IDictionary<string,string> BrokenRules
        {
            get { return _brokenRules; }
        }

        public void AddBrokenRule(string key, string message)
        {
            if (this._brokenRules.ContainsKey(key))
                _brokenRules[key] = message;
            else
                _brokenRules.Add(key, message);
        }
    }
}