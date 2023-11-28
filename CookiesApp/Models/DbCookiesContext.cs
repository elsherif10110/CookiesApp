using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CookiesApp.Models;

public partial class DbCookiesContext : DbContext
{
    public DbCookiesContext()
    {
    }

    public DbCookiesContext(DbContextOptions<DbCookiesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LoginLog> LoginLogs { get; set; }

    public virtual DbSet<TbAdminActivityLog> TbAdminActivityLogs { get; set; }

    public virtual DbSet<TbAdminUser> TbAdminUsers { get; set; }

    public virtual DbSet<TbAnswer> TbAnswers { get; set; }

    public virtual DbSet<TbAnswerType> TbAnswerTypes { get; set; }

    public virtual DbSet<TbCategory> TbCategories { get; set; }

    public virtual DbSet<TbCommon> TbCommons { get; set; }

    public virtual DbSet<TbForm> TbForms { get; set; }

    public virtual DbSet<TbQuestion> TbQuestions { get; set; }

    public virtual DbSet<TbRegistrationLog> TbRegistrationLogs { get; set; }

    public virtual DbSet<TbResult> TbResults { get; set; }

    public virtual DbSet<TbUserAuthentication> TbUserAuthentication { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-BBT3LB8\\SQLEXPRESS;Database=DbCookies;user=Sa;password=123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LoginLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__LoginLog__5E5486485D30EA6A");

            entity.ToTable("LoginLog");

            entity.Property(e => e.LogId).ValueGeneratedNever();
            entity.Property(e => e.LoginTime).HasColumnType("datetime");
            entity.Property(e => e.LogoutTime).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.LoginLogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__LoginLog__UserId__3B75D760");
        });

        modelBuilder.Entity<TbAdminActivityLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__TbAdminA__5E548648FF547811");

            entity.ToTable("TbAdminActivityLog");

            entity.Property(e => e.LogId).ValueGeneratedNever();
            entity.Property(e => e.ActivityTime).HasColumnType("datetime");

