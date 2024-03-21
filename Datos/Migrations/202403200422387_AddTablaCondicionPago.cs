namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTablaCondicionPago : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CondicionPago",
                c => new
                    {
                        CondicionPagoId = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 50),
                        DescripcionCP = c.String(nullable: false, maxLength: 50),
                        Estado = c.Boolean(nullable: false),
                        Dias = c.Int(nullable: false),
                        FechaCreacionCP = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CondicionPagoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CondicionPago");
        }
    }
}
