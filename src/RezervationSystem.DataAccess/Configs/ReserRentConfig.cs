using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RezervationSystem.Entity.Concrete;

namespace RezervationSystem.DataAccess.Configs;

public sealed class ReserRentConfig : IEntityTypeConfiguration<ReserRent>
{
    public void Configure(EntityTypeBuilder<ReserRent> builder)
    {
        builder.ToTable("ReserRents")
            .HasKey(r => r.Id);

        builder.HasOne(r => r.Reser);

        builder.Property(r => r.Id)
            .HasColumnName("Id");

        builder.Property(r => r.ReserId)
            .HasColumnName("ReserId");

        builder.Property(r => r.CustomerId)
            .HasColumnName("CustomerId");

        builder.Property(r => r.StartDate)
            .IsRequired()
            .HasColumnName("StartDate");
        builder.Property(r => r.EndDate)
            .IsRequired()
            .HasColumnName("EndDate");

        builder.Property(r => r.CreateDate)
            .HasColumnName("CreateDate");
        builder.Property(r => r.UpdateDate)
            .HasColumnName("UpdateDate");
        builder.Property(r => r.DeletedDate)
            .HasColumnName("DeletedDate");

        ReserRent[] reserRentEntitySeeds =
            {
                new(1,1,DateTime.Now,DateTime.Now.AddDays(3),DateTime.Now),
                new(2,2,DateTime.Now,DateTime.Now.AddDays(3),DateTime.Now),
                new(3,3,DateTime.Now,DateTime.Now.AddDays(3),DateTime.Now)
            };

        builder.HasData(reserRentEntitySeeds);
    }
}
