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
    /// Lógica interna para frmEmbalagemProduto.xaml
    /// </summary>
    public partial class frmEmbalagemProduto : Window
    {
        public frmEmbalagemProduto()
        {
            InitializeComponent();
        }

        private void btnGravarProduto_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigoEmbalagem.Text) &&
                !string.IsNullOrEmpty(txtDescricaoEmbalagem.Text) &&
                !string.IsNullOrEmpty(txtQuantidadeEmbalagem.Text) &&
                !string.IsNullOrEmpty(txtTipoEmbalagem.Text))
            {
                Embalagem em = new Embalagem
                {
                    CodigoEmbalagem = Convert.ToInt32(txtCodigoEmbalagem.Text),
                    DescricaoEmbalagem = txtDescricaoEmbalagem.Text,
                    QuantidadeProdutoEmbalagem = Convert.ToInt16(txtQuantidadeEmbalagem.Text),
                    TipoEmbalagem = txtTipoEmbalagem.Text
                };
                if (EmbalagemDAO.CadastrarEmbalagem(em))
                {
                    MessageBox.Show("Embalagem cadastrada com sucesso",
                        "Controle de Estoque", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Não foi possivel cadastrar a embalagem!",
                        "Controle de Estoque", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Favor preencher os campos",
                    "Controle de Estoque", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnAlterarCategoria_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExcluirCategoria_Click(object sender, RoutedEventArgs e)
        {

        }

        public void LimparCampos()
        {
            txtCodigoEmbalagem.Clear();
            txtDescricaoEmbalagem.Clear();
            txtQuantidadeEmbalagem.Focus();
            txtTipoEmbalagem.Clear();
        }
    }
}
