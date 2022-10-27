using BoostIK.CORE.Entities;
using BoostIK.CORE.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BoostIK.DAL
{
    public class AppDbContext : IdentityDbContext<Personel>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Personel> Personels { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<DayOffRequest> DayOffRequests { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionLimit> PermissionLimits { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Spending> Spendings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // EntityConfigurations klasöründeki IEntityTypeConfiguration interfaceinden türetilen bütün configleri otomatik alacak
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            // ************** SEED DATA ************** //

            // ********* ROLES **********
            IdentityRole adminRole = new IdentityRole {Name = "Admin", NormalizedName = "ADMIN" };
            IdentityRole companyManager = new IdentityRole { Name = "Manager", NormalizedName = "MANAGER" };
            IdentityRole personelRole = new IdentityRole { Name = "Personel", NormalizedName = "PERSONEL" };
            builder.Entity<IdentityRole>().HasData(adminRole, companyManager, personelRole);

            ////Company
            Company company = new Company();
            company.CompanyID = new Guid("5f1bf6a6-4a1f-410f-a07b-dc7dcd50a19b");
            company.MailExtension = "@bilgeadam.com";
            company.CompanyName = "BilgeAdam";
            company.City = City.İstanbul;
            company.Adress = "Caferağa, Mühürdar Cd. No:76, 34710 Kadıköy/İstanbul";
            company.CreationDate = DateTime.Now;
            company.Status = true;
            company.MembershipEnd = new DateTime(2022, 12, 31);


            //Department
            Department department = new Department();
            department.DepartmentID = Guid.NewGuid();
            department.Name = "İnsan Kaynakları";
            department.CompanyID = company.CompanyID;
            department.CreationDate = company.CreationDate;
            department.Status = true;

            ////Personel
            Personel personel = new Personel();
            personel.Id = "76cd1492-a593-4e7c-a1fa-5fe5677d6a99";
            personel.FirstName = "Rober";
            personel.LastName = "Hatemo";
            personel.PersonelMail = "beyazvesen@gmail.com";
            personel.Email = "beyazvesen@gmail.com";
            personel.NormalizedEmail = "BEYAZVESEN@GMAIL.COM";
            personel.UserName = "beyazvesen@gmail.com";
            personel.NormalizedUserName = "BEYAZVESEN@gmail.com";
            personel.PasswordHash = "AQAAAAEAACcQAAAAEKpyrdvmsPkODSCAljhCSJMJlvzQ/Mrbvkhxm4RP1kbHKFepD7AUAIs96OG40roakw==";
            personel.IdentificationNumber = "01234567899";
            personel.Position = "Uzman Yardımcısı";
            personel.DepartmentID = department.DepartmentID;
            personel.CompanyID = company.CompanyID;
            personel.Salary = 10000;
            personel.City = City.İstanbul;
            personel.PostCode = "34335";
            personel.Adress = "Acıbadem Mah. Çeçen Sk. No:25, 34660 Üsküdar";
            personel.MobilePhone = "+905322563232";
            personel.BirthDate = new DateTime(1990, 1, 1);
            personel.WorkStartDate = new DateTime(2022, 2, 15);
            personel.ImagePath = "/images/users/256_rsz_1andy-lee-642320-unsplash.jpg";
            personel.Gender = Gender.Erkek;
            personel.AnnualLeave = 14;
            personel.RemaningAnnualLeave = 7;
            personel.MaritalStatus = MaritalStatus.Bekar;
            personel.BloodGroup = BloodGroup.ORhNegative;
            personel.EducationLevel = EducationLevel.Lisans;
            personel.EmergencyPerson = "Burak Kut";
            personel.EmergencyPersonPhone = "5546663354";
            personel.Status = true;
            personel.IBAN = "TR330006100519786457841326";
            personel.isPasswordChanged = false;

            //Admin
            Personel admin = new Personel();
            admin.Id = Guid.NewGuid().ToString();
            admin.FirstName = "Admin";
            admin.LastName = "Admin";
            admin.PhoneNumber = "04542121212";
            admin.UserName = "admin@ikmerkezim.com";
            admin.Email = "admin@ikmerkezim.com";
            admin.NormalizedEmail = "ADMIN@IKMERKEZIM.COM";
            admin.PasswordHash = "AQAAAAEAACcQAAAAEKpyrdvmsPkODSCAljhCSJMJlvzQ/Mrbvkhxm4RP1kbHKFepD7AUAIs96OG40roakw==";
            admin.NormalizedUserName = "ADMIN@IKMERKEZIM.COM";
            admin.Status = true;
            admin.isPasswordChanged = false;
            admin.Position = "Site Yöneticisi";


            builder.Entity<Company>().HasData(company);
            builder.Entity<Department>().HasData(department);
            builder.Entity<Personel>().HasData(personel);
            builder.Entity<Personel>().HasData(admin);
            builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = adminRole.Id,
                UserId = admin.Id,
            },
            new IdentityUserRole<string>
            {
                RoleId=personelRole.Id,
                UserId=personel.Id
            });


            builder.Entity<Permission>().HasData(
            new Permission()
            {
                PermissionID = 1,
                Name = "Yıllık İzin",
                MaxDayCount = 365,
                Gender = Gender.Hepsi,
                Status = true
            },
            new Permission()
            {
                PermissionID = 2,
                Name = "Ücretsiz İzin",
                MaxDayCount = 365,
                Gender = Gender.Hepsi,
                Status = true
            },
            new Permission()
            {
                PermissionID = 3,
                Name = "Mazeret İzni",
                MaxDayCount = 3,
                Gender = Gender.Hepsi,
                Status = true
            },
            new Permission()
            {
                PermissionID = 4,
                Name = "Hastalık İzni",
                MaxDayCount = 20,
                Gender = Gender.Hepsi,
                Status = true
            },
            new Permission()
            {
                PermissionID = 5,
                Name = "Doğum İzni",
                MaxDayCount = 56,
                Gender = Gender.Kadın,
                Status = true
            },
            new Permission()
            {
                PermissionID = 6,
                Name = "Doğum Sonrası İzni",
                MaxDayCount = 56,
                Gender = Gender.Kadın,
                Status = true
            },
            new Permission()
            {
                PermissionID = 7,
                Name = "Vefat İzni",
                MaxDayCount = 3,
                Gender = Gender.Hepsi,
                Status = true
            },
            new Permission()
            {
                PermissionID = 8,
                Name = "Evlilik İzni",
                MaxDayCount = 3,
                Gender = Gender.Hepsi,
                Status = true
            },
            new Permission()
            {
                PermissionID = 9,
                Name = "Askerlik İzni",
                MaxDayCount = 30,
                Gender = Gender.Erkek,
                Status = true
            },
            new Permission()
            {
                PermissionID = 10,
                Name = "Babalık İzni",
                MaxDayCount = 5,
                Gender = Gender.Erkek,
                Status = true
            },
            new Permission()
            {
                PermissionID = 11,
                Name = "Yol İzni",
                MaxDayCount = 4,
                Gender = Gender.Erkek,
                Status = true
            },
            new Permission()
            {
                PermissionID = 12,
                Name = "Saatlik",
                MaxDayCount = 999,
                Gender = Gender.Erkek,
                Status = true
            }
            );

            builder.Entity<PermissionLimit>().HasData(
                new PermissionLimit()
                {
                    ID = 1,
                    CompanyID = company.CompanyID,
                    PermissionID = 1,
                    MaxDayCount = 365,
                    CreationDate = DateTime.Now,
                    Status = true,
                },
                new PermissionLimit()
                {
                    ID = 2,
                    CompanyID = company.CompanyID,
                    PermissionID = 2,
                    MaxDayCount = 365,
                    CreationDate = DateTime.Now,
                    Status = true,
                },
                new PermissionLimit()
                {
                    ID = 3,
                    CompanyID = company.CompanyID,
                    PermissionID = 3,
                    MaxDayCount = 3,
                    CreationDate = DateTime.Now,
                    Status = true,
                },
                new PermissionLimit()
                {
                    ID = 4,
                    CompanyID = company.CompanyID,
                    PermissionID = 4,
                    MaxDayCount = 20,
                    CreationDate = DateTime.Now,
                    Status = true,
                },
                new PermissionLimit()
                {
                    ID = 5,
                    CompanyID = company.CompanyID,
                    PermissionID = 5,
                    MaxDayCount = 56,
                    CreationDate = DateTime.Now,
                    Status = true,
                },
                new PermissionLimit()
                {
                    ID = 6,
                    CompanyID = company.CompanyID,
                    PermissionID = 6,
                    MaxDayCount = 56,
                    CreationDate = DateTime.Now,
                    Status = true,
                },
                new PermissionLimit()
                {
                    ID = 7,
                    CompanyID = company.CompanyID,
                    PermissionID = 7,
                    MaxDayCount = 3,
                    CreationDate = DateTime.Now,
                    Status = true,
                },
                new PermissionLimit()
                {
                    ID = 8,
                    CompanyID = company.CompanyID,
                    PermissionID = 8,
                    MaxDayCount = 3,
                    CreationDate = DateTime.Now,
                    Status = true,
                },
                new PermissionLimit()
                {
                    ID = 9,
                    CompanyID = company.CompanyID,
                    PermissionID = 9,
                    MaxDayCount = 30,
                    CreationDate = DateTime.Now,
                    Status = true,
                },
                new PermissionLimit()
                {
                    ID = 10,
                    CompanyID = company.CompanyID,
                    PermissionID = 10,
                    MaxDayCount = 5,
                    CreationDate = DateTime.Now,
                    Status = true,
                },
                new PermissionLimit()
                {
                    ID = 11,
                    CompanyID = company.CompanyID,
                    PermissionID = 11,
                    MaxDayCount = 4,
                    CreationDate = DateTime.Now,
                    Status = true,
                }
                );

            builder.Entity<DayOffRequest>().HasData(
                new DayOffRequest()
                {
                    CompanyID = company.CompanyID,
                    CreationDate = DateTime.Now,
                    PersonelID = personel.Id,
                    PermissionID = 1,
                    DayCount = 10,
                    Description = "kafa dinlemek için izin istiyorum nolur verin",
                    StartDate = new DateTime(2022, 09,13),
                    EndDate = new DateTime(2022, 09,22),
                    RestType = RestType.Günlük,
                    State = RequestState.Bekliyor,
                }
                );

            base.OnModelCreating(builder);

        }
    }
}
