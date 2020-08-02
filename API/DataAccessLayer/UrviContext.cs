using System.Text;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DataAccessLayer
{
    public class UrviContext : DbContext
    {
        private readonly IOptions<DbConfig> _dbConfig;

        public UrviContext()
        {
        }

        public UrviContext(IOptions<DbConfig> dbConfig, DbContextOptions<UrviContext> options)
            : base(options)
        {
            _dbConfig = dbConfig;
        }

        public virtual DbSet<AllergenMaster> AllergenMaster { get; set; }
        public virtual DbSet<BrandMaster> BrandMaster { get; set; }
        public virtual DbSet<CategoryMaster> CategoryMaster { get; set; }
        public virtual DbSet<ImageMaster> ImageMaster { get; set; }
        public virtual DbSet<ProductMaster> ProductMaster { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AllergenMaster>(entity =>
            {
                entity.ToTable("allergen_master");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.IsGlutenfree).HasColumnName("is_glutenfree");

                entity.Property(e => e.IsLactoseIntolerant).HasColumnName("is_lactose_intolerant");

                entity.Property(e => e.IsSulphiteFree).HasColumnName("is_sulphite_free");

                entity.Property(e => e.IsVegan).HasColumnName("is_vegan");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.AllergenMaster)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__allergen___produ__2F10007B");
            });

            modelBuilder.Entity<BrandMaster>(entity =>
            {
                entity.ToTable("brand_master");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CategoryMaster>(entity =>
            {
                entity.ToTable("category_master");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ImageMaster>(entity =>
            {
                entity.ToTable("image_master");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ImageMaster)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__image_mas__produ__2C3393D0");
            });

            modelBuilder.Entity<ProductMaster>(entity =>
            {
                entity.ToTable("product_master");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BrandId).HasColumnName("brand_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Size)
                    .IsRequired()
                    .HasColumnName("size")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.ProductMaster)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__product_m__brand__29572725");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProductMaster)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__product_m__categ__286302EC");
            });
        }

        private string GetConnectionString()
        {
            var connectionString = new StringBuilder();

            connectionString.Append("User ID=");
            connectionString.Append(_dbConfig.Value.UserId);
            connectionString.Append(";Password=");
            connectionString.Append(_dbConfig.Value.Password);
            connectionString.Append(";Data Source=");
            connectionString.Append(_dbConfig.Value.Server);
            connectionString.Append(";Initial Catalog=");
            connectionString.Append(_dbConfig.Value.Database);

            return connectionString.ToString();
        }
    }
}
