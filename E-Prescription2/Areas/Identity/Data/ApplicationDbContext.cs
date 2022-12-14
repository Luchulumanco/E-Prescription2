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
    
    public virtual DbSet<ActiveIngredientRecord>? ActiveIngredientRecords { get; set; }
    public virtual DbSet<DosageForm>? DosageForms { get; set; }
    public virtual DbSet<MedicationActiveIngredient>? MedicationActiveIngredient { get; set; }
    public virtual DbSet<Schedule>? Schedule { get; set; }
    public virtual DbSet<Condition>? Conditions { get; set; }
    public virtual DbSet<ContraIndication>? ContraIndications { get; set; }
   public virtual DbSet<Prescription>? Prescriptions { get; set; }
    public virtual DbSet<PrescriptionLine>? PrescriptionLines { get; set; }
    public virtual DbSet<DispenseDetails>? DispenseDetails { get; set; }
    public virtual DbSet<MedicationInteraction>? MedicationInteractions { get; set; }
    public virtual DbSet<DrugAllergy>? DrugAllergies { get; set; }
    public virtual DbSet<ChronicCondition>? ChricConditions { get; set; }
    public virtual DbSet<ChronicMedication>? ChronicMedications { get; set; }
    public virtual DbSet<Patient>? Patients { get; set; }
    public virtual DbSet<Doctor>? Doctors { get; set; }
    public virtual DbSet<Pharmacist>? Pharmacists { get; set; }

   
 


    protected override void OnModelCreating(ModelBuilder builder)
    {
        //Composite primary key for MedicationActiveIngredient
        //builder.Entity<MedicationActiveIngredient>()
        //    .HasKey(ba => new { ba.MedicationId, ba.ActiveIngredientId });
        //one-to-many relationship between MedicationRecords and MedicationRecordsActiveIngredient
        //builder.Entity<MedicationActiveIngredient>()
        //    .HasOne(ba => ba.MedicationRecords)
        //    .WithMany()
        //    .HasForeignKey(ba => ba.MedicationId);
        //one-to-many relationship between ActiveIngredientRecords and MedicationRecordsActiveIngredient
        builder.Entity<MedicationActiveIngredient>()
            .HasOne(ba => ba.ActiveIngredientRecord1)
            .WithMany()
            .HasForeignKey(ba => ba.ActiveIngredientId1);

        builder.Entity<MedicationActiveIngredient>()
            .HasOne(ba => ba.ActiveIngredientRecord2)
            .WithMany()
            .HasForeignKey(ba => ba.ActiveIngredientId2);

        builder.Entity<MedicationActiveIngredient>()
            .HasOne(ba => ba.ActiveIngredientRecord3)
            .WithMany()
            .HasForeignKey(ba => ba.ActiveIngredientId3);
        builder.Entity<MedicationActiveIngredient>()
            .HasOne(ba => ba.ActiveIngredientRecord4)
            .WithMany()
            .HasForeignKey(ba => ba.ActiveIngredientId4);

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
        //one-to-many relationship between Prescription and DoctorUser
        builder.Entity<Prescription>()
            .HasOne(ba => ba.DoctorUser)
            .WithMany()
            .HasForeignKey(ba => ba.DoctorId);
        //one-to-many relationship between Prescription and PatientUser
        builder.Entity<Prescription>()
            .HasOne(ba => ba.PatientUser)
            .WithMany()
            .HasForeignKey(ba => ba.PatientID);
        //one-to-many relationship between PrescriptionLine and MedicationActive
        builder.Entity<PrescriptionLine>()
            .HasOne(ba => ba.medicationActive)
            .WithMany()
            .HasForeignKey(ba => ba.MedicationId);
        //one-to-many relationship between PrescriptionLine and Dispense
        builder.Entity<PrescriptionLine>()
            .HasOne(ba => ba.dispenseDetails)
            .WithMany()
            .HasForeignKey(ba => ba.DispenseId);
        //one-to-many relationship between PrescriptionLine and MedicationActive
        builder.Entity<DispenseDetails>()
            .HasOne(ba => ba.PharmacistUser)
            .WithMany()
            .HasForeignKey(ba => ba.PharmacistId);
        //one-to-many relationship between PrescriptionLine and MedicationActive
        builder.Entity<DispenseDetails>()
            .HasOne(ba => ba.PharmacyRecords)
            .WithMany()
            .HasForeignKey(ba => ba.PharmacyId);
        //one-to-many relationship between ActiveIngredients and MedicationInteractions

        builder.Entity<MedicationInteraction>()
            .HasOne(ba => ba.ActiveIngredientOne)
            .WithMany()
            .HasForeignKey(ba => ba.ActiveOne);

        builder.Entity<MedicationInteraction>()
            .HasOne(ba=>ba.ActiveIngredientTwo)
            .WithMany()
            .HasForeignKey(ba=>ba.ActiveTwo);

        builder.Entity<DrugAllergy>()
            .HasOne(ba=>ba.ActiveIngredientRecords)
            .WithMany()
            .HasForeignKey(ba => ba.ActiveIngredientId);

        builder.Entity<DrugAllergy>()
            .HasOne(ba=>ba.User)
            .WithMany()
            .HasForeignKey(ba=>ba.UserId);

        builder.Entity<ChronicCondition>()
            .HasOne(ba=>ba.Conditions)
            .WithMany()
            .HasForeignKey(ba=>ba.ConditionId);

        builder.Entity<ChronicCondition>()
            .HasOne(ba => ba.User)
            .WithMany()
            .HasForeignKey(ba => ba.UserId);

        builder.Entity<ChronicMedication>()
            .HasOne(ba => ba.PatientUser)
            .WithMany()
            .HasForeignKey(ba => ba.UserId);
        builder.Entity<ChronicMedication>()
            .HasOne(ba => ba.MediActiveIngredient)
            .WithMany()
            .HasForeignKey(ba => ba.MedicationId);



        builder.Entity<City>()
            .HasOne(ba => ba.Provinces)
            .WithMany()
            .HasForeignKey(ba => ba.ProvinceId);
        builder.Entity<Province>();

        builder.Entity<Suburb>()
            .HasOne(ba => ba.Cities)
            .WithMany()
            .HasForeignKey(ba => ba.CityId);
        builder.Entity<Suburb>()
            .HasOne(ba => ba.PostalCodes)
            .WithMany()
            .HasForeignKey(ba => ba.PostalCodeId);
        builder.Entity<Prescription>()
            .HasOne(ba => ba.PrescriptionLines)
            .WithMany()
            .HasForeignKey(ba => ba.prescriptionLineId);

        







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
