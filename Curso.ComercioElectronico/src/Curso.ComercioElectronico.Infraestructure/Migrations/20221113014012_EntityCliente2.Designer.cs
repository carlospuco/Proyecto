﻿// <auto-generated />
using System;
using Curso.ComercioElectronico.Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Curso.ComercioElectronico.Infraestructure.Migrations
{
    [DbContext(typeof(ComercioElectronicoDbContext))]
    [Migration("20221113014012_EntityCliente2")]
    partial class EntityCliente2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("Curso.ComercioElectronico.Domain.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Curso.ComercioElectronico.Domain.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("Curso.ComercioElectronico.Domain.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Caducidad")
                        .HasColumnType("TEXT");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MarcaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.Property<string>("Observaciones")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Precio")
                        .HasColumnType("TEXT");

                    b.Property<int>("TipoProductoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MarcaId");

                    b.HasIndex("TipoProductoId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Curso.ComercioElectronico.Domain.TipoProducto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TiposProducto");
                });

            modelBuilder.Entity("Curso.ComercioElectronico.Domain.Producto", b =>
                {
                    b.HasOne("Curso.ComercioElectronico.Domain.Marca", "Marca")
                        .WithMany()
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Curso.ComercioElectronico.Domain.TipoProducto", "TipoProducto")
                        .WithMany()
                        .HasForeignKey("TipoProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marca");

                    b.Navigation("TipoProducto");
                });
#pragma warning restore 612, 618
        }
    }
}
