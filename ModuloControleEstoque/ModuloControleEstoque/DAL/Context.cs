using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuloControleEstoque.Model;
using System.Data.SqlClient;

namespace ModuloControleEstoque.DAL
{
    class Context : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<ItemVenda> ItensVendas { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        //public DbSet<EnderecoEstoque> Endereco { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Embalagem> Embalagem { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Transportadora> Transportadora { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<EnderecoLocal> EnderecoLocal { get; set; }
        public DbSet<EnderecoRua> EnderecoRua { get; set; }
        public DbSet<EnderecoPredio> EnderecoPredio { get; set; }
        public DbSet<EnderecoNivel> EnderecoNivel { get; set; }
        public DbSet<EnderecoApartamento> EnderecoApartamento { get; set; }

    }

    
}
