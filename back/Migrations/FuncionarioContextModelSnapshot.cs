﻿// <auto-generated />
using FuncionarioApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FuncionarioApi.Migrations
{
    [DbContext(typeof(FuncionarioContext))]
    partial class FuncionarioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FuncionarioApi.Entities.Funcionario", b =>
                {
                    b.Property<int>("IdFuncionario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFuncionario"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeFuncionario")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Ramal")
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("Re")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.HasKey("IdFuncionario");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("FuncionarioApi.Entities.FuncionarioImagem", b =>
                {
                    b.Property<int>("IdFuncionarioImagem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFuncionarioImagem"));

                    b.Property<int>("IdFuncionario")
                        .HasColumnType("int");

                    b.Property<string>("ImagemBase")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdFuncionarioImagem");

                    b.HasIndex("IdFuncionario")
                        .IsUnique();

                    b.ToTable("FuncionarioImagens");
                });

            modelBuilder.Entity("FuncionarioApi.Entities.FuncionarioImagem", b =>
                {
                    b.HasOne("FuncionarioApi.Entities.Funcionario", "Funcionario")
                        .WithOne("FuncionarioImagem")
                        .HasForeignKey("FuncionarioApi.Entities.FuncionarioImagem", "IdFuncionario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("FuncionarioApi.Entities.Funcionario", b =>
                {
                    b.Navigation("FuncionarioImagem");
                });
#pragma warning restore 612, 618
        }
    }
}