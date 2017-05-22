using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloControleEstoque.Model
{
    [Table("Vendedores")]
    class Vendedor
    {
        [Key]
        public int VendedorId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public double Comissao { get; set; }

        //public Usuario Usuario { get; set; }

        public Vendedor()
        {
            //Usuario = new Usuario();
        }

        public override string ToString()
        {
            return "\nNome: " + Nome + " CPF: " + CPF;
        }
    }
}
