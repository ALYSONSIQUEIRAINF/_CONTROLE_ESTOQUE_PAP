using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloControleEstoque.Model
{
    [Table("EnderecoLocal")]
    class EnderecoLocal
    {
        [Key]
        public int EnderecoLocalId { get; set; }
        public int CodigoLocal { get; set; }
        public string DescricaoLocal { get; set; }
        public List<EnderecoRua> EnderecoRua { get; set; }

        public EnderecoLocal()
        {
            EnderecoRua = new List<EnderecoRua>();
        }
    }
}
