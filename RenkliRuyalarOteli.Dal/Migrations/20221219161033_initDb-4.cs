using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RenkliRuyalarOteli.DAL.Migrations
{
    /// <inheritdoc />
    public partial class initDb4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "Roller");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "Rezervasyonlar");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "RezervasyonDetay");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "Odalar");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "OdaFiyatlari");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "Musteriler");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "KullaniciLar");

            migrationBuilder.RenameColumn(
                name: "SoyAdi",
                table: "KullaniciLar",
                newName: "Soyadi");

            migrationBuilder.AlterColumn<string>(
                name: "Soyadi",
                table: "KullaniciLar",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "KullaniciAdi",
                table: "KullaniciLar",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Adi",
                table: "KullaniciLar",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "Cinsiyet",
                table: "KullaniciLar",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "KullaniciLar",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciLar_Email",
                table: "KullaniciLar",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciLar_KullaniciAdi",
                table: "KullaniciLar",
                column: "KullaniciAdi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciLar_TcNo",
                table: "KullaniciLar",
                column: "TcNo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_KullaniciLar_Email",
                table: "KullaniciLar");

            migrationBuilder.DropIndex(
                name: "IX_KullaniciLar_KullaniciAdi",
                table: "KullaniciLar");

            migrationBuilder.DropIndex(
                name: "IX_KullaniciLar_TcNo",
                table: "KullaniciLar");

            migrationBuilder.DropColumn(
                name: "Cinsiyet",
                table: "KullaniciLar");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "KullaniciLar");

            migrationBuilder.RenameColumn(
                name: "Soyadi",
                table: "KullaniciLar",
                newName: "SoyAdi");

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "Roller",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "Rezervasyonlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "RezervasyonDetay",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "Odalar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "OdaFiyatlari",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "Musteriler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "SoyAdi",
                table: "KullaniciLar",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "KullaniciAdi",
                table: "KullaniciLar",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Adi",
                table: "KullaniciLar",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "KullaniciLar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
