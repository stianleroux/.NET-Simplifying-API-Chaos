namespace Core.EFMapping;

using Common.Entities.V1;

public class VoteMap : IEntityTypeConfiguration<Vote>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Vote> builder)
    {
        // table
        builder.ToTable("Vote");

        // key
        builder.HasKey(t => t.Id);

        // properties
        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("ID")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(t => t.VoterName)
            .IsRequired()
            .HasColumnName("VoterName")
            .HasColumnType("varchar(200)")
            .HasMaxLength(200);

        builder.Property(t => t.VoteFor)
            .IsRequired()
            .HasColumnName("VoteFor")
            .HasColumnType("varchar(200)")
            .HasMaxLength(200)
            .HasConversion<string>();

        builder.Property(t => t.DateCreated)
            .HasColumnName("DateCreated")
            .HasColumnType("datetime")
            .HasDefaultValueSql("GETDATE()");
    }

    public struct Table
    {
        public const string Schema = "";
        public const string Name = "Sample";
    }

    public struct Columns
    {
        public const string Id = "Id";
        public const string Name = "Name";
        public const string DateCreated = "DateCreated";
        public const string Disabled = "Disabled";
    }
}
