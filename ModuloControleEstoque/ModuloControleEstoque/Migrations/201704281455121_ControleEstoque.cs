namespace ModuloControleEstoque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ControleEstoque : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        DescricaoCategoria = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        CodigoProduto = c.Int(nullable: false),
                        DescricaoProduto = c.String(),
                        PrecoProduto = c.Double(nullable: false),
                        PesoBrutoProduto = c.Double(nullable: false),
                        PesoLiquidoProduto = c.Double(nullable: false),
                        QuantidadeEstoqueProduto = c.Int(nullable: false),
                        EnderecoRua = c.String(),
                        EnderecoBloco = c.String(),
                        EnderecoPratileira = c.String(),
                        CorProduto = c.String(),
                        CategoriaProduto_CategoriaId = c.Int(),
                        EmbalagemProduto_EmbalagemId = c.Int(),
                    })
                .PrimaryKey(t => t.ProdutoId)
                .ForeignKey("dbo.Categoria", t => t.CategoriaProduto_CategoriaId)
                .ForeignKey("dbo.Embalagem", t => t.EmbalagemProduto_EmbalagemId)
                .Index(t => t.CategoriaProduto_CategoriaId)
                .Index(t => t.EmbalagemProduto_EmbalagemId);
            
            CreateTable(
                "dbo.Embalagem",
                c => new
                    {
                        EmbalagemId = c.Int(nullable: false, identity: true),
                        DescricaoEmbalagem = c.String(),
                        CodigoEmbalagem = c.Int(nullable: false),
                        QuantidadeProdutoEmbalagem = c.Int(nullable: false),
                        TipoEmbalagem = c.String(),
                    })
                .PrimaryKey(t => t.EmbalagemId);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        SobreNome = c.String(),
                        CPF = c.String(),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.EnderecoApartamento",
                c => new
                    {
                        EnderecoApartamentoId = c.Int(nullable: false, identity: true),
                        CodigoApartamento = c.Int(nullable: false),
                        DescricaoApartamento = c.String(),
                        EnderecoNivel_EnderecoNivelId = c.Int(),
                    })
                .PrimaryKey(t => t.EnderecoApartamentoId)
                .ForeignKey("dbo.EnderecoNivel", t => t.EnderecoNivel_EnderecoNivelId)
                .Index(t => t.EnderecoNivel_EnderecoNivelId);
            
            CreateTable(
                "dbo.EnderecoLocal",
                c => new
                    {
                        EnderecoLocalId = c.Int(nullable: false, identity: true),
                        CodigoLocal = c.Int(nullable: false),
                        DescricaoLocal = c.String(),
                    })
                .PrimaryKey(t => t.EnderecoLocalId);
            
            CreateTable(
                "dbo.EnderecoRua",
                c => new
                    {
                        EnderecoRuaId = c.Int(nullable: false, identity: true),
                        CodigoRua = c.Int(nullable: false),
                        DescricaoRua = c.String(),
                        EnderecoLocal_EnderecoLocalId = c.Int(),
                    })
                .PrimaryKey(t => t.EnderecoRuaId)
                .ForeignKey("dbo.EnderecoLocal", t => t.EnderecoLocal_EnderecoLocalId)
                .Index(t => t.EnderecoLocal_EnderecoLocalId);
            
            CreateTable(
                "dbo.EnderecoPredio",
                c => new
                    {
                        EnderecoPredioId = c.Int(nullable: false, identity: true),
                        CodigoPredio = c.Int(nullable: false),
                        DescricaoPredio = c.String(),
                        EnderecoRua_EnderecoRuaId = c.Int(),
                    })
                .PrimaryKey(t => t.EnderecoPredioId)
                .ForeignKey("dbo.EnderecoRua", t => t.EnderecoRua_EnderecoRuaId)
                .Index(t => t.EnderecoRua_EnderecoRuaId);
            
            CreateTable(
                "dbo.EnderecoNivel",
                c => new
                    {
                        EnderecoNivelId = c.Int(nullable: false, identity: true),
                        CodigoNivel = c.Int(nullable: false),
                        DescricaoNivel = c.String(),
                        EnderecoPredio_EnderecoPredioId = c.Int(),
                    })
                .PrimaryKey(t => t.EnderecoNivelId)
                .ForeignKey("dbo.EnderecoPredio", t => t.EnderecoPredio_EnderecoPredioId)
                .Index(t => t.EnderecoPredio_EnderecoPredioId);
            
            CreateTable(
                "dbo.Estoques",
                c => new
                    {
                        EstoqueId = c.Int(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        MargemSeg = c.Double(nullable: false),
                        Produtos_ProdutoId = c.Int(),
                    })
                .PrimaryKey(t => t.EstoqueId)
                .ForeignKey("dbo.Produto", t => t.Produtos_ProdutoId)
                .Index(t => t.Produtos_ProdutoId);
            
            CreateTable(
                "dbo.ItemVenda",
                c => new
                    {
                        ItemVendaId = c.Int(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        QtdadeEstoque = c.Int(nullable: false),
                        PrecoUnitario = c.Double(nullable: false),
                        Categoria_CategoriaId = c.Int(),
                        Embalagem_EmbalagemId = c.Int(),
                        Produto_ProdutoId = c.Int(),
                        Venda_VendaId = c.Int(),
                    })
                .PrimaryKey(t => t.ItemVendaId)
                .ForeignKey("dbo.Categoria", t => t.Categoria_CategoriaId)
                .ForeignKey("dbo.Embalagem", t => t.Embalagem_EmbalagemId)
                .ForeignKey("dbo.Produto", t => t.Produto_ProdutoId)
                .ForeignKey("dbo.Vendas", t => t.Venda_VendaId)
                .Index(t => t.Categoria_CategoriaId)
                .Index(t => t.Embalagem_EmbalagemId)
                .Index(t => t.Produto_ProdutoId)
                .Index(t => t.Venda_VendaId);
            
            CreateTable(
                "dbo.Pagamento",
                c => new
                    {
                        PagamentoId = c.Int(nullable: false, identity: true),
                        NomeCondicaoPagamento = c.String(),
                        CodigoNegociacaoPagamento = c.String(),
                        DescricaoCondicaoPagamento = c.String(),
                        DescontoCondicaoPagamento = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PagamentoId);
            
            CreateTable(
                "dbo.Transportadora",
                c => new
                    {
                        TransportadoraId = c.Int(nullable: false, identity: true),
                        NomeTransportadora = c.String(),
                        AcrescimoTransportadora = c.Double(nullable: false),
                        AgregadoMinimo = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.TransportadoraId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        CodigoUsuario = c.String(),
                        SenhaUsuario = c.String(),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Vendas",
                c => new
                    {
                        VendaId = c.Int(nullable: false, identity: true),
                        DataDaVenda = c.DateTime(nullable: false),
                        MyProperty = c.Int(nullable: false),
                        Cliente_ClienteId = c.Int(),
                        Pagamento_PagamentoId = c.Int(),
                        Transportadora_TransportadoraId = c.Int(),
                        Vendedor_VendedorId = c.Int(),
                    })
                .PrimaryKey(t => t.VendaId)
                .ForeignKey("dbo.Clientes", t => t.Cliente_ClienteId)
                .ForeignKey("dbo.Pagamento", t => t.Pagamento_PagamentoId)
                .ForeignKey("dbo.Transportadora", t => t.Transportadora_TransportadoraId)
                .ForeignKey("dbo.Vendedores", t => t.Vendedor_VendedorId)
                .Index(t => t.Cliente_ClienteId)
                .Index(t => t.Pagamento_PagamentoId)
                .Index(t => t.Transportadora_TransportadoraId)
                .Index(t => t.Vendedor_VendedorId);
            
            CreateTable(
                "dbo.Vendedores",
                c => new
                    {
                        VendedorId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        CPF = c.String(),
                        Comissao = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.VendedorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendas", "Vendedor_VendedorId", "dbo.Vendedores");
            DropForeignKey("dbo.Vendas", "Transportadora_TransportadoraId", "dbo.Transportadora");
            DropForeignKey("dbo.ItemVenda", "Venda_VendaId", "dbo.Vendas");
            DropForeignKey("dbo.Vendas", "Pagamento_PagamentoId", "dbo.Pagamento");
            DropForeignKey("dbo.Vendas", "Cliente_ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.ItemVenda", "Produto_ProdutoId", "dbo.Produto");
            DropForeignKey("dbo.ItemVenda", "Embalagem_EmbalagemId", "dbo.Embalagem");
            DropForeignKey("dbo.ItemVenda", "Categoria_CategoriaId", "dbo.Categoria");
            DropForeignKey("dbo.Estoques", "Produtos_ProdutoId", "dbo.Produto");
            DropForeignKey("dbo.EnderecoRua", "EnderecoLocal_EnderecoLocalId", "dbo.EnderecoLocal");
            DropForeignKey("dbo.EnderecoPredio", "EnderecoRua_EnderecoRuaId", "dbo.EnderecoRua");
            DropForeignKey("dbo.EnderecoNivel", "EnderecoPredio_EnderecoPredioId", "dbo.EnderecoPredio");
            DropForeignKey("dbo.EnderecoApartamento", "EnderecoNivel_EnderecoNivelId", "dbo.EnderecoNivel");
            DropForeignKey("dbo.Produto", "EmbalagemProduto_EmbalagemId", "dbo.Embalagem");
            DropForeignKey("dbo.Produto", "CategoriaProduto_CategoriaId", "dbo.Categoria");
            DropIndex("dbo.Vendas", new[] { "Vendedor_VendedorId" });
            DropIndex("dbo.Vendas", new[] { "Transportadora_TransportadoraId" });
            DropIndex("dbo.Vendas", new[] { "Pagamento_PagamentoId" });
            DropIndex("dbo.Vendas", new[] { "Cliente_ClienteId" });
            DropIndex("dbo.ItemVenda", new[] { "Venda_VendaId" });
            DropIndex("dbo.ItemVenda", new[] { "Produto_ProdutoId" });
            DropIndex("dbo.ItemVenda", new[] { "Embalagem_EmbalagemId" });
            DropIndex("dbo.ItemVenda", new[] { "Categoria_CategoriaId" });
            DropIndex("dbo.Estoques", new[] { "Produtos_ProdutoId" });
            DropIndex("dbo.EnderecoNivel", new[] { "EnderecoPredio_EnderecoPredioId" });
            DropIndex("dbo.EnderecoPredio", new[] { "EnderecoRua_EnderecoRuaId" });
            DropIndex("dbo.EnderecoRua", new[] { "EnderecoLocal_EnderecoLocalId" });
            DropIndex("dbo.EnderecoApartamento", new[] { "EnderecoNivel_EnderecoNivelId" });
            DropIndex("dbo.Produto", new[] { "EmbalagemProduto_EmbalagemId" });
            DropIndex("dbo.Produto", new[] { "CategoriaProduto_CategoriaId" });
            DropTable("dbo.Vendedores");
            DropTable("dbo.Vendas");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Transportadora");
            DropTable("dbo.Pagamento");
            DropTable("dbo.ItemVenda");
            DropTable("dbo.Estoques");
            DropTable("dbo.EnderecoNivel");
            DropTable("dbo.EnderecoPredio");
            DropTable("dbo.EnderecoRua");
            DropTable("dbo.EnderecoLocal");
            DropTable("dbo.EnderecoApartamento");
            DropTable("dbo.Clientes");
            DropTable("dbo.Embalagem");
            DropTable("dbo.Produto");
            DropTable("dbo.Categoria");
        }
    }
}
