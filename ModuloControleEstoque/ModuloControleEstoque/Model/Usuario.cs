using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloControleEstoque.Model
{
    [Table("Usuarios")]
    class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        public string CodigoUsuario { get; set; }

        public string SenhaUsuario { get; set; }


    }
}
