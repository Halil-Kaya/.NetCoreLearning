﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using emre.Model;

namespace emre.Migrations
{
    [DbContext(typeof(KutuphaneContext))]
    partial class KutuphaneContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("emre.Model.Kutuphane", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("bekleyen")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("guncelleme_tarihi")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("kapasite")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("kutuphane")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("mevcut_oran")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.ToTable("Kutuphanes");
                });
#pragma warning restore 612, 618
        }
    }
}
