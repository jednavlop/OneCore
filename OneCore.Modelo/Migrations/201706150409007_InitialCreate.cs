namespace OneCore.Modelo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 5),
                        Contraseña = c.String(nullable: false, maxLength: 5),
                        Correo = c.String(maxLength: 5),
                        Sexo = c.String(nullable: false, maxLength: 1),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioID)
                .Index(t => t.Nombre, unique: true, name: "IX_UsuariosNombre")
                .Index(t => t.Contraseña, name: "IX_UsuarioContraseña");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Usuarios", "IX_UsuarioContraseña");
            DropIndex("dbo.Usuarios", "IX_UsuariosNombre");
            DropTable("dbo.Usuarios");
        }
    }
}
