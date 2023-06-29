using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MICMACISMMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class partition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Partition",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Iteration = table.Column<int>(type: "int", nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partition", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Partition_ProjectIdentitiy_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "ProjectIdentitiy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartitionFeatureSet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartitionID = table.Column<int>(type: "int", nullable: false),
                    FeatureID = table.Column<int>(type: "int", nullable: false),
                    SelectedLevel = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartitionFeatureSet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PartitionFeatureSet_Features_FeatureID",
                        column: x => x.FeatureID,
                        principalTable: "Features",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartitionFeatureSet_Partition_PartitionID",
                        column: x => x.PartitionID,
                        principalTable: "Partition",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PartitionAntecedentSet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureID = table.Column<int>(type: "int", nullable: false),
                    PartitionFeatureSetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartitionAntecedentSet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PartitionAntecedentSet_Features_FeatureID",
                        column: x => x.FeatureID,
                        principalTable: "Features",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartitionAntecedentSet_PartitionFeatureSet_PartitionFeatureSetID",
                        column: x => x.PartitionFeatureSetID,
                        principalTable: "PartitionFeatureSet",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PartitionIntersectionSet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureID = table.Column<int>(type: "int", nullable: false),
                    PartitionFeatureSetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartitionIntersectionSet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PartitionIntersectionSet_Features_FeatureID",
                        column: x => x.FeatureID,
                        principalTable: "Features",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartitionIntersectionSet_PartitionFeatureSet_PartitionFeatureSetID",
                        column: x => x.PartitionFeatureSetID,
                        principalTable: "PartitionFeatureSet",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PartitionReachabilitySet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureID = table.Column<int>(type: "int", nullable: false),
                    PartitionFeatureSetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartitionReachabilitySet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PartitionReachabilitySet_Features_FeatureID",
                        column: x => x.FeatureID,
                        principalTable: "Features",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartitionReachabilitySet_PartitionFeatureSet_PartitionFeatureSetID",
                        column: x => x.PartitionFeatureSetID,
                        principalTable: "PartitionFeatureSet",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Partition_ProjectID",
                table: "Partition",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_PartitionAntecedentSet_FeatureID",
                table: "PartitionAntecedentSet",
                column: "FeatureID");

            migrationBuilder.CreateIndex(
                name: "IX_PartitionAntecedentSet_PartitionFeatureSetID",
                table: "PartitionAntecedentSet",
                column: "PartitionFeatureSetID");

            migrationBuilder.CreateIndex(
                name: "IX_PartitionFeatureSet_FeatureID",
                table: "PartitionFeatureSet",
                column: "FeatureID");

            migrationBuilder.CreateIndex(
                name: "IX_PartitionFeatureSet_PartitionID",
                table: "PartitionFeatureSet",
                column: "PartitionID");

            migrationBuilder.CreateIndex(
                name: "IX_PartitionIntersectionSet_FeatureID",
                table: "PartitionIntersectionSet",
                column: "FeatureID");

            migrationBuilder.CreateIndex(
                name: "IX_PartitionIntersectionSet_PartitionFeatureSetID",
                table: "PartitionIntersectionSet",
                column: "PartitionFeatureSetID");

            migrationBuilder.CreateIndex(
                name: "IX_PartitionReachabilitySet_FeatureID",
                table: "PartitionReachabilitySet",
                column: "FeatureID");

            migrationBuilder.CreateIndex(
                name: "IX_PartitionReachabilitySet_PartitionFeatureSetID",
                table: "PartitionReachabilitySet",
                column: "PartitionFeatureSetID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartitionAntecedentSet");

            migrationBuilder.DropTable(
                name: "PartitionIntersectionSet");

            migrationBuilder.DropTable(
                name: "PartitionReachabilitySet");

            migrationBuilder.DropTable(
                name: "PartitionFeatureSet");

            migrationBuilder.DropTable(
                name: "Partition");
        }
    }
}
