using ModuloControleEstoque.DAL;
using ModuloControleEstoque.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ModuloControleEstoque.View
{
    /// <summary>
    /// Interaction logic for frmTransportadora.xaml
    /// </summary>
    public partial class frmTransportadora : Window
    {
        private Transportadora t;

        public frmTransportadora()
        {
            InitializeComponent();
        }

        private void btnBuscarTransportadora_Click(object sender, RoutedEventArgs e)
        {
            btnGravarTransportadora.IsEnabled = false;
            btnAlterarTransportadora.IsEnabled = true;

            if (!string.IsNullOrEmpty(txtNomeTransportadora.Text))
            {
                t = new Transportadora
                {
                    NomeTransportadora = txtNomeTransportadora.Text
                };
                t = TransportadoraDAO.ProcurarTransportadora(t);
                if (t != null)
                {
                    txtNomeTransportadora.Text = t.NomeTransportadora;
                    txtAgregadoTransportadora.Text = Convert.ToString(t.AgregadoMinimo);
                    txtAcrescimoTransportadora.Text = Convert.ToString(t.AcrescimoTransportadora);
                }
                else
                {
                    MessageBox.Show("Não foi possível encontrar a Transportadora!", "Transportadora WPF",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Favor preencher os campos", "Transportadora WPF",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnGravarTransportadora_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNomeTransportadora.Text) && !string.IsNullOrEmpty(txtAgregadoTransportadora.Text))
            {
                if (!string.IsNullOrEmpty(txtAcrescimoTransportadora.Text))
                {
                    t = new Transportadora
                    {
                        NomeTransportadora = txtNomeTransportadora.Text,
                        AcrescimoTransportadora = Convert.ToDouble(txtAcrescimoTransportadora.Text),
                        AgregadoMinimo = Convert.ToDouble(txtAgregadoTransportadora.Text)
                    };
                    if (TransportadoraDAO.AdicionarTransportadora(t))
                    {
                        MessageBox.Show("Transportadora cadastrada com sucesso!", "Transportadora WPF",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        LimparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível adicionar a Transportadora!", "Transportadora WPF",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Favor preencher os campos", "Transportadora WPF",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnAlterarTransportadora_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNomeTransportadora.Text) && !string.IsNullOrEmpty(txtAgregadoTransportadora.Text))
            {
                if (!string.IsNullOrEmpty(txtAcrescimoTransportadora.Text))
                {
                    txtNomeTransportadora.Text = t.NomeTransportadora;
                    txtAgregadoTransportadora.Text = Convert.ToString(t.AgregadoMinimo);
                    txtAcrescimoTransportadora.Text = Convert.ToString(t.AcrescimoTransportadora);

                    if (TransportadoraDAO.AlterarTransportadora(t))
                    {
                        MessageBox.Show("Transportadora alterado com sucesso!", "Transportadora WPF",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        LimparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível alterar a Transportadora!", "Transportadora WPF",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Favor preencher os campos", "Transportadora WPF",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        public void LimparCampos()
        {
            txtAcrescimoTransportadora.Clear();
            txtAgregadoTransportadora.Clear();
            txtNomeTransportadora.Focus();

        }

    }
}
