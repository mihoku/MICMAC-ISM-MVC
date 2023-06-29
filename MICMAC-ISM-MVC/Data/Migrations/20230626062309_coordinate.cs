using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MICMACISMMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class coordinate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MICMACCoordinate",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureID = table.Column<int>(type: "int", nullable: false),
                    Dependence = table.Column<int>(type: "int", nullable: false),
                    DrivingPower = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MICMACCoordinate", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MICMACCoordinate_Features_FeatureID",
                        column: x => x.FeatureID,
                        principalTable: "Features",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MICMACCoordinate_FeatureID",
                table: "MICMACCoordinate",
                column: "FeatureID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MICMACCoordinate");
        }
    }
}
