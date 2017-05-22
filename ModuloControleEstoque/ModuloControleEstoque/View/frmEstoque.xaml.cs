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
    public partial class frmEstoque : Window
    {
        Estoque es = new Estoque();
        static List<dynamic> listaGrid = new List<dynamic>();

        public frmEstoque()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            cboNomeProduto.ItemsSource = ProdutoDAO.RetornarListaDeProduto();
            cboNomeProduto.DisplayMemberPath = "DescricaoProduto";
            cboNomeProduto.SelectedValuePath = "ProdutoId";
        }

        private void btnGravar_Click(object sender, RoutedEventArgs e)
        {
            
            Produto p = new Produto();

            if (!string.IsNullOrEmpty(cboNomeProduto.Text) &&
                !string.IsNullOrEmpty(txtQuantidade.Text))
            {
                
                int idProduto = (int)cboNomeProduto.SelectedValue;
                Produto produto = ProdutoDAO.BuscarProdutoPorId(idProduto);
                es.Produtos = produto;
                

                es.Quantidade = Convert.ToInt32(txtQuantidade.Text);
                es.MargemSeg = 3;
                


                if (EstoqueDAO.AdicionarEstoque(es))
                {
                    MessageBox.Show("Produto registrado com sucesso no estoque",
                        "Controle de Estoque", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Não foi possivel registrar o produto!",
                        "Controle de Estoque", MessageBoxButton.OK, MessageBoxImage.Error);
                    LimparCampos();
                }
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            btnGravar.IsEnabled = false;
            btnAlterar.IsEnabled = true;

            if (!string.IsNullOrEmpty(cboNomeProduto.Text))
            {
                int idProduto = (int)cboNomeProduto.SelectedValue;
                Estoque estoque = EstoqueDAO.ProcurarEstoque(idProduto);

                
                if (estoque != null)
                {
                    //cboNomeProduto.Text = estoque.Produtos.DescricaoProduto;
                    txtQuantidade.Text = Convert.ToString(estoque.Quantidade);
                }
                else
                {
                    MessageBox.Show("Não foi possível encontrar o produto!", "Estoque WPF",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Favor preencher os campos", "Estoque WPF",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(cboNomeProduto.Text) && !string.IsNullOrEmpty(txtQuantidade.Text))
            {
                es.Produtos.DescricaoProduto = cboNomeProduto.Text;
                es.Quantidade = Convert.ToInt32(txtQuantidade.Text);
                es.MargemSeg = 3;

                if (EstoqueDAO.AlterarEstoque(es))
                {
                    MessageBox.Show("Endereço alterado com sucesso!",
                        "Controle Estoque", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Não foi possivel alterar o Endereço!",
                        "Controle Estoque", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Favor preencher os campos", "ModuloControleEstoque WPF",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        public void LimparCampos()
        {
            txtQuantidade.Clear();
        }

        private void cboNomeProduto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cboCategoriaProduto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cboNomeRua_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void cboNomeBloco_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void cboNomePratileira_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
