using Microsoft.EntityFrameworkCore.Migrations;

namespace UtopiaCity.Data.Migrations
{
    public partial class BusRouteTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusRoute",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartStation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinalStation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusStops = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusRoute", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusRoute");
        }
    }
}
