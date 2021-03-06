﻿using System.Data.Entity.ModelConfiguration;
using SecondFloor.Model;

namespace SecondFloor.RepositoryEF.Mappings
{
    public class EstadoConfiguration : EntityTypeConfiguration<Estado>
    {
        public EstadoConfiguration()
        {
            ToTable("tbEstado");
            HasKey(e => e.Id);
            Property(e => e.Id).HasColumnName("Id");
            Property(e => e.Nome).HasColumnName("Nome").HasMaxLength(20);
            Property(e => e.Sigla).HasColumnName("Sigla").HasMaxLength(5);
        }
    }
}