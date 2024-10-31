using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using tukun_tech_platform.Tukun.Domain.Model.Aggregates.CriticalAlerts;
using tukun_tech_platform.Tukun.Domain.Model.Aggregates.Doctors;
using tukun_tech_platform.Tukun.Domain.Model.Aggregates.Patients;
using tukun_tech_platform.Tukun.Domain.Model.Aggregates.EmergencyNumbers;
using tukun_tech_platform.Tukun.Domain.Model.Aggregates.PendingMedicine;
using tukun_tech_platform.Tukun.Domain.Model.Aggregates.Elder;
using tukun_tech_platform.Tukun.Domain.Model.Aggregates.FrequentlyQuestions;

namespace tukun_tech_platform.Shared.Infrastructure.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Doctor>().HasKey(f => f.Id);
        builder.Entity<Doctor>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Doctor>().Property(f => f.Name).IsRequired();
        builder.Entity<Doctor>().Property(f => f.LastName).IsRequired();
        builder.Entity<Doctor>().Property(f => f.Dni).IsRequired();
        builder.Entity<Doctor>().Property(f => f.Age).IsRequired();
        builder.Entity<Doctor>().Property(f => f.CmpCode).IsRequired();
        builder.Entity<Doctor>().Property(f => f.Nationality).IsRequired();
        builder.Entity<Doctor>().Property(f => f.Specialization).IsRequired();
        builder.Entity<Doctor>().Property(f => f.Contact).IsRequired();
        
        
        builder.Entity<Patient>().HasKey(f => f.Id);
        builder.Entity<Patient>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Patient>().Property(f => f.Name).IsRequired();
        builder.Entity<Patient>().Property(f => f.LastName).IsRequired();
        builder.Entity<Patient>().Property(f => f.Dni).IsRequired();
        builder.Entity<Patient>().Property(f => f.Gender).IsRequired();
        builder.Entity<Patient>().Property(f => f.Age).IsRequired();
        builder.Entity<Patient>().Property(f => f.BloodType).IsRequired();
        builder.Entity<Patient>().Property(f => f.Nationality).IsRequired();
        builder.Entity<Patient>().Property(f => f.NumberPolicies).IsRequired();
        builder.Entity<Patient>().Property(f => f.Insurance).IsRequired();
        builder.Entity<Patient>().Property(f => f.AlLergies).IsRequired();
        
        builder.Entity<EmergencyNumbers>().HasKey(f => f.Id);
        builder.Entity<EmergencyNumbers>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<EmergencyNumbers>().Property(f => f.Number).IsRequired();

        builder.Entity<PendingMedicine>().HasKey(f => f.Id);
        builder.Entity<PendingMedicine>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<PendingMedicine>().Property(f => f.Name).IsRequired();
        builder.Entity<PendingMedicine>().Property(f => f.Dose).IsRequired();
        builder.Entity<PendingMedicine>().Property(f => f.DueDate).IsRequired();

        builder.Entity<Elder>().HasKey(f => f.Id);
        builder.Entity<Elder>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Elder>().Property(f => f.Name).IsRequired();
        builder.Entity<Elder>().Property(f => f.LastName).IsRequired();
        builder.Entity<Elder>().Property(f => f.Dni).IsRequired();
        builder.Entity<Elder>().Property(f => f.Gender).IsRequired();
        builder.Entity<Elder>().Property(f => f.Age).IsRequired();
        builder.Entity<Elder>().Property(f => f.BloodType).IsRequired();
        builder.Entity<Elder>().Property(f => f.Nationality).IsRequired();
        builder.Entity<Elder>().Property(f => f.NumberPolicies).IsRequired();
        builder.Entity<Elder>().Property(f => f.Insurance).IsRequired();
        builder.Entity<Elder>().Property(f => f.Allergies).IsRequired();
        
        builder.Entity<FrequentlyQuestions>().HasKey(f => f.Id);
        builder.Entity<FrequentlyQuestions>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<FrequentlyQuestions>().Property(f => f.Text).IsRequired();

        builder.Entity<CriticalAlerts>().HasKey(f => f.Id);
        builder.Entity<CriticalAlerts>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<CriticalAlerts>().Property(f => f.Message).IsRequired();

        
        
    }
    
}