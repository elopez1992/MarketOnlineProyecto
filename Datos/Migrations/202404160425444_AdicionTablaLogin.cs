namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionTablaLogin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Login",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        UsuarioLogin = c.String(nullable: false),
                        Nombre = c.String(nullable: false),
                        Clave = c.String(),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Login");
        }
    }
}
