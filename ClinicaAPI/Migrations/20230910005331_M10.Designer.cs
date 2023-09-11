﻿// <auto-generated />
using System;
using ClinicaAPI.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ClinicaAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230910005331_M10")]
    partial class M10
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ClinicaAPI.Models.AgendaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Dia")
                        .HasColumnType("date");

                    b.Property<DateTime>("DtAlt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Historico")
                        .HasColumnType("text");

                    b.Property<string>("Horario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("IdCliente")
                        .HasColumnType("integer");

                    b.Property<int>("IdFuncAlt")
                        .HasColumnType("integer");

                    b.Property<string>("Obs")
                        .HasColumnType("text");

                    b.Property<int>("Repeticao")
                        .HasColumnType("integer");

                    b.Property<int>("Sala")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Subtitulo")
                        .HasColumnType("text");

                    b.Property<int>("Unidade")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Agendas");
                });

            modelBuilder.Entity("ClinicaAPI.Models.ClienteModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AreaSession")
                        .HasColumnType("text");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<string>("Celular")
                        .HasColumnType("text");

                    b.Property<DateTime>("ClienteDesde")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DtInclusao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateOnly>("DtNascim")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Identidade")
                        .HasColumnType("text");

                    b.Property<string>("Mae")
                        .HasColumnType("text");

                    b.Property<bool>("MaeRestric")
                        .HasColumnType("boolean");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Pai")
                        .HasColumnType("text");

                    b.Property<bool>("PaiRestric")
                        .HasColumnType("boolean");

                    b.Property<int>("RespFinanc")
                        .HasColumnType("integer");

                    b.Property<bool>("SaiSozinho")
                        .HasColumnType("boolean");

                    b.Property<string>("TelComercial")
                        .HasColumnType("text");

                    b.Property<string>("TelFixo")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ClinicaAPI.Models.ColaboradorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AreaSession")
                        .HasColumnType("text");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Celular")
                        .HasColumnType("text");

                    b.Property<DateOnly>("DtAdmis")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DtDeslig")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DtNasc")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("IdPerfil")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RG")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SenhaHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TelFixo")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Colaboradors");
                });

            modelBuilder.Entity("ClinicaAPI.Models.DocumentoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CliOuProf")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.Property<DateTime>("DtInclusao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("IdPessoa")
                        .HasColumnType("integer");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Documentos");
                });

            modelBuilder.Entity("ClinicaAPI.Models.DonoSalaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly?>("DataFim")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DataInicio")
                        .HasColumnType("date");

                    b.Property<string>("DiaSemana")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("IdProfissional")
                        .HasColumnType("integer");

                    b.Property<string>("Periodo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Sala")
                        .HasColumnType("integer");

                    b.Property<int>("Unidade")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("DonoSalas");
                });

            modelBuilder.Entity("ClinicaAPI.Models.EscolaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AnoLetivo")
                        .HasColumnType("integer");

                    b.Property<string>("Escola")
                        .HasColumnType("text");

                    b.Property<int>("IdCliente")
                        .HasColumnType("integer");

                    b.Property<int>("Periodo")
                        .HasColumnType("integer");

                    b.Property<string>("Professor")
                        .HasColumnType("text");

                    b.Property<string>("Serie")
                        .HasColumnType("text");

                    b.Property<int?>("TelEscola")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Escolas");
                });

            modelBuilder.Entity("ClinicaAPI.Models.FormacaoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AreasRelacionadas")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly?>("DtConclusao")
                        .HasColumnType("date");

                    b.Property<int>("IdFuncionario")
                        .HasColumnType("integer");

                    b.Property<string>("Instituicao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nivel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NomeFormacao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Registro")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Formacaos");
                });

            modelBuilder.Entity("ClinicaAPI.Models.PerfilModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("AlteraAgenda")
                        .HasColumnType("boolean");

                    b.Property<bool>("AlteraCadOutros")
                        .HasColumnType("boolean");

                    b.Property<bool>("AlteraCadProprio")
                        .HasColumnType("boolean");

                    b.Property<bool>("AlteraPerfil")
                        .HasColumnType("boolean");

                    b.Property<bool>("CadastraCliente")
                        .HasColumnType("boolean");

                    b.Property<bool>("CadastraProfiss")
                        .HasColumnType("boolean");

                    b.Property<bool>("CtrFinanceiro")
                        .HasColumnType("boolean");

                    b.Property<bool>("ProntAdm")
                        .HasColumnType("boolean");

                    b.Property<bool>("ProntClin")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Perfils");
                });

            modelBuilder.Entity("ClinicaAPI.Models.ProntuarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Clinico")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("DtInsercao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("IdCliente")
                        .HasColumnType("integer");

                    b.Property<int>("IdColab")
                        .HasColumnType("integer");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Prontuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
