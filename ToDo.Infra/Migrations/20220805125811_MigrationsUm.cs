using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.Infra.Migrations
{
    public partial class MigrationsUm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(180)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(180)", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "todos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(180)", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_todos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_todos_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "VARCHAR(280)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TodoId = table.Column<int>(type: "int", nullable: true),
                    Conclued = table.Column<byte>(type: "TINYINT", nullable: false, defaultValue: (byte)0),
                    ConcluedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    DeadLine = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    TodoListId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tasks_todos_TodoListId",
                        column: x => x.TodoListId,
                        principalTable: "todos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tasks_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tasks_TodoListId",
                table: "tasks",
                column: "TodoListId");

            migrationBuilder.CreateIndex(
                name: "IX_tasks_UserId",
                table: "tasks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_todos_UserId",
                table: "todos",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tasks");

            migrationBuilder.DropTable(
                name: "todos");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
