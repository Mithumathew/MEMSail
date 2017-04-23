using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MEMSail.Models
{
    public partial class SailContext : DbContext
    {
        public SailContext(DbContextOptions<SailContext> options)
    :base(options)
{ }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnnualFeeStructure>(entity =>
            {
                entity.HasKey(e => e.Year)
                    .HasName("aaaaaannualFeeStructure_PK");

                entity.ToTable("annualFeeStructure");

                entity.Property(e => e.Year)
                    .HasColumnName("year")
                    .ValueGeneratedNever();

                entity.Property(e => e.AnnualFee).HasColumnName("annualFee");

                entity.Property(e => e.EarlyDiscountEndDate)
                    .HasColumnName("earlyDiscountEndDate")
                    .HasColumnType("date");

                entity.Property(e => e.EarlyDiscountedFee).HasColumnName("earlyDiscountedFee");

                entity.Property(e => e.ForthAndSubsequentBoatFee).HasColumnName("forthAndSubsequentBoatFee");

                entity.Property(e => e.NewMember25DiscountDate)
                    .HasColumnName("newMember25DiscountDate")
                    .HasColumnType("date");

                entity.Property(e => e.NewMember50DiscountDate)
                    .HasColumnName("newMember50DiscountDate")
                    .HasColumnType("date");

                entity.Property(e => e.NewMember75DiscountDate)
                    .HasColumnName("newMember75DiscountDate")
                    .HasColumnType("date");

                entity.Property(e => e.NonSailFee).HasColumnName("nonSailFee");

                entity.Property(e => e.RenewDeadlineDate)
                    .HasColumnName("renewDeadlineDate")
                    .HasColumnType("date");

                entity.Property(e => e.SecondBoatFee).HasColumnName("secondBoatFee");

                entity.Property(e => e.TaskExemptionFee).HasColumnName("taskExemptionFee");

                entity.Property(e => e.ThirdBoatFee).HasColumnName("thirdBoatFee");
            });

            modelBuilder.Entity<Boat>(entity =>
            {
                entity.ToTable("boat");

                entity.Property(e => e.BoatId).HasColumnName("boatId");

                entity.Property(e => e.BoatClass)
                    .HasColumnName("boatClass")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.BoatTypeId).HasColumnName("boatTypeId");

                entity.Property(e => e.HullColour)
                    .HasColumnName("hullColour")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.HullLength).HasColumnName("hullLength");

                entity.Property(e => e.MemberId).HasColumnName("memberId");

                entity.Property(e => e.ParkingCode)
                    .HasColumnName("parkingCode")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SailNumber)
                    .HasColumnName("sailNumber")
                    .HasColumnType("varchar(50)");

                entity.HasOne(d => d.BoatType)
                    .WithMany(p => p.Boat)
                    .HasForeignKey(d => d.BoatTypeId)
                    .HasConstraintName("FK_boat_boatType");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Boat)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_boat_member");

                entity.HasOne(d => d.ParkingCodeNavigation)
                    .WithMany(p => p.Boat)
                    .HasForeignKey(d => d.ParkingCode)
                    .HasConstraintName("FK_boat_parking");
            });

            modelBuilder.Entity<BoatType>(entity =>
            {
                entity.ToTable("boatType");

                entity.Property(e => e.BoatTypeId).HasColumnName("boatTypeId");

                entity.Property(e => e.Chargeable)
                    .HasColumnName("chargeable")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Sail)
                    .HasColumnName("sail")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryCode)
                    .HasName("PK_country");

                entity.ToTable("country");

                entity.Property(e => e.CountryCode)
                    .HasColumnName("countryCode")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.PhonePattern)
                    .HasColumnName("phonePattern")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.PostalPattern)
                    .HasColumnName("postalPattern")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("member");

                entity.Property(e => e.MemberId)
                    .HasColumnName("memberId")
                    .ValueGeneratedNever();

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.FullName)
                    .HasColumnName("fullName")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.HomePhone)
                    .HasColumnName("homePhone")
                    .HasColumnType("char(12)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.PostalCode)
                    .HasColumnName("postalCode")
                    .HasColumnType("char(7)");

                entity.Property(e => e.ProvinceCode)
                    .HasColumnName("provinceCode")
                    .HasColumnType("char(2)");

                entity.Property(e => e.SpouseFirstName)
                    .HasColumnName("spouseFirstName")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SpouseLastName)
                    .HasColumnName("spouseLastName")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Street)
                    .HasColumnName("street")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.TaskExempt)
                    .HasColumnName("taskExempt")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.UseCanadaPost)
                    .HasColumnName("useCanadaPost")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.YearJoined).HasColumnName("yearJoined");

                entity.HasOne(d => d.ProvinceCodeNavigation)
                    .WithMany(p => p.Member)
                    .HasForeignKey(d => d.ProvinceCode)
                    .HasConstraintName("FK_member_province");
            });

            modelBuilder.Entity<MemberTask>(entity =>
            {
                entity.ToTable("memberTask");

                entity.Property(e => e.MemberTaskId).HasColumnName("memberTaskId");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.MemberId).HasColumnName("memberId");

                entity.Property(e => e.TaskId).HasColumnName("taskId");

                entity.Property(e => e.WednesdayDate)
                    .HasColumnName("wednesdayDate")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.MemberTask)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_memberTask_member");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.MemberTask)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK_memberTask_tasks");
            });

            modelBuilder.Entity<Membership>(entity =>
            {
                entity.ToTable("membership");

                entity.Property(e => e.MembershipId).HasColumnName("membershipId");

                entity.Property(e => e.Comments)
                    .HasColumnName("comments")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Fee).HasColumnName("fee");

                entity.Property(e => e.MemberId).HasColumnName("memberId");

                entity.Property(e => e.MembershipTypeName)
                    .IsRequired()
                    .HasColumnName("membershipTypeName")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Paid)
                    .HasColumnName("paid")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Membership)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_membership_member");

                entity.HasOne(d => d.MembershipTypeNameNavigation)
                    .WithMany(p => p.Membership)
                    .HasForeignKey(d => d.MembershipTypeName)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_membership_membershipType");
            });

            modelBuilder.Entity<MembershipType>(entity =>
            {
                entity.HasKey(e => e.MembershipTypeName)
                    .HasName("aaaaamembershipType_PK");

                entity.ToTable("membershipType");

                entity.Property(e => e.MembershipTypeName)
                    .HasColumnName("membershipTypeName")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.RatioToFull).HasColumnName("ratioToFull");
            });

            modelBuilder.Entity<Parking>(entity =>
            {
                entity.HasKey(e => e.ParkingCode)
                    .HasName("aaaaaparking_PK");

                entity.ToTable("parking");

                entity.Property(e => e.ParkingCode)
                    .HasColumnName("parkingCode")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ActualBoatId)
                    .HasColumnName("actualBoatId")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.BoatTypeId).HasColumnName("boatTypeId");

                entity.HasOne(d => d.BoatType)
                    .WithMany(p => p.Parking)
                    .HasForeignKey(d => d.BoatTypeId)
                    .HasConstraintName("FK_parking_boatType");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.HasKey(e => e.ProvinceCode)
                    .HasName("PK_province");

                entity.ToTable("province");

                entity.Property(e => e.ProvinceCode)
                    .HasColumnName("provinceCode")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Capital)
                    .HasColumnName("capital")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasColumnName("countryCode")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.TaxCode)
                    .HasColumnName("taxCode")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.TaxRate)
                    .HasColumnName("taxRate")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Province)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_province_country");
            });

            modelBuilder.Entity<Surcharge>(entity =>
            {
                entity.ToTable("surcharge");

                entity.Property(e => e.SurchargeId).HasColumnName("surchargeId");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.EndYear).HasColumnName("endYear");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.StartYear).HasColumnName("startYear");
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.HasKey(e => e.TaskId)
                    .HasName("aaaaatasks_PK");

                entity.ToTable("tasks");

                entity.Property(e => e.TaskId)
                    .HasColumnName("taskId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<Town>(entity =>
            {
                entity.HasKey(e => e.TownName)
                    .HasName("PK_town");

                entity.ToTable("town");

                entity.Property(e => e.TownName)
                    .HasColumnName("townName")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ProvinceCode)
                    .HasColumnName("provinceCode")
                    .HasColumnType("char(2)");

                entity.HasOne(d => d.ProvinceCodeNavigation)
                    .WithMany(p => p.Town)
                    .HasForeignKey(d => d.ProvinceCode)
                    .HasConstraintName("FK_town_province");
            });
        }

        public virtual DbSet<AnnualFeeStructure> AnnualFeeStructure { get; set; }
        public virtual DbSet<Boat> Boat { get; set; }
        public virtual DbSet<BoatType> BoatType { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<MemberTask> MemberTask { get; set; }
        public virtual DbSet<Membership> Membership { get; set; }
        public virtual DbSet<MembershipType> MembershipType { get; set; }
        public virtual DbSet<Parking> Parking { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<Surcharge> Surcharge { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<Town> Town { get; set; }
    }
}