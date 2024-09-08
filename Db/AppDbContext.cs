using Microsoft.EntityFrameworkCore;

namespace Users_Api.Db
{
    //"Host=localhost;Username=postgres;Password=1;Database=LibraryUsers"
    public partial class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        private readonly string _connectionString;

        public AppDbContext() { }

        public AppDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                                => optionsBuilder.UseNpgsql(_connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.Id).HasName("user_pkey");
                entity.HasIndex(e => e.Email).IsUnique();

                entity.ToTable("users");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Email).HasColumnName("email");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Surname).HasColumnName("surname");
                entity.Property(e => e.Registred).HasColumnName("registred");
                entity.Property(e => e.Active).HasColumnName("active");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
