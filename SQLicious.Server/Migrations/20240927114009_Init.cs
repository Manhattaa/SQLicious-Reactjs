using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SQLicious.Server.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    MenuItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    MenuType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.MenuItemId);
                });

            migrationBuilder.CreateTable(
                name: "MenuPDFs",
                columns: table => new
                {
                    MenuPDFId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuType = table.Column<int>(type: "int", nullable: false),
                    PdfUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuPDFs", x => x.MenuPDFId);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    TableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.TableId);
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
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
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
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountOfCustomers = table.Column<int>(type: "int", nullable: false),
                    BookedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    TableId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "TableId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "JohnDoe@hotmail.com", "John", "Doe", null },
                    { 2, "eriksvensson@example.com", "Erik", "Svensson", null },
                    { 3, "fatimahassan@example.com", "Fatima", "Hassan", null },
                    { 4, "liwang@example.com", "Li", "Wang", null },
                    { 5, "carlosgarcia@example.com", "Carlos", "Garcia", null },
                    { 6, "annanilsson@example.com", "Anna", "Nilsson", null },
                    { 7, "omarali@example.com", "Omar", "Ali", null },
                    { 8, "sophiasmith@example.com", "Sophia", "Smith", null },
                    { 9, "bjornjohansson@example.com", "Björn", "Johansson", null },
                    { 10, "javierlopez@example.com", "Javier", "Lopez", null },
                    { 11, "laylaibrahim@example.com", "Layla", "Ibrahim", null },
                    { 12, "ameliabrown@example.com", "Amelia", "Brown", null },
                    { 13, "fengxu@example.com", "Feng", "Xu", null },
                    { 14, "jackwilson@example.com", "Jack", "Wilson", null },
                    { 15, "leenavirtanen@example.com", "Leena", "Virtanen", null },
                    { 16, "zainabkhan@example.com", "Zainab", "Khan", null },
                    { 17, "evaandersson@example.com", "Eva", "Andersson", null },
                    { 18, "sofiaperez@example.com", "Sofia", "Perez", null },
                    { 19, "weiyang@example.com", "Wei", "Yang", null },
                    { 20, "mohammedzaid@example.com", "Mohammed", "Zaid", null },
                    { 21, "luciamartinez@example.com", "Lucia", "Martinez", null },
                    { 22, "lichen@example.com", "Li", "Chen", null },
                    { 23, "jarikorhonen@example.com", "Jari", "Korhonen", null },
                    { 24, "miguellopez@example.com", "Miguel", "Lopez", null },
                    { 25, "isabellagarcia@example.com", "Isabella", "Garcia", null },
                    { 26, "xiazhou@example.com", "Xia", "Zhou", null },
                    { 27, "akiheikkinen@example.com", "Aki", "Heikkinen", null },
                    { 28, "fatimaali@example.com", "Fatima", "Ali", null },
                    { 29, "oliversmith@example.com", "Oliver", "Smith", null },
                    { 30, "zhangyang@example.com", "Zhang", "Yang", null },
                    { 31, "carlosgonzalez@example.com", "Carlos", "Gonzalez", null },
                    { 32, "samivirtanen@example.com", "Sami", "Virtanen", null },
                    { 33, "emilytaylor@example.com", "Emily", "Taylor", null },
                    { 34, "wangzhao@example.com", "Wang", "Zhao", null },
                    { 35, "bjornlarsson@example.com", "Björn", "Larsson", null },
                    { 36, "sophiadavies@example.com", "Sophia", "Davies", null },
                    { 37, "ahmedhassan@example.com", "Ahmed", "Hassan", null },
                    { 38, "aaravpatel@example.com", "Aarav", "Patel", null },
                    { 39, "annajohansson@example.com", "Anna", "Johansson", null },
                    { 40, "omarkhan@example.com", "Omar", "Khan", null },
                    { 41, "jacksmith@example.com", "Jack", "Smith", null },
                    { 42, "laylazaid@example.com", "Layla", "Zaid", null },
                    { 43, "sofiamartinez@example.com", "Sofia", "Martinez", null },
                    { 44, "eriknilsson@example.com", "Erik", "Nilsson", null },
                    { 45, "lixu@example.com", "Li", "Xu", null },
                    { 46, "johanlarsson@example.com", "Johan", "Larsson", null },
                    { 47, "emilydavies@example.com", "Emily", "Davies", null },
                    { 48, "johnwilson@example.com", "John", "Wilson", null },
                    { 49, "fengchen@example.com", "Feng", "Chen", null },
                    { 50, "ameliasmith@example.com", "Amelia", "Smith", null },
                    { 51, "isabellalopez@example.com", "Isabella", "Lopez", null },
                    { 52, "miguelperez@example.com", "Miguel", "Perez", null },
                    { 53, "leenavirtanen@example.com", "Leena", "Virtanen", null },
                    { 54, "yusufzaid@example.com", "Yusuf", "Zaid", null },
                    { 55, "larsandersson@example.com", "Lars", "Andersson", null },
                    { 56, "bjornandersson@example.com", "Björn", "Andersson", null },
                    { 57, "liyang@example.com", "Li", "Yang", null },
                    { 58, "zainabhassan@example.com", "Zainab", "Hassan", null },
                    { 59, "wangxu@example.com", "Wang", "Xu", null },
                    { 60, "xiayang@example.com", "Xia", "Yang", null },
                    { 61, "yusufkhan@example.com", "Yusuf", "Khan", null },
                    { 62, "omarali@example.com", "Omar", "Ali", null },
                    { 63, "carlosgarcia@example.com", "Carlos", "Garcia", null },
                    { 64, "xiachen@example.com", "Xia", "Chen", null },
                    { 65, "zhangchen@example.com", "Zhang", "Chen", null },
                    { 66, "isabellamartinez@example.com", "Isabella", "Martinez", null },
                    { 67, "yusufkhan@example.com", "Yusuf", "Khan", null },
                    { 68, "jarinieminen@example.com", "Jari", "Nieminen", null },
                    { 69, "tuulikorhonen@example.com", "Tuuli", "Korhonen", null },
                    { 70, "mikkomakinen@example.com", "Mikko", "Mäkinen", null },
                    { 71, "sofiagonzalez@example.com", "Sofia", "Gonzalez", null },
                    { 72, "leenavirtanen@example.com", "Leena", "Virtanen", null },
                    { 73, "zainabibrahim@example.com", "Zainab", "Ibrahim", null },
                    { 74, "akiheikkinen@example.com", "Aki", "Heikkinen", null },
                    { 75, "liyang@example.com", "Li", "Yang", null },
                    { 76, "zhangchen@example.com", "Zhang", "Chen", null },
                    { 77, "tuulimakinen@example.com", "Tuuli", "Mäkinen", null },
                    { 78, "lichen@example.com", "Li", "Chen", null },
                    { 79, "fatimazaid@example.com", "Fatima", "Zaid", null },
                    { 80, "ameliawilson@example.com", "Amelia", "Wilson", null },
                    { 81, "luciagonzalez@example.com", "Lucia", "Gonzalez", null },
                    { 82, "yusufhassan@example.com", "Yusuf", "Hassan", null },
                    { 83, "Alfredsmith@example.com", "Alfred", "Smith", null },
                    { 84, "JohannaKhan@example.com", "Johanna", "Khan", null },
                    { 85, "lasse@example.com", "Lars", "Andersson", null },
                    { 86, "bjorn@example.com", "Björn", "Andersson", null },
                    { 87, "deez@example.com", "Deez", "Nuts", null },
                    { 88, "sofia@examples.com", "Sofia", "Gonzalez", null },
                    { 89, "virtanen@example.com", "Leena", "Virtanen", null },
                    { 90, "zai@example.com", "Zainab", "Ibrahim", null },
                    { 91, "akke@yahoo.se", "Aki", "Heikkinen", null },
                    { 92, "dfaj@yahoo.se", "Lieee", "Yang", null },
                    { 93, "cheng@yahoo.se", "Zhang", "Chen", null },
                    { 94, "email@fun.com", "Tuuli", "Mäkinen", null },
                    { 95, "M@example.com", "Lao", "Chen", null },
                    { 96, "zaid@yahoo.se", "Fatima", "Zaid", null },
                    { 97, "amalie@example.com", "Amelia", "Wilson", null },
                    { 98, "sanktalucia@gmail.com", "Lucia", "Gonzalez", null },
                    { 99, "hassan@yahoo.se", "Yusuf", "Hassan", null },
                    { 100, "alfred@batman.se", "Alfred", "Nobel", null },
                    { 101, "carlosgonzalez@example.com", "Carlos", "Gonzalez", null },
                    { 102, "laylaibrahim@example.com", "Layla", "Ibrahim", null },
                    { 103, "zainabibrahim@example.com", "Zainab", "Ibrahim", null },
                    { 104, "mohammedzaid@example.com", "Mohammed", "Zaid", null },
                    { 105, "mikkomakinen@example.com", "Mikko", "Mäkinen", null },
                    { 106, "lucialopez@example.com", "Lucia", "Lopez", null },
                    { 107, "emilysmith@example.com", "Emily", "Smith", null },
                    { 108, "fatimaali@example.com", "Fatima", "Ali", null },
                    { 109, "yusufhassan@example.com", "Yusuf", "Hassan", null },
                    { 110, "evajohansson@example.com", "Eva", "Johansson", null },
                    { 111, "yusufkhan@example.com", "Yusuf", "Khan", null },
                    { 112, "miguellopez@example.com", "Miguel", "Lopez", null },
                    { 113, "tuulikorhonen@example.com", "Tuuli", "Korhonen", null },
                    { 114, "zainabali@example.com", "Zainab", "Ali", null },
                    { 115, "sophiataylor@example.com", "Sophia", "Taylor", null },
                    { 116, "carlosgonzalez@example.com", "Carlos", "Gonzalez", null },
                    { 117, "lisajohansson@example.com", "Lisa", "Johansson", null },
                    { 118, "emilybrown@example.com", "Emily", "Brown", null },
                    { 119, "zhangzhao@example.com", "Zhang", "Zhao", null },
                    { 120, "bjornnilsson@example.com", "Björn", "Nilsson", null },
                    { 121, "zainabhassan@example.com", "Zainab", "Hassan", null },
                    { 122, "carlosperez@example.com", "Carlos", "Perez", null },
                    { 123, "sophiamartinez@example.com", "Sophia", "Martinez", null },
                    { 124, "omarzaid@example.com", "Omar", "Zaid", null },
                    { 125, "mikkovirtanen@example.com", "Mikko", "Virtanen", null },
                    { 126, "erikjohansson@example.com", "Erik", "Johansson", null },
                    { 127, "bjornandersson@example.com", "Björn", "Andersson", null },
                    { 128, "fatimai@ibrahim.com", "Fatima", "Ibrahim", null },
                    { 129, "laylaali@example.com", "Layla", "Ali", null },
                    { 130, "leenakorhonen@example.com", "Leena", "Korhonen", null },
                    { 131, "akimakinen@example.com", "Aki", "Mäkinen", null },
                    { 132, "samivirtanen@example.com", "Sami", "Virtanen", null },
                    { 133, "fatimakhan@example.com", "Fatima", "Khan", null },
                    { 134, "carlosgonzalez@example.com", "Carlos", "Gonzalez", null },
                    { 135, "bjornandersson@example.com", "Björn", "Andersson", null },
                    { 136, "eriksvensson@example.com", "Erik", "Svensson", null },
                    { 137, "lizhou@example.com", "Li", "Zhou", null },
                    { 138, "xiaxu@example.com", "Xia", "Xu", null },
                    { 139, "ameliataylor@example.com", "Amelia", "Taylor", null },
                    { 140, "emilytaylor@example.com", "Emily", "Taylor", null },
                    { 141, "oliversmith@example.com", "Oliver", "Smith", null },
                    { 142, "zhangchen@example.com", "Zhang", "Chen", null },
                    { 143, "fatimahassan@example.com", "Fatima", "Hassan", null },
                    { 144, "zainabkhan@example.com", "Zainab", "Khan", null },
                    { 145, "leenamakinen@example.com", "Leena", "Mäkinen", null },
                    { 146, "sofiaperez@example.com", "Sofia", "Perez", null },
                    { 147, "zainabhassan@example.com", "Zainab", "Hassan", null },
                    { 148, "bjornnilsson@example.com", "Björn", "Nilsson", null },
                    { 149, "carlosgarcia@example.com", "Carlos", "Garcia", null },
                    { 150, "evajohansson@example.com", "Eva", "Johansson", null },
                    { 151, "jackdavies@example.com", "Jack", "Davies", null },
                    { 152, "xiaxu@example.com", "Xia", "Xu", null },
                    { 153, "omarkhan@example.com", "Omar", "Khan", null },
                    { 154, "lichen@example.com", "Li", "Chen", null },
                    { 155, "ameliasmith@example.com", "Amelia", "Smith", null },
                    { 156, "evalarsson@example.com", "Eva", "Larsson", null },
                    { 157, "leenanieminen@example.com", "Leena", "Nieminen", null },
                    { 158, "fatimakhan@example.com", "Fatima", "Khan", null },
                    { 159, "sophiasmith@example.com", "Sophia", "Smith", null },
                    { 160, "zhangzhou@example.com", "Zhang", "Zhou", null },
                    { 161, "ameliadavies@example.com", "Amelia", "Davies", null },
                    { 162, "eriksvensson@example.com", "Erik", "Svensson", null },
                    { 163, "zainabkhan@example.com", "Zainab", "Khan", null },
                    { 164, "xiaxu@example.com", "Xia", "Xu", null },
                    { 165, "annaandersson@example.com", "Anna", "Andersson", null },
                    { 166, "lucialopez@example.com", "Lucia", "Lopez", null },
                    { 167, "ameliataylor@example.com", "Amelia", "Taylor", null },
                    { 168, "samiheikkinen@example.com", "Sami", "Heikkinen", null },
                    { 169, "luciagarcia@example.com", "Lucia", "Garcia", null },
                    { 170, "bjornlarsson@example.com", "Björn", "Larsson", null },
                    { 171, "sophiataylor@example.com", "Sophia", "Taylor", null },
                    { 172, "ameliasmith@example.com", "Amelia", "Smith", null },
                    { 173, "liyang@example.com", "Li", "Yang", null },
                    { 174, "mohammedzaid@example.com", "Mohammed", "Zaid", null },
                    { 175, "tuulikorhonen@example.com", "Tuuli", "Korhonen", null },
                    { 176, "fengzhou@example.com", "Feng", "Zhou", null },
                    { 177, "bjornsensson@example.com", "Björn", "Svensson", null },
                    { 178, "sophiataylor@example.com", "Sophia", "Taylor", null },
                    { 179, "larssvensson@example.com", "Lars", "Svensson", null },
                    { 180, "leenamakinen@example.com", "Leena", "Mäkinen", null },
                    { 181, "annajohansson@example.com", "Anna", "Johansson", null },
                    { 182, "samimakinen@example.com", "Sami", "Mäkinen", null },
                    { 183, "isabellagarcia@example.com", "Isabella", "Garcia", null },
                    { 184, "eriknilsson@example.com", "Erik", "Nilsson", null },
                    { 185, "larsnilsson@example.com", "Lars", "Nilsson", null },
                    { 186, "jackbrown@example.com", "Jack", "Brown", null },
                    { 187, "tuulinieminen@example.com", "Tuuli", "Nieminen", null },
                    { 188, "leenaheikkinen@example.com", "Leena", "Heikkinen", null },
                    { 189, "evanilsson@example.com", "Eva", "Nilsson", null },
                    { 190, "larssvensson@example.com", "Lars", "Svensson", null },
                    { 191, "zainabibrahim@example.com", "Zainab", "Ibrahim", null },
                    { 192, "saminieminen@example.com", "Sami", "Nieminen", null },
                    { 193, "johntaylor@example.com", "John", "Taylor", null },
                    { 194, "eriknilsson@example.com", "Erik", "Nilsson", null },
                    { 195, "carlosgarcia@example.com", "Carlos", "Garcia", null },
                    { 196, "johndavies@example.com", "John", "Davies", null },
                    { 197, "zhangzhou@example.com", "Zhang", "Zhou", null },
                    { 198, "zhangzhao@example.com", "Zhang", "Zhao", null },
                    { 199, "emilybrown@example.com", "Emily", "Brown", null },
                    { 200, "mohammedkhan@example.com", "Mohammed", "Khan", null },
                    { 201, "jarinieminen@example.com", "Jari", "Nieminen", null },
                    { 202, "lizhao@example.com", "Li", "Zhao", null },
                    { 203, "emilytaylor@example.com", "Emily", "Taylor", null },
                    { 204, "ameliabrown@example.com", "Amelia", "Brown", null },
                    { 205, "fatimazaid@example.com", "Fatima", "Zaid", null },
                    { 206, "xiaxu@example.com", "Xia", "Xu", null },
                    { 207, "tuulimakinen@example.com", "Tuuli", "Mäkinen", null },
                    { 208, "johnbrown@example.com", "John", "Brown", null },
                    { 209, "ameliabrown@example.com", "Amelia", "Brown", null },
                    { 210, "johntaylor@example.com", "John", "Taylor", null },
                    { 211, "bjornandersson@example.com", "Björn", "Andersson", null },
                    { 212, "mikkonieminen@example.com", "Mikko", "Nieminen", null },
                    { 213, "omarali@example.com", "Omar", "Ali", null },
                    { 214, "fatimazaid@example.com", "Fatima", "Zaid", null },
                    { 215, "fengzhou@example.com", "Feng", "Zhou", null },
                    { 216, "lizhou@example.com", "Li", "Zhou", null },
                    { 217, "zainabkhan@example.com", "Zainab", "Khan", null },
                    { 218, "sophiataylor@example.com", "Sophia", "Taylor", null },
                    { 219, "sofiaperez@example.com", "Sofia", "Perez", null },
                    { 220, "bjornlarsson@example.com", "Björn", "Larsson", null },
                    { 221, "mohammedkhan@example.com", "Mohammed", "Khan", null },
                    { 222, "zainabhassan@example.com", "Zainab", "Hassan", null },
                    { 223, "fengchen@example.com", "Feng", "Chen", null },
                    { 224, "wangchen@example.com", "Wang", "Chen", null },
                    { 225, "mikkoheikkinen@example.com", "Mikko", "Heikkinen", null },
                    { 226, "zainabkhan@example.com", "Zainab", "Khan", null },
                    { 227, "samimakinen@example.com", "Sami", "Mäkinen", null },
                    { 228, "sophiabrown@example.com", "Sophia", "Brown", null },
                    { 229, "oliversmith@example.com", "Oliver", "Smith", null },
                    { 230, "sophiataylor@example.com", "Sophia", "Taylor", null },
                    { 231, "annasvensson@example.com", "Anna", "Svensson", null },
                    { 232, "wangchen@example.com", "Wang", "Chen", null },
                    { 233, "mohammedkhan@example.com", "Mohammed", "Khan", null },
                    { 234, "sofiaperez@example.com", "Sofia", "Perez", null },
                    { 235, "miguelperez@example.com", "Miguel", "Perez", null },
                    { 236, "xiayang@example.com", "Xia", "Yang", null },
                    { 237, "evaandersson@example.com", "Eva", "Andersson", null },
                    { 238, "weiyang@example.com", "Wei", "Yang", null },
                    { 239, "tuulivirtanen@example.com", "Tuuli", "Virtanen", null },
                    { 240, "ameliasmith@example.com", "Amelia", "Smith", null },
                    { 241, "tuulivirtanen@example.com", "Tuuli", "Virtanen", null },
                    { 242, "saminieminen@example.com", "Sami", "Nieminen", null },
                    { 243, "samikorhonen@example.com", "Sami", "Korhonen", null },
                    { 244, "fengzhou@example.com", "Feng", "Zhou", null },
                    { 245, "emilysmith@example.com", "Emily", "Smith", null },
                    { 246, "evajohansson@example.com", "Eva", "Johansson", null },
                    { 247, "xiazhao@example.com", "Xia", "Zhao", null },
                    { 248, "emilydavies@example.com", "Emily", "Davies", null },
                    { 249, "luciagarcia@example.com", "Lucia", "Garcia", null },
                    { 250, "xiachen@example.com", "Xia", "Chen", null }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "TableId", "Capacity", "IsAvailable" },
                values: new object[,]
                {
                    { 1, 6, true },
                    { 2, 6, true },
                    { 3, 4, true },
                    { 4, 4, true },
                    { 5, 4, true },
                    { 6, 4, true },
                    { 7, 4, true },
                    { 8, 4, true },
                    { 9, 4, true },
                    { 10, 4, true },
                    { 11, 4, true },
                    { 12, 8, true },
                    { 13, 8, true },
                    { 14, 8, true }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "AmountOfCustomers", "BookedDateTime", "CustomerId", "TableId" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2024, 11, 15, 12, 30, 0, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 2, 2, new DateTime(2024, 10, 22, 18, 0, 0, 0, DateTimeKind.Unspecified), 2, 7 },
                    { 3, 3, new DateTime(2024, 9, 27, 13, 0, 0, 0, DateTimeKind.Unspecified), 3, 4 },
                    { 4, 3, new DateTime(2024, 9, 27, 14, 0, 0, 0, DateTimeKind.Unspecified), 4, 10 },
                    { 5, 3, new DateTime(2024, 9, 27, 14, 30, 0, 0, DateTimeKind.Unspecified), 5, 4 },
                    { 6, 2, new DateTime(2024, 9, 27, 15, 0, 0, 0, DateTimeKind.Unspecified), 6, 7 },
                    { 7, 4, new DateTime(2024, 9, 27, 16, 0, 0, 0, DateTimeKind.Unspecified), 7, 4 },
                    { 8, 2, new DateTime(2024, 9, 27, 16, 30, 0, 0, DateTimeKind.Unspecified), 8, 6 },
                    { 9, 3, new DateTime(2024, 9, 27, 17, 30, 0, 0, DateTimeKind.Unspecified), 9, 8 },
                    { 10, 4, new DateTime(2024, 9, 27, 18, 0, 0, 0, DateTimeKind.Unspecified), 10, 3 },
                    { 11, 4, new DateTime(2024, 9, 27, 19, 0, 0, 0, DateTimeKind.Unspecified), 11, 7 },
                    { 12, 7, new DateTime(2024, 9, 27, 19, 30, 0, 0, DateTimeKind.Unspecified), 12, 12 },
                    { 13, 6, new DateTime(2024, 9, 27, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 13 },
                    { 14, 8, new DateTime(2024, 9, 27, 21, 0, 0, 0, DateTimeKind.Unspecified), 14, 14 },
                    { 15, 7, new DateTime(2024, 9, 28, 7, 0, 0, 0, DateTimeKind.Unspecified), 15, 13 },
                    { 16, 6, new DateTime(2024, 9, 28, 7, 30, 0, 0, DateTimeKind.Unspecified), 16, 13 },
                    { 17, 7, new DateTime(2024, 9, 28, 8, 30, 0, 0, DateTimeKind.Unspecified), 17, 13 },
                    { 18, 7, new DateTime(2024, 9, 28, 9, 30, 0, 0, DateTimeKind.Unspecified), 18, 12 },
                    { 19, 6, new DateTime(2024, 9, 28, 10, 0, 0, 0, DateTimeKind.Unspecified), 19, 12 },
                    { 20, 6, new DateTime(2024, 9, 28, 11, 0, 0, 0, DateTimeKind.Unspecified), 20, 13 },
                    { 21, 6, new DateTime(2024, 9, 28, 11, 30, 0, 0, DateTimeKind.Unspecified), 21, 12 },
                    { 22, 7, new DateTime(2024, 9, 28, 12, 30, 0, 0, DateTimeKind.Unspecified), 22, 13 },
                    { 23, 8, new DateTime(2024, 9, 28, 13, 30, 0, 0, DateTimeKind.Unspecified), 23, 14 },
                    { 24, 6, new DateTime(2024, 9, 28, 14, 0, 0, 0, DateTimeKind.Unspecified), 24, 14 },
                    { 25, 7, new DateTime(2024, 9, 28, 15, 0, 0, 0, DateTimeKind.Unspecified), 25, 14 },
                    { 26, 7, new DateTime(2024, 9, 28, 16, 0, 0, 0, DateTimeKind.Unspecified), 26, 13 },
                    { 27, 8, new DateTime(2024, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), 27, 14 },
                    { 28, 6, new DateTime(2024, 9, 28, 18, 0, 0, 0, DateTimeKind.Unspecified), 28, 12 },
                    { 29, 7, new DateTime(2024, 9, 28, 19, 0, 0, 0, DateTimeKind.Unspecified), 29, 12 },
                    { 30, 8, new DateTime(2024, 9, 28, 20, 0, 0, 0, DateTimeKind.Unspecified), 30, 14 },
                    { 31, 7, new DateTime(2024, 9, 28, 21, 0, 0, 0, DateTimeKind.Unspecified), 31, 14 },
                    { 32, 6, new DateTime(2024, 9, 29, 7, 0, 0, 0, DateTimeKind.Unspecified), 32, 14 },
                    { 33, 7, new DateTime(2024, 9, 29, 7, 30, 0, 0, DateTimeKind.Unspecified), 33, 12 },
                    { 34, 6, new DateTime(2024, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), 34, 12 },
                    { 35, 6, new DateTime(2024, 9, 29, 8, 30, 0, 0, DateTimeKind.Unspecified), 35, 12 },
                    { 36, 7, new DateTime(2024, 9, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), 36, 14 },
                    { 37, 8, new DateTime(2024, 9, 29, 10, 0, 0, 0, DateTimeKind.Unspecified), 37, 12 },
                    { 38, 6, new DateTime(2024, 9, 29, 11, 0, 0, 0, DateTimeKind.Unspecified), 38, 14 },
                    { 39, 7, new DateTime(2024, 9, 29, 11, 30, 0, 0, DateTimeKind.Unspecified), 39, 14 },
                    { 40, 8, new DateTime(2024, 9, 29, 12, 30, 0, 0, DateTimeKind.Unspecified), 40, 14 },
                    { 41, 6, new DateTime(2024, 9, 29, 13, 30, 0, 0, DateTimeKind.Unspecified), 41, 14 },
                    { 42, 7, new DateTime(2024, 9, 29, 14, 0, 0, 0, DateTimeKind.Unspecified), 42, 14 },
                    { 43, 8, new DateTime(2024, 9, 29, 15, 0, 0, 0, DateTimeKind.Unspecified), 43, 14 },
                    { 44, 7, new DateTime(2024, 9, 29, 16, 0, 0, 0, DateTimeKind.Unspecified), 44, 14 },
                    { 45, 6, new DateTime(2024, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), 45, 14 },
                    { 46, 7, new DateTime(2024, 9, 29, 18, 0, 0, 0, DateTimeKind.Unspecified), 46, 14 },
                    { 47, 8, new DateTime(2024, 9, 29, 19, 0, 0, 0, DateTimeKind.Unspecified), 47, 14 },
                    { 48, 6, new DateTime(2024, 9, 29, 20, 0, 0, 0, DateTimeKind.Unspecified), 48, 14 },
                    { 49, 7, new DateTime(2024, 9, 29, 21, 0, 0, 0, DateTimeKind.Unspecified), 49, 14 },
                    { 50, 8, new DateTime(2024, 9, 30, 7, 0, 0, 0, DateTimeKind.Unspecified), 50, 14 },
                    { 51, 7, new DateTime(2024, 9, 30, 7, 30, 0, 0, DateTimeKind.Unspecified), 51, 14 },
                    { 52, 6, new DateTime(2024, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), 52, 14 },
                    { 53, 7, new DateTime(2024, 9, 30, 8, 30, 0, 0, DateTimeKind.Unspecified), 53, 14 },
                    { 54, 8, new DateTime(2024, 9, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), 54, 14 },
                    { 55, 6, new DateTime(2024, 9, 30, 10, 0, 0, 0, DateTimeKind.Unspecified), 55, 14 },
                    { 56, 7, new DateTime(2024, 9, 30, 11, 0, 0, 0, DateTimeKind.Unspecified), 56, 14 },
                    { 57, 8, new DateTime(2024, 9, 30, 11, 30, 0, 0, DateTimeKind.Unspecified), 57, 14 },
                    { 58, 6, new DateTime(2024, 9, 30, 12, 30, 0, 0, DateTimeKind.Unspecified), 58, 14 },
                    { 59, 7, new DateTime(2024, 9, 30, 13, 30, 0, 0, DateTimeKind.Unspecified), 59, 14 },
                    { 60, 8, new DateTime(2024, 9, 30, 14, 0, 0, 0, DateTimeKind.Unspecified), 60, 14 },
                    { 61, 7, new DateTime(2024, 9, 30, 15, 0, 0, 0, DateTimeKind.Unspecified), 61, 14 },
                    { 62, 6, new DateTime(2024, 9, 30, 16, 0, 0, 0, DateTimeKind.Unspecified), 62, 14 },
                    { 63, 7, new DateTime(2024, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), 63, 14 },
                    { 64, 8, new DateTime(2024, 9, 30, 18, 0, 0, 0, DateTimeKind.Unspecified), 64, 14 },
                    { 65, 6, new DateTime(2024, 9, 30, 19, 0, 0, 0, DateTimeKind.Unspecified), 65, 14 },
                    { 66, 7, new DateTime(2024, 9, 30, 20, 0, 0, 0, DateTimeKind.Unspecified), 66, 14 },
                    { 67, 8, new DateTime(2024, 9, 30, 21, 0, 0, 0, DateTimeKind.Unspecified), 67, 14 },
                    { 68, 6, new DateTime(2024, 10, 1, 7, 0, 0, 0, DateTimeKind.Unspecified), 68, 14 },
                    { 69, 7, new DateTime(2024, 10, 1, 7, 30, 0, 0, DateTimeKind.Unspecified), 69, 14 },
                    { 70, 8, new DateTime(2024, 10, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 70, 14 },
                    { 71, 6, new DateTime(2024, 10, 1, 8, 30, 0, 0, DateTimeKind.Unspecified), 71, 14 },
                    { 72, 7, new DateTime(2024, 10, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 72, 14 },
                    { 73, 8, new DateTime(2024, 10, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 73, 14 },
                    { 74, 6, new DateTime(2024, 10, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), 74, 14 },
                    { 75, 7, new DateTime(2024, 10, 1, 11, 30, 0, 0, DateTimeKind.Unspecified), 75, 14 },
                    { 76, 8, new DateTime(2024, 10, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), 76, 14 },
                    { 77, 6, new DateTime(2024, 10, 1, 13, 30, 0, 0, DateTimeKind.Unspecified), 77, 14 },
                    { 78, 7, new DateTime(2024, 10, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), 78, 14 },
                    { 79, 8, new DateTime(2024, 10, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), 79, 14 },
                    { 80, 7, new DateTime(2024, 10, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), 80, 14 },
                    { 81, 7, new DateTime(2024, 9, 27, 13, 0, 0, 0, DateTimeKind.Unspecified), 81, 12 },
                    { 82, 6, new DateTime(2024, 9, 27, 13, 30, 0, 0, DateTimeKind.Unspecified), 82, 14 },
                    { 83, 7, new DateTime(2024, 9, 27, 14, 30, 0, 0, DateTimeKind.Unspecified), 83, 13 },
                    { 84, 8, new DateTime(2024, 9, 27, 15, 30, 0, 0, DateTimeKind.Unspecified), 84, 12 },
                    { 85, 6, new DateTime(2024, 9, 27, 16, 0, 0, 0, DateTimeKind.Unspecified), 85, 14 },
                    { 86, 7, new DateTime(2024, 9, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), 86, 13 },
                    { 87, 6, new DateTime(2024, 9, 27, 17, 30, 0, 0, DateTimeKind.Unspecified), 87, 14 },
                    { 88, 8, new DateTime(2024, 9, 27, 18, 30, 0, 0, DateTimeKind.Unspecified), 88, 12 },
                    { 89, 8, new DateTime(2024, 9, 27, 19, 30, 0, 0, DateTimeKind.Unspecified), 89, 13 },
                    { 90, 8, new DateTime(2024, 9, 27, 20, 0, 0, 0, DateTimeKind.Unspecified), 90, 12 },
                    { 91, 7, new DateTime(2024, 9, 27, 21, 0, 0, 0, DateTimeKind.Unspecified), 91, 12 },
                    { 92, 8, new DateTime(2024, 9, 27, 21, 30, 0, 0, DateTimeKind.Unspecified), 92, 14 },
                    { 93, 8, new DateTime(2024, 9, 28, 7, 0, 0, 0, DateTimeKind.Unspecified), 93, 12 },
                    { 94, 7, new DateTime(2024, 9, 28, 7, 30, 0, 0, DateTimeKind.Unspecified), 94, 14 },
                    { 95, 8, new DateTime(2024, 9, 28, 8, 0, 0, 0, DateTimeKind.Unspecified), 95, 12 },
                    { 96, 6, new DateTime(2024, 9, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), 96, 14 },
                    { 97, 6, new DateTime(2024, 9, 28, 9, 30, 0, 0, DateTimeKind.Unspecified), 97, 13 },
                    { 98, 7, new DateTime(2024, 9, 28, 10, 30, 0, 0, DateTimeKind.Unspecified), 98, 14 },
                    { 99, 6, new DateTime(2024, 9, 28, 11, 30, 0, 0, DateTimeKind.Unspecified), 99, 12 },
                    { 100, 8, new DateTime(2024, 9, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), 100, 12 },
                    { 101, 6, new DateTime(2024, 9, 28, 12, 30, 0, 0, DateTimeKind.Unspecified), 101, 14 },
                    { 102, 6, new DateTime(2024, 9, 28, 13, 30, 0, 0, DateTimeKind.Unspecified), 102, 12 },
                    { 103, 6, new DateTime(2024, 9, 28, 14, 0, 0, 0, DateTimeKind.Unspecified), 103, 13 },
                    { 104, 7, new DateTime(2024, 9, 28, 15, 0, 0, 0, DateTimeKind.Unspecified), 104, 12 },
                    { 105, 8, new DateTime(2024, 9, 28, 16, 0, 0, 0, DateTimeKind.Unspecified), 105, 13 },
                    { 106, 6, new DateTime(2024, 9, 28, 16, 30, 0, 0, DateTimeKind.Unspecified), 106, 14 },
                    { 107, 7, new DateTime(2024, 9, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), 107, 13 },
                    { 108, 8, new DateTime(2024, 9, 28, 18, 0, 0, 0, DateTimeKind.Unspecified), 108, 14 },
                    { 109, 7, new DateTime(2024, 9, 28, 18, 30, 0, 0, DateTimeKind.Unspecified), 109, 12 },
                    { 110, 6, new DateTime(2024, 9, 28, 19, 30, 0, 0, DateTimeKind.Unspecified), 110, 13 },
                    { 111, 7, new DateTime(2024, 9, 28, 20, 0, 0, 0, DateTimeKind.Unspecified), 111, 14 },
                    { 112, 6, new DateTime(2024, 9, 28, 21, 0, 0, 0, DateTimeKind.Unspecified), 112, 12 },
                    { 113, 6, new DateTime(2024, 9, 28, 21, 30, 0, 0, DateTimeKind.Unspecified), 113, 14 },
                    { 114, 7, new DateTime(2024, 9, 29, 7, 0, 0, 0, DateTimeKind.Unspecified), 114, 12 },
                    { 115, 8, new DateTime(2024, 9, 29, 7, 30, 0, 0, DateTimeKind.Unspecified), 115, 13 },
                    { 116, 6, new DateTime(2024, 9, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), 116, 11 },
                    { 117, 7, new DateTime(2024, 9, 29, 8, 30, 0, 0, DateTimeKind.Unspecified), 117, 12 },
                    { 118, 8, new DateTime(2024, 9, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), 118, 13 },
                    { 119, 6, new DateTime(2024, 9, 29, 10, 0, 0, 0, DateTimeKind.Unspecified), 119, 14 },
                    { 120, 7, new DateTime(2024, 9, 29, 11, 0, 0, 0, DateTimeKind.Unspecified), 120, 12 },
                    { 121, 8, new DateTime(2024, 9, 29, 11, 30, 0, 0, DateTimeKind.Unspecified), 121, 13 },
                    { 122, 6, new DateTime(2024, 9, 29, 12, 30, 0, 0, DateTimeKind.Unspecified), 122, 14 },
                    { 123, 7, new DateTime(2024, 9, 29, 13, 30, 0, 0, DateTimeKind.Unspecified), 123, 12 },
                    { 124, 6, new DateTime(2024, 9, 29, 14, 0, 0, 0, DateTimeKind.Unspecified), 124, 2 },
                    { 125, 7, new DateTime(2024, 9, 29, 15, 0, 0, 0, DateTimeKind.Unspecified), 125, 3 },
                    { 126, 8, new DateTime(2024, 9, 29, 16, 0, 0, 0, DateTimeKind.Unspecified), 126, 4 },
                    { 127, 6, new DateTime(2024, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), 127, 5 },
                    { 128, 7, new DateTime(2024, 9, 29, 18, 0, 0, 0, DateTimeKind.Unspecified), 128, 6 },
                    { 129, 8, new DateTime(2024, 9, 29, 19, 0, 0, 0, DateTimeKind.Unspecified), 129, 7 },
                    { 130, 6, new DateTime(2024, 9, 29, 20, 0, 0, 0, DateTimeKind.Unspecified), 130, 8 },
                    { 131, 7, new DateTime(2024, 9, 29, 21, 0, 0, 0, DateTimeKind.Unspecified), 131, 9 },
                    { 132, 8, new DateTime(2024, 9, 30, 7, 0, 0, 0, DateTimeKind.Unspecified), 132, 10 },
                    { 133, 6, new DateTime(2024, 9, 30, 7, 30, 0, 0, DateTimeKind.Unspecified), 133, 11 },
                    { 134, 7, new DateTime(2024, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), 134, 12 },
                    { 135, 8, new DateTime(2024, 9, 30, 8, 30, 0, 0, DateTimeKind.Unspecified), 135, 13 },
                    { 136, 6, new DateTime(2024, 9, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), 136, 14 },
                    { 137, 7, new DateTime(2024, 9, 30, 10, 0, 0, 0, DateTimeKind.Unspecified), 137, 2 },
                    { 138, 8, new DateTime(2024, 9, 30, 11, 0, 0, 0, DateTimeKind.Unspecified), 138, 3 },
                    { 139, 6, new DateTime(2024, 9, 30, 11, 30, 0, 0, DateTimeKind.Unspecified), 139, 4 },
                    { 140, 7, new DateTime(2024, 9, 30, 12, 30, 0, 0, DateTimeKind.Unspecified), 140, 5 },
                    { 141, 8, new DateTime(2024, 9, 30, 13, 30, 0, 0, DateTimeKind.Unspecified), 141, 6 },
                    { 142, 6, new DateTime(2024, 9, 30, 14, 0, 0, 0, DateTimeKind.Unspecified), 142, 7 },
                    { 143, 7, new DateTime(2024, 9, 30, 15, 0, 0, 0, DateTimeKind.Unspecified), 143, 8 },
                    { 144, 8, new DateTime(2024, 9, 30, 16, 0, 0, 0, DateTimeKind.Unspecified), 144, 9 },
                    { 145, 6, new DateTime(2024, 9, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), 145, 10 },
                    { 146, 7, new DateTime(2024, 9, 30, 18, 0, 0, 0, DateTimeKind.Unspecified), 146, 11 },
                    { 147, 8, new DateTime(2024, 9, 30, 19, 0, 0, 0, DateTimeKind.Unspecified), 147, 12 },
                    { 148, 6, new DateTime(2024, 9, 30, 20, 0, 0, 0, DateTimeKind.Unspecified), 148, 13 },
                    { 149, 7, new DateTime(2024, 9, 30, 21, 0, 0, 0, DateTimeKind.Unspecified), 149, 14 },
                    { 150, 8, new DateTime(2024, 10, 1, 7, 0, 0, 0, DateTimeKind.Unspecified), 150, 2 },
                    { 151, 6, new DateTime(2024, 10, 1, 7, 30, 0, 0, DateTimeKind.Unspecified), 151, 3 },
                    { 152, 7, new DateTime(2024, 10, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 152, 4 },
                    { 153, 8, new DateTime(2024, 10, 1, 8, 30, 0, 0, DateTimeKind.Unspecified), 153, 5 },
                    { 154, 6, new DateTime(2024, 10, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 154, 6 },
                    { 155, 7, new DateTime(2024, 10, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 155, 7 },
                    { 156, 8, new DateTime(2024, 10, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), 156, 8 },
                    { 157, 6, new DateTime(2024, 10, 1, 11, 30, 0, 0, DateTimeKind.Unspecified), 157, 9 },
                    { 158, 7, new DateTime(2024, 10, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), 158, 10 },
                    { 159, 8, new DateTime(2024, 10, 1, 13, 30, 0, 0, DateTimeKind.Unspecified), 159, 11 },
                    { 160, 6, new DateTime(2024, 10, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), 160, 12 },
                    { 161, 7, new DateTime(2024, 10, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), 161, 13 },
                    { 162, 8, new DateTime(2024, 10, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), 162, 14 },
                    { 163, 6, new DateTime(2024, 10, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), 163, 2 },
                    { 164, 7, new DateTime(2024, 10, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), 164, 3 },
                    { 165, 8, new DateTime(2024, 10, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), 165, 4 },
                    { 166, 6, new DateTime(2024, 10, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), 166, 5 },
                    { 167, 7, new DateTime(2024, 10, 1, 21, 0, 0, 0, DateTimeKind.Unspecified), 167, 6 },
                    { 168, 8, new DateTime(2024, 10, 2, 7, 0, 0, 0, DateTimeKind.Unspecified), 168, 7 },
                    { 169, 6, new DateTime(2024, 10, 2, 7, 30, 0, 0, DateTimeKind.Unspecified), 169, 8 },
                    { 170, 7, new DateTime(2024, 10, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), 170, 9 },
                    { 171, 8, new DateTime(2024, 10, 2, 8, 30, 0, 0, DateTimeKind.Unspecified), 171, 10 },
                    { 172, 6, new DateTime(2024, 10, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), 172, 11 },
                    { 173, 7, new DateTime(2024, 10, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), 173, 12 },
                    { 174, 8, new DateTime(2024, 10, 2, 11, 0, 0, 0, DateTimeKind.Unspecified), 174, 13 },
                    { 175, 6, new DateTime(2024, 10, 2, 11, 30, 0, 0, DateTimeKind.Unspecified), 175, 14 },
                    { 176, 7, new DateTime(2024, 10, 2, 12, 30, 0, 0, DateTimeKind.Unspecified), 176, 2 },
                    { 177, 8, new DateTime(2024, 10, 2, 13, 30, 0, 0, DateTimeKind.Unspecified), 177, 3 },
                    { 178, 6, new DateTime(2024, 10, 2, 14, 0, 0, 0, DateTimeKind.Unspecified), 178, 4 },
                    { 179, 7, new DateTime(2024, 10, 2, 15, 0, 0, 0, DateTimeKind.Unspecified), 179, 5 },
                    { 180, 8, new DateTime(2024, 10, 2, 16, 0, 0, 0, DateTimeKind.Unspecified), 180, 6 },
                    { 181, 6, new DateTime(2024, 10, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), 181, 7 },
                    { 182, 7, new DateTime(2024, 10, 2, 18, 0, 0, 0, DateTimeKind.Unspecified), 182, 8 },
                    { 183, 8, new DateTime(2024, 10, 2, 19, 0, 0, 0, DateTimeKind.Unspecified), 183, 9 },
                    { 184, 6, new DateTime(2024, 10, 2, 20, 0, 0, 0, DateTimeKind.Unspecified), 184, 10 },
                    { 185, 7, new DateTime(2024, 10, 2, 21, 0, 0, 0, DateTimeKind.Unspecified), 185, 11 },
                    { 186, 8, new DateTime(2024, 10, 3, 7, 0, 0, 0, DateTimeKind.Unspecified), 186, 12 },
                    { 187, 6, new DateTime(2024, 10, 3, 7, 30, 0, 0, DateTimeKind.Unspecified), 187, 13 },
                    { 188, 7, new DateTime(2024, 10, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), 188, 14 },
                    { 189, 8, new DateTime(2024, 10, 3, 8, 30, 0, 0, DateTimeKind.Unspecified), 189, 2 },
                    { 190, 6, new DateTime(2024, 10, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), 190, 3 },
                    { 191, 7, new DateTime(2024, 10, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), 191, 4 },
                    { 192, 8, new DateTime(2024, 10, 3, 11, 0, 0, 0, DateTimeKind.Unspecified), 192, 5 },
                    { 193, 6, new DateTime(2024, 10, 3, 11, 30, 0, 0, DateTimeKind.Unspecified), 193, 6 },
                    { 194, 7, new DateTime(2024, 10, 3, 12, 30, 0, 0, DateTimeKind.Unspecified), 194, 7 },
                    { 195, 8, new DateTime(2024, 10, 3, 13, 30, 0, 0, DateTimeKind.Unspecified), 195, 8 },
                    { 196, 6, new DateTime(2024, 10, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), 196, 9 },
                    { 197, 7, new DateTime(2024, 10, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), 197, 10 },
                    { 198, 8, new DateTime(2024, 10, 3, 16, 0, 0, 0, DateTimeKind.Unspecified), 198, 11 },
                    { 199, 6, new DateTime(2024, 10, 3, 17, 0, 0, 0, DateTimeKind.Unspecified), 199, 12 },
                    { 200, 7, new DateTime(2024, 10, 3, 18, 0, 0, 0, DateTimeKind.Unspecified), 200, 13 },
                    { 201, 8, new DateTime(2024, 10, 3, 19, 0, 0, 0, DateTimeKind.Unspecified), 201, 14 },
                    { 202, 6, new DateTime(2024, 10, 3, 20, 0, 0, 0, DateTimeKind.Unspecified), 202, 2 },
                    { 203, 7, new DateTime(2024, 10, 3, 21, 0, 0, 0, DateTimeKind.Unspecified), 203, 3 },
                    { 204, 8, new DateTime(2024, 10, 4, 7, 0, 0, 0, DateTimeKind.Unspecified), 204, 4 },
                    { 205, 6, new DateTime(2024, 10, 4, 7, 30, 0, 0, DateTimeKind.Unspecified), 205, 5 },
                    { 206, 7, new DateTime(2024, 10, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), 206, 6 },
                    { 207, 8, new DateTime(2024, 10, 4, 8, 30, 0, 0, DateTimeKind.Unspecified), 207, 7 },
                    { 208, 6, new DateTime(2024, 10, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), 208, 8 },
                    { 209, 7, new DateTime(2024, 10, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), 209, 9 },
                    { 210, 8, new DateTime(2024, 10, 4, 11, 0, 0, 0, DateTimeKind.Unspecified), 210, 10 },
                    { 211, 6, new DateTime(2024, 10, 4, 11, 30, 0, 0, DateTimeKind.Unspecified), 211, 11 },
                    { 212, 7, new DateTime(2024, 10, 4, 12, 30, 0, 0, DateTimeKind.Unspecified), 212, 12 },
                    { 213, 8, new DateTime(2024, 10, 4, 13, 30, 0, 0, DateTimeKind.Unspecified), 213, 13 },
                    { 214, 6, new DateTime(2024, 10, 4, 14, 0, 0, 0, DateTimeKind.Unspecified), 214, 14 },
                    { 215, 7, new DateTime(2024, 10, 4, 15, 0, 0, 0, DateTimeKind.Unspecified), 215, 2 },
                    { 216, 8, new DateTime(2024, 10, 4, 16, 0, 0, 0, DateTimeKind.Unspecified), 216, 3 },
                    { 217, 6, new DateTime(2024, 10, 4, 17, 0, 0, 0, DateTimeKind.Unspecified), 217, 4 },
                    { 218, 7, new DateTime(2024, 10, 4, 18, 0, 0, 0, DateTimeKind.Unspecified), 218, 5 },
                    { 219, 8, new DateTime(2024, 10, 4, 19, 0, 0, 0, DateTimeKind.Unspecified), 219, 6 },
                    { 220, 6, new DateTime(2024, 10, 4, 20, 0, 0, 0, DateTimeKind.Unspecified), 220, 7 },
                    { 221, 7, new DateTime(2024, 10, 4, 21, 0, 0, 0, DateTimeKind.Unspecified), 221, 8 },
                    { 222, 8, new DateTime(2024, 10, 5, 7, 0, 0, 0, DateTimeKind.Unspecified), 222, 9 },
                    { 223, 6, new DateTime(2024, 10, 5, 7, 30, 0, 0, DateTimeKind.Unspecified), 223, 10 },
                    { 224, 7, new DateTime(2024, 10, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), 224, 11 },
                    { 225, 8, new DateTime(2024, 10, 5, 8, 30, 0, 0, DateTimeKind.Unspecified), 225, 12 },
                    { 226, 6, new DateTime(2024, 10, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), 226, 13 },
                    { 227, 7, new DateTime(2024, 10, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), 227, 14 },
                    { 228, 8, new DateTime(2024, 10, 5, 11, 0, 0, 0, DateTimeKind.Unspecified), 228, 2 },
                    { 229, 6, new DateTime(2024, 10, 5, 11, 30, 0, 0, DateTimeKind.Unspecified), 229, 3 },
                    { 230, 3, new DateTime(2024, 9, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), 230, 3 },
                    { 231, 4, new DateTime(2024, 9, 29, 17, 30, 0, 0, DateTimeKind.Unspecified), 231, 4 },
                    { 232, 3, new DateTime(2024, 9, 29, 18, 0, 0, 0, DateTimeKind.Unspecified), 232, 5 },
                    { 233, 4, new DateTime(2024, 9, 29, 18, 30, 0, 0, DateTimeKind.Unspecified), 233, 6 },
                    { 234, 2, new DateTime(2024, 9, 29, 19, 0, 0, 0, DateTimeKind.Unspecified), 234, 7 },
                    { 235, 4, new DateTime(2024, 9, 29, 19, 30, 0, 0, DateTimeKind.Unspecified), 235, 8 },
                    { 236, 6, new DateTime(2024, 9, 29, 20, 0, 0, 0, DateTimeKind.Unspecified), 236, 1 },
                    { 237, 5, new DateTime(2024, 9, 29, 20, 30, 0, 0, DateTimeKind.Unspecified), 237, 2 },
                    { 238, 4, new DateTime(2024, 9, 29, 21, 0, 0, 0, DateTimeKind.Unspecified), 238, 3 },
                    { 239, 3, new DateTime(2024, 9, 29, 21, 30, 0, 0, DateTimeKind.Unspecified), 239, 4 },
                    { 240, 2, new DateTime(2024, 9, 30, 7, 0, 0, 0, DateTimeKind.Unspecified), 240, 5 },
                    { 241, 4, new DateTime(2024, 9, 30, 7, 30, 0, 0, DateTimeKind.Unspecified), 241, 6 },
                    { 242, 3, new DateTime(2024, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), 242, 7 },
                    { 243, 2, new DateTime(2024, 9, 30, 8, 30, 0, 0, DateTimeKind.Unspecified), 243, 8 },
                    { 244, 6, new DateTime(2024, 9, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), 244, 1 },
                    { 245, 5, new DateTime(2024, 9, 30, 9, 30, 0, 0, DateTimeKind.Unspecified), 245, 2 },
                    { 246, 3, new DateTime(2024, 9, 30, 10, 0, 0, 0, DateTimeKind.Unspecified), 246, 3 },
                    { 247, 4, new DateTime(2024, 9, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), 247, 4 },
                    { 248, 2, new DateTime(2024, 9, 30, 11, 0, 0, 0, DateTimeKind.Unspecified), 248, 5 },
                    { 249, 4, new DateTime(2024, 9, 30, 11, 30, 0, 0, DateTimeKind.Unspecified), 249, 6 },
                    { 250, 3, new DateTime(2024, 9, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), 250, 7 }
                });

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
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CustomerId",
                table: "Bookings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TableId",
                table: "Bookings",
                column: "TableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "MenuPDFs");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Tables");
        }
    }
}
