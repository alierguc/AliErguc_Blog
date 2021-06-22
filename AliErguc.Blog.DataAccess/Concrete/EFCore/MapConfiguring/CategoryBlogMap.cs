using AliErguc.Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliErguc.Blog.DataAccess.Concrete.EFCore.MapConfiguring
{
    public class CategoryBlogMap : IEntityTypeConfiguration<CategoryBlog>
    {
        public void Configure(EntityTypeBuilder<CategoryBlog> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.HasIndex(I => new { I.BlogId, I.CategoryId }).IsUnique();

        }
    }
}
