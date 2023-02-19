using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EShopping.ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Products(Name, Price, Description, Stock, ImageUrl,CategoryId)" + 
                "Values('Caderno',7.55,'Caderno','10','caderno1.jpg',1)");

            mb.Sql("Insert into Products(Name, Price, Description, Stock, ImageUrl,CategoryId)" +
            "Values('Lapis',3.55,'Lapis Preto','20','Lapis1.jpg',1)");

            mb.Sql("Insert into Products(Name, Price, Description, Stock, ImageUrl,CategoryId)" +
            "Values('Clips',5.55,'Clips para papel','10','Clips.jpg',2)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from Products");

        }
    }
}
