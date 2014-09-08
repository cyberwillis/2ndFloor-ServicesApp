using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SecondFloor.Infrastructure.Model;

namespace SecondFloor.Infrastructure.UnitTest.Model
{
    [TestFixture]
    public class BusinesRuleTest
    {
        [Test]
        public void is_equal()
        {
            BusinessRule br1 = new BusinessRule("p1","Rule 01");
            BusinessRule br2 = new BusinessRule("p1", "Rule 01");

            var result = br1.Equals(br2);
            Assert.IsTrue(result);
        }

        [Test]
        public void is_equal_isntance()
        {
            BusinessRule br1 = new BusinessRule("p1", "Rule 01");
            BusinessRule br2 = br1;

            var result = br1.Equals(br2);
            Assert.IsTrue(result);
        }

        [Test]
        public void is_not_equal()
        {
            BusinessRule br1 = new BusinessRule("p1", "Rule 01");
            BusinessRule br2 = new BusinessRule("p2", "Rule 02");

            var result = br1.Equals(br2);
            Assert.IsFalse(result);
        }

        [Test]
        public void is_contains()
        {
            BusinessRule br1 = new BusinessRule("p1", "Rule 01");
            List<BusinessRule> brList = new List<BusinessRule>(){new BusinessRule("p1", "Rule 01")};

            var result = brList.Contains(br1);
            Assert.IsTrue(result);
        }
    }
}
