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
    /// Lógica interna para frmAlteracaoProduto.xaml
    /// </summary>
    public partial class frmAlteracaoProduto : Window
    {
        private Produto p;
        private Embalagem em;
        private Categoria c;
        public frmAlteracaoProduto()
        {
            InitializeComponent();
        }

        private void btnGravarAlteracaoProduto_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(cbxEmbalagemDisponivel.Text)&&
                !string.IsNullOrEmpty(txtNomeProduto.Text)&&
                !string.IsNullOrEmpty(txtPesoBruto.Text)&&
                !string.IsNullOrEmpty(txtPesoLiquido.Text)&&
                !string.IsNullOrEmpty(txtPrecoProduto.Text)&&
                !string.IsNullOrEmpty(Convert.ToString(cbxCategoriaProduto)))
            {
                

                p.DescricaoProduto = txtNomeProduto.Text;
                p.PesoBrutoProduto = Convert.ToDouble(txtPesoBruto.Text);
                p.PesoLiquidoProduto = Convert.ToDouble(txtPesoLiquido);
                em.EmbalagemId = Convert.ToInt32(cbxEmbalagemDisponivel.Text);
                p.PrecoProduto = Convert.ToInt32(txtPrecoProduto.Text);
                c.CategoriaId = Convert.ToInt32(cbxCategoriaProduto.Text);
                if (ProdutoDAO.AlteraCadastroProduto(p))
                {
                    MessageBox.Show("Produto alterado com sucesso!",
                        "Modulo Estoque", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Não foi possivel alterar o Produto!",
                        "Modulo Estoque", MessageBoxButton.OK, MessageBoxImage.Error);
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
            txtNomeProduto.Clear();
            txtPesoBruto.Clear();
            txtPesoLiquido.Clear();
            txtPrecoProduto.Clear();
            cbxCategoriaProduto.Items.Clear();
            cbxEmbalagemDisponivel.Items.Clear();

        }
    }
}
