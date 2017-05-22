using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloControleEstoque.Model
{
    [Table("EnderecoNivel")]
    class EnderecoNivel
    {
        [Key]
        public int EnderecoNivelId { get; set; }
        public int CodigoNivel { get; set; }
        public string DescricaoNivel { get; set; }
        public List<EnderecoApartamento> EnderecoApartamento { get; set; }
        public EnderecoNivel()
        {
            EnderecoApartamento = new List<EnderecoApartamento>();
        }
    }
}
