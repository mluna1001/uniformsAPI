using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UniformsAPI.Domain.Models
{
    public partial class UniformsContext : DbContext
    {
        public UniformsContext()
        {
        }

        public UniformsContext(DbContextOptions<UniformsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<StoreResponse> StoreResponse { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeType> EmployeeTypes { get; set; }
        public virtual DbSet<Garment> Garments { get; set; }
        public virtual DbSet<GarmentDelivery> GarmentDeliveries { get; set; }
        public virtual DbSet<GarmentSize> GarmentSizes { get; set; }
        public virtual DbSet<GroupEmployee> GroupEmployees { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<VwdeliverStatus> VwdeliverStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data source=<server_here>,1433;User id=<user_here>; Password=<password_here>; Initial catalog=Uniforms");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.Property(e => e.GroupEmployeeId)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.GroupEmployee)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.GroupEmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMPLOYEE_GE");
            });

            modelBuilder.Entity<EmployeeType>(entity =>
            {
                entity.ToTable("EmployeeType");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Garment>(entity =>
            {
                entity.ToTable("Garment");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.EmployeeType)
                    .WithMany(p => p.Garments)
                    .HasForeignKey(d => d.EmployeeTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GARMENT_ET");
            });

            modelBuilder.Entity<GarmentDelivery>(entity =>
            {
                entity.HasKey(e => e.DeliveryId)
                    .HasName("PK__GarmentD__626D8FCECA03BCBA");

                entity.ToTable("GarmentDelivery");

                entity.Property(e => e.ActionDate).HasColumnType("smalldatetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.GarmentDeliveries)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GD_Employee");

                entity.HasOne(d => d.GarmentSize)
                    .WithMany(p => p.GarmentDeliveries)
                    .HasForeignKey(d => d.GarmentSizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GD_GS");
            });

            modelBuilder.Entity<GarmentSize>(entity =>
            {
                entity.ToTable("GarmentSize");

                entity.HasOne(d => d.Garment)
                    .WithMany(p => p.GarmentSizes)
                    .HasForeignKey(d => d.GarmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GS_GARMENT");
            });

            modelBuilder.Entity<GroupEmployee>(entity =>
            {
                entity.ToTable("GroupEmployee");

                entity.Property(e => e.GroupEmployeeId).HasMaxLength(1);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.EmployeeType)
                    .WithMany(p => p.GroupEmployees)
                    .HasForeignKey(d => d.EmployeeTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GE_ET");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory");

                entity.HasOne(d => d.GarmentSize)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.GarmentSizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_INVENTORY_GS");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("Size");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<VwdeliverStatus>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VWDeliverStatus");

                entity.Property(e => e.DeliverSize).HasMaxLength(171);

                entity.Property(e => e.DeliveryDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Garment)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Group)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<VwdeliverStatus>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VWDeliverStatus");

                entity.Property(e => e.DeliverSize).HasMaxLength(171);

                entity.Property(e => e.DeliveryDate).HasColumnType("smalldatetime");

                entity.Property(e => e.Garment)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Group)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<StoreResponse>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.Status);
                entity.Property(e => e.Message);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
