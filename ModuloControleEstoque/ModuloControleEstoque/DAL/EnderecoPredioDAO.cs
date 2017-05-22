using ModuloControleEstoque.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloControleEstoque.DAL
{
    class EnderecoPredioDAO
    {
        private static List<EnderecoNivel> EnderecoNivel = new List<EnderecoNivel>();
        private static Context ctx = Singleton.Instance.Context;
    }
}
