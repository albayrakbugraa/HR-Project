using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BoostIK.DAL.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    PermissionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxDayCount = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.PermissionID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TradeName = table.Column<int>(type: "int", nullable: false),
                    MailExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxOffice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MersisNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<int>(type: "int", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MembershipEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ManagerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyID);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                    table.ForeignKey(
                        name: "FK_Departments_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionLimits",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionID = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaxDayCount = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionLimits", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PermissionLimits_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionLimits_Permissions_PermissionID",
                        column: x => x.PermissionID,
                        principalTable: "Permissions",
                        principalColumn: "PermissionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PersonelMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentificationNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DepartmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CompanyID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    City = table.Column<int>(type: "int", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DismissalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    AnnualLeave = table.Column<int>(type: "int", nullable: true),
                    RemaningAnnualLeave = table.Column<int>(type: "int", nullable: true),
                    MaritalStatus = table.Column<int>(type: "int", nullable: true),
                    SpouseEmploymentState = table.Column<int>(type: "int", nullable: true),
                    DegreeOfDisability = table.Column<int>(type: "int", nullable: true),
                    ChildrenCount = table.Column<int>(type: "int", nullable: true),
                    BloodGroup = table.Column<int>(type: "int", nullable: true),
                    EducationLevel = table.Column<int>(type: "int", nullable: true),
                    EmergencyPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyPersonPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsWorking = table.Column<bool>(type: "bit", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IBAN = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: true),
                    isPasswordChanged = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DayOffRequests",
                columns: table => new
                {
                    DayOffRequestID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonelID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionID = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DayCount = table.Column<int>(type: "int", nullable: false),
                    StartHour = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndHour = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HourCount = table.Column<double>(type: "float", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    ReplyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RestType = table.Column<int>(type: "int", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    RefuseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayOffRequests", x => x.DayOffRequestID);
                    table.ForeignKey(
                        name: "FK_DayOffRequests_AspNetUsers_PersonelID",
                        column: x => x.PersonelID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DayOffRequests_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID");
                    table.ForeignKey(
                        name: "FK_DayOffRequests_Permissions_PermissionID",
                        column: x => x.PermissionID,
                        principalTable: "Permissions",
                        principalColumn: "PermissionID");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonelID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyUnit = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    ReplyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    RefuseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Payments_AspNetUsers_PersonelID",
                        column: x => x.PersonelID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Payments_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID");
                });

            migrationBuilder.CreateTable(
                name: "Spendings",
                columns: table => new
                {
                    SpendingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyUnit = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfSpending = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    PersonelID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpendingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    RefuseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spendings", x => x.SpendingID);
                    table.ForeignKey(
                        name: "FK_Spendings_AspNetUsers_PersonelID",
                        column: x => x.PersonelID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Spendings_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10904629-caf7-4409-b6a9-324001fb85e5", "777c3d2e-89a9-4e99-8dca-0d2421ed2709", "Personel", "PERSONEL" },
                    { "391423bb-a16c-45bb-97c7-1862bc1a38ca", "9c77d58b-a069-4b44-aa89-780b0c40c60f", "Admin", "ADMIN" },
                    { "51a1fe7e-6e21-4adb-96ab-edfea9a93e15", "8ed6cd99-7b06-4901-8ec5-d2f3fadd36b6", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adress", "AnnualLeave", "BirthDate", "BloodGroup", "ChildrenCount", "City", "CompanyID", "ConcurrencyStamp", "CreationDate", "DegreeOfDisability", "DeleteDate", "DepartmentID", "DismissalDate", "EducationLevel", "Email", "EmailConfirmed", "EmergencyPerson", "EmergencyPersonPhone", "FirstName", "Gender", "IBAN", "IdentificationNumber", "ImagePath", "IsWorking", "LastName", "LockoutEnabled", "LockoutEnd", "MaritalStatus", "MobilePhone", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PersonelMail", "PhoneNumber", "PhoneNumberConfirmed", "Position", "PostCode", "RemaningAnnualLeave", "Salary", "SecondName", "SecurityStamp", "SpouseEmploymentState", "Status", "TwoFactorEnabled", "UpdateDate", "UserName", "WorkStartDate", "isPasswordChanged" },
                values: new object[] { "91e897d3-8ff7-4ce6-af2a-b5195f8d6f4e", 0, null, null, null, null, null, null, null, "bddb7c97-7a78-446d-ac4c-e687e5f8a6e9", new DateTime(2022, 10, 25, 1, 7, 45, 354, DateTimeKind.Local).AddTicks(5165), null, null, null, null, null, "admin@ikmerkezim.com", false, null, null, "Admin", null, null, null, "/images/users/account-add-photo.svg", true, "Admin", false, null, null, null, "ADMIN@IKMERKEZIM.COM", "ADMIN@IKMERKEZIM.COM", "AQAAAAEAACcQAAAAEKpyrdvmsPkODSCAljhCSJMJlvzQ/Mrbvkhxm4RP1kbHKFepD7AUAIs96OG40roakw==", null, "04542121212", false, "Site Yöneticisi", null, null, null, null, "7ac3ec9a-20ab-42d0-896e-93f1747c971d", null, true, false, null, "admin@ikmerkezim.com", null, false });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyID", "Adress", "City", "CompanyName", "CreationDate", "DeleteDate", "LogoPath", "MailExtension", "ManagerId", "MembershipEnd", "MersisNumber", "PhoneNumber", "Status", "TaxNumber", "TaxOffice", "TradeName", "UpdateDate", "WebsiteAdress" },
                values: new object[] { new Guid("5f1bf6a6-4a1f-410f-a07b-dc7dcd50a19b"), "Caferağa, Mühürdar Cd. No:76, 34710 Kadıköy/İstanbul", 34, "BilgeAdam", new DateTime(2022, 10, 25, 1, 7, 45, 352, DateTimeKind.Local).AddTicks(8800), null, "images/account-add-photo.svg", "@bilgeadam.com", null, new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, 0, null, null });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "PermissionID", "CreationDate", "DeleteDate", "Gender", "MaxDayCount", "Name", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { 5, new DateTime(2022, 10, 25, 1, 7, 45, 354, DateTimeKind.Local).AddTicks(7445), null, 1, 56, "Doğum İzni", true, null },
                    { 6, new DateTime(2022, 10, 25, 1, 7, 45, 354, DateTimeKind.Local).AddTicks(7447), null, 1, 56, "Doğum Sonrası İzni", true, null },
                    { 7, new DateTime(2022, 10, 25, 1, 7, 45, 354, DateTimeKind.Local).AddTicks(7449), null, 3, 3, "Vefat İzni", true, null },
                    { 3, new DateTime(2022, 10, 25, 1, 7, 45, 354, DateTimeKind.Local).AddTicks(7441), null, 3, 3, "Mazeret İzni", true, null },
                    { 9, new DateTime(2022, 10, 25, 1, 7, 45, 354, DateTimeKind.Local).AddTicks(7452), null, 2, 30, "Askerlik İzni", true, null },
                    { 10, new DateTime(2022, 10, 25, 1, 7, 45, 354, DateTimeKind.Local).AddTicks(7454), null, 2, 5, "Babalık İzni", true, null },
                    { 11, new DateTime(2022, 10, 25, 1, 7, 45, 354, DateTimeKind.Local).AddTicks(7456), null, 2, 4, "Yol İzni", true, null },
                    { 12, new DateTime(2022, 10, 25, 1, 7, 45, 354, DateTimeKind.Local).AddTicks(7512), null, 2, 999, "Saatlik", true, null },
                    { 2, new DateTime(2022, 10, 25, 1, 7, 45, 354, DateTimeKind.Local).AddTicks(7435), null, 3, 365, "Ücretsiz İzin", true, null },
                    { 1, new DateTime(2022, 10, 25, 1, 7, 45, 354, DateTimeKind.Local).AddTicks(6392), null, 3, 365, "Yıllık İzin", true, null },
                    { 4, new DateTime(2022, 10, 25, 1, 7, 45, 354, DateTimeKind.Local).AddTicks(7443), null, 3, 20, "Hastalık İzni", true, null },
                    { 8, new DateTime(2022, 10, 25, 1, 7, 45, 354, DateTimeKind.Local).AddTicks(7450), null, 3, 3, "Evlilik İzni", true, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "391423bb-a16c-45bb-97c7-1862bc1a38ca", "91e897d3-8ff7-4ce6-af2a-b5195f8d6f4e" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentID", "CompanyID", "CreationDate", "DeleteDate", "Name", "Status", "UpdateDate" },
                values: new object[] { new Guid("ec417f09-33f0-4ad7-b9f1-2631f6b0e442"), new Guid("5f1bf6a6-4a1f-410f-a07b-dc7dcd50a19b"), new DateTime(2022, 10, 25, 1, 7, 45, 352, DateTimeKind.Local).AddTicks(8800), null, "İnsan Kaynakları", true, null });

            migrationBuilder.InsertData(
                table: "PermissionLimits",
                columns: new[] { "ID", "CompanyID", "CreationDate", "DeleteDate", "MaxDayCount", "PermissionID", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new Guid("5f1bf6a6-4a1f-410f-a07b-dc7dcd50a19b"), new DateTime(2022, 10, 25, 1, 7, 45, 354, DateTimeKind.Local).AddTicks(8575), null, 365, 1, true, null },
                    { 2, new Guid("5f1bf6a6-4a1f-410f-a07b-dc7dcd50a19b"), new DateTime(2022, 10, 25, 1, 7, 45, 354, DateTimeKind.Local).AddTicks(8936), null, 365, 2, true, null },
                    { 3, new Guid("5f1bf6a6-4a1f-410f-a07b-dc7dcd50a19b"), new DateTime(2022, 10, 25, 1, 7, 45, 354, DateTimeKind.Local).AddTicks(8940), null, 3, 3, true, null },
                    { 4, new Guid("5f1bf6a6-4a1f-410f-a07b-dc7dcd50a19b"), new DateTime(2022, 10, 25, 1, 7, 45, 354, DateTimeKind.Local).AddTicks(8941), null, 20, 4, true, null },
                    { 5, new Guid("5f1bf6a6-4a1f-410f-a07b-dc7dcd50a19b"), new DateTime(2022, 10, 25, 1, 7, 45, 354, DateTimeKind.Local).AddTicks(8943), null, 56, 5, true, null },
                    { 6, new Guid("5f1bf6a6-4a1f-410f-a07b-dc7dcd50a19b"), new DateTime(2022, 10, 25, 1, 7, 45, 354, DateTimeKind.Local).AddTicks(8945), null, 56, 6, true, null },
                    { 7, new Guid("5f1bf6a6-4a1f-410f-a07b-dc7dcd50a19b"), new DateTime(2022, 10, 25, 1, 7, 45, 354, DateTimeKind.Local).AddTicks(8946), null, 3, 7, true, null },
                    { 8, new Guid("5f1bf6a6-4a1f-410f-a07b-dc7dcd50a19b"), new DateTime(2022, 10, 25, 1, 7, 45, 354, DateTimeKind.Local).AddTicks(8948), null, 3, 8, true, null },
                    { 9, new Guid("5f1bf6a6-4a1f-410f-a07b-dc7dcd50a19b"), new DateTime(2022, 10, 25, 1, 7, 45, 354, DateTimeKind.Local).AddTicks(8950), null, 30, 9, true, null },
                    { 10, new Guid("5f1bf6a6-4a1f-410f-a07b-dc7dcd50a19b"), new DateTime(2022, 10, 25, 1, 7, 45, 354, DateTimeKind.Local).AddTicks(8951), null, 5, 10, true, null },
                    { 11, new Guid("5f1bf6a6-4a1f-410f-a07b-dc7dcd50a19b"), new DateTime(2022, 10, 25, 1, 7, 45, 354, DateTimeKind.Local).AddTicks(8953), null, 4, 11, true, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adress", "AnnualLeave", "BirthDate", "BloodGroup", "ChildrenCount", "City", "CompanyID", "ConcurrencyStamp", "CreationDate", "DegreeOfDisability", "DeleteDate", "DepartmentID", "DismissalDate", "EducationLevel", "Email", "EmailConfirmed", "EmergencyPerson", "EmergencyPersonPhone", "FirstName", "Gender", "IBAN", "IdentificationNumber", "ImagePath", "IsWorking", "LastName", "LockoutEnabled", "LockoutEnd", "MaritalStatus", "MobilePhone", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PersonelMail", "PhoneNumber", "PhoneNumberConfirmed", "Position", "PostCode", "RemaningAnnualLeave", "Salary", "SecondName", "SecurityStamp", "SpouseEmploymentState", "Status", "TwoFactorEnabled", "UpdateDate", "UserName", "WorkStartDate", "isPasswordChanged" },
                values: new object[] { "76cd1492-a593-4e7c-a1fa-5fe5677d6a99", 0, "Acıbadem Mah. Çeçen Sk. No:25, 34660 Üsküdar", 14, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, null, 34, new Guid("5f1bf6a6-4a1f-410f-a07b-dc7dcd50a19b"), "813ac1a9-6bac-4915-9ac8-6eba581ecba0", new DateTime(2022, 10, 25, 1, 7, 45, 353, DateTimeKind.Local).AddTicks(8516), null, null, new Guid("ec417f09-33f0-4ad7-b9f1-2631f6b0e442"), null, 5, "beyazvesen@gmail.com", false, "Burak Kut", "5546663354", "Rober", 2, "TR330006100519786457841326", "01234567899", "/images/users/256_rsz_1andy-lee-642320-unsplash.jpg", true, "Hatemo", false, null, 1, "+905322563232", "BEYAZVESEN@GMAIL.COM", "BEYAZVESEN@gmail.com", "AQAAAAEAACcQAAAAEKpyrdvmsPkODSCAljhCSJMJlvzQ/Mrbvkhxm4RP1kbHKFepD7AUAIs96OG40roakw==", "beyazvesen@gmail.com", null, false, "Uzman Yardımcısı", "34335", 7, 10000m, null, "614ce7c3-13e5-45e3-bbd2-0ca7135e60d9", null, true, false, null, "beyazvesen@gmail.com", new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "10904629-caf7-4409-b6a9-324001fb85e5", "76cd1492-a593-4e7c-a1fa-5fe5677d6a99" });

            migrationBuilder.InsertData(
                table: "DayOffRequests",
                columns: new[] { "DayOffRequestID", "CompanyID", "CreationDate", "DayCount", "DeleteDate", "Description", "EndDate", "EndHour", "FilePath", "HourCount", "PermissionID", "PersonelID", "RefuseDescription", "ReplyDate", "RestType", "StartDate", "StartHour", "State", "Status", "UpdateDate" },
                values: new object[] { new Guid("398c3f95-93ef-4fd7-a7e3-83c68ee1cc22"), new Guid("5f1bf6a6-4a1f-410f-a07b-dc7dcd50a19b"), new DateTime(2022, 10, 25, 1, 7, 45, 355, DateTimeKind.Local).AddTicks(397), 10, null, "kafa dinlemek için izin istiyorum nolur verin", new DateTime(2022, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 1, "76cd1492-a593-4e7c-a1fa-5fe5677d6a99", null, null, 1, new DateTime(2022, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, true, null });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanyID",
                table: "AspNetUsers",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentID",
                table: "AspNetUsers",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ManagerId",
                table: "Companies",
                column: "ManagerId",
                unique: true,
                filter: "[ManagerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DayOffRequests_CompanyID",
                table: "DayOffRequests",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_DayOffRequests_PermissionID",
                table: "DayOffRequests",
                column: "PermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_DayOffRequests_PersonelID",
                table: "DayOffRequests",
                column: "PersonelID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CompanyID",
                table: "Departments",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CompanyID",
                table: "Payments",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PersonelID",
                table: "Payments",
                column: "PersonelID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionLimits_CompanyID",
                table: "PermissionLimits",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionLimits_PermissionID",
                table: "PermissionLimits",
                column: "PermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_Spendings_CompanyID",
                table: "Spendings",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Spendings_PersonelID",
                table: "Spendings",
                column: "PersonelID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_COMPANY_MANAGER",
                table: "Companies",
                column: "ManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COMPANY_MANAGER",
                table: "Companies");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DayOffRequests");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "PermissionLimits");

            migrationBuilder.DropTable(
                name: "Spendings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
