using Library.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.DataAccess.Contexts;
public class BooksDbContext: DbContext
{
    public virtual DbSet<AuthorEntity> Authors { get; set; }
    public virtual DbSet<PublisherEntity> Publishers { get; set; }
    public virtual DbSet<BookEntity> Books { get; set; }

    public BooksDbContext(DbContextOptions<BooksDbContext> options):base(options)
    {
        //Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuthorEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("authors_table_pkey");
                
            entity.ToTable("authors_table");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("second_name");
        });

        modelBuilder.Entity<PublisherEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("publishers_table_pkey");

            entity.ToTable("publishers_table");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<BookEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("books_table_pkey");

            entity.ToTable("books_table");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorId).ValueGeneratedOnAdd().HasColumnName("author_id");
            entity.Property(e => e.PublisherId).ValueGeneratedOnAdd().HasColumnName("publisher_id");
            entity.Property(e => e.Name).HasMaxLength(100).HasColumnName("name");
            entity.Property(e => e.Year).HasMaxLength(100).HasColumnName("year");
            entity.Property(e => e.Genre).HasMaxLength(100).HasColumnName("genre");
            entity.HasOne(d => d.Author).WithMany(p => p.Books).HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("books_table_author_id_fkey");
            entity.HasOne(d => d.Publisher).WithMany(p => p.Books).HasForeignKey(d => d.PublisherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("books_table_publisher_id_fkey");
        });
    }
}
