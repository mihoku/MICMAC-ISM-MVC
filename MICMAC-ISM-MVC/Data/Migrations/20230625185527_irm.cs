using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MICMACISMMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class irm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InitialReachabilityMatrix",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureAID = table.Column<int>(type: "int", nullable: false),
                    FeatureBID = table.Column<int>(type: "int", nullable: false),
                    IRM = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitialReachabilityMatrix", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InitialReachabilityMatrix_Features_FeatureAID",
                        column: x => x.FeatureAID,
                        principalTable: "Features",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InitialReachabilityMatrix_FeatureAID",
                table: "InitialReachabilityMatrix",
                column: "FeatureAID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InitialReachabilityMatrix");
        }
    }
}
