﻿// <auto-generated />
using System;
using FoodexpMvc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoodexpMvc.Migrations
{
    [DbContext(typeof(Database))]
    partial class DatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("FoodexpMvc.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ListaSpesaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ListaSpesaId");

                    b.ToTable("Categorie");
                });

            modelBuilder.Entity("FoodexpMvc.Models.ListaSpesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Alimento")
                        .HasColumnType("TEXT");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantita")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UtenteId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ListaSpesa");
                });

            modelBuilder.Entity("FoodexpMvc.Models.Utente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ListaSpesaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ListaSpesaId");

                    b.ToTable("Utenti");
                });

            modelBuilder.Entity("FoodexpMvc.Models.Categoria", b =>
                {
                    b.HasOne("FoodexpMvc.Models.ListaSpesa", null)
                        .WithMany("Categorie")
                        .HasForeignKey("ListaSpesaId");
                });

            modelBuilder.Entity("FoodexpMvc.Models.Utente", b =>
                {
                    b.HasOne("FoodexpMvc.Models.ListaSpesa", null)
                        .WithMany("Utenti")
                        .HasForeignKey("ListaSpesaId");
                });

            modelBuilder.Entity("FoodexpMvc.Models.ListaSpesa", b =>
                {
                    b.Navigation("Categorie");

                    b.Navigation("Utenti");
                });
#pragma warning restore 612, 618
        }
    }
}
