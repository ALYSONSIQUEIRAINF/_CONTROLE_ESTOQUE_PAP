using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ModuloControleEstoque.Model
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        public string DescricaoCategoria { get; set; }

        public List<Produto> CategoriaProduto { get; set; }
        public Categoria()
        {

        }
    }

    
}
