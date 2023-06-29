using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MICMACISMMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class frm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinalReachabilityMatrix",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureAID = table.Column<int>(type: "int", nullable: false),
                    FeatureBID = table.Column<int>(type: "int", nullable: false),
                    FRM = table.Column<int>(type: "int", nullable: false),
                    AddingTransitivity = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalReachabilityMatrix", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FinalReachabilityMatrix_Features_FeatureAID",
                        column: x => x.FeatureAID,
                        principalTable: "Features",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransitivityNotes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureAID = table.Column<int>(type: "int", nullable: false),
                    FeatureBID = table.Column<int>(type: "int", nullable: false),
                    FeatureCID = table.Column<int>(type: "int", nullable: false),
                    FRMID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransitivityNotes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TransitivityNotes_FinalReachabilityMatrix_FRMID",
                        column: x => x.FRMID,
                        principalTable: "FinalReachabilityMatrix",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinalReachabilityMatrix_FeatureAID",
                table: "FinalReachabilityMatrix",
                column: "FeatureAID");

            migrationBuilder.CreateIndex(
                name: "IX_TransitivityNotes_FRMID",
                table: "TransitivityNotes",
                column: "FRMID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransitivityNotes");

            migrationBuilder.DropTable(
                name: "FinalReachabilityMatrix");
        }
    }
}
