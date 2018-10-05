using System;
using ControleFreteApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ControleFreteApi.Data
{
    public partial class SisLogFreteContext : DbContext
    {
        public virtual DbSet<BaseFrete> BaseFrete { get; set; }
        public virtual DbSet<Cidade> Cidade { get; set; }
        public virtual DbSet<FreteCliente> FreteCliente { get; set; }
        public virtual DbSet<OrigemDestino> OrigemDestino { get; set; }
        public virtual DbSet<Uf> Uf { get; set; }

        public SisLogFreteContext(DbContextOptions<SisLogFreteContext> optionsBuilder)
            : base(optionsBuilder)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseFrete>(entity =>
            {
                entity.HasKey(e => e.IdBaseFrete);

                entity.ToTable("base_frete");

                entity.Property(e => e.IdBaseFrete)
                    .HasColumnName("id_base_frete")
                    .ValueGeneratedNever();

                entity.Property(e => e.DtCadastro)
                    .IsRequired()
                    .HasColumnName("dt_cadastro")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.IdOrigemDestino).HasColumnName("id_origem_destino");

                entity.Property(e => e.VlAtivo).HasColumnName("vl_ativo");

                entity.Property(e => e.VlBase)
                    .HasColumnName("vl_base")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.HasKey(e => e.IdCidade);

                entity.ToTable("cidade");

                entity.Property(e => e.IdCidade)
                    .HasColumnName("id_cidade")
                    .HasColumnType("char(7)")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdUf)
                    .IsRequired()
                    .HasColumnName("id_uf")
                    .HasColumnType("char(2)");

                entity.Property(e => e.NmCidade)
                    .IsRequired()
                    .HasColumnName("nm_cidade")
                    .HasColumnType("nvarchar(max)");

                entity.HasOne(d => d.IdUfNavigation)
                    .WithMany(p => p.Cidade)
                    .HasForeignKey(d => d.IdUf)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cidade_uf");
            });

            modelBuilder.Entity<FreteCliente>(entity =>
            {
                entity.HasKey(e => e.IdFreteCliente);

                entity.ToTable("frete_cliente");

                entity.Property(e => e.IdFreteCliente)
                    .HasColumnName("id_frete_cliente")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cnpj)
                    .HasColumnName("cnpj")
                    .HasColumnType("char(14)");

                entity.Property(e => e.DtNegociacao)
                    .HasColumnName("dt_negociacao")
                    .HasColumnType("date");

                entity.Property(e => e.EmailCliente)
                    .HasColumnName("email_cliente")
                    .IsUnicode(false);

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.NmCliente).HasColumnName("nm_Cliente");

                entity.Property(e => e.VlAtivo).HasColumnName("vl_ativo");

                entity.Property(e => e.VlDesconto)
                    .HasColumnName("vl_desconto")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<OrigemDestino>(entity =>
            {
                entity.HasKey(e => e.IdOrigemDestino);

                entity.ToTable("origem_destino");

                entity.Property(e => e.IdOrigemDestino)
                    .HasColumnName("id_origem_destino")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdCidadeDestino)
                    .IsRequired()
                    .HasColumnName("id_cidade_destino")
                    .HasColumnType("char(7)");

                entity.Property(e => e.IdCidadeOrigem)
                    .IsRequired()
                    .HasColumnName("id_cidade_origem")
                    .HasColumnType("char(7)");

                entity.HasOne(d => d.IdCidadeDestinoNavigation)
                    .WithMany(p => p.OrigemDestinoIdCidadeDestinoNavigation)
                    .HasForeignKey(d => d.IdCidadeDestino)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_origem_destino_cidade1");

                entity.HasOne(d => d.IdCidadeOrigemNavigation)
                    .WithMany(p => p.OrigemDestinoIdCidadeOrigemNavigation)
                    .HasForeignKey(d => d.IdCidadeOrigem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_origem_destino_cidade");
            });

            modelBuilder.Entity<Uf>(entity =>
            {
                entity.HasKey(e => e.IdUf);

                entity.ToTable("uf");

                entity.Property(e => e.IdUf)
                    .HasColumnName("id_uf")
                    .HasColumnType("char(2)")
                    .ValueGeneratedNever();

                entity.Property(e => e.NmUf)
                    .HasColumnName("nm_uf")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SgUf)
                    .HasColumnName("sg_uf")
                    .HasColumnType("char(2)");
            });
        }
    }
}
