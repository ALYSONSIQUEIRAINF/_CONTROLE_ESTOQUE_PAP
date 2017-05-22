using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloControleEstoque.Model
{
    [Table("Transportadora")]
    class Transportadora
    {
        [Key]
        public int TransportadoraId{ get; set; }
        public string NomeTransportadora { get; set; }
        public double AcrescimoTransportadora { get; set; }
        public double AgregadoMinimo { get; set; }
        

    }
}
