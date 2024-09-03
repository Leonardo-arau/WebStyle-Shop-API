using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebStyle.ProductApi.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Products(Name, Price, Description, Stock, ImagemUrl, CategoryId) " +
                "values('Camiseta', '35.50', 'Camiseta', 13, 'Camiseta1.jpg', 2)");

            mb.Sql("Insert into Products(Name, Price, Description, Stock, ImagemUrl, CategoryId) " +
              "values('Camisa', 20.50, 'Camisa', 19, 'Camisa1.jpg', 2)");

            mb.Sql("Insert into Products(Name, Price, Description, Stock, ImagemUrl, CategoryId) " +
              "values('Calças', 45.50, 'Calça', 10, 'Calça1.jpg', 2)");

            mb.Sql("Insert into Products(Name, Price, Description, Stock, ImagemUrl, CategoryId) " +
             "values('Bolsa', 60.00, 'Bolsa' ,7 ,'Bolsa1.jpg', 1)");

            mb.Sql("Insert into Products(Name, Price, Description, Stock, ImagemUrl, CategoryId) " +
             "values('Chapéu', 20.99, 'Chapéu', 13, 'chapeu1.jpg',1)");
            
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from Products");
        }
    }
}
