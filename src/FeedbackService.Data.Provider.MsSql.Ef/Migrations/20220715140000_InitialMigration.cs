using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityHelper.FeedbackService.Data.Provider.MsSql.Ef.Migrations
{
  /// <inheritdoc />
  public partial class InitialMigration : Migration
  {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Feedbacks",
          columns: table => new
          {
            Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            Type = table.Column<int>(type: "int", nullable: false),
            Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
            Status = table.Column<int>(type: "int", nullable: false),
            SenderFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
            SenderIp = table.Column<string>(type: "nvarchar(max)", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Feedbacks", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "Images",
          columns: table => new
          {
            Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
            Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
            CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
            FeedbackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Images", x => x.Id);
            table.ForeignKey(
                      name: "FK_Images_Feedbacks_FeedbackId",
                      column: x => x.FeedbackId,
                      principalTable: "Feedbacks",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateIndex(
          name: "IX_Images_FeedbackId",
          table: "Images",
          column: "FeedbackId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Images");

      migrationBuilder.DropTable(
          name: "Feedbacks");
    }
  }
}