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
    /// Interaction logic for frmLogin.xaml
    /// </summary>
    public partial class frmLogin : Window
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(txtUsuario.Text) &&
                !string.IsNullOrEmpty(txtSenha.Password))
            {
                string usuario = txtUsuario.Text;
                string senha = txtSenha.Password;

                if (UsuarioDAO.ValidarSenhaUsuario(usuario, senha))
                {
                    frmPrincipal frm = new frmPrincipal();
                    frm.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Usuario ou Senha invalida!",
                        "Controle de Estoque", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Preencher todos os campos!",
                        "Controle de Estoque", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           if (MessageBox.Show("Deseja fechar o aplicativo?",
                "Controle Estoque",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        
    }
}
