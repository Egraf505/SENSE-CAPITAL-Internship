﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TicTacToe.Persistence.Contex;

#nullable disable

namespace TicTacToe.Persistence.Migrations
{
    [DbContext(typeof(GameContex))]
    [Migration("20230310193052_UpdateTypes")]
    partial class UpdateTypes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TicTacToe.Domain.GameTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("finished")
                        .HasColumnType("boolean");

                    b.Property<bool?>("p0")
                        .HasColumnType("boolean");

                    b.Property<bool?>("p1")
                        .HasColumnType("boolean");

                    b.Property<bool?>("p2")
                        .HasColumnType("boolean");

                    b.Property<bool?>("p3")
                        .HasColumnType("boolean");

                    b.Property<bool?>("p4")
                        .HasColumnType("boolean");

                    b.Property<bool?>("p5")
                        .HasColumnType("boolean");

                    b.Property<bool?>("p6")
                        .HasColumnType("boolean");

                    b.Property<bool?>("p7")
                        .HasColumnType("boolean");

                    b.Property<bool?>("p8")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("GameTables");
                });
#pragma warning restore 612, 618
        }
    }
}
