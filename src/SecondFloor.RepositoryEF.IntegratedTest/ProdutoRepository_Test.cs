using System;
using System.Data.Entity;
using NUnit.Framework;
using SecondFloor.Model;
using SecondFloor.RepositoryEF.Repositories;

namespace SecondFloor.RepositoryEF.IntegratedTest.AnuncioRepository_Test
{
    [TestFixture]
    public class ProdutoRepository_Test
    {
        private IProdutoRepository _produtoRepository;
        private IAnuncianteRepository _anuncianteRepository;
        private EFUnitOfWork<Produto> _unitOfWorkProduto;
        private EFUnitOfWork<Anunciante> _unitOfWorkAnunciante;
        private Produto _produto;
            
        [SetUp]
        public void Init()
        {
            Database.SetInitializer( new DropCreateDatabaseAlways<AnuncianteContext>());

            _unitOfWorkProduto = new EFUnitOfWork<Produto>();
            _produtoRepository = new ProdutoRepository(_unitOfWorkProduto);

            _unitOfWorkAnunciante = new EFUnitOfWork<Anunciante>();
            _anuncianteRepository = new AnuncianteRepository(_unitOfWorkAnunciante);
        }

        [TearDown]
        public void Finish()
        {
           //Dispose if needed
        }

        [Test]
        public void test_EncontrarProdutoPor_return_one_element_pass()
        {
            var id = Guid.NewGuid();

            //Produto
            _produto = new Produto();
            _produto.Id = id;
            _produto.NomeProduto = "Esponja de Aço";
            _produto.Descricao = "Esencial para lavar pratos e panelas";
            _produto.Referencia = "000001";
            _produto.Fabricante = "Bom Brill";
            _produto.Valor = decimal.Parse("3.40");
            
            _produtoRepository.InserirProduto(_produto);
            _produtoRepository.Persist();

            var produto = _produtoRepository.EncontrarProdutoPor(id);

            Assert.IsTrue(produto != null);

            _produtoRepository.ExcluirProduto(_produto);
            _produtoRepository.Persist();
        }

        [Test]
        public void test_ExcluirProduto_returns_zero_elements_pass()
        {
            var id = Guid.NewGuid();

            //Produto
            _produto = new Produto();
            _produto.Id = id;
            _produto.NomeProduto = "Esponja de Aço";
            _produto.Descricao = "Esencial para lavar pratos e panelas";
            _produto.Referencia = "000001";
            _produto.Fabricante = "Bom Brill";
            _produto.Valor = decimal.Parse("3.40");

            _produtoRepository.InserirProduto(_produto);
            _produtoRepository.Persist();

            var produto = _produtoRepository.EncontrarProdutoPor(id);

            Assert.IsTrue(produto != null);

            _produtoRepository.ExcluirProduto(_produto);
            _produtoRepository.Persist();

            produto = null;
            produto = _produtoRepository.EncontrarProdutoPor(id);

            Assert.IsNull(produto);
        }
    }
}