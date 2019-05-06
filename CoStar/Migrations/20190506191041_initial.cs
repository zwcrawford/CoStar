﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoStar.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ApplicationUserImage = table.Column<byte[]>(nullable: true),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    EnrollDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    LinkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LinkUrl = table.Column<string>(nullable: false),
                    LinkDescription = table.Column<string>(nullable: false),
                    UserIdId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.LinkId);
                    table.ForeignKey(
                        name: "FK_Links_AspNetUsers_UserIdId",
                        column: x => x.UserIdId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Principles",
                columns: table => new
                {
                    PrincipleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PrincipleImage = table.Column<string>(nullable: true),
                    PrincipleName = table.Column<string>(nullable: false),
                    PrincipleDescription = table.Column<string>(nullable: false),
                    UserIdId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Principles", x => x.PrincipleId);
                    table.ForeignKey(
                        name: "FK_Principles_AspNetUsers_UserIdId",
                        column: x => x.UserIdId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    IntQuestionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IntQuestionName = table.Column<string>(nullable: false),
                    IntQuestionDescription = table.Column<string>(nullable: false),
                    UserIdId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.IntQuestionId);
                    table.ForeignKey(
                        name: "FK_Questions_AspNetUsers_UserIdId",
                        column: x => x.UserIdId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Whiteboards",
                columns: table => new
                {
                    WhiteboardId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WhiteboardImage = table.Column<string>(nullable: true),
                    WhiteboardName = table.Column<string>(nullable: false),
                    WhiteboardDescription = table.Column<string>(nullable: false),
                    UserIdId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Whiteboards", x => x.WhiteboardId);
                    table.ForeignKey(
                        name: "FK_Whiteboards_AspNetUsers_UserIdId",
                        column: x => x.UserIdId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ApplicationUserImage", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4516b530-a728-428d-b429-5c4433e55432", 0, null, "9187ea44-e262-4de7-8347-c2b6405cf068", "admin@admin.com", true, "Admin", "Admin", false, null, "admin@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAED8cCOSoCrLIZoXZTGLj9ViXc42CigHzcos05mM1k8HnN6oa7Hm+HYchNP8ausB6sQ==", null, false, "db96abf0-ebc4-43f3-b4b3-18772efc2b1c", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ApplicationUserImage", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2b5cb8a2-1d65-4b22-8af7-4a1ac2a5610f", 0, null, "4c880e31-f1d6-4f15-9219-01ed0590898d", "guest@admin.com", true, "Guest", "Guest", false, null, "guest@ADMIN.COM", "GUEST@ADMIN.COM", "AQAAAAEAACcQAAAAEC8iUlCkaCFLVqQleRdj1XShKQiieVAYa+QVlKIqPlYk8gGhCEPrQr8WqapJ7r86Yw==", null, false, "af8b3989-88ee-42da-b2d1-14356ae71f88", false, "guest@admin.com" });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "LinkId", "LinkDescription", "LinkUrl", "UserIdId" },
                values: new object[,]
                {
                    { 1, "JavaScript language Documentation", "https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference", null },
                    { 2, "C# language Documentation", "https://docs.microsoft.com/en-us/dotnet/csharp/", null },
                    { 3, "React - Getting Started", "https://reactjs.org/docs/getting-started.html", null }
                });

            migrationBuilder.InsertData(
                table: "Principles",
                columns: new[] { "PrincipleId", "PrincipleDescription", "PrincipleImage", "PrincipleName", "UserIdId" },
                values: new object[,]
                {
                    { 1, "SOLID is an acronym for the first five object-oriented design(OOD) principles by Robert C. Martin. These principles, when combined together, make it easy for a programmer to develop software that are easy to maintain and extend, and are also a part of agile, an adaptive software development principle. [S]ingle Responsibility Principle, [O]pen/ Closed Principle, [L]iskov Substitution Principle, [I]ntegration Segregation Principle, [D]ependency Inversion Principle", "../wwwroot/Images/SOLID_Img.png", "S.O.L.I.D.", null },
                    { 2, "Object Oriented Programming(OOP) is a language model that is organized around objects rather than actions and data rather than logic. There are four pillars of OOP: Abstraction, Polymorphism, Inheritance, and Encapsulation. You can remember this mnemonic device - A.P.I.E., because pie is awesome!", "../wwwroot/Images/OOP_Img.png", "O.O.P.", null },
                    { 3, "There are four values derived from the Agile Manifesto: Individuals and Interactions Over Processes and Tools, Working Software Over Comprehensive Documentation, Customer Collaboration Over Contract Negotiation, Responding to Change Over Following a Plan.", "../wwwroot/Images/AGILE_Img.png", "Agile", null }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "IntQuestionId", "IntQuestionDescription", "IntQuestionName", "UserIdId" },
                values: new object[,]
                {
                    { 1, "Alert and Prompt.", "What are the two types of pop-ups?", null },
                    { 2, "Content can be replaced anywhere.", "What is the disadvantage of using : 'innerHTML'?", null },
                    { 3, "var is function-scoped and let is block-scoped.", "What is the difference between var and let?", null },
                    { 4, "The first option == checks value equality, whereas === returns false, and checks both type and value equality.", "What is the difference between '==' and '==='?", null }
                });

            migrationBuilder.InsertData(
                table: "Whiteboards",
                columns: new[] { "WhiteboardId", "UserIdId", "WhiteboardDescription", "WhiteboardImage", "WhiteboardName" },
                values: new object[,]
                {
                    { 1, null, "Find the median of two sorted arrays.", "../wwwroot/Images/MedianArrays_Img.png", "Median of Arrays" },
                    { 2, null, "Write a program that prints the numbers from 1 to 100 (here I have only written it for 1 to 15). But for multiples of three print 'Fizz' instead of the number and for the multiples of five print 'Buzz'. For numbers which are multiples of both three and five print 'FizzBuzz'.", "../wwwroot/Images/FizzBuzz_Img.png", "Fizz Buzz" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Links_UserIdId",
                table: "Links",
                column: "UserIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Principles_UserIdId",
                table: "Principles",
                column: "UserIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_UserIdId",
                table: "Questions",
                column: "UserIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Whiteboards_UserIdId",
                table: "Whiteboards",
                column: "UserIdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Principles");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Whiteboards");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
