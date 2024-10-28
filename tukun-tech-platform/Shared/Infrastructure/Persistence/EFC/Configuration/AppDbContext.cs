using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using tukun_tech_platform.Tukun.Domain.Model.Aggregates.Doctors;
using tukun_tech_platform.Tukun.Domain.Model.Aggregates.Patients;

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
        

    }
    
}