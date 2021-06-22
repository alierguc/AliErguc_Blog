using AliErguc.Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliErguc.Blog.DataAccess.Concrete.EFCore.MapConfiguring
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.UserName).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Password).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Email).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Name).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Surname).HasMaxLength(100).IsRequired();

            builder.HasMany(I => I.Blogs).WithOne(I => I.AppUser).HasForeignKey(I => I.AppUserId);
        }
    }
}
