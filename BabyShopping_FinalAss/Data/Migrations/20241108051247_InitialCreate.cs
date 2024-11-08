using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BabyShopping_FinalAss.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    AccountType = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductName = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    AveragePoint = table.Column<decimal>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    RatingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: false),
                    Point = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.RatingId);
                    table.ForeignKey(
                        name: "FK_Ratings_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "AccountType", "Email", "Password", "Phone", "Status", "Username" },
                values: new object[,]
                {
                    { 1, 1, "thanhthao110889@gmail.com", "12345678", "0982345167", 1, "thaolent" },
                    { 2, 1, "kisshoang@gmail.com", "12345678", "0982345168", 1, "dungdq" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 1, "Diapers", "Diaper for infant and baby" },
                    { 2, "Powdered Milk", "A dairy product made by evaporating milk to dryness" },
                    { 3, "Reconstituted milk", "Mixing milk powder with water to create liquid milk" },
                    { 4, "Baby Food", "This food is specifically made to meet the nutritional needs of infants and toddlers, ensuring they get the essential vitamins and minerals for proper growth and development" },
                    { 5, "Vitamins", " vitamins are essential for their growth and development" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "AveragePoint", "CategoryId", "CreatedBy", "CreatedDate", "Description", "Image", "Price", "ProductName", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 7.5m, 1, "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 403, DateTimeKind.Local).AddTicks(4088), "Platinum", "D:\\.NET\\BabyShopping_Image\\Diaper\\Huggies.jpg", 195000.0m, "Huggies Nature Made", "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(6652) },
                    { 2, 5.0m, 1, "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7832), "Bobby for baby", "D:\\.NET\\BabyShopping_Image\\Diaper\\bobby.jpg", 189900.0m, "Bobby", "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7834) },
                    { 3, 9.0m, 1, "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7836), "Gooby Extra Newborn Little ", "D:\\.NET\\BabyShopping_Image\\Diaper\\gooby.jpg", 205000.0m, "Gooby", "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7836) },
                    { 4, 7.2m, 1, "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7838), "Bland, soft fabric. - Ultra-soft fabric using the super-microfiber ", "D:\\.NET\\BabyShopping_Image\\Diaper\\nabizam.jpg", 234098.0m, "Nabizam", "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7838) },
                    { 5, 6.1m, 1, "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7864), "MAMOGOM Premium CARE ORGANIC KOREAN PREMIUM CARE  ", "D:\\.NET\\BabyShopping_Image\\Diaper\\mamogom.jpg", 245000.0m, "Mamogom", "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7865) },
                    { 6, 7.5m, 2, "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7866), "Aptamil NewZeland", "D:\\.NET\\BabyShopping_Image\\Milk\\Powdered milk\\aptamil_bac.jpg", 195000.0m, "Aptamil", "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7867) },
                    { 7, 5.0m, 2, "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7869), "For infant", "D:\\.NET\\BabyShopping_Image\\Milk\\Powdered milk\\blackmore.jpg", 189900.0m, "Blackmores", "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7870) },
                    { 8, 9.0m, 2, "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7871), "Colos for baby", "D:\\.NET\\BabyShopping_Image\\Milk\\Powdered milk\\colosbaby.jpg", 205000.0m, "ColosBaby", "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7872) },
                    { 9, 7.2m, 2, "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7873), "Well-cooked, pureed legumes such as beans, lentils and chickpeas.", "D:\\.NET\\BabyShopping_Image\\Milk\\Powdered milk\\enfamil.jpg", 234098.0m, "Enfamil A+", "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7874) },
                    { 10, 6.1m, 2, "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7875), "HiPP becomes Germany's third company and first food manufacturer", "D:\\.NET\\BabyShopping_Image\\Milk\\Powdered milk\\hipp.jpg", 245000.0m, "HiPP", "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7876) },
                    { 11, 7.5m, 3, "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7877), "Abott Grow", "D:\\.NET\\BabyShopping_Image\\Milk\\Liquid milk\\abottgrow.jpg", 195000.0m, "Abott Grow", "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7878) },
                    { 12, 5.6m, 3, "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7879), "Aptakid", "D:\\.NET\\BabyShopping_Image\\Milk\\Liquid milk\\aptakid.jpg", 189900.0m, "Aptakid", "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7892) },
                    { 13, 4.0m, 3, "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7894), "Colos for baby", "D:\\.NET\\BabyShopping_Image\\Milk\\Liquid milk\\colosbaby.jpg", 205000.0m, "ColosBaby", "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7895) },
                    { 14, 7.4m, 3, "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7896), "DalatMilk", "D:\\.NET\\BabyShopping_Image\\Milk\\Liquid milk\\dalatmilk.jpg", 123000.0m, "DalatMilk", "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7897) },
                    { 15, 9.8m, 3, "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7898), "Vinamil Green farm", "D:\\.NET\\BabyShopping_Image\\Milk\\Liquid milk\\vinamilk xanh.jpg", 134000.0m, "Vinamilk", "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7899) },
                    { 16, 7.5m, 4, "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7900), "Banh an dam", "D:\\.NET\\BabyShopping_Image\\Baby Food\\banhandamGerber.jpg", 195000.0m, "Gerber Puffs", "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7901) },
                    { 17, 5.6m, 4, "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7902), "Bot an dam vi lua mach", "D:\\.NET\\BabyShopping_Image\\Baby Food\\botbiokid.jpg", 189900.0m, "BioKids", "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7903) },
                    { 18, 4.0m, 4, "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7970), "Bot an dam vij sua", "D:\\.NET\\BabyShopping_Image\\Baby Food\\botHeinz.jpg", 205000.0m, "Bot Heinz", "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7971) },
                    { 19, 7.4m, 4, "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7973), "Bot an dam Hipp", "D:\\.NET\\BabyShopping_Image\\Baby Food\\botHipp.jpg", 123000.0m, "Bot HiPP Organic", "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7973) },
                    { 20, 9.8m, 4, "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7991), "Vang sua trai cay", "D:\\.NET\\BabyShopping_Image\\Baby Food\\vangsuahoff.jpg", 134000.0m, "Vang sua Hoff", "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7991) },
                    { 21, 7.5m, 5, "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7993), "Men tieu hoa", "D:\\.NET\\BabyShopping_Image\\Vitamin\\biogaia.jpg", 195000.0m, "BioGaia", "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7994) },
                    { 22, 5.6m, 5, "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7995), "D3K2", "D:\\.NET\\BabyShopping_Image\\Vitamin\\sunday natural.jpg", 189900.0m, "Sunday Natural", "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7996) },
                    { 23, 4.0m, 5, "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7997), "An ngon ngu ngon", "D:\\.NET\\BabyShopping_Image\\Vitamin\\fitobimbi.jpg", 205000.0m, "Fitobimbi", "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7998) },
                    { 24, 7.4m, 5, "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(7999), "MultiVitamins", "D:\\.NET\\BabyShopping_Image\\Vitamin\\pediakid.jpg", 123000.0m, "PediaKid", "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(8000) },
                    { 25, 9.8m, 5, "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(8001), "Probiotic", "D:\\.NET\\BabyShopping_Image\\Vitamin\\pribiotic.jpg", 134000.0m, "Kid Smart drops", "Admin", new DateTime(2024, 11, 8, 12, 12, 46, 404, DateTimeKind.Local).AddTicks(8002) }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "RatingId", "Comment", "Point", "ProductId" },
                values: new object[,]
                {
                    { 1, "This iss rating for product 1", 5, 1 },
                    { 2, "This iss rating for product 6", 7, 6 },
                    { 3, "This iss rating for product 10", 8, 10 },
                    { 4, "This iss rating for product 19", 6, 19 },
                    { 5, "This iss rating for product 22", 9, 22 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ProductId",
                table: "Ratings",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
