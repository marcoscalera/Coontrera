﻿// <auto-generated />
using System;
using Coontrera.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Coontrera.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250508115535_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Coontrera.Models.Aulas", b =>
                {
                    b.Property<int>("id_aula")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_aula"));

                    b.Property<DateTime>("data_aula")
                        .HasColumnType("datetime2");

                    b.Property<int>("id_usuario")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_aula");

                    b.ToTable("Aulas");
                });

            modelBuilder.Entity("Coontrera.Models.Contatos", b =>
                {
                    b.Property<int>("id_contato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_contato"));

                    b.Property<DateTime>("data_contato")
                        .HasColumnType("datetime2");

                    b.Property<int>("id_usuario")
                        .HasColumnType("int");

                    b.Property<string>("mensagem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_contato");

                    b.ToTable("Contatos");
                });

            modelBuilder.Entity("Coontrera.Models.Feedbacks", b =>
                {
                    b.Property<int>("id_feedback")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_feedback"));

                    b.Property<bool>("aprovado")
                        .HasColumnType("bit");

                    b.Property<string>("comentario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("data_envio")
                        .HasColumnType("datetime2");

                    b.Property<int>("id_usuario")
                        .HasColumnType("int");

                    b.Property<int>("verificado_por")
                        .HasColumnType("int");

                    b.HasKey("id_feedback");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("Coontrera.Models.Usuario", b =>
                {
                    b.Property<int>("id_usuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_usuario"));

                    b.Property<DateTime>("data_cadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("nivel_usuario")
                        .HasColumnType("bit");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("primeira_aula_realizada")
                        .HasColumnType("bit");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_usuario");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
