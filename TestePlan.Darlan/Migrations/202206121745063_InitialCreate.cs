namespace TestePlan.Darlan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        IDCliente = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        TipoCliente = c.Int(nullable: false),
                        DocumentoCNPJ = c.String(),
                        DocumentoCPF = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                        Inativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IDCliente);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clientes");
        }
    }
}
