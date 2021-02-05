using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AgriLandPortalAPI.Models
{
    public partial class agrilandContext : DbContext
    {
        public agrilandContext()
        {
        }

        public agrilandContext(DbContextOptions<agrilandContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LandDetails> LandDetails { get; set; }
        public virtual DbSet<LandType> LandType { get; set; }
        public virtual DbSet<UserTypes> UserTypes { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Login> UserLogin { get; set; }
        public virtual DbSet<LandDetails> PostLandDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=aws-db-agriland.cm8iqe38wuws.us-east-1.rds.amazonaws.com;database=agriland;uid=mysqladmin;pwd=Sunanj224", x => x.ServerVersion("8.0.20-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LandDetails>(entity =>
            {
                entity.HasKey(e => e.LandId)
                    .HasName("PRIMARY");

                entity.ToTable("landDetails");

                entity.HasIndex(e => e.LandTypeId)
                    .HasName("fk_userTypeId");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_userId");

                entity.Property(e => e.LandId).HasColumnName("landId");

                entity.Property(e => e.Address1)
                    .HasColumnName("address1")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(250)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.IsLease).HasColumnName("is_Lease");

                entity.Property(e => e.IsSell).HasColumnName("is_Sell");

                entity.Property(e => e.IsWatersource).HasColumnName("is_Watersource");

                entity.Property(e => e.LandTypeId).HasColumnName("landTypeId");

                entity.Property(e => e.Mobile)
                    .HasColumnName("mobile")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.PriceType)
                    .IsRequired()
                    .HasColumnName("priceType")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Tittle)
                    .IsRequired()
                    .HasColumnName("tittle")
                    .HasColumnType("varchar(250)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.TotalArea).HasColumnName("totalArea");

                entity.Property(e => e.UnitsOfMeasure)
                    .HasColumnName("unitsOfMeasure")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updatedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Village)
                    .HasColumnName("village")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.WaterSourceType)
                    .HasColumnName("waterSource_Type")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Zip)
                    .HasColumnName("zip")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.LandType)
                    .WithMany(p => p.LandDetails)
                    .HasForeignKey(d => d.LandTypeId)
                    .HasConstraintName("fk_landTypeId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LandDetails)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_userId");
            });

            modelBuilder.Entity<LandType>(entity =>
            {
                entity.HasKey(e => e.Lid)
                    .HasName("PRIMARY");

                entity.ToTable("landType");

                entity.Property(e => e.Lid).HasColumnName("LId");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<UserTypes>(entity =>
            {
                entity.HasKey(e => e.Utid)
                    .HasName("PRIMARY");

                entity.ToTable("userTypes");

                entity.Property(e => e.Utid).HasColumnName("UTId");

                entity.Property(e => e.Utdescription)
                    .IsRequired()
                    .HasColumnName("UTDescription")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("users");

                entity.HasIndex(e => e.UserType)
                    .HasName("fk_userType");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("createdBy")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasColumnName("mobile")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("char(120)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updatedOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UserType).HasColumnName("userType");

                entity.HasOne(d => d.UserTypeNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserType)
                    .HasConstraintName("fk_userType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
