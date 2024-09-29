using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SQLicious.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedAuthenticatorKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthenticatorKey",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "MenuItemId", "Description", "IsAvailable", "MenuType", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Våfflorna serveras med färska bär och grädde", true, 0, "Våfflor med bär och grädde", 89f },
                    { 2, "Gravad lax serveras med krispigt knäckebröd", true, 0, "Gravad lax och knäckebröd", 99f },
                    { 3, "Omelett med färsk svamp och spenat", true, 0, "Omelett med svamp och spenat", 89f },
                    { 4, "Nyrostat kaffe serveras med en smörgås toppad med ost, skinka och gurka", true, 0, "Kaffe och smörgås", 79f },
                    { 5, "Chiafrön serveras med krämig yoghurt och ringlad honung", true, 0, "Chiafrön med yoghurt och honung", 79f },
                    { 6, "Två stekta ägg serveras med krispig bacon", true, 0, "Ägg och bacon", 89f },
                    { 7, "Ett urval av färsk, säsongsbetonad frukt", true, 0, "Fruktfat", 69f },
                    { 8, "Färskpressad apelsin- eller äppeljuice", true, 0, "Färskpressad juice", 49f },
                    { 9, "Krämig äggröra med rökt lax och färsk gräslök", true, 1, "Äggröra med lax och gräslök", 119f },
                    { 10, "Klassisk skagenröra serverad på nyrostat bröd", true, 1, "Skagenröra på toast", 139f },
                    { 11, "Belgiska våfflor serverade med sirap och färska bär", true, 1, "Belgiska våfflor med sirap och bär", 129f },
                    { 12, "Svenska köttbullar serverade med krämig potatisgratäng", true, 1, "Köttbullar och potatisgratäng", 159f },
                    { 13, "Avokado-toast toppad med ett pocherat ägg", true, 1, "Avokado-toast med pocherat ägg", 119f },
                    { 14, "Lättgravad lax serverad med nyrostat bröd", true, 1, "Lättgravad lax med rostat bröd", 139f },
                    { 15, "Krispig rösti toppad med crème fraîche och rökt lax", true, 1, "Rösti med crème fraîche och rökt lax", 149f },
                    { 16, "Fräsch fruktsallad smaksatt med mynta", true, 1, "Fruktsallad med mynta", 89f },
                    { 17, "Klassisk räksmörgås på rågbröd med ägg och majonnäs", true, 2, "Räksmörgås", 179f },
                    { 18, "Svenska köttbullar serverade med potatismos, lingon och gräddsås", true, 2, "Svenska köttbullar med potatismos", 159f },
                    { 19, "Grillad laxfilé serverad med dillstuvad potatis", true, 2, "Laxfilé med dillstuvad potatis", 189f },
                    { 20, "Pannbiff serverad med karamelliserad lök och potatis", true, 2, "Pannbiff med lök", 149f },
                    { 21, "Vegetarisk lasagne fylld med spenat och ricotta", true, 2, "Vegetarisk lasagne med spenat och ricotta", 139f },
                    { 22, "Caesarsallad toppad med grillad kyckling", true, 2, "Caesarsallad med kyckling", 149f },
                    { 23, "Fisksoppa smaksatt med saffran och serverad med aioli", true, 2, "Fisksoppa med saffran och aioli", 179f },
                    { 24, "Krämig kycklinggryta med svamp och timjan", true, 2, "Kycklinggryta med svamp och timjan", 169f },
                    { 25, "Grillad entrecôte serverad med rödvinssås och rostad potatis", true, 3, "Grillad entrecôte med rödvinssås", 269f },
                    { 26, "Krämig fiskgratäng toppad med räkor och dill", true, 3, "Fiskgratäng med räkor och dill", 219f },
                    { 27, "Mör vildsvinsstek serverad med kantareller", true, 3, "Vildsvinsstek med kantareller", 279f },
                    { 28, "Oxfilé serverad med potatisgratäng och bearnaisesås", true, 3, "Oxfilé med potatisgratäng och bearnaisesås", 299f },
                    { 29, "Krämig sparrisrisotto toppad med parmesan och tryffelolja", true, 3, "Sparrisrisotto med parmesan och tryffelolja", 219f },
                    { 30, "Renskav serverad med potatismos och lingonsylt", true, 3, "Renskav med potatismos och lingonsylt", 239f },
                    { 31, "Färska havskräftor serverade med vitlökssmör", true, 3, "Havskräftor med vitlökssmör", 249f },
                    { 32, "Vegetarisk biff serverad med quinoa och grillade grönsaker", true, 3, "Vegetarisk biff med quinoa och grillade grönsaker", 199f },
                    { 33, "Traditionellt Julbord i riktig SQLicious anda!", true, 4, "Julbord - Vuxen", 349f },
                    { 34, "OBS: Gäller ej barn under 6 år.", true, 4, "Julbord - Barn", 129f },
                    { 35, "Ingen vet hur man uttalar detta.", true, 4, "Apotekarnes Julmust", 29f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 35);

            migrationBuilder.DropColumn(
                name: "AuthenticatorKey",
                table: "AspNetUsers");
        }
    }
}
