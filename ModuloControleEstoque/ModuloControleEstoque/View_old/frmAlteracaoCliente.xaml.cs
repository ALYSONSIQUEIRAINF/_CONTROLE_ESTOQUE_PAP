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
    /// Lógica interna para frmAlteracaoCliente.xaml
    /// </summary>
    public partial class frmAlteracaoCliente : Window
    {
        private Cliente c;
        

        public frmAlteracaoCliente()
        {
            InitializeComponent();
        }

        private void btnBuscarCliente_Click(object sender, RoutedEventArgs e)
        
        {
            
            if (!string.IsNullOrEmpty(txtCpf.Text))
            {
                c = new Cliente
                {
                    CPF = txtCpf.Text
                };
                c = ClienteDAO.ProcurarClientePorCPF(c);
                
                if (c!= null)
                {
                    txtCpf.Text = c.CPF;
                    txtNome.Text = c.Nome;
                    txtSobreNome.Text = c.SobreNome;

                    btnAlterarCliente.IsEnabled = true;
                    btnExcluirCliente.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show("Não foi possivel econtrar o Cliente!",
                        "Modulo Estoque", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBox.Show("Favor preencher os campos!",
                        "Modulo Estoque", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAlterarCliente_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(txtCpf.Text)&&
                !string.IsNullOrEmpty(txtNome.Text)&&
                !string.IsNullOrEmpty(txtSobreNome.Text))
            {
                c.Nome = txtNome.Text;
                c.SobreNome = txtSobreNome.Text;
                c.CPF = txtCpf.Text;
                if (ClienteDAO.EditaCliente(c))
                {
                    MessageBox.Show("Cliente alterado com sucesso!",
                        "Controle Estoque", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Não foi possivel alterar o cliente!",
                        "Controle Estoque", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Favor preencher os campos!",
                        "Vendas WPF", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnExcluirCliente_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(txtCpf.Text)&&
                !string.IsNullOrEmpty(txtNome.Text)&&
                !string.IsNullOrEmpty(txtSobreNome.Text))
            {
                ClienteDAO.ExluiCliente(c);
                MessageBox.Show("Cliente excluido com sucesso!",
                        "Controle Estoque", MessageBoxButton.OK, MessageBoxImage.Information);
                LimparCampos();
            }
            else
            {
                MessageBox.Show("Não foi possivel excluir o Cliente!",
                        "Controle Estoque", MessageBoxButton.OK, MessageBoxImage.Information);
                LimparCampos();
            }
        }

        private void LimparCampos()
        {
            txtCpf.Clear();
            txtNome.Clear();
            txtSobreNome.Clear();
        }
    }
}
