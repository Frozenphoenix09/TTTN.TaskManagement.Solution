using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TTTN.TaskManagement.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    ActionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.ActionId);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    ModuleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.ModuleId);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Addresss = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSuperAdmin = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpDatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Avartar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ModuleActions",
                columns: table => new
                {
                    ModuleActionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    ActionId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleActions", x => x.ModuleActionId);
                    table.ForeignKey(
                        name: "FK_ModuleActions_Actions_ActionId",
                        column: x => x.ActionId,
                        principalTable: "Actions",
                        principalColumn: "ActionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleActions_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commands",
                columns: table => new
                {
                    CommandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommandText = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatorUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commands", x => x.CommandId);
                    table.ForeignKey(
                        name: "FK_Commands_Users_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotificationDetails",
                columns: table => new
                {
                    NotificationDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationId = table.Column<int>(type: "int", nullable: false),
                    SendTo = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationDetails", x => x.NotificationDetailId);
                    table.ForeignKey(
                        name: "FK_NotificationDetails_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "NotificationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotificationDetails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignTo = table.Column<int>(type: "int", nullable: true),
                    TaskName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttachFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaskDeadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssignedUserUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Tasks_Users_AssignedUserUserId",
                        column: x => x.AssignedUserUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UserRoleId);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleModuleActions",
                columns: table => new
                {
                    RoleModuleActionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ModuleActionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleModuleActions", x => x.RoleModuleActionId);
                    table.ForeignKey(
                        name: "FK_RoleModuleActions_ModuleActions_ModuleActionId",
                        column: x => x.ModuleActionId,
                        principalTable: "ModuleActions",
                        principalColumn: "ModuleActionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleModuleActions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commands_CreatorUserId",
                table: "Commands",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleActions_ActionId",
                table: "ModuleActions",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleActions_ModuleId",
                table: "ModuleActions",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationDetails_NotificationId",
                table: "NotificationDetails",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationDetails_UserId",
                table: "NotificationDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleModuleActions_ModuleActionId",
                table: "RoleModuleActions",
                column: "ModuleActionId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleModuleActions_RoleId",
                table: "RoleModuleActions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AssignedUserUserId",
                table: "Tasks",
                column: "AssignedUserUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commands");

            migrationBuilder.DropTable(
                name: "NotificationDetails");

            migrationBuilder.DropTable(
                name: "RoleModuleActions");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "ModuleActions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "Modules");
        }
    }
}
