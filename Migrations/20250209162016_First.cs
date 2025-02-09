using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace auto_tasker.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            // Insert dummy data
            migrationBuilder.Sql(
                @"INSERT INTO Tasks (Title, Description, DueDate, Priority, Status, CreatedAt, UpdatedAt)
                  VALUES
                  ('Task 1', 'Description for task 1', DATEADD(DAY, 1, GETDATE()), 1, 0, GETDATE(), GETDATE()),
                  ('Task 2', 'Description for task 2', DATEADD(DAY, 2, GETDATE()), 2, 1, GETDATE(), GETDATE()),
                  ('Task 3', 'Description for task 3', DATEADD(DAY, 3, GETDATE()), 3, 2, GETDATE(), GETDATE());"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Tasks");
        }
    }
}
