﻿using Microsoft.EntityFrameworkCore;
using R5._08.Project.Database.Entities;

namespace R5._08.Project.Database;

public partial class R508projetContext : DbContext
{
    public R508projetContext()
    {
    }

    public R508projetContext(DbContextOptions options)
        : base(options)
    {
    }

    public virtual DbSet<Scoreboard> Scoreboards { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_unicode_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Scoreboard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("scoreboard")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.AverageTime).HasColumnType("int(11)");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasDefaultValueSql("''");
            entity.Property(e => e.NumberOfGames).HasColumnType("int(11)");
            entity.Property(e => e.NumberOfWins).HasColumnType("int(11)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}