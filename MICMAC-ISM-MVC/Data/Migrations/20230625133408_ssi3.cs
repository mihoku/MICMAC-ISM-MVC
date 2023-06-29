using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MICMACISMMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class ssi3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SSI_Feature");

            migrationBuilder.AddColumn<int>(
                name: "FeatureAID",
                table: "StructuralSelfInteractions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FeatureBID",
                table: "StructuralSelfInteractions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StructuralSelfInteractions_FeatureAID",
                table: "StructuralSelfInteractions",
                column: "FeatureAID");

            migrationBuilder.AddForeignKey(
                name: "FK_StructuralSelfInteractions_Features_FeatureAID",
                table: "StructuralSelfInteractions",
                column: "FeatureAID",
                principalTable: "Features",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StructuralSelfInteractions_Features_FeatureAID",
                table: "StructuralSelfInteractions");

            migrationBuilder.DropIndex(
                name: "IX_StructuralSelfInteractions_FeatureAID",
                table: "StructuralSelfInteractions");

            migrationBuilder.DropColumn(
                name: "FeatureAID",
                table: "StructuralSelfInteractions");

            migrationBuilder.DropColumn(
                name: "FeatureBID",
                table: "StructuralSelfInteractions");

            migrationBuilder.CreateTable(
                name: "SSI_Feature",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Feature_ID = table.Column<int>(type: "int", nullable: false),
                    SSI_ID = table.Column<int>(type: "int", nullable: false),
                    FeatureID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SSI_Feature", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SSI_Feature_Features_Feature_ID",
                        column: x => x.Feature_ID,
                        principalTable: "Features",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SSI_Feature_StructuralSelfInteractions_SSI_ID",
                        column: x => x.SSI_ID,
                        principalTable: "StructuralSelfInteractions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SSI_Feature_Feature_ID",
                table: "SSI_Feature",
                column: "Feature_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SSI_Feature_SSI_ID",
                table: "SSI_Feature",
                column: "SSI_ID");
        }
    }
}
