using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MICMACISMMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectIdentitiy",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Organization = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectIdentitiy", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Experts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Organization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Experts_ProjectIdentitiy_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "ProjectIdentitiy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VariableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Features_ProjectIdentitiy_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "ProjectIdentitiy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StructuralSelfInteractions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureAID = table.Column<int>(type: "int", nullable: false),
                    FeatureBID = table.Column<int>(type: "int", nullable: false),
                    InteractionType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StructuralSelfInteractions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StructuralSelfInteractions_Features_FeatureAID",
                        column: x => x.FeatureAID,
                        principalTable: "Features",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_StructuralSelfInteractions_Features_FeatureBID",
                        column: x => x.FeatureBID,
                        principalTable: "Features",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ExpertOpinions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpertID = table.Column<int>(type: "int", nullable: false),
                    StructuralSelfInteractionID = table.Column<int>(type: "int", nullable: false),
                    InteractionType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertOpinions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ExpertOpinions_Experts_ExpertID",
                        column: x => x.ExpertID,
                        principalTable: "Experts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpertOpinions_StructuralSelfInteractions_StructuralSelfInteractionID",
                        column: x => x.StructuralSelfInteractionID,
                        principalTable: "StructuralSelfInteractions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpertOpinions_ExpertID",
                table: "ExpertOpinions",
                column: "ExpertID");

            migrationBuilder.CreateIndex(
                name: "IX_ExpertOpinions_StructuralSelfInteractionID",
                table: "ExpertOpinions",
                column: "StructuralSelfInteractionID");

            migrationBuilder.CreateIndex(
                name: "IX_Experts_ProjectID",
                table: "Experts",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Features_ProjectID",
                table: "Features",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_StructuralSelfInteractions_FeatureAID",
                table: "StructuralSelfInteractions",
                column: "FeatureAID");

            migrationBuilder.CreateIndex(
                name: "IX_StructuralSelfInteractions_FeatureBID",
                table: "StructuralSelfInteractions",
                column: "FeatureBID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpertOpinions");

            migrationBuilder.DropTable(
                name: "Experts");

            migrationBuilder.DropTable(
                name: "StructuralSelfInteractions");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "ProjectIdentitiy");
        }
    }
}
