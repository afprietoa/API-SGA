﻿// <auto-generated />
using System;
using API_SGA.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API_SGA.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240620023133_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("API_SGA.Models.Emergency", b =>
                {
                    b.Property<int>("ResourceId")
                        .HasColumnType("integer");

                    b.Property<int>("PollutantId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int>("Magnitude")
                        .HasColumnType("integer");

                    b.HasKey("ResourceId", "PollutantId");

                    b.HasIndex("PollutantId");

                    b.ToTable("Emergencies");
                });

            modelBuilder.Entity("API_SGA.Models.Measure", b =>
                {
                    b.Property<int>("ResourceId")
                        .HasColumnType("integer");

                    b.Property<int>("PollutantId")
                        .HasColumnType("integer");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<float>("Ph")
                        .HasColumnType("real");

                    b.Property<float>("Temperature")
                        .HasColumnType("real");

                    b.Property<DateTime>("date")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ResourceId", "PollutantId");

                    b.HasIndex("PollutantId");

                    b.ToTable("Measures");
                });

            modelBuilder.Entity("API_SGA.Models.Pollutant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<float>("Load")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Pollutants");
                });

            modelBuilder.Entity("API_SGA.Models.Resource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<float>("Latitude")
                        .HasColumnType("real");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Longitude")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("API_SGA.Models.Signal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("EmergencyId")
                        .HasColumnType("integer");

                    b.Property<int>("EmergencyPollutantId")
                        .HasColumnType("integer");

                    b.Property<int>("EmergencyResourceId")
                        .HasColumnType("integer");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EmergencyResourceId", "EmergencyPollutantId");

                    b.ToTable("Signals");
                });

            modelBuilder.Entity("API_SGA.Models.Emergency", b =>
                {
                    b.HasOne("API_SGA.Models.Pollutant", null)
                        .WithMany("Emergencies")
                        .HasForeignKey("PollutantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_SGA.Models.Resource", null)
                        .WithMany("Emergencies")
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API_SGA.Models.Measure", b =>
                {
                    b.HasOne("API_SGA.Models.Pollutant", null)
                        .WithMany("Measures")
                        .HasForeignKey("PollutantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_SGA.Models.Resource", null)
                        .WithMany("Measures")
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API_SGA.Models.Signal", b =>
                {
                    b.HasOne("API_SGA.Models.Emergency", "Emergency")
                        .WithMany()
                        .HasForeignKey("EmergencyResourceId", "EmergencyPollutantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Emergency");
                });

            modelBuilder.Entity("API_SGA.Models.Pollutant", b =>
                {
                    b.Navigation("Emergencies");

                    b.Navigation("Measures");
                });

            modelBuilder.Entity("API_SGA.Models.Resource", b =>
                {
                    b.Navigation("Emergencies");

                    b.Navigation("Measures");
                });
#pragma warning restore 612, 618
        }
    }
}
