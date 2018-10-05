﻿// <auto-generated />
using ControleFreteApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ControleFreteApi.Migrations
{
    [DbContext(typeof(SisLogFreteContext))]
    [Migration("20180918131132_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ControleFreteApi.Data.Models.BaseFrete", b =>
                {
                    b.Property<Guid>("IdBaseFrete")
                        .HasColumnName("id_base_frete");

                    b.Property<string>("DtCadastro")
                        .IsRequired()
                        .HasColumnName("dt_cadastro")
                        .HasColumnType("nchar(10)");

                    b.Property<Guid>("IdOrigemDestino")
                        .HasColumnName("id_origem_destino");

                    b.Property<bool>("VlAtivo")
                        .HasColumnName("vl_ativo");

                    b.Property<decimal>("VlBase")
                        .HasColumnName("vl_base")
                        .HasColumnType("numeric(18, 0)");

                    b.HasKey("IdBaseFrete");

                    b.ToTable("base_frete");
                });

            modelBuilder.Entity("ControleFreteApi.Data.Models.Cidade", b =>
                {
                    b.Property<string>("IdCidade")
                        .HasColumnName("id_cidade")
                        .HasColumnType("char(7)");

                    b.Property<string>("IdUf")
                        .IsRequired()
                        .HasColumnName("id_uf")
                        .HasColumnType("char(2)");

                    b.Property<string>("NmCidade")
                        .IsRequired()
                        .HasColumnName("nm_cidade")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCidade");

                    b.HasIndex("IdUf");

                    b.ToTable("cidade");
                });

            modelBuilder.Entity("ControleFreteApi.Data.Models.FreteCliente", b =>
                {
                    b.Property<Guid>("IdFreteCliente")
                        .HasColumnName("id_frete_cliente");

                    b.Property<string>("Cnpj")
                        .HasColumnName("cnpj")
                        .HasColumnType("char(14)");

                    b.Property<DateTime?>("DtNegociacao")
                        .HasColumnName("dt_negociacao")
                        .HasColumnType("date");

                    b.Property<string>("EmailCliente")
                        .HasColumnName("email_cliente")
                        .IsUnicode(false);

                    b.Property<Guid?>("IdCliente")
                        .HasColumnName("id_cliente");

                    b.Property<string>("NmCliente")
                        .HasColumnName("nm_Cliente");

                    b.Property<bool?>("VlAtivo")
                        .HasColumnName("vl_ativo");

                    b.Property<decimal?>("VlDesconto")
                        .HasColumnName("vl_desconto")
                        .HasColumnType("numeric(18, 0)");

                    b.HasKey("IdFreteCliente");

                    b.ToTable("frete_cliente");
                });

            modelBuilder.Entity("ControleFreteApi.Data.Models.OrigemDestino", b =>
                {
                    b.Property<Guid>("IdOrigemDestino")
                        .HasColumnName("id_origem_destino");

                    b.Property<string>("IdCidadeDestino")
                        .IsRequired()
                        .HasColumnName("id_cidade_destino")
                        .HasColumnType("char(7)");

                    b.Property<string>("IdCidadeOrigem")
                        .IsRequired()
                        .HasColumnName("id_cidade_origem")
                        .HasColumnType("char(7)");

                    b.HasKey("IdOrigemDestino");

                    b.HasIndex("IdCidadeDestino");

                    b.HasIndex("IdCidadeOrigem");

                    b.ToTable("origem_destino");
                });

            modelBuilder.Entity("ControleFreteApi.Data.Models.Uf", b =>
                {
                    b.Property<string>("IdUf")
                        .HasColumnName("id_uf")
                        .HasColumnType("char(2)");

                    b.Property<string>("NmUf")
                        .HasColumnName("nm_uf")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("SgUf")
                        .HasColumnName("sg_uf")
                        .HasColumnType("char(2)");

                    b.HasKey("IdUf");

                    b.ToTable("uf");
                });

            modelBuilder.Entity("ControleFreteApi.Data.Models.Cidade", b =>
                {
                    b.HasOne("ControleFreteApi.Data.Models.Uf", "IdUfNavigation")
                        .WithMany("Cidade")
                        .HasForeignKey("IdUf")
                        .HasConstraintName("FK_cidade_uf");
                });

            modelBuilder.Entity("ControleFreteApi.Data.Models.OrigemDestino", b =>
                {
                    b.HasOne("ControleFreteApi.Data.Models.Cidade", "IdCidadeDestinoNavigation")
                        .WithMany("OrigemDestinoIdCidadeDestinoNavigation")
                        .HasForeignKey("IdCidadeDestino")
                        .HasConstraintName("FK_origem_destino_cidade1");

                    b.HasOne("ControleFreteApi.Data.Models.Cidade", "IdCidadeOrigemNavigation")
                        .WithMany("OrigemDestinoIdCidadeOrigemNavigation")
                        .HasForeignKey("IdCidadeOrigem")
                        .HasConstraintName("FK_origem_destino_cidade");
                });
#pragma warning restore 612, 618
        }
    }
}
