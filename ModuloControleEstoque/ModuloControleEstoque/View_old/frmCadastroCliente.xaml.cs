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
    /// Lógica interna para frmCadastroCliente.xaml
    /// </summary>
    public partial class frmCadastroCliente : Window
    {
        public frmCadastroCliente()
        {
            InitializeComponent();
        }

        private void btnGravarCliente_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCpf.Text) &&
                !string.IsNullOrEmpty(txtNome.Text) &&
                !string.IsNullOrEmpty(txtSobreNome.Text))
            {
                Cliente c = new Cliente
                {
                    Nome = txtNome.Text,
                    SobreNome = txtSobreNome.Text,
                    CPF = txtCpf.Text
                };
                if(ClienteDAO.AdicionarCliente(c))
                {
                    MessageBox.Show("Cliente cadastrado com sucesso",
                        "Controle Estoque", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Não foi possivel adicionar o Cliente!",
                        "Controle Estoque", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Favor preencher os campos!",
                    "Controle Estoque", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void LimparCampos()
        {
            txtNome.Clear();
            txtSobreNome.Clear();
            txtCpf.Clear();
        }
    }
}

