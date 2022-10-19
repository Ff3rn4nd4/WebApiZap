﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiZap;

#nullable disable

namespace WebApiZap.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221018130521_Pedidos")]
    partial class Pedidos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApiZap.Entidades.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.Property<int>("ZapatoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ZapatoId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("WebApiZap.Entidades.Zapato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Talla")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Zapatos");
                });

            modelBuilder.Entity("WebApiZap.Entidades.Pedido", b =>
                {
                    b.HasOne("WebApiZap.Entidades.Zapato", "Zapato")
                        .WithMany("pedidos")
                        .HasForeignKey("ZapatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Zapato");
                });

            modelBuilder.Entity("WebApiZap.Entidades.Zapato", b =>
                {
                    b.Navigation("pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}