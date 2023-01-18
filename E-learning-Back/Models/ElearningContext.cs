using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace E_learning_Back.Models;

public partial class ElearningContext : DbContext
{
    public ElearningContext()
    {
    }

    public ElearningContext(DbContextOptions<ElearningContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Cour> Cours { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<SkillCour> SkillCours { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.IdAdmin).HasName("PK__admin__4C3F97F461E21ED1");

            entity.ToTable("admin");

            entity.Property(e => e.AdminName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("adminName");
            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__category__3213E83F5B8411C0");

            entity.ToTable("category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Img).HasColumnName("img");
            entity.Property(e => e.Title)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__comment__3213E83F0053858D");

            entity.ToTable("comment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("content");
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IdCours).HasColumnName("idCours");
            entity.Property(e => e.Score).HasColumnName("score");
            entity.Property(e => e.Username)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.IdCoursNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.IdCours)
                .HasConstraintName("FK__comment__idCours__2B3F6F97");
        });

        modelBuilder.Entity<Cour>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cours__3213E83F877D89FD");

            entity.ToTable("cours");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("categoryID");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Img).HasColumnName("img");
            entity.Property(e => e.Title)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.Category).WithMany(p => p.Cours)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__cours__categoryI__286302EC");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Skill__3213E83F94E58C49");

            entity.ToTable("Skill");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<SkillCour>(entity =>
        {
            entity.HasKey(e => new { e.IdCours, e.IdSkill }).HasName("PK__Skill_Co__AD3E23868FDCBDE9");

            entity.ToTable("Skill_Cours");

            entity.Property(e => e.IdCours).HasColumnName("idCours");
            entity.Property(e => e.IdSkill).HasColumnName("idSkill");
            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.IdCoursNavigation).WithMany(p => p.SkillCours)
                .HasForeignKey(d => d.IdCours)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Skill_Cou__idCou__300424B4");

            entity.HasOne(d => d.IdSkillNavigation).WithMany(p => p.SkillCours)
                .HasForeignKey(d => d.IdSkill)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Skill_Cou__idSki__30F848ED");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
