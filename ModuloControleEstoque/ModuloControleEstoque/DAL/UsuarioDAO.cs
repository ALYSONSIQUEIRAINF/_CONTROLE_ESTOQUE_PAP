using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuloControleEstoque.Model;

namespace ModuloControleEstoque.DAL
{
    class UsuarioDAO
    {

        private static Context ctx = Singleton.Instance.Context;
        private List<Usuario> Usuarios = new List<Usuario>();
        
        public static bool AdicionarUsuario(Usuario usuario)
        {
            if(ProcurarUsuarioPorCodigo1(usuario)!= null)
            {
                return false;
            }else
            {
                try
                {
                    ctx.Usuario.Add(usuario);
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static Usuario ProcurarUsuarioPorCodigo1(Usuario usuario)
        {
            return ctx.Usuario.FirstOrDefault(x => x.CodigoUsuario.Equals(usuario));

        }

        public static Usuario ProcurarUsuarioPorCodigo(string usuario)
        {
            return ctx.Usuario.FirstOrDefault(x => x.CodigoUsuario.Equals(usuario));
            
        }

        public static Usuario ValidarUsuarioPorSenha(string senha)
        {
           return ctx.Usuario.FirstOrDefault(x => x.SenhaUsuario.Equals(senha));
        }

        public static bool ValidarSenhaUsuario(string usuario, string senha)
        {

            if (ProcurarUsuarioPorCodigo(usuario) != null &&
                ValidarUsuarioPorSenha(senha) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
