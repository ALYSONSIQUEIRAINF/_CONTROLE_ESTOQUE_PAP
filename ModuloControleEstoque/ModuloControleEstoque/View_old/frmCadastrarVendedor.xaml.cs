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
    /// Interaction logic for frmCadastrarVendedor.xaml
    /// </summary>
    public partial class frmCadastrarVendedor : Window
    {
        private Vendedor v;

        public frmCadastrarVendedor()
        {
            InitializeComponent();
        }

        private void btnCadastrarVendedor_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(txtNomeVendedor.Text) && !string.IsNullOrEmpty(txtCPFVendedor.Text) &&
               !string.IsNullOrEmpty(DtAdmissao.Text) && !string.IsNullOrEmpty(txtComissaoVendedor.Text))
            {


                v = new Vendedor
                {
                    Nome = txtNomeVendedor.Text,
                    CPF = txtCPFVendedor.Text,
                    Comissao = Convert.ToDouble(txtComissaoVendedor.Text),
                    DataAdmissao = Convert.ToDateTime(DtAdmissao.Text),
                    DataDemissao = Convert.ToDateTime(DtDemissao.Text)
                };
                if (VendedorDAO.AdicionarVendedor(v))
                {
                    MessageBox.Show("Vendedor cadastrado com sucesso",
                        "Vendas WPF", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Não foi possível cadastrar o Vendedor",
                        "Vendas WPF", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

        }

        private void btnAlterarVendedor_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNomeVendedor.Text) && !string.IsNullOrEmpty(txtCPFVendedor.Text) &&
               !string.IsNullOrEmpty(DtAdmissao.Text) && !string.IsNullOrEmpty(txtComissaoVendedor.Text))
            {
                v.Nome = txtNomeVendedor.Text;
                v.CPF = txtCPFVendedor.Text;
                v.Comissao = Convert.ToDouble(txtComissaoVendedor.Text);
                v.DataAdmissao = Convert.ToDateTime(DtAdmissao.Text);
                v.DataDemissao = Convert.ToDateTime(DtDemissao.Text);

                if (VendedorDAO.AlterarVendedor(v))
                {
                    MessageBox.Show("Vendedor alterado com Sucesso!", "Controle de Estoque", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Não foi possível alterar Vendedor!", "Controle de Estoque", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos", "Controle de Estoque", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnBuscarVendedor_Click(object sender, RoutedEventArgs e)
        {
            btnAlterarVendedor.IsEnabled = true;
            btnCadastrarVendedor.IsEnabled = false;

            if (!string.IsNullOrEmpty(txtCPFVendedor.Text))
            {
                v = new Vendedor();

                v = VendedorDAO.ProcurarVendedorPorCPF(v);
                if (v != null)
                {
                    txtNomeVendedor.Text = v.Nome;
                    txtCPFVendedor.Text = v.CPF;
                    txtComissaoVendedor.Text = Convert.ToString(v.Comissao);
                    DtAdmissao.Text = Convert.ToString(v.DataAdmissao);
                    DtDemissao.Text = Convert.ToString(v.DataDemissao);

                }
                else
                {
                    MessageBox.Show("Não foi possível encontrar o Vendedor!", "VendasWPF", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Preencha o CPF do Vendedor!", "VendasWPF", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void LimparCampos()
        {
            txtNomeVendedor.Clear();
            txtCPFVendedor.Clear();
            txtComissaoVendedor.Clear();
            txtNomeVendedor.Focus();
        }
    }
}
