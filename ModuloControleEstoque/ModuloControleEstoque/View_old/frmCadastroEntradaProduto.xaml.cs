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
using ModuloControleEstoque.Model;
using ModuloControleEstoque.DAL;

namespace ModuloControleEstoque.View
{
    /// <summary>
    /// Lógica interna para frmCadastroEntradaProduto.xaml
    /// </summary>
    public partial class frmCadastroEntradaProduto : Window
    {
        private Produto p;

        public frmCadastroEntradaProduto()
        {
            InitializeComponent();
        }

        private void btnGravarEntradaProduto_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigoProduto.Text) &&
                !string.IsNullOrEmpty(txtNovaQuantidade.Text))
            {
                p.CodigoProduto = Convert.ToInt32(txtCodigoProduto.Text);
                p.QuantidadeEstoqueProduto = Convert.ToInt32(txtNovaQuantidade.Text);
                if (ProdutoDAO.AlteraSaldoEstoqueProduto(p))
                {
                    MessageBox.Show("Saldo alterado com sucesso!",
                        "Modulo Estoque", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Não foi possivel alterar o saldo!",
                        "Modulo Estoque", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Favor preencher os campos!",
                        "Modulo Estoque", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnBuscarSaldoProduto_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigoProduto.Text))
            {
                p = new Produto
                {
                    CodigoProduto = Convert.ToInt32(txtCodigoProduto.Text)
                };

                p = ProdutoDAO.ProcurarProdutoPorCodigo(p);

                if (p != null)

                {
                    txtCodigoProduto.Text = Convert.ToString(p.CodigoProduto);
                    txtNovaQuantidade.Text = Convert.ToString(p.QuantidadeEstoqueProduto);

                    btnGravarEntradaProduto.IsEnabled = true;
                }
            }
            else
            {
                MessageBox.Show("Favor preencher os campos!",
                        "Modulo Estoque", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void LimparCampos()
        {
            txtCodigoProduto.Clear();
            txtNovaQuantidade.Clear();
        }
    }
}
