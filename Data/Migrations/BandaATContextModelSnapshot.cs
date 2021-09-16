﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(BandaATContext))]
    partial class BandaATContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Model.Models.BandaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("FazendoShow")
                        .HasColumnType("bit");

                    b.Property<string>("GeneroMusical")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InicioBanda")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nacionalidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bandas");
                });

            modelBuilder.Entity("Model.Models.MusicoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BandaId")
                        .HasColumnType("int");

                    b.Property<bool>("MuitosInstrumentos")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Nascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrincipalInstrumento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UltimoNome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BandaId");

                    b.ToTable("Musicos");
                });

            modelBuilder.Entity("Model.Models.MusicoModel", b =>
                {
                    b.HasOne("Model.Models.BandaModel", "Banda")
                        .WithMany("Musicos")
                        .HasForeignKey("BandaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Banda");
                });

            modelBuilder.Entity("Model.Models.BandaModel", b =>
                {
                    b.Navigation("Musicos");
                });
#pragma warning restore 612, 618
        }
    }
}