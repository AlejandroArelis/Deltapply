﻿// <auto-generated />
using Deltapply.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Deltapply.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Deltapply.Models.Nihongo.Kanjis.Examples.Example", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("KanjiId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KanjiId");

                    b.ToTable("Examples");
                });

            modelBuilder.Entity("Deltapply.Models.Nihongo.Kanjis.Examples.ExampleChar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ExampleId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExampleId");

                    b.ToTable("Chars");
                });

            modelBuilder.Entity("Deltapply.Models.Nihongo.Kanjis.Examples.ExampleMeaning", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ExampleId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExampleId");

                    b.ToTable("ExamplesMeanings");
                });

            modelBuilder.Entity("Deltapply.Models.Nihongo.Kanjis.Examples.ExampleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("Deltapply.Models.Nihongo.Kanjis.Kanji", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Attempts")
                        .HasColumnType("int");

                    b.Property<string>("Char")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<bool>("Checked")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Jlpt")
                        .HasColumnType("int");

                    b.Property<int>("Successes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Kanjis");
                });

            modelBuilder.Entity("Deltapply.Models.Nihongo.Kanjis.KanjiMeaning", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("KanjiId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KanjiId");

                    b.ToTable("KanjisMeanings");
                });

            modelBuilder.Entity("Deltapply.Models.Nihongo.Kanjis.Kun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("KanjiId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KanjiId");

                    b.ToTable("Kuns");
                });

            modelBuilder.Entity("Deltapply.Models.Nihongo.Kanjis.Name", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("KanjiId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KanjiId");

                    b.ToTable("Names");
                });

            modelBuilder.Entity("Deltapply.Models.Nihongo.Kanjis.On", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("KanjiId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KanjiId");

                    b.ToTable("Ons");
                });

            modelBuilder.Entity("Deltapply.Models.Nihongo.Kanjis.Examples.Example", b =>
                {
                    b.HasOne("Deltapply.Models.Nihongo.Kanjis.Kanji", "Kanji")
                        .WithMany("Examples")
                        .HasForeignKey("KanjiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kanji");
                });

            modelBuilder.Entity("Deltapply.Models.Nihongo.Kanjis.Examples.ExampleChar", b =>
                {
                    b.HasOne("Deltapply.Models.Nihongo.Kanjis.Examples.Example", "Example")
                        .WithMany("Chars")
                        .HasForeignKey("ExampleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Example");
                });

            modelBuilder.Entity("Deltapply.Models.Nihongo.Kanjis.Examples.ExampleMeaning", b =>
                {
                    b.HasOne("Deltapply.Models.Nihongo.Kanjis.Examples.Example", "Example")
                        .WithMany("Meanings")
                        .HasForeignKey("ExampleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Example");
                });

            modelBuilder.Entity("Deltapply.Models.Nihongo.Kanjis.KanjiMeaning", b =>
                {
                    b.HasOne("Deltapply.Models.Nihongo.Kanjis.Kanji", "Kanji")
                        .WithMany("Meanings")
                        .HasForeignKey("KanjiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kanji");
                });

            modelBuilder.Entity("Deltapply.Models.Nihongo.Kanjis.Kun", b =>
                {
                    b.HasOne("Deltapply.Models.Nihongo.Kanjis.Kanji", null)
                        .WithMany("Kuns")
                        .HasForeignKey("KanjiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Deltapply.Models.Nihongo.Kanjis.Name", b =>
                {
                    b.HasOne("Deltapply.Models.Nihongo.Kanjis.Kanji", null)
                        .WithMany("Names")
                        .HasForeignKey("KanjiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Deltapply.Models.Nihongo.Kanjis.On", b =>
                {
                    b.HasOne("Deltapply.Models.Nihongo.Kanjis.Kanji", null)
                        .WithMany("Ons")
                        .HasForeignKey("KanjiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Deltapply.Models.Nihongo.Kanjis.Examples.Example", b =>
                {
                    b.Navigation("Chars");

                    b.Navigation("Meanings");
                });

            modelBuilder.Entity("Deltapply.Models.Nihongo.Kanjis.Kanji", b =>
                {
                    b.Navigation("Examples");

                    b.Navigation("Kuns");

                    b.Navigation("Meanings");

                    b.Navigation("Names");

                    b.Navigation("Ons");
                });
#pragma warning restore 612, 618
        }
    }
}
