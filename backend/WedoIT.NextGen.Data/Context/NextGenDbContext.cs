using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using WedoIT.NextGen.Data.Entities;

namespace WedoIT.NextGen.Data.Context;

public class NextGenDbContext : DbContext
{
    public NextGenDbContext(DbContextOptions<NextGenDbContext> options)
        : base(options)
    {
    }

    [ExcludeFromCodeCoverage] public virtual DbSet<Block> Blocks { get; set; } = null!;

    [ExcludeFromCodeCoverage] public virtual DbSet<History> Histories { get; set; } = null!;

    [ExcludeFromCodeCoverage] public virtual DbSet<Person> Persons { get; set; } = null!;
    
    [ExcludeFromCodeCoverage] public virtual DbSet<ProjectBlock> ProjectBlocks { get; set; } = null!;

    [ExcludeFromCodeCoverage] public virtual DbSet<Project> Projects { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Block>(entity =>
        {
            entity.ToTable("Blocks");

            entity.Property(block => block.Id).ValueGeneratedNever();
            
            entity.HasMany(block => block.ProjectBlocks)
                .WithOne(projectblock => projectblock.Block)
                .HasForeignKey( projectblock => projectblock.BlockId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<History>(entity =>
        {
            entity.ToTable("Histories");

            entity.Property(history => history.Id).ValueGeneratedNever();

            entity.HasOne(history => history.Person)
                .WithMany(history => history.Histories)
                .HasForeignKey(history => history.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(history => history.Project)
                .WithMany(history => history.Histories)
                .HasForeignKey(history => history.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            
            entity.HasOne(history => history.Block)
                .WithMany(history => history.Histories)
                .HasForeignKey(history => history.BlockId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("Persons");

            entity.Property(person => person.Id).ValueGeneratedNever();
            
            entity.HasMany(person => person.Blocks)
                .WithOne(block => block.Creator)
                .HasForeignKey(block => block.CreatorId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.ToTable("Projects");

            entity.Property(project => project.Id).ValueGeneratedNever();

            entity.HasOne(project => project.Creator)
                .WithMany(project => project.Projects)
                .HasForeignKey(project => project.CreatorId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            
            entity.HasMany(project => project.ProjectBlocks)
                .WithOne(Projectblock => Projectblock.Project)
                .HasForeignKey(projectblock => projectblock.ProjectId);
        });
    }
}