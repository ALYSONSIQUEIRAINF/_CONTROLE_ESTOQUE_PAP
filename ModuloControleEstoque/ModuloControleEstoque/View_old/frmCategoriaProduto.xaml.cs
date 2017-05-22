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
    /// Lógica interna para frmCategoriaProduto.xaml
    /// </summary>
    public partial class frmCategoriaProduto : Window
    {
        Categoria c = new Categoria();

        public frmCategoriaProduto()
        {
            InitializeComponent();
        }

        private void btnAlterarCategoria_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNomeCategoria.Text))
            {
                c.DescricaoCategoria = txtNomeCategoria.Text;
                if (CategoriaDAO.EditaCategoriaProduto(c))
                {
                    MessageBox.Show("Categoria alterada com sucesso!",
                        "Modulo Estoque", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Não foi possivel alterar a Categoria!",
                        "Modulo Estoque", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Favor preencher os campos!",
                        "Modulo Estoque", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void btnExcluirCategoria_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnGravarCategoriaProduto_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNomeCategoria.Text))
            {
                Categoria c = new Categoria
                {
                    DescricaoCategoria = txtNomeCategoria.Text
                };

                if (CategoriaDAO.AdicionarCategoriaProduto(c))
                {
                    MessageBox.Show("Categoria de Produto cadastrado com sucesso",
                    "Vendas WPF", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Não foi possivel adicionar a categoria do Produto!",
                    "Vendas WPF", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Favor preencher o campo com o Nome da Categoria do Produto",
                    "Vendas WPF", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void LimparCampos()
        {
            txtNomeCategoria.Clear();
        }
    }
}

