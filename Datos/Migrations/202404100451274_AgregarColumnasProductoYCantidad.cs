namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarColumnasProductoYCantidad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedido", "ProductoId", c => c.Int(nullable: false));
            AddColumn("dbo.Pedido", "Cantidad", c => c.Int(nullable: false));
            CreateIndex("dbo.Pedido", "ProductoId");
            AddForeignKey("dbo.Pedido", "ProductoId", "dbo.Producto", "ProductoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedido", "ProductoId", "dbo.Producto");
            DropIndex("dbo.Pedido", new[] { "ProductoId" });
            DropColumn("dbo.Pedido", "Cantidad");
            DropColumn("dbo.Pedido", "ProductoId");
        }
    }
}
