using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SecondFloor.Infrastructure.UnitTest
{
    [TestFixture]
    public class DocumentosUtilTest
    {
        [TestCase("40.123.456.0001-20")]
        [TestCase("00.000.000.0000-00")]
        [TestCase("11.111.111.1111-11")]
        [TestCase("22.222.222.2222-22")]
        [TestCase("33.333.333.3333-33")]
        [TestCase("44.444.444.4444-44")]
        [TestCase("55.555.555.5555-55")]
        [TestCase("66.666.666.6666-66")]
        [TestCase("77.777.777.7777-77")]
        [TestCase("88.888.888.8888-88")]
        [TestCase("99.999.999.9999-99")]
        public void invalid_cnpj(String cnpj)
        {
            bool ret = DocumentosUtil.ValidaCnpj(cnpj);
            Assert.IsFalse(ret);
        }

        [TestCase("49.107.344/0001-93")]
        [TestCase("98.637.625/0001-63")]
        [TestCase("30.324.304/0001-75")]
        public void valid_cnpj(string cnpj)
        {
            bool ret = DocumentosUtil.ValidaCnpj(cnpj);
            Assert.IsTrue(ret);
        }


    }
}
