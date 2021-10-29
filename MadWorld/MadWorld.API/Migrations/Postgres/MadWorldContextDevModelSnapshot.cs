﻿// <auto-generated />
using System;
using MadWorld.DataLayer.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MadWorld.API.Migrations.Postgres
{
    [DbContext(typeof(MadWorldContextDev))]
    partial class MadWorldContextDevModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0-rc.2.21480.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MadWorld.DataLayer.Database.Tables.Account", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AzureID")
                        .HasColumnType("uuid");

                    b.Property<string>("EmailAdress")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("IsAdminstrator")
                        .HasColumnType("boolean");

                    b.HasKey("ID");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("MadWorld.DataLayer.Database.Tables.BlobFile", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BlobName")
                        .HasColumnType("uuid");

                    b.Property<string>("ContentType")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("ExternName")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<int>("FileType")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("MadWorld.DataLayer.Database.Tables.Resume", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FullName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Nationality")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("ID");

                    b.ToTable("Resumes");
                });

            modelBuilder.Entity("MadWorld.DataLayer.Database.Tables.SecurityReport", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ClientIpAddress")
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.Property<string>("Description")
                        .HasMaxLength(10000)
                        .HasColumnType("character varying(10000)");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("FullName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("PublicKeyID")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("ID");

                    b.HasIndex("PublicKeyID")
                        .IsUnique();

                    b.ToTable("SecurityReports");
                });

            modelBuilder.Entity("MadWorld.DataLayer.Database.Tables.SecurityReportAttachment", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BlobFileID")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SecurityReportID")
                        .HasColumnType("uuid");

                    b.HasKey("ID");

                    b.HasIndex("BlobFileID");

                    b.HasIndex("SecurityReportID");

                    b.ToTable("SecurityReportAttachments");
                });

            modelBuilder.Entity("MadWorld.DataLayer.Database.Tables.SecurityReport", b =>
                {
                    b.HasOne("MadWorld.DataLayer.Database.Tables.BlobFile", "PublicKeyFile")
                        .WithOne("SecurityReport")
                        .HasForeignKey("MadWorld.DataLayer.Database.Tables.SecurityReport", "PublicKeyID");

                    b.Navigation("PublicKeyFile");
                });

            modelBuilder.Entity("MadWorld.DataLayer.Database.Tables.SecurityReportAttachment", b =>
                {
                    b.HasOne("MadWorld.DataLayer.Database.Tables.BlobFile", "BlobFile")
                        .WithMany("SecurityReportAttachments")
                        .HasForeignKey("BlobFileID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MadWorld.DataLayer.Database.Tables.SecurityReport", "SecurityReport")
                        .WithMany("Attachments")
                        .HasForeignKey("SecurityReportID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BlobFile");

                    b.Navigation("SecurityReport");
                });

            modelBuilder.Entity("MadWorld.DataLayer.Database.Tables.BlobFile", b =>
                {
                    b.Navigation("SecurityReport");

                    b.Navigation("SecurityReportAttachments");
                });

            modelBuilder.Entity("MadWorld.DataLayer.Database.Tables.SecurityReport", b =>
                {
                    b.Navigation("Attachments");
                });
#pragma warning restore 612, 618
        }
    }
}
