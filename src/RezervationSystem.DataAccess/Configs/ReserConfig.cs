using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RezervationSystem.Entity.Concrete;

namespace RezervationSystem.DataAccess.Configs;

public sealed class ReserConfig : IEntityTypeConfiguration<Reser>
{
    public void Configure(EntityTypeBuilder<Reser> builder)
    {
        builder.ToTable("Resers")
            .HasKey(r => r.Id);

        builder.HasMany(r => r.ObjectRents);

        builder.Property(r => r.Id)
            .HasColumnName("Id");

        builder.Property(r => r.UserId)
            .HasColumnName("UserId");

        builder.Property(r => r.Name)
            .HasColumnName("Name")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(r => r.Address)
            .HasColumnName("Address")
            .HasMaxLength(255);

        builder.Property(r => r.Descripton)
            .HasColumnName("Descripton")
            .HasMaxLength(255);

        builder.Property(r => r.Price)
            .HasColumnName("Price")
            .IsRequired();

        builder.Property(r => r.CreateDate)
            .HasColumnName("CreateDate");
        builder.Property(r => r.UpdateDate)
            .HasColumnName("UpdateDate");
        builder.Property(r => r.DeletedDate)
            .HasColumnName("DeletedDate");

        Reser[] reserEntitySeeds = {
                new(1,"Halısaha 1","Address Line 1","Description",1,1,DateTime.Now),
                new(2,"Halısaha 2","Address Line 2","Description",1,1,DateTime.Now),
                new(3,"Halısaha 3","Address Line 3","Description",1,1,DateTime.Now),
            };
        builder.HasData(reserEntitySeeds);
    }
}
