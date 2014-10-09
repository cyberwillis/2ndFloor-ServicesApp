using System;
using System.Collections.Generic;
using SecondFloor.Infrastructure.Repository;

namespace SecondFloor.Model
{
    public interface IEnderecoRepository : IRepository<Endereco, Guid>
    {
        Endereco EncontrarEnderecoPor(Guid id);
        void InserirEndereco(Endereco endereco);
        void AtualizarEndereco(Endereco endereco);
        void ExcluirEndereco(Endereco endereco);
        IList<Endereco> EncontrarTodosEnderecosPorAnunciante(Guid id);
    }
}