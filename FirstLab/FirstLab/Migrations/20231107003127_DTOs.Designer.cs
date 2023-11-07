﻿// <auto-generated />
using System;
using FirstLab.src.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FirstLab.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231107003127_DTOs")]
    partial class DTOs
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("FirstLab.src.back_end.FlashcardDTO", b =>
                {
                    b.Property<long>("FlashcardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FlashcardAnswer")
                        .HasColumnType("TEXT");

                    b.Property<string>("FlashcardColor")
                        .HasColumnType("TEXT");

                    b.Property<string>("FlashcardName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FlashcardQuestion")
                        .HasColumnType("TEXT");

                    b.Property<string>("FlashcardSetDTOFlashcardSetName")
                        .HasColumnType("TEXT");

                    b.Property<string>("FlashcardTimer")
                        .HasColumnType("TEXT");

                    b.HasKey("FlashcardId");

                    b.HasIndex("FlashcardSetDTOFlashcardSetName");

                    b.ToTable("Flashcards");
                });

            modelBuilder.Entity("FirstLab.src.back_end.FlashcardSetDTO", b =>
                {
                    b.Property<string>("FlashcardSetName")
                        .HasColumnType("TEXT");

                    b.HasKey("FlashcardSetName");

                    b.ToTable("FlashcardSets");
                });

            modelBuilder.Entity("FirstLab.src.back_end.FlashcardSetLogDTO", b =>
                {
                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("Duration")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PlayedSetsName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Date");

                    b.ToTable("FlashcardsLog");
                });

            modelBuilder.Entity("FirstLab.src.back_end.FlashcardDTO", b =>
                {
                    b.HasOne("FirstLab.src.back_end.FlashcardSetDTO", null)
                        .WithMany("Flashcards")
                        .HasForeignKey("FlashcardSetDTOFlashcardSetName");
                });

            modelBuilder.Entity("FirstLab.src.back_end.FlashcardSetDTO", b =>
                {
                    b.Navigation("Flashcards");
                });
#pragma warning restore 612, 618
        }
    }
}
