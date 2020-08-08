using Contracts.Domain;
using Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DataAccessLayer
{
    public class OrdersContext : DbContext
    {
        private readonly IOptions<AppSettings> _appSettings;

        public OrdersContext()
        {
        }

        public OrdersContext(IOptions<AppSettings> appSettings, DbContextOptions<OrdersContext> options)
            : base(options)
        {
            _appSettings = appSettings;
        }

        public virtual DbSet<OrderDetailsAudit> OrderDetailsAudit { get; set; }

        public virtual DbSet<OrderDetailsMaster> OrderDetailsMaster { get; set; }

        public virtual DbSet<OrdersAudit> OrdersAudit { get; set; }

        public virtual DbSet<OrdersMaster> OrdersMaster { get; set; }

        public virtual DbSet<Cart> Cart { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStringsHelper.GetConnectionString(_appSettings.Value));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("cart");

                entity.Property(e => e.Id)
                    .HasColumnName("id").ValueGeneratedOnAdd();

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.EmailNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Email)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cart__email__4E88ABD4");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cart__product_id__4F7CD00D");
            });

            modelBuilder.Entity<OrderDetailsAudit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("order_details_audit");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Size)
                    .HasColumnName("size")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Order)
                    .WithMany()
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__order_det__order__3F466844");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__order_det__produ__403A8C7D");
            });

            modelBuilder.Entity<OrderDetailsMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("order_details_master");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Size)
                    .HasColumnName("size")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Order)
                    .WithMany()
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__order_det__order__398D8EEE");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__order_det__produ__3A81B327");
            });

            modelBuilder.Entity<OrdersAudit>(entity =>
            {
                entity.ToTable("orders_audit");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TotalPrice).HasColumnName("total_price");
            });

            modelBuilder.Entity<OrdersMaster>(entity =>
            {
                entity.ToTable("orders_master");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnName("create_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TotalPrice).HasColumnName("total_price");
            });
        }
    }
}
