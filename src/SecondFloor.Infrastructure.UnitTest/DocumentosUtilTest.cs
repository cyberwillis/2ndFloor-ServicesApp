using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SecondFloor.Infrastructure.UnitTest
{
    [TestFixture]
    public class DocumentosUtilTest
    {
        [TestCase("40.123.456.0001-20")]
        [TestCase("00.000.000.0000-00")] //is valid but cannot exists in domain
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

        [TestCase("487.026.647-48")]
        [TestCase("000.000.000-00")] //is valid but cannot exists in domain
        [TestCase("111.111.111-11")] //is valid but cannot exists in domain
        [TestCase("222.222.222-22")] //is valid but cannot exists in domain
        [TestCase("333.333.333-33")] //is valid but cannot exists in domain
        [TestCase("444.444.444-44")] //is valid but cannot exists in domain
        [TestCase("555.555.555-55")] //is valid but cannot exists in domain
        [TestCase("666.666.666-66")] //is valid but cannot exists in domain
        [TestCase("777.777.777-77")] //is valid but cannot exists in domain
        [TestCase("888.888.888-88")] //is valid but cannot exists in domain
        [TestCase("999.999.999-99")] //is valid but cannot exists in domain
        public void invalid_cpf(string cpf)
        {
            bool ret = DocumentosUtil.ValidaCpf(cpf);
            Assert.IsFalse(ret);
        }

        [TestCase("487.026.647-47")]
        public void valid_cpf(string cpf)
        {
            bool ret = DocumentosUtil.ValidaCpf(cpf);
            Assert.IsTrue(ret);
        }

        [TestCase("joe")] // should fail
        [TestCase("joe@home")] // should fail
        [TestCase("a@b.c")] // should fail because .c is only one character but must be 2-4 characters
        [TestCase("joe-bob[at]home.com")] // should fail because [at] is not valid
        [TestCase("joe@his.home.place")] // should fail because place is 5 characters but must be 2-4 characters
        [TestCase("joe.@bob.com")] // should fail because there is a dot at the end of the local-part
        [TestCase(".joe@bob.com")] // should fail because there is a dot at the beginning of the local-part
        [TestCase("john..doe@bob.com")] // should fail because there are two dots in the local-part
        [TestCase("john.doe@bob..com")] // should fail because there are two dots in the domain
        [TestCase("joe<>bob@bob.come")] // should fail because <> are not valid
        [TestCase("joe@his.home.com.")] // should fail because it can't end with a period
        [TestCase("a@10.1.100.1a")] // Should fail because of the extra character
        public void invalid_email(string email)
        {
            bool ret = DocumentosUtil.ValidaEmail(email);
            Assert.IsFalse(ret);
        }

        [TestCase("joe@home.org")]
        [TestCase("joe@joebob.name")]
        [TestCase("joe&bob@bob.com")]
        [TestCase("~joe@bob.com")]
        [TestCase("joe$@bob.com")]
        [TestCase("joe+bob@bob.com")]
        [TestCase("o'reilly@there.com")]
        [TestCase("joe@home.com")]
        [TestCase("joe.bob@home.com")]
        [TestCase("joe@his.home.com")]
        [TestCase("a@abc.org")]
        [TestCase("a@192.168.0.1")]
        [TestCase("a@10.1.100.1")]
        public void valid_email(string email)
        {
            bool ret = DocumentosUtil.ValidaEmail(email);
            Assert.IsTrue(ret);
        }

        

    }
}
