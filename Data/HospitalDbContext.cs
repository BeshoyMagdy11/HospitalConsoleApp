
using HospitalConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalConsoleApp.Data;

public class HospitalDbContext : DbContext
{
    public HospitalDbContext(
        DbContextOptions<HospitalDbContext> options)
        : base(options)
    {
    }

    public DbSet<Patient> Patients => Set<Patient>();

    public DbSet<Specialization> Specializations =>
        Set<Specialization>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(p => p.CreatedAt)
                .IsRequired();

            entity.HasOne<Specialization>()
                .WithMany()
                .HasForeignKey(p => p.SpecializationId)
                .IsRequired();

            entity.HasIndex(p => new
            {
                p.SpecializationId,
                p.Status,
                p.Id
            });
        });

        modelBuilder.Entity<Specialization>(entity =>
        {
            entity.HasKey(s => s.Id);

            entity.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(s => s.Capacity)
                .IsRequired();
        });

        modelBuilder.Entity<Specialization>().HasData(
            new Specialization { Id = 1, Name = "Children", Capacity = 5 },
            new Specialization { Id = 2, Name = "Surgery", Capacity = 5 },
            new Specialization { Id = 3, Name = "Internal Medicine", Capacity = 5 },
            new Specialization { Id = 4, Name = "Cardiology", Capacity = 5 },
            new Specialization { Id = 5, Name = "Neurology", Capacity = 5 },
            new Specialization { Id = 6, Name = "Orthopedics", Capacity = 5 },
            new Specialization { Id = 7, Name = "Ophthalmology", Capacity = 5 },
            new Specialization { Id = 8, Name = "ENT", Capacity = 5 },
            new Specialization { Id = 9, Name = "Dermatology", Capacity = 5 },
            new Specialization { Id = 10, Name = "Dentistry", Capacity = 5 },
            new Specialization { Id = 11, Name = "Urology", Capacity = 5 },
            new Specialization { Id = 12, Name = "Gynecology", Capacity = 5 },
            new Specialization { Id = 13, Name = "Psychiatry", Capacity = 5 },
            new Specialization { Id = 14, Name = "Oncology", Capacity = 5 },
            new Specialization { Id = 15, Name = "Radiology", Capacity = 5 },
            new Specialization { Id = 16, Name = "Emergency", Capacity = 5 },
            new Specialization { Id = 17, Name = "Pediatrics", Capacity = 5 },
            new Specialization { Id = 18, Name = "Pulmonology", Capacity = 5 },
            new Specialization { Id = 19, Name = "Nephrology", Capacity = 5 },
            new Specialization { Id = 20, Name = "Gastroenterology", Capacity = 5 }
        );
    }
}
