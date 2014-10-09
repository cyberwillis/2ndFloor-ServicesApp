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
        private EFUnitOfWork<Endereco> _unitOfWorkEndereco;
        private EFUnitOfWork<Anunciante> _unitOfWorkAnunciante;
        private IEnderecoRepository _enderecoRepository;
        private IAnuncianteRepository _anuncianteRepository;

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
            
        }

        [Test]
        public void Teste()
        {
            IList<Anunciante> anunciantes = null;
            try
            {
                anunciantes = _anuncianteRepository.FindAll();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            

        }
    }
}