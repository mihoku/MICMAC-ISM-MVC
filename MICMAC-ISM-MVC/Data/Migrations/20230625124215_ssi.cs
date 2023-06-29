using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MICMACISMMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class ssi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_StructuralSelfInteractions_Features_FeatureBID",
            //    table: "StructuralSelfInteractions");

            //migrationBuilder.DropIndex(
            //    name: "IX_StructuralSelfInteractions_FeatureBID",
            //    table: "StructuralSelfInteractions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateIndex(
            //    name: "IX_StructuralSelfInteractions_FeatureBID",
            //    table: "StructuralSelfInteractions",
            //    column: "FeatureBID");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_StructuralSelfInteractions_Features_FeatureBID",
            //    table: "StructuralSelfInteractions",
            //    column: "FeatureBID",
            //    principalTable: "Features",
            //    principalColumn: "ID",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
