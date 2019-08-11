using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLLDadosSyscom.Models;
using Cadastros.Migrations;

namespace Cadastros.DataBase
{
    public class Cadastro_DBContext : DbContext
    {
        public DbSet<Benefios> Beneficios { get; set; }
        public DbSet<Cad_CRT> Cad_CRT { get; set; }
        public DbSet<Cad_CSOSN> Cad_CSOSN { get; set; }
        public DbSet<Cad_CST_IPI> Cad_CST_IPI { get; set; }
        public DbSet<Cad_CST_PIS_Cofins> Cad_CST_PIS_Cofins { get; set; }
        public DbSet<Cad_Natureza_Juridica> Cad_Natureza_Juridica { get; set; }
        public DbSet<Cad_Trib_EspecNFSe> Cad_Trib_EspecNFSe { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Cnae> Cnae { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Endereco_Empresa> Endereco_Empresa { get; set; }
        public DbSet<Endereco_Entidade> Endereco_Entidade { get; set; }
        public DbSet<Entidade> Entidade { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<Grupo_Permissao> Grupo_Permissao { get; set; }
        public DbSet<Tabela_Sistema> Tabela_Sistema { get; set; }
        public DbSet<Tel_Empresa> Tel_Empresa { get; set; }
        public DbSet<Tel_Entidade> Tel_Entidade { get; set; }
        public DbSet<Tipo_Contratacao> Tipo_Contratacao { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public Cadastro_DBContext(string conexao) : base(conexao)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Cadastro_DBContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cnae>()
                .HasMany(c => c.empresas)
                .WithMany(c => c.Cnaes)
                .Map(m =>
                {
                    m.ToTable("Cnae_Empresa","Cadastros");
                    m.MapLeftKey("EmpresaID");
                    m.MapRightKey("CnaeID");
                });

            modelBuilder.Entity<Benefios>()
                .HasMany(b => b.funcionarios)
                .WithMany(b => b.beneficios)
                .Map(m => 
                {
                    m.ToTable("BeneficiosFuncionarios","Cadastros");
                    m.MapLeftKey("FuncionarioID");
                    m.MapRightKey("BeneficioID");
                });

            modelBuilder.Entity<Tel_Empresa>()
               .HasRequired(t => t.empresa)
               .WithMany(t => t.telefonesEmpresa)
               .Map(m => 
               {
                   m.MapKey("EmpresaId");
               });

            modelBuilder.Entity<Endereco_Empresa>()
                .HasRequired(e => e.empresa)
                .WithMany(e => e.enderecosEmpresa)
                .Map(m => m.MapKey("EmpresaId"));

            modelBuilder.Entity<Tel_Entidade>()
                .HasRequired(t => t.entidade)
                .WithMany(t => t.telefonesEntidade)
                .Map(m => m.MapKey("EntidadeId"));

            modelBuilder.Entity<Endereco_Entidade>()
                .HasRequired(e => e.entidade)
                .WithMany(e => e.EnderecosEntidade)
                .Map(m => m.MapKey("EntidadeId"));

            modelBuilder.Entity<Fornecedor>()
                .HasRequired(f => f.entidade)
                .WithOptional(f => f.fornecedor)
                .Map(m => m.MapKey("EntidadeId"));

            modelBuilder.Entity<Cliente>()
                .HasRequired(c => c.entidade)
                .WithOptional(c => c.cliente)
                .Map(m => m.MapKey("EntidadeId"));

            modelBuilder.Entity<Funcionario>()
                .HasRequired(fun => fun.entidade)
                .WithOptional(fun => fun.funcionario)
                .Map(m => m.MapKey("EntidadeId"));

            modelBuilder.Entity<Funcionario>()
                .HasRequired(fun => fun.departamento)
                .WithMany(fun => fun.funcionarios)
                .Map(m => m.MapKey("DepartamentoId"));

            modelBuilder.Entity<Funcionario>()
                .HasRequired(fun => fun.tipo_Contratacao)
                .WithMany(fun => fun.funcionarios)               
                .Map(m => m.MapKey("TipoContratacaoId"));

            modelBuilder.Entity<Funcionario>()
                .HasOptional(fun => fun.usuario)
                .WithOptionalDependent()
                .Map(m => m.MapKey("UsuarioId"));

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.grupos)
                .WithMany(u => u.usuarios)
                .Map(m => 
                {
                    m.ToTable("GrupoUsuarios", "Cadastros");
                    m.MapLeftKey("UsuarioId");
                    m.MapRightKey("GrupoId");
                });

            modelBuilder.Entity<Grupo_Permissao>()
                .HasRequired(g => g.grupo)
                .WithOptional(g => g.grupo_Permissao)
                .Map(m => m.MapKey("GrupoId"));

            modelBuilder.Entity<Grupo_Permissao>()
                .HasRequired(g => g.tabela)
                .WithMany(g => g.grupos_Permissao)
                .Map(m => m.MapKey("TabelaId"));

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.empresas)
                .WithMany(u => u.usuarios)
                .Map(m => 
                {
                    m.ToTable("UsuariosEmpresas", "Cadastros");
                    m.MapLeftKey("UsuarioId");
                    m.MapRightKey("EmpresaId");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
