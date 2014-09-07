using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using SecondFloor.Model;

namespace SecondFloor.RepositoryEF.IntegratedTest
{
    [TestFixture]
    public class AnuncioTest
    {
        [Test]
        public void test1()
        {
            AnuncioContext anuncioContext = new AnuncioContext();
            var anuncios = anuncioContext.Anuncios.ToList();

            Debug.WriteLine(anuncios.Count);
        }
    }
}