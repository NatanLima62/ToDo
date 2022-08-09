using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.Infra.Migrations
{
    public partial class migrationDois : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_todos_TodoListId",
                table: "tasks");

            migrationBuilder.AlterColumn<int>(
                name: "TodoListId",
                table: "tasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_todos_TodoListId",
                table: "tasks",
                column: "TodoListId",
                principalTable: "todos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_todos_TodoListId",
                table: "tasks");

            migrationBuilder.AlterColumn<int>(
                name: "TodoListId",
                table: "tasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_todos_TodoListId",
                table: "tasks",
                column: "TodoListId",
                principalTable: "todos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
