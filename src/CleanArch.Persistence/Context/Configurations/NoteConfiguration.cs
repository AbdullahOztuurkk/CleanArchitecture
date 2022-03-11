using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Persistence.Context.Configurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.ToTable("Notes");

            builder.HasKey(pred => pred.Id);
            builder.Property(pred => pred.Id)
                .UseIdentityColumn();
            builder.HasOne(pred => pred.Tag)
                .WithMany(pred => pred.Notes)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
