using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Diplom.BdModels
{
    public partial class CoreModel : DbContext
    {
        private static CoreModel instance;

        public static CoreModel init()
        {
            if (instance==null)
            {
                instance = new CoreModel();
            }
            return instance;
        }
        public CoreModel()
        {
        }

        public CoreModel(DbContextOptions<CoreModel> options)
            : base(options)
        {
        }

        public virtual DbSet<Bibl> Bibls { get; set; } = null!;
        public virtual DbSet<ListsOfFiction> ListsOfFictions { get; set; } = null!;
        public virtual DbSet<ListsOfTextbook> ListsOfTextbooks { get; set; } = null!;
        public virtual DbSet<ListsTextbooksApplication> ListsTextbooksApplications { get; set; } = null!;
        public virtual DbSet<SchoolBoy> SchoolBoys { get; set; } = null!;
        public virtual DbSet<TypesOfLiterature> TypesOfLiteratures { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=cfif31.ru;port=3306;user id=ISPr23-36_SmolinSA;database=ISPr23-36_SmolinSA_Kyrsach;password=ISPr23-36_SmolinSA;character set=utf8", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.36-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Bibl>(entity =>
            {
                entity.HasKey(e => e.IdBibl)
                    .HasName("PRIMARY");

                entity.ToTable("Bibl");

                entity.HasIndex(e => e.IdListsOfFiction, "Bibl_Lists_of_fiction_idx");

                entity.HasIndex(e => e.IdListsOfTextbook, "Bibl_Lists_of_textbook_idx");

                entity.HasIndex(e => e.IdListsTextbooksApplication, "Bibl_Lists_textbooks_Application_idx");

                entity.HasIndex(e => e.IdSchoolBoy, "Bibl_SchoolBoy_idx");

                entity.HasIndex(e => e.IdTypesOfLiterature, "Bibl_Types_of_Literature_idx");

                entity.HasIndex(e => e.IdUser, "Bibl_User_idx");

                entity.Property(e => e.IdBibl).HasColumnName("idBibl");

                entity.Property(e => e.IdListsOfFiction).HasColumnName("id_Lists_of_fiction");

                entity.Property(e => e.IdListsOfTextbook).HasColumnName("id_Lists_of_textbook");

                entity.Property(e => e.IdListsTextbooksApplication).HasColumnName("id_Lists_textbooks_Application");

                entity.Property(e => e.IdSchoolBoy).HasColumnName("id_SchoolBoy");

                entity.Property(e => e.IdTypesOfLiterature).HasColumnName("id_Types_of_Literature");

                entity.Property(e => e.IdUser).HasColumnName("id_User");

                entity.HasOne(d => d.IdListsOfFictionNavigation)
                    .WithMany(p => p.Bibls)
                    .HasForeignKey(d => d.IdListsOfFiction)
                    .HasConstraintName("Bibl_Lists_of_fiction");

                entity.HasOne(d => d.IdListsOfTextbookNavigation)
                    .WithMany(p => p.Bibls)
                    .HasForeignKey(d => d.IdListsOfTextbook)
                    .HasConstraintName("Bibl_Lists_of_textbook");

                entity.HasOne(d => d.IdListsTextbooksApplicationNavigation)
                    .WithMany(p => p.Bibls)
                    .HasForeignKey(d => d.IdListsTextbooksApplication)
                    .HasConstraintName("Bibl_Lists_textbooks_Application");

                entity.HasOne(d => d.IdSchoolBoyNavigation)
                    .WithMany(p => p.Bibls)
                    .HasForeignKey(d => d.IdSchoolBoy)
                    .HasConstraintName("Bibl_SchoolBoy");

                entity.HasOne(d => d.IdTypesOfLiteratureNavigation)
                    .WithMany(p => p.Bibls)
                    .HasForeignKey(d => d.IdTypesOfLiterature)
                    .HasConstraintName("Bibl_Types_of_Literature");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Bibls)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("Bibl_User");
            });

            modelBuilder.Entity<ListsOfFiction>(entity =>
            {
                entity.HasKey(e => e.IdListsOfFiction)
                    .HasName("PRIMARY");

                entity.ToTable("Lists_of_fiction");

                entity.Property(e => e.IdListsOfFiction).HasColumnName("id_Lists_of_fiction");

                entity.Property(e => e.Author).HasMaxLength(45);

                entity.Property(e => e.Genre).HasMaxLength(45);

                entity.Property(e => e.Name).HasMaxLength(45);
            });

            modelBuilder.Entity<ListsOfTextbook>(entity =>
            {
                entity.HasKey(e => e.IdListsOfTextbook)
                    .HasName("PRIMARY");

                entity.ToTable("Lists_of_textbook");

                entity.Property(e => e.IdListsOfTextbook).HasColumnName("id_Lists_of_textbook");

                entity.Property(e => e.Author).HasMaxLength(45);

                entity.Property(e => e.Date).HasMaxLength(45);

                entity.Property(e => e.Name).HasMaxLength(45);
            });

            modelBuilder.Entity<ListsTextbooksApplication>(entity =>
            {
                entity.HasKey(e => e.IdListsTextbooksApplication)
                    .HasName("PRIMARY");

                entity.ToTable("Lists_textbooks_Application");

                entity.Property(e => e.IdListsTextbooksApplication).HasColumnName("id_Lists_textbooks_Application");

                entity.Property(e => e.Author).HasMaxLength(45);

                entity.Property(e => e.DateOfIssue)
                    .HasMaxLength(45)
                    .HasColumnName("Date_of_issue");

                entity.Property(e => e.IdClass).HasColumnName("idClass");

                entity.Property(e => e.Librarian).HasMaxLength(45);

                entity.Property(e => e.Name).HasMaxLength(45);

                entity.Property(e => e.Reader).HasMaxLength(45);

                entity.Property(e => e.ReturnDate)
                    .HasMaxLength(45)
                    .HasColumnName("Return_date");
            });

            modelBuilder.Entity<SchoolBoy>(entity =>
            {
                entity.HasKey(e => e.IdSchoolBoy)
                    .HasName("PRIMARY");

                entity.ToTable("SchoolBoy");

                entity.Property(e => e.IdSchoolBoy).HasColumnName("id_SchoolBoy");

                entity.Property(e => e.IdClass).HasColumnName("idClass");

                entity.Property(e => e.Name).HasMaxLength(45);

                entity.Property(e => e.NumberPhone).HasColumnName("number_phone");

                entity.Property(e => e.Patronymic).HasMaxLength(45);

                entity.Property(e => e.Surname).HasMaxLength(45);
            });

            modelBuilder.Entity<TypesOfLiterature>(entity =>
            {
                entity.HasKey(e => e.IdTypesOfLiterature)
                    .HasName("PRIMARY");

                entity.ToTable("Types_of_Literature");

                entity.Property(e => e.IdTypesOfLiterature).HasColumnName("id_Types_of_Literature");

                entity.Property(e => e.ArtisticLiterature)
                    .HasMaxLength(45)
                    .HasColumnName("Artistic_literature");

                entity.Property(e => e.Author).HasMaxLength(45);

                entity.Property(e => e.Author1).HasMaxLength(45);

                entity.Property(e => e.Author2).HasMaxLength(45);

                entity.Property(e => e.Author3).HasMaxLength(45);

                entity.Property(e => e.Author4).HasMaxLength(45);

                entity.Property(e => e.LiteratureByIndustry)
                    .HasMaxLength(45)
                    .HasColumnName("Literature_by_industry");

                entity.Property(e => e.RefrenceLiterature)
                    .HasMaxLength(45)
                    .HasColumnName("Refrence_literature");

                entity.Property(e => e.Textbooks).HasMaxLength(45);

                entity.Property(e => e.TrainingManuals)
                    .HasMaxLength(45)
                    .HasColumnName("Training_manuals");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PRIMARY");

                entity.ToTable("User");

                entity.Property(e => e.IdUser).HasColumnName("id_User");

                entity.Property(e => e.Dolzhnost).HasMaxLength(45);

                entity.Property(e => e.Login).HasMaxLength(45);

                entity.Property(e => e.Name).HasMaxLength(45);

                entity.Property(e => e.Password).HasMaxLength(45);

                entity.Property(e => e.Patronymic).HasMaxLength(45);

                entity.Property(e => e.Surname).HasMaxLength(45);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
