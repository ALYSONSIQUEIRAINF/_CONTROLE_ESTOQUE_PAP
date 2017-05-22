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
    /// Interaction logic for frmEnderecoEstoque.xaml
    /// </summary>
    public partial class frmEnderecoEstoque : Window
    {
        public frmEnderecoEstoque()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboNomeProduto.ItemsSource = ProdutoDAO.RetornarListaDeProduto();
            cboNomeProduto.DisplayMemberPath = "DescricaoProduto";
            cboNomeProduto.SelectedValuePath = "ProdutoId";
        }

        private void btnGravarEnderecoProduto_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(cboNomeProduto.Text)&&
                !string.IsNullOrEmpty(txtEnderecoRua.Text)&&
                !string.IsNullOrEmpty(txtEnderecoBloco.Text)&&
                !string.IsNullOrEmpty(txtEnderecoPratileira.Text))
            {
                int idProduto = (int)cboNomeProduto.SelectedValue;
                Produto produto = ProdutoDAO.BuscarProdutoPorId(idProduto);

                produto.EnderecoRua = txtEnderecoRua.Text;
                produto.EnderecoBloco = txtEnderecoBloco.Text;
                produto.EnderecoPratileira = txtEnderecoPratileira.Text;

                if (ProdutoDAO.CadastrarEnderecoProduto(produto))
                {
                    MessageBox.Show("Endereco cadastrado com sucesso!",
                            "Controle de Estoque", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                }else
                {
                    MessageBox.Show("Endereço ocupado",
                            "Controle de Estoque", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    
                }

            }
        }

        private void cboNomeProduto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
