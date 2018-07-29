using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace PracticeASPNETCORE.Models
{
    public partial class LTIContext : DbContext
    {
        IConfiguration Configuration;
        public LTIContext(IConfiguration config)
        {
            Configuration = config;
        }

        public virtual DbSet<Admins> Admins { get; set; }
        public virtual DbSet<Claims> Claims { get; set; }
        public virtual DbSet<Complains> Complains { get; set; }
        public virtual DbSet<Configurations> Configurations { get; set; }
        public virtual DbSet<HistoryStudents> HistoryStudents { get; set; }
        public virtual DbSet<HistoryTeachers> HistoryTeachers { get; set; }
        public virtual DbSet<Normas> Normas { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<Suggestion> Suggestion { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }
        public virtual DbSet<Trimestres> Trimestres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("LTICon"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admins>(entity =>
            {
                entity.HasKey(e => e.AdminId);

                entity.HasIndex(e => e.TeacherId);

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Admins)
                    .HasForeignKey(d => d.TeacherId);
            });

            modelBuilder.Entity<Claims>(entity =>
            {
                entity.HasKey(e => e.ClaimId);

                entity.HasIndex(e => e.StudentId);

                entity.HasIndex(e => e.TeacherId);

                entity.Property(e => e.ClaimId).HasColumnName("ClaimID");

                entity.Property(e => e.ClaimText)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Claims)
                    .HasForeignKey(d => d.StudentId);

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Claims)
                    .HasForeignKey(d => d.TeacherId);
            });

            modelBuilder.Entity<Complains>(entity =>
            {
                entity.HasKey(e => e.ComplainId);

                entity.HasIndex(e => e.StudentId);

                entity.HasIndex(e => e.TeacherId);

                entity.Property(e => e.ComplainId).HasColumnName("ComplainID");

                entity.Property(e => e.ComplainText)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Complains)
                    .HasForeignKey(d => d.StudentId);

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Complains)
                    .HasForeignKey(d => d.TeacherId);
            });

            modelBuilder.Entity<Configurations>(entity =>
            {
                entity.HasKey(e => e.MyconfigurationId);

                entity.Property(e => e.MyconfigurationId).HasColumnName("MyconfigurationID");

                entity.Property(e => e.Key).HasMaxLength(30);

                entity.Property(e => e.Value).HasMaxLength(1200);
            });

            modelBuilder.Entity<HistoryStudents>(entity =>
            {
                entity.HasKey(e => e.HistoryStudentId);

                entity.Property(e => e.HistoryStudentId).HasColumnName("HistoryStudentID");

                entity.Property(e => e.ComputerName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.Property(e => e.Domain)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LoginName)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.SubjectName).HasMaxLength(80);

                entity.Property(e => e.SubjectSection).HasMaxLength(10);
            });

            modelBuilder.Entity<HistoryTeachers>(entity =>
            {
                entity.HasKey(e => e.HistoryTeacherId);

                entity.Property(e => e.HistoryTeacherId).HasColumnName("HistoryTeacherID");

                entity.Property(e => e.ComputerName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.Property(e => e.Domain)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LoginName)
                    .IsRequired()
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<Normas>(entity =>
            {
                entity.HasKey(e => e.NormaId);

                entity.Property(e => e.NormaId).HasColumnName("NormaID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.NormaContent)
                    .IsRequired()
                    .HasMaxLength(1250);
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.HasIndex(e => e.HistoryStudentId);

                entity.HasIndex(e => e.TeacherId);

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.ComputerName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.Property(e => e.Domain)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.HistoryStudentId).HasColumnName("HistoryStudentID");

                entity.Property(e => e.LoginName)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.SubjectCode).HasMaxLength(20);

                entity.Property(e => e.SubjectName).HasMaxLength(140);

                entity.Property(e => e.SubjectSection).HasMaxLength(10);

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.HasOne(d => d.HistoryStudent)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.HistoryStudentId);

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.TeacherId);
            });

            modelBuilder.Entity<Subjects>(entity =>
            {
                entity.HasKey(e => e.SubjectId);

                entity.HasIndex(e => e.TeacherId);

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.Property(e => e.SubjectCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.SubjectName)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.TeacherId);
            });

            modelBuilder.Entity<Suggestion>(entity =>
            {
                entity.HasIndex(e => e.StudentId);

                entity.HasIndex(e => e.TeacherId);

                entity.Property(e => e.SuggestionId).HasColumnName("SuggestionID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.SuggestionText)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Suggestion)
                    .HasForeignKey(d => d.StudentId);

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Suggestion)
                    .HasForeignKey(d => d.TeacherId);
            });

            modelBuilder.Entity<Teachers>(entity =>
            {
                entity.HasKey(e => e.TeacherId);

                entity.HasIndex(e => e.HistoryTeacherId);

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.Property(e => e.ComputerName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.Property(e => e.Domain)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.HistoryTeacherId).HasColumnName("HistoryTeacherID");

                entity.Property(e => e.LoginName)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.HasOne(d => d.HistoryTeacher)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.HistoryTeacherId);
            });

            modelBuilder.Entity<Trimestres>(entity =>
            {
                entity.HasKey(e => e.TrimestreId);

                entity.Property(e => e.TrimestreId).HasColumnName("TrimestreID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(120);
            });
        }
    }
}
