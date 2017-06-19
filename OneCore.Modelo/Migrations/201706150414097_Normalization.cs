namespace OneCore.Modelo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Normalization : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Usuarios", "IX_UsuariosNombre");
            DropIndex("dbo.Usuarios", "IX_UsuarioContraseña");
            AlterColumn("dbo.Usuarios", "Nombre", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Usuarios", "Contraseña", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Usuarios", "Correo", c => c.String(maxLength: 50));
            CreateIndex("dbo.Usuarios", "Nombre", unique: true, name: "IX_UsuariosNombre");
            CreateIndex("dbo.Usuarios", "Contraseña", name: "IX_UsuarioContraseña");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Usuarios", "IX_UsuarioContraseña");
            DropIndex("dbo.Usuarios", "IX_UsuariosNombre");
            AlterColumn("dbo.Usuarios", "Correo", c => c.String(maxLength: 5));
            AlterColumn("dbo.Usuarios", "Contraseña", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.Usuarios", "Nombre", c => c.String(nullable: false, maxLength: 5));
            CreateIndex("dbo.Usuarios", "Contraseña", name: "IX_UsuarioContraseña");
            CreateIndex("dbo.Usuarios", "Nombre", unique: true, name: "IX_UsuariosNombre");
        }
    }
}
