using ModuloControleEstoque.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModuloControleEstoque.DAL
{
    class TransportadoraDAO
    {
        private static List<Transportadora> transportadoras = new List<Transportadora>();

        private static Context ctx = Singleton.Instance.Context;

        public static bool AdicionarTransportadora(Transportadora transportadora)
        {

            if (ProcurarTransportadora(transportadora) != null)
            {
                return false;
            }
            else
            {
                try
                {
                    ctx.Transportadora.Add(transportadora);
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }

        public static Transportadora ProcurarTransportadora(Transportadora transportadora)
        {
            return ctx.Transportadora.FirstOrDefault(x => x.NomeTransportadora.Equals(transportadora.NomeTransportadora));
        }

        public static Transportadora ProcurarTransportadoraPorId(int id)
        {
            return ctx.Transportadora.FirstOrDefault(x => x.TransportadoraId.Equals(id));
        }

        public static List<Transportadora> RetornarLista()
        {

            return ctx.Transportadora.ToList();
        }

        public static bool AlterarTransportadora(Transportadora transportadora)
        {
            try
            {
                ctx.Entry(transportadora).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public static bool RemoverTransportadora(Transportadora transportadora)
        {
            try
            {
                ctx.Transportadora.Remove(transportadora);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



    }
}
