using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Restful.Login.Infra.Data.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "grades",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grades", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(type: "varchar(50)", nullable: true),
                    last_name = table.Column<string>(type: "varchar(50)", nullable: true),
                    email = table.Column<string>(type: "varchar(50)", nullable: true),
                    confirm_email = table.Column<string>(type: "varchar(50)", nullable: true),
                    birth_date = table.Column<DateTime>(type: "date", nullable: false),
                    password = table.Column<string>(type: "varchar(150)", nullable: true),
                    confirm_password = table.Column<string>(type: "varchar(150)", nullable: true),
                    created_at = table.Column<DateTime>(type: "date", nullable: false),
                    updated_at = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(type: "varchar(50)", nullable: true),
                    GradeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id);
                    table.ForeignKey(
                        name: "FK_students_grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "grades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_students_GradeId",
                table: "students",
                column: "GradeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "grades");
        }
    }
}
