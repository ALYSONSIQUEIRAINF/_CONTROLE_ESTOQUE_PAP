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
    /// Interaction logic for frmCadastroPagamento.xaml
    /// </summary>
    public partial class frmCadastroPagamento : Window
    {
        private Pagamento p;
        public frmCadastroPagamento()
        {
            InitializeComponent();
        }

        private void btnCadastrarPagamento_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigoPag.Text) && !string.IsNullOrEmpty(txtNomePag.Text) &&
                !string.IsNullOrEmpty(txtDescontoPag.Text) && !string.IsNullOrEmpty(txtDescricaoPag.Text))
            {
                p = new Pagamento
                {
                    NomeCondicaoPagamento = txtNomePag.Text,
                    CodigoNegociacaoPagamento = txtCodigoPag.Text,
                    DescontoCondicaoPagamento = Convert.ToDouble(txtDescontoPag.Text),
                    DescricaoCondicaoPagamento = txtDescricaoPag.Text
                };

                if (PagamentoDAO.AdicionarCondicaoPagamento(p))
                {
                    MessageBox.Show("Pagamento cadastrado com sucesso",
                        "Vendas WPF", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Não foi possível cadastrar o Pagamento",
                        "Vendas WPF", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void btnAlterarPagamento_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigoPag.Text) && !string.IsNullOrEmpty(txtNomePag.Text) &&
                !string.IsNullOrEmpty(txtDescontoPag.Text) && !string.IsNullOrEmpty(txtDescricaoPag.Text))
            {
                p.CodigoNegociacaoPagamento = txtCodigoPag.Text;
                p.NomeCondicaoPagamento = txtNomePag.Text;
                p.DescontoCondicaoPagamento = Convert.ToDouble(txtDescontoPag.Text);
                p.DescricaoCondicaoPagamento = txtDescricaoPag.Text;

                if (PagamentoDAO.AlterarPagamento(p))
                {
                    MessageBox.Show("Pagamento alterado com Sucesso!", "Controle de Estoque", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Não foi possível alterar o Pagamento!", "Controle de Estoque", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos", "Controle de Estoque", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }



        private void btnBuscarPagamento_Click(object sender, RoutedEventArgs e)
        {
            btnAlterarPagamento.IsEnabled = true;
            btnCadastrarPagamento.IsEnabled = false;

            if (!string.IsNullOrEmpty(txtCodigoPag.Text))
            {
                p = new Pagamento
                {
                    CodigoNegociacaoPagamento = txtCodigoPag.Text
                };

                p = PagamentoDAO.procurarCondicaoPagamentoPorCodigo(p);
                if (p != null)
                {
                    txtCodigoPag.Text = p.CodigoNegociacaoPagamento;
                    txtNomePag.Text = p.NomeCondicaoPagamento;
                    txtDescontoPag.Text = Convert.ToString(p.DescontoCondicaoPagamento);
                    txtDescricaoPag.Text = p.DescricaoCondicaoPagamento;

                }
                else
                {
                    MessageBox.Show("Não foi possível encontrar o Pagamento!", "VendasWPF", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Preencha o Cógigo do Pagamento!", "VendasWPF", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void LimparCampos()
        {
            txtNomePag.Clear();
            txtCodigoPag.Clear();
            txtDescontoPag.Clear();
            txtDescricaoPag.Clear();
            txtCodigoPag.Focus();
        }
    }
}
