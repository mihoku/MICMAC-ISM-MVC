using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MICMACISMMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class ssi6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StructuralSelfInteractions_Features_FeatureAID",
                table: "StructuralSelfInteractions");

            migrationBuilder.DropIndex(
                name: "IX_StructuralSelfInteractions_FeatureAID",
                table: "StructuralSelfInteractions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StructuralSelfInteractions_FeatureAID",
                table: "StructuralSelfInteractions",
                column: "FeatureAID");

            migrationBuilder.AddForeignKey(
                name: "FK_StructuralSelfInteractions_Features_FeatureAID",
                table: "StructuralSelfInteractions",
                column: "FeatureAID",
                principalTable: "Features",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
