using Microsoft.EntityFrameworkCore.Migrations;

namespace Site.Migrations
{
    public partial class b : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "SiteOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomClientId",
                table: "SiteOrder",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Custom",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeClient = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PrenumeClient = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NrTelefon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Custom", x => x.ClientId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SiteOrder_CustomClientId",
                table: "SiteOrder",
                column: "CustomClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_SiteOrder_Custom_CustomClientId",
                table: "SiteOrder",
                column: "CustomClientId",
                principalTable: "Custom",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SiteOrder_Custom_CustomClientId",
                table: "SiteOrder");

            migrationBuilder.DropTable(
                name: "Custom");

            migrationBuilder.DropIndex(
                name: "IX_SiteOrder_CustomClientId",
                table: "SiteOrder");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "SiteOrder");

            migrationBuilder.DropColumn(
                name: "CustomClientId",
                table: "SiteOrder");
        }
    }
}
