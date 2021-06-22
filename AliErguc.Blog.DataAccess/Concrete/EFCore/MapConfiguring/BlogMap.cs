using Microsoft.EntityFrameworkCore;
using AliErguc.Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AliErguc.Blog.DataAccess.Concrete.EFCore.MapConfiguring
{
    public class BlogMap : IEntityTypeConfiguration<BlogSection>
    {
        public void Configure(EntityTypeBuilder<BlogSection> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Title).HasMaxLength(100).IsRequired();
            builder.Property(I => I.ShortDescription).HasMaxLength(500).IsRequired();
            builder.Property(I => I.Description).HasColumnType("ntext");
            builder.Property(I => I.ImagePath).HasMaxLength(300);
            builder.HasMany(I => I.Comments).WithOne(I => I.Blog).HasForeignKey(I => I.BlogId);
            builder.HasMany(I => I.CategoryBlogs).WithOne(I => I.Blog).HasForeignKey(I => I.BlogId);

        }
    }
}
