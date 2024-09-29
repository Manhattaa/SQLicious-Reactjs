using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SQLicious.Server.Migrations
{
    /// <inheritdoc />
    public partial class DataProcessingMenuItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 33,
                columns: new[] { "Description", "MenuType", "Name", "Price" },
                values: new object[] { "Fräsch smoothie bowl med banan, bär och granola", 0, "Smoothie bowl", 79f });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 34,
                columns: new[] { "Description", "MenuType", "Name", "Price" },
                values: new object[] { "Pocherade ägg med hollandaisesås på rostat bröd", 0, "Ägg Benedict", 119f });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 35,
                columns: new[] { "Description", "MenuType", "Name", "Price" },
                values: new object[] { "Amerikanska pannkakor med lönnsirap och smör", 0, "Pannkakor med sirap", 99f });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "MenuItemId", "Description", "IsAvailable", "MenuType", "Name", "Price" },
                values: new object[,]
                {
                    { 36, "Havregrynsgröt toppad med äppelkompott och kanel", true, 0, "Gröt med äppelkompott", 69f },
                    { 37, "Nygräddad fralla med ost och skinka", true, 0, "Fralla med ost och skinka", 49f },
                    { 38, "Chiapudding smaksatt med kokos och toppad med bär", true, 1, "Chiapudding med kokos", 89f },
                    { 39, "Fransk toast toppad med färska bär och sirap", true, 1, "Franska toast med bär", 109f },
                    { 40, "Smashed avocado på rostat surdegsbröd med chili flakes", true, 1, "Smashed avocado", 119f },
                    { 41, "Shakshuka med ägg, tomat och paprika", true, 1, "Shakshuka", 129f },
                    { 42, "Klassisk Croque Monsieur med ost och skinka", true, 1, "Croque Monsieur", 149f },
                    { 43, "Grillade kycklingspett serverade med tzatziki och sallad", true, 2, "Kycklingspett med tzatziki", 159f },
                    { 44, "Vegetarisk halloumiburgare med rostad paprika och tzatziki", true, 2, "Halloumiburgare", 139f },
                    { 45, "Rödbetsbiffar serverade med chevre och honung", true, 2, "Rödbetsbiffar med chevre", 149f },
                    { 46, "Klassisk pasta carbonara med guancale och parmesan", true, 2, "Pasta Carbonara", 169f },
                    { 47, "Vedugnsbakad pizza med tomat, mozzarella och basilika", true, 2, "Pizza Margherita", 139f },
                    { 48, "Mör lammlägg serverad med rosmarinsky och potatisgratäng", true, 3, "Lammlägg med rosmarin", 279f },
                    { 49, "Krämig hummersoppa smaksatt med konjak", true, 3, "Hummersoppa", 249f },
                    { 50, "Grillad lax serverad med citronsås och sparris", true, 3, "Grillad lax med citronsås", 219f },
                    { 51, "Krämig risotto med svamp och tryffelolja", true, 3, "Risotto med svamp och tryffel", 239f },
                    { 52, "Torskrygg serverad med brynt smör och pepparrot", true, 3, "Torskrygg med brynt smör", 259f },
                    { 53, "Traditionellt Julbord i riktig SQLicious anda!", true, 4, "Julbord - Vuxen", 349f },
                    { 54, "OBS: Gäller ej barn under 6 år.", true, 4, "Julbord - Barn", 129f },
                    { 55, "Ingen vet hur man uttalar detta.", true, 4, "Apotekarnes Julmust", 29f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 55);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 33,
                columns: new[] { "Description", "MenuType", "Name", "Price" },
                values: new object[] { "Traditionellt Julbord i riktig SQLicious anda!", 4, "Julbord - Vuxen", 349f });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 34,
                columns: new[] { "Description", "MenuType", "Name", "Price" },
                values: new object[] { "OBS: Gäller ej barn under 6 år.", 4, "Julbord - Barn", 129f });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 35,
                columns: new[] { "Description", "MenuType", "Name", "Price" },
                values: new object[] { "Ingen vet hur man uttalar detta.", 4, "Apotekarnes Julmust", 29f });
        }
    }
}
