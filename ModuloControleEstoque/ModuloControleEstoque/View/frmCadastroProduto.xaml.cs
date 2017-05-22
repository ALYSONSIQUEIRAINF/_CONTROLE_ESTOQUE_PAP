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
using System.Data.SqlClient;
using System.Data;

namespace ModuloControleEstoque.View
{
    /// <summary>
    /// Lógica interna para frmCadastroProduto.xaml
    /// </summary>
    public partial class frmCadastroProduto : Window
    {
        static List<dynamic> listaGrid = new List<dynamic>();

        public frmCadastroProduto()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboCategoriaProduto.ItemsSource = CategoriaDAO.RetornarListaDeCategoria();
            cboCategoriaProduto.DisplayMemberPath = "DescricaoCategoria";
            cboCategoriaProduto.SelectedValuePath = "CategoriaId";

            cboEmbalagemProduto.ItemsSource = EmbalagemDAO.RetornarListaDeEmbalagem();
            cboEmbalagemProduto.DisplayMemberPath = "DescricaoEmbalagem";
            cboEmbalagemProduto.SelectedValuePath = "EmbalagemId";
        }

        private void btnGravarProduto_Click(object sender, RoutedEventArgs e)
        {
            Produto p = new Produto();

            if (!string.IsNullOrEmpty(cboCategoriaProduto.Text) &&
                !string.IsNullOrEmpty(txtCodigoProduto.Text) &&
                !string.IsNullOrEmpty(cboEmbalagemProduto.Text) &&
                !string.IsNullOrEmpty(txtNomeProduto.Text) &&
                !string.IsNullOrEmpty(txtPesoBruto.Text) &&
                !string.IsNullOrEmpty(txtPesoLiquido.Text) &&
                !string.IsNullOrEmpty(txtPrecoProduto.Text))
            {
                int idCategoria = (int)cboCategoriaProduto.SelectedValue;
                Categoria categoria = CategoriaDAO.BuscarCategoriaPorId(idCategoria);
                p.CategoriaProduto = categoria;

                int idEmbalagem = (int)cboEmbalagemProduto.SelectedValue;
                Embalagem embalagem = EmbalagemDAO.BuscarEmbalagemPorId(idEmbalagem);
                p.EmbalagemProduto = embalagem;

                p.CodigoProduto = Convert.ToInt32(txtCodigoProduto.Text);
                p.DescricaoProduto = txtNomeProduto.Text;
                p.PesoBrutoProduto = Convert.ToInt32(txtPesoBruto.Text);
                p.PesoLiquidoProduto = Convert.ToInt32(txtPesoLiquido.Text);
                p.PrecoProduto = Convert.ToDouble(txtPrecoProduto.Text);

                if (ProdutoDAO.AdicionarProduto(p))
                {
                    MessageBox.Show("Produto cadastrado com sucesso",
                        "Controle de Estoque", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Não foi possivel cadastrar o produto!",
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
            //cboCategoriaProduto.ClearValue();
            txtCodigoProduto.Clear();
            //cboEmbalagemProduto.Clear();
            txtNomeProduto.Clear();
            txtPesoBruto.Clear();
            txtPesoLiquido.Clear();
            txtPrecoProduto.Clear();
        }

        private void cboProduto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cboCategoriaProduto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
