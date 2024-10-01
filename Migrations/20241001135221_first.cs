using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sessions_app.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "table_user_pb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    name_pb = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    email_pb = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    password_pb = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    status_active_pb = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    role_pb = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    avatar_pb = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_table_user_pb", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "table_user_pb");
        }
    }
}