            entity.HasOne(d => d.Admin).WithMany(p => p.TbAdminActivityLogs)
                .HasForeignKey(d => d.AdminId)
                .HasConstraintName("FK__TbAdminAc__Admin__44FF419A");
        });

        modelBuilder.Entity<TbAdminUser>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__TbAdminU__719FE488FB4FD3A8");

            entity.HasIndex(e => e.Username, "UQ__TbAdminU__536C85E43E672C2C").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__TbAdminU__A9D1053450108332").IsUnique();

            entity.Property(e => e.AdminId).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PasswordHash).HasMaxLength(64);
            entity.Property(e => e.PasswordSalt).HasMaxLength(32);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<TbAnswer>(entity =>
        {
            entity.HasKey(e => e.AnswerId).HasName("PK__TbAnswer__D48250042B93150B");

            entity.ToTable("TbAnswer");

            entity.Property(e => e.AnswerId).ValueGeneratedNever();

            entity.HasOne(d => d.AnswerType).WithMany(p => p.TbAnswers)
                .HasForeignKey(d => d.AnswerTypeId)
                .HasConstraintName("FK__TbAnswer__Answer__4E88ABD4");
        });

        modelBuilder.Entity<TbAnswerType>(entity =>
        {
            entity.HasKey(e => e.AnswerTypeId).HasName("PK__TbAnswer__4D81A36710B6DA3B");

            entity.ToTable("TbAnswerType");

            entity.Property(e => e.AnswerTypeId).ValueGeneratedNever();
            entity.Property(e => e.AnswerTypeName).HasMaxLength(255);
        });

        modelBuilder.Entity<TbCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__TbCatego__19093A0BE7876AA1");

            entity.ToTable("TbCategory");

            entity.Property(e => e.CategoryId).ValueGeneratedNever();
            entity.Property(e => e.CategoryName).HasMaxLength(255);
        });

        modelBuilder.Entity<TbCommon>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TbCommon");

            entity.HasOne(d => d.Answer).WithMany()
                .HasForeignKey(d => d.AnswerId)
                .HasConstraintName("FK__TbCommon__Answer__5DCAEF64");

            entity.HasOne(d => d.AnswerType).WithMany()
                .HasForeignKey(d => d.AnswerTypeId)
                .HasConstraintName("FK__TbCommon__Answer__5EBF139D");

            entity.HasOne(d => d.Form).WithMany()
                .HasForeignKey(d => d.FormId)
                .HasConstraintName("FK__TbCommon__FormId__5CD6CB2B");

            entity.HasOne(d => d.Question).WithMany()
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK__TbCommon__Questi__5FB337D6");
        });

        modelBuilder.Entity<TbForm>(entity =>
        {
            entity.HasKey(e => e.FormId).HasName("PK__TbForm__FB05B7DDD0EE7B3B");

            entity.ToTable("TbForm");

            entity.Property(e => e.FormId).ValueGeneratedNever();
            entity.Property(e => e.FormDate).HasColumnType("date");

            entity.HasOne(d => d.Admin).WithMany(p => p.TbForms)
                .HasForeignKey(d => d.AdminId)
                .HasConstraintName("FK__TbForm__AdminId__5441852A");

            entity.HasOne(d => d.Answer).WithMany(p => p.TbForms)
                .HasForeignKey(d => d.AnswerId)
                .HasConstraintName("FK__TbForm__AnswerId__534D60F1");

            entity.HasOne(d => d.Category).WithMany(p => p.TbForms)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__TbForm__Category__5165187F");

            entity.HasOne(d => d.Question).WithMany(p => p.TbForms)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK__TbForm__Question__52593CB8");

            entity.HasOne(d => d.User).WithMany(p => p.TbForms)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__TbForm__UserId__5535A963");
        });

        modelBuilder.Entity<TbQuestion>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__TbQuesti__0DC06FACB3D68F7A");

            entity.ToTable("TbQuestion");

            entity.Property(e => e.QuestionId).ValueGeneratedNever();

            entity.HasOne(d => d.Category).WithMany(p => p.TbQuestions)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__TbQuestio__Categ__49C3F6B7");
        });

        modelBuilder.Entity<TbRegistrationLog>(entity =>
        {
            entity.HasKey(e => e.RegistrationId).HasName("PK__TbRegist__6EF588101A05D753");

            entity.ToTable("TbRegistrationLog");

            entity.Property(e => e.RegistrationId).ValueGeneratedNever();
            entity.Property(e => e.RegistrationTime).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.TbRegistrationLogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__TbRegistr__UserI__3E52440B");
        });

        modelBuilder.Entity<TbResult>(entity =>
        {
            entity.HasKey(e => e.ResultId).HasName("PK__TbResult__97690208B8A7C5B2");

            entity.Property(e => e.ResultId).ValueGeneratedNever();
            entity.Property(e => e.ResultDate).HasColumnType("date");

            entity.HasOne(d => d.Answer).WithMany(p => p.TbResults)
                .HasForeignKey(d => d.AnswerId)
                .HasConstraintName("FK__TbResults__Answe__5AEE82B9");

            entity.HasOne(d => d.Form).WithMany(p => p.TbResults)
                .HasForeignKey(d => d.FormId)
                .HasConstraintName("FK__TbResults__FormI__5812160E");

            entity.HasOne(d => d.Question).WithMany(p => p.TbResults)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK__TbResults__Quest__59FA5E80");

            entity.HasOne(d => d.User).WithMany(p => p.TbResults)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__TbResults__UserI__59063A47");
        });

        modelBuilder.Entity<TbUserAuthentication>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__TbUserAu__1788CC4CE2327DE7");

            entity.ToTable("TbUserAuthentication");

            entity.HasIndex(e => e.Username, "UQ__TbUserAu__536C85E4B8155C71").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__TbUserAu__A9D10534221BE214").IsUnique();

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.Birthdate).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PasswordHash).HasMaxLength(64);
            entity.Property(e => e.PasswordSalt).HasMaxLength(32);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
