using System.Collections;

namespace SecondFloor.Infrastructure.Model
{
    public class BusinessRule:IEqualityComparer
    {
        private string _property;
        private string _rule;

        public BusinessRule(string property, string rule)
        {
            _property = property;
            _rule = rule;
        }

        public string Property
        {
            get { return _property; }
            set { _property = value; }
        }

        public string Rule
        {
            get { return _rule; }
            set { _rule = value; }
        }

        public override bool Equals(object obj)
        {
            BusinessRule businessRule = obj as BusinessRule;
            if (businessRule == null)
            {
                return false;
            }
            return this.Property.Equals(businessRule.Property) && this.Rule.Equals(businessRule.Rule);
        }

        public bool Equals(object x, object y)
        {
            if (x == null || y == null)
                return false;
            BusinessRule businessRuleX = x as BusinessRule;
            BusinessRule businessRuleY = y as BusinessRule;

            if (businessRuleX == null || businessRuleY == null)
                return false;

            return businessRuleX.Equals(businessRuleY);
        }

        public int GetHashCode(object obj)
        {
            return base.GetHashCode();
        }

    }
}