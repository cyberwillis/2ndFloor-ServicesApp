using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using NUnit.Framework;
using SecondFloor.Infrastructure.Repository;
using SecondFloor.Model;
using SecondFloor.RepositoryEF.Repositories;

namespace SecondFloor.RepositoryEF.IntegratedTest.AnuncioRepository_Test
{
    [TestFixture]
    public class EnderecoRepository_Test
    {
        private IEnderecoRepository _enderecoRepository;
        private IAnuncianteRepository _anuncianteRepository;
        private EFUnitOfWork<Endereco> _unitOfWorkEndereco;
        private EFUnitOfWork<Anunciante> _unitOfWorkAnunciante;
        private Endereco _endereco;

        [SetUp]
        public void Init()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<AnuncianteContext>());

            _unitOfWorkEndereco = new EFUnitOfWork<Endereco>();
            _enderecoRepository = new EnderecoRepository(_unitOfWorkEndereco); //contexto compartilhado

            _unitOfWorkAnunciante = new EFUnitOfWork<Anunciante>();
            _anuncianteRepository = new AnuncianteRepository(_unitOfWorkAnunciante); //contexto compartilhado
        }

        [TearDown]
        public void Finish()
        {
            //Dispose if needed
        }

        [Test]
        public void test_EncontrarEnderecoPor_returns_one_element_pass()
        {
            var id = Guid.NewGuid();

            //Endereco
            _endereco = new Endereco();
            _endereco.Id = id;
            _endereco.Logradouro = "Rua Teste";
            _endereco.Numero = "1250";
            _endereco.Complemento = "Bloco A";
            _endereco.Bairro = "Europa";
            _endereco.Cidade = "São Paulo";
            _endereco.Estado = "SP";
            _endereco.Cep = "00000-000";

            _enderecoRepository.InserirEndereco(_endereco);
            _enderecoRepository.Persist();

            var endereco = _enderecoRepository.EncontrarEnderecoPor(id);

            Assert.IsTrue(endereco != null);

            _enderecoRepository.ExcluirEndereco(_endereco);
            _enderecoRepository.Persist();
        }

        [Test]
        public void test_EncontrarEnderecoPor_returns_zero_elements_pass()
        {
            var id = Guid.NewGuid();

            //Endereco
            _endereco = new Endereco();
            _endereco.Id = id;
            _endereco.Logradouro = "Rua Teste";
            _endereco.Numero = "1250";
            _endereco.Complemento = "Bloco A";
            _endereco.Bairro = "Europa";
            _endereco.Cidade = "São Paulo";
            _endereco.Estado = "SP";
            _endereco.Cep = "00000-000";

            _enderecoRepository.InserirEndereco(_endereco);
            _enderecoRepository.Persist();

            var endereco = _enderecoRepository.EncontrarEnderecoPor(id);

            Assert.IsTrue(endereco != null);

            _enderecoRepository.ExcluirEndereco(_endereco);
            _enderecoRepository.Persist();

            endereco = null;
            endereco = _enderecoRepository.EncontrarEnderecoPor(id);

            Assert.IsNull(endereco);
        }
    }
}