using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MICMACISMMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class tn_features : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TransitivityNotes_FeatureAID",
                table: "TransitivityNotes",
                column: "FeatureAID");

            migrationBuilder.AddForeignKey(
                name: "FK_TransitivityNotes_Features_FeatureAID",
                table: "TransitivityNotes",
                column: "FeatureAID",
                principalTable: "Features",
                principalColumn: "ID"
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransitivityNotes_Features_FeatureAID",
                table: "TransitivityNotes");

            migrationBuilder.DropIndex(
                name: "IX_TransitivityNotes_FeatureAID",
                table: "TransitivityNotes");
        }
    }
}
