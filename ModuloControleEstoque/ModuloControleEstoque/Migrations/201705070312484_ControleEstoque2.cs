namespace ModuloControleEstoque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ControleEstoque2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pagamento", "AcrescimentoPagamento", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pagamento", "AcrescimentoPagamento");
        }
    }
}
