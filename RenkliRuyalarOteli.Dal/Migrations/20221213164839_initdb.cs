using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RenkliRuyalarOteli.DAL.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KullaniciLar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TcNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciLar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Musteriler",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Cinsiyet = table.Column<bool>(type: "bit", nullable: false),
                    MusteriTcNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CepNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    KullaniciId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteriler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Musteriler_KullaniciLar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "KullaniciLar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Odalar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OdaNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KisiSayisi = table.Column<byte>(type: "tinyint", nullable: false),
                    Durum = table.Column<bool>(type: "bit", nullable: false),
                    KullaniciId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Odalar_KullaniciLar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "KullaniciLar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OdaFiyatlari",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OdaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Baslangic = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Bitis = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fiyat = table.Column<float>(type: "real", nullable: false),
                    KullaniciId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdaFiyatlari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OdaFiyatlari_KullaniciLar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "KullaniciLar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OdaFiyatlari_Odalar_OdaId",
                        column: x => x.OdaId,
                        principalTable: "Odalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervasyonlar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OdaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OdaFiyatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GirisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CikisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KullaniciId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MusteriId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervasyonlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezervasyonlar_KullaniciLar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "KullaniciLar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervasyonlar_Musteriler_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "Musteriler",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rezervasyonlar_OdaFiyatlari_OdaFiyatId",
                        column: x => x.OdaFiyatId,
                        principalTable: "OdaFiyatlari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervasyonlar_Odalar_OdaId",
                        column: x => x.OdaId,
                        principalTable: "Odalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RezervasyonDetay",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RezervasyonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MusteriId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KullaniciId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RezervasyonDetay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RezervasyonDetay_KullaniciLar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "KullaniciLar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RezervasyonDetay_Musteriler_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "Musteriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RezervasyonDetay_Rezervasyonlar_RezervasyonId",
                        column: x => x.RezervasyonId,
                        principalTable: "Rezervasyonlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Musteriler_KullaniciId",
                table: "Musteriler",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_OdaFiyatlari_KullaniciId",
                table: "OdaFiyatlari",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_OdaFiyatlari_OdaId",
                table: "OdaFiyatlari",
                column: "OdaId");

            migrationBuilder.CreateIndex(
                name: "IX_Odalar_KullaniciId",
                table: "Odalar",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_RezervasyonDetay_KullaniciId",
                table: "RezervasyonDetay",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_RezervasyonDetay_MusteriId",
                table: "RezervasyonDetay",
                column: "MusteriId");

            migrationBuilder.CreateIndex(
                name: "IX_RezervasyonDetay_RezervasyonId",
                table: "RezervasyonDetay",
                column: "RezervasyonId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_KullaniciId",
                table: "Rezervasyonlar",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_MusteriId",
                table: "Rezervasyonlar",
                column: "MusteriId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_OdaFiyatId",
                table: "Rezervasyonlar",
                column: "OdaFiyatId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_OdaId",
                table: "Rezervasyonlar",
                column: "OdaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RezervasyonDetay");

            migrationBuilder.DropTable(
                name: "Rezervasyonlar");

            migrationBuilder.DropTable(
                name: "Musteriler");

            migrationBuilder.DropTable(
                name: "OdaFiyatlari");

            migrationBuilder.DropTable(
                name: "Odalar");

            migrationBuilder.DropTable(
                name: "KullaniciLar");
        }
    }
}
