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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbxCategoriaProduto.ItemsSource = CategoriaDAO.RetornarListaDeCategoria();
            cbxCategoriaProduto.DisplayMemberPath = "DescricaoCategoria";
            cbxCategoriaProduto.SelectedValuePath = "CategoriaId";

            cbxEmbalagemDisponivel.ItemsSource = EmbalagemDAO.RetornarListaDeEmbalagem();
            cbxEmbalagemDisponivel.DisplayMemberPath = "DescricaoEmbalagem";
            cbxEmbalagemDisponivel.SelectedValuePath = "EmbalagemId";
        }

        private void btnBuscarProduto_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigoProduto.Text))
            {
                p = new Produto
                {
                   CodigoProduto = Convert.ToInt32(txtCodigoProduto.Text)
                };
                p = ProdutoDAO.ProcurarProdutoPorCodigo(p);
                if(p != null)
                {
                    txtCodigoProduto.Text = Convert.ToString(p.CodigoProduto);
                    txtPrecoProduto.Text = Convert.ToString(p.PrecoProduto);
                    txtNomeProduto.Text = p.DescricaoProduto;
                    txtPesoBruto.Text = Convert.ToString(p.PesoBrutoProduto);
                    txtPesoLiquido.Text = Convert.ToString(p.PesoLiquidoProduto);
                    cbxCategoriaProduto.Text = Convert.ToString(p.CategoriaProduto.CategoriaId);
                    cbxEmbalagemDisponivel.Text = Convert.ToString(p.EmbalagemProduto.EmbalagemId);

                    btnGravarAlteracaoProduto.IsEnabled = false;
                }else
                {
                    MessageBox.Show("Não foi possivel encontrar o Produto!",
                        "Modulo Estoque", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }else
            {
                MessageBox.Show("Preencher todos os campos!",
                        "Modulo Estoque", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnGravarAlteracaoProduto_Click(object sender, RoutedEventArgs e)
        {
           

            if (!string.IsNullOrEmpty(cbxCategoriaProduto.Text) &&
                !string.IsNullOrEmpty(txtCodigoProduto.Text) &&
                !string.IsNullOrEmpty(cbxEmbalagemDisponivel.Text) &&
                !string.IsNullOrEmpty(txtNomeProduto.Text) &&
                !string.IsNullOrEmpty(txtPesoBruto.Text) &&
                !string.IsNullOrEmpty(txtPesoLiquido.Text) &&
                !string.IsNullOrEmpty(txtPrecoProduto.Text))
            {

                int idCategoria = (int)cbxCategoriaProduto.SelectedValue;
                Categoria categoria = CategoriaDAO.BuscarCategoriaPorId(idCategoria);
                p.CategoriaProduto = categoria;

                int idEmbalagem = (int)cbxEmbalagemDisponivel.SelectedValue;
                Embalagem embalagem = EmbalagemDAO.BuscarEmbalagemPorId(idEmbalagem);
                p.EmbalagemProduto = embalagem;

                p.CodigoProduto = Convert.ToInt32(txtCodigoProduto.Text);
                p.DescricaoProduto = txtNomeProduto.Text;
                p.PesoBrutoProduto = Convert.ToInt32(txtPesoBruto.Text);
                p.PesoLiquidoProduto = Convert.ToInt32(txtPesoLiquido.Text);
                p.PrecoProduto = Convert.ToDouble(txtPrecoProduto.Text);

                if (ProdutoDAO.AlteraCadastroProduto(p))
                {
                    MessageBox.Show("Produto cadastrado com sucesso",
                        "Controle de Estoque", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Não foi possivel alterar o produto!",
                        "Controle de Estoque", MessageBoxButton.OK, MessageBoxImage.Error);
                    LimparCampos();
                }
            }
            else
            {
                MessageBox.Show("Preencher todos os campos",
                        "Controle de Estoque", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                LimparCampos();
            }
        }
        public void LimparCampos()
        {
            txtNomeProduto.Clear();
            txtPesoBruto.Clear();
            txtPesoLiquido.Clear();
            txtPrecoProduto.Clear();

        }

        
    }
}
