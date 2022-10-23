using E_Prescription2.Areas.Identity.Data;
using E_Prescription2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace E_Prescription2.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Gender>? Genders { get; set; }
    public virtual DbSet<Province>? Provinces { get; set; }
    public virtual DbSet<City>? Cities { get; set; }
    public virtual DbSet<Suburb>? Suburbs { get; set; }
    public virtual DbSet<PostalCode>? PostalCodes { get; set; }
    public virtual DbSet<MedicalPracticeRecord>? MedicalPracticeRecords { get; set; }
    public virtual DbSet<PharmacyRecord>? PharmacyRecords { get; set; }
    public virtual DbSet<MedicationRecord>? MedicationRecords { get; set; }
    public virtual DbSet<ActiveIngredientRecord>? ActiveIngredientRecords { get; set; }
    public virtual DbSet<DosageForm>? DosageForms { get; set; }
    public virtual DbSet<MedicationActiveIngredient>? MedicationActiveIngredient { get; set; }
    public virtual DbSet<Schedule>? Schedule { get; set; }
    public virtual DbSet<Condition>? Conditions { get; set; }
    public virtual DbSet<ContraIndication>? ContraIndications { get; set; }
   
   
 


    protected override void OnModelCreating(ModelBuilder builder)
    {
        //Composite primary key for MedicationActiveIngredient
        //builder.Entity<MedicationActiveIngredient>()
        //    .HasKey(ba => new { ba.MedicationId, ba.ActiveIngredientId });
        //one-to-many relationship between MedicationRecords and MedicationRecordsActiveIngredient
        builder.Entity<MedicationActiveIngredient>()
            .HasOne(ba => ba.MedicationRecords)
            .WithMany()
            .HasForeignKey(ba => ba.MedicationId);
        //one-to-many relationship between ActiveIngredientRecords and MedicationRecordsActiveIngredient
        builder.Entity<MedicationActiveIngredient>()
            .HasOne(ba => ba.ActiveIngredientRecords)
            .WithMany()
            .HasForeignKey(ba => ba.ActiveIngredientId);
        //one-to-many relationship between ActiveIngredientRecords and ContraIndication
        builder.Entity<ContraIndication>()
            .HasOne(ba => ba.ActiveIngredientRecords)
            .WithMany()
            .HasForeignKey(ba => ba.ActiveIngredientId);
        //one-to-many relationship between Condition and ContraIndication
        builder.Entity<ContraIndication>()
            .HasOne(ba => ba.Conditions)
            .WithMany()
            .HasForeignKey(ba => ba.ConditionId);

        
        //builder.Entity<City>()
        //    .HasOne(ba=>ba.Provinces)
        //    .WithMany()
        //    .HasForeignKey(ba=>ba.ProvinceId);
        //builder.Entity<Province>();

        //builder.Entity<Suburb>()
        //    .HasOne(ba => ba.Cities)
        //    .WithMany()
        //    .HasForeignKey(ba => ba.CityId);
        //builder.Entity<Suburb>()
        //    .HasOne(ba=>ba.PostalCodes)
        //    .WithMany()
        //    .HasForeignKey(ba=>ba.PostalCodeId);
        //builder.Entity<PostalCode>();
          
           





        base.OnModelCreating(builder);
        builder.HasDefaultSchema("Identity");
        builder.Entity<IdentityUser>(entity =>
        {
            entity.ToTable(name: "User");
        });
        builder.Entity<IdentityRole>(entity =>
        {
            entity.ToTable(name: "Role");
        });
        builder.Entity<IdentityUserRole<string>>(entity =>
        {
            entity.ToTable("UserRoles");
        });
        builder.Entity<IdentityUserClaim<string>>(entity =>
        {
            entity.ToTable("UserClaims");
        });
        builder.Entity<IdentityUserLogin<string>>(entity =>
        {
            entity.ToTable("UserLogins");
        });
        builder.Entity<IdentityRoleClaim<string>>(entity =>
        {
            entity.ToTable("RoleClaims");
        });
        builder.Entity<IdentityUserToken<string>>(entity =>
        {
            entity.ToTable("UserTokens");
        });
    }
}
