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
using ModuloControleEstoque.DAL;
using ModuloControleEstoque.Model;
using ModuloControleEstoque.Relatorio;
using System.Text.RegularExpressions;

namespace ModuloControleEstoque.View
{
    /// <summary>
    /// Lógica interna para frmPrincipal.xaml
    /// </summary>
    public partial class frmPrincipal : Window
    {
        double valorTotalPedido = 0.0;
        int qtdadeItem = 0;
        ItemVenda iv = new ItemVenda();
        Venda ve = new Venda();
        Estoque es = new Estoque();
        //Venda v = new Venda();
        static List<dynamic> listaGrid = new List<dynamic>();
        static List<dynamic> listaItem = new List<dynamic>();
        bool flag = false;

        public frmPrincipal()
        {
            
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbxCondicaoPagamento.ItemsSource = PagamentoDAO.retornarListaDePagamento();
            cbxCondicaoPagamento.DisplayMemberPath = "CodigoNegociacaoPagamento";
            cbxCondicaoPagamento.SelectedValuePath = "PagamentoId";

            cbxTransportadora.ItemsSource = TransportadoraDAO.RetornarLista();
            cbxTransportadora.DisplayMemberPath = "NomeTransportadora";
            cbxTransportadora.SelectedValuePath = "TransportadoraId";
        }

        private void menuCadastroProduto_Click(object sender, RoutedEventArgs e)
        {
            frmCadastroProduto frm = new frmCadastroProduto();
            frm.ShowDialog();
        }

        private void menuEntradaProduto_Click(object sender, RoutedEventArgs e)
        {
            frmCadastroEntradaProduto frm = new frmCadastroEntradaProduto();
            frm.ShowDialog();
        }

        private void menuAlteracaoProduto_Click(object sender, RoutedEventArgs e)
        {
            frmAlteracaoProduto frm = new frmAlteracaoProduto();
            frm.ShowDialog();
        }

        private void menuCadastroVendedor_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarVendedor frm = new frmCadastrarVendedor();
            frm.ShowDialog();
        }

        private void menuAlteraVendedor_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menuCadastroCliente_Click(object sender, RoutedEventArgs e)
        {
            frmCadastroCliente frm = new frmCadastroCliente();
            frm.ShowDialog();
        }

        private void menuAlteraCliente_Click(object sender, RoutedEventArgs e)
        {
            frmAlteracaoCliente frm = new frmAlteracaoCliente();
            frm.ShowDialog();
        }

        private void menuCadastroCondicaoPagamento_Click(object sender, RoutedEventArgs e)
        {
            flag = true;
            frmCadastroPagamento frm = new frmCadastroPagamento();
            frm.ShowDialog();
        }

        private void menuAlteraCondicaoPagamento_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menuRalatorioDeSaidaProduto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menuRelatorioGeralDeEstoque_Click(object sender, RoutedEventArgs e)
        {
            frmRelatorioProduto frm = new frmRelatorioProduto();
            frm.ShowDialog();
        }

        private void menuRelatorioVendaVendedor_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void menuRelatorioDeSaidaProduto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menuCadastroTransportadora_Click(object sender, RoutedEventArgs e)
        {
            frmTransportadora frm = new frmTransportadora();
            frm.ShowDialog();
        }

        private void menuAlteraTransportadora_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFinalizarVenda_Click(object sender, RoutedEventArgs e)
        {
            Venda ve = new Venda();

            if (!string.IsNullOrEmpty(txtCodigoVendedor.Text) &&
                !string.IsNullOrEmpty(txtCpfCliente.Text) &&
                !string.IsNullOrEmpty(cbxCondicaoPagamento.Text) &&
                !string.IsNullOrEmpty(cbxTransportadora.Text))
            {
                int idCondicaoPagamento = (int)cbxCondicaoPagamento.SelectedValue;
                Pagamento condicaoPagamento = PagamentoDAO.procurarCondicaoPagamentoPorId(idCondicaoPagamento);
                ve.Pagamento = condicaoPagamento;


                int idTransportadora = (int)cbxTransportadora.SelectedValue;
                Transportadora transportadora = TransportadoraDAO.ProcurarTransportadoraPorId(idTransportadora);
                ve.Transportadora = transportadora;


                string cpfVendedor = txtCodigoVendedor.Text;
                Vendedor vendedor = VendedorDAO.ProcurarVendedorPorCPFString(cpfVendedor);

                if (vendedor != null)
                {
                    ve.Vendedor = vendedor;

                    string cpfCliente = txtCpfCliente.Text;
                    Cliente cliente = ClienteDAO.ProcurarClientePorCPFString(cpfCliente);
                    if (cliente != null)
                    {
                        es = new Estoque();

                        ve.Cliente = cliente;

                        ve.DataDaVenda = DateTime.Now;

                        ve.Produtos.Add(iv);

                        foreach (var eitem in listaItem)
                        {
                            int codigoP = eitem.CodigoProduto;
                            Estoque estoque = EstoqueDAO.ProcurarEstoque2(codigoP);
                            int est = estoque.Quantidade - Convert.ToInt32(eitem.Quantidade);
                            estoque.Quantidade = est;
                            EstoqueDAO.AlterarProdutoEstoque(estoque);
                        }

                        if (VendaDAO.AdicionarVenda(ve))
                        {

                            MessageBox.Show("Venda cadastrada com sucesso!\n" +
                                "Total:" + valorTotalPedido,
                            "Controle de Estoque", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            LimparCampos();
                        }
                        else
                        {
                            MessageBox.Show("Ops! Algo deu errado com a venda!",
                            "Controle de Estoque", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cliente invalido!",
                        "Controle de Estoque", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Vendedor invalido!",
                        "Controle de Estoque", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }

            }
            else
            {
                MessageBox.Show("Favor  preencher todos os campos!",
                        "Controle de Estoque", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void menuCategoriaProduto_Click(object sender, RoutedEventArgs e)
        {
            frmCategoriaProduto frm = new frmCategoriaProduto();
            frm.ShowDialog();
        }

        private void menuEmbalagemProduto_Click(object sender, RoutedEventArgs e)
        {
            frmEmbalagemProduto frm = new frmEmbalagemProduto();
            frm.ShowDialog();
        }

        private void menuSair_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void menuLogout_Click(object sender, RoutedEventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.ShowDialog();
        }

        private void btnAdicionarItemVenda_Click(object sender, RoutedEventArgs e)
        {
            iv = new ItemVenda();

            int idCondicaoPagamento = (int)cbxCondicaoPagamento.SelectedValue;
            Pagamento condicaoPagamento = PagamentoDAO.procurarCondicaoPagamentoPorId(idCondicaoPagamento);
            ve.Pagamento = condicaoPagamento;

            if (!string.IsNullOrEmpty(txtCodigoProduto.Text) &&
                !string.IsNullOrEmpty((txtQuantidadeProduto.Text)))
            {
                int qtdadeProduto = Convert.ToInt32(txtQuantidadeProduto.Text);

                int codProduto = Convert.ToInt32(txtCodigoProduto.Text);



                //Procurar o produto pelo id
                Produto produto = ProdutoDAO.ProcurarProdutoPorCodigo1(codProduto);
                if (produto != null)
                {
                    double precoUnitario = produto.PrecoProduto;
                    double subTotal = produto.PrecoProduto * Convert.ToInt32(txtQuantidadeProduto.Text);

                    //Procurar o id do produto
                    int idProduto2 = produto.ProdutoId;

                    //Procurar o estoque pelo id do produto
                    Estoque estoque = EstoqueDAO.ProcurarEstoque1(idProduto2);

                    if (estoque != null)
                    {
                        if (qtdadeProduto < estoque.Quantidade)
                        {
                            //quant = quantidade do estoque - quantidade digitada pelo usuario
                            int quant = (estoque.Quantidade - qtdadeProduto);

                            //Passa a quantida de estoque atual para o QtdadeEstoque do Item de Venda
                            iv.QtdadeEstoque = quant;

                            if (quant > estoque.MargemSeg)
                            {
                                listaItem.Add(new
                                {
                                    CodigoProduto = produto.CodigoProduto,
                                    NomeProduto = produto.DescricaoProduto,
                                    Quantidade = txtQuantidadeProduto.Text,
                                    PrecoUnitario = precoUnitario.ToString("C2"),
                                    SubTotal = subTotal.ToString("C2")

                                });
                                
                                valorTotalPedido = valorTotalPedido + subTotal;

                                iv.Produto = produto;
                                iv.Quantidade = Convert.ToInt32(txtQuantidadeProduto.Text);
                                iv.PrecoUnitario = precoUnitario;

                                if (ve.Pagamento.DescontoCondicaoPagamento > 0.0)
                                {
                                    double vr = ve.Pagamento.DescontoCondicaoPagamento;
                                    double vl = valorTotalPedido * vr;
                                    valorTotalPedido = valorTotalPedido - vl;

                                }
                                else if (ve.Pagamento.AcrescimentoPagamento > 0.0)
                                {
                                    double vr = ve.Pagamento.AcrescimentoPagamento;
                                    double vl =  valorTotalPedido * vr;
                                    valorTotalPedido = valorTotalPedido + vl;
                                }

                                ve.Produtos.Add(iv);

                                grdProdutos.ItemsSource = listaItem;
                                grdProdutos.Items.Refresh();

                                //***Estava alterando a quantidade do estoque para o valor que o usuario digitasse na quantidade
                                //estoque.Quantidade = Convert.ToInt32(txtQuantidadeProduto.Text);

                                //Alterar o saldo do item, mas sem dar commit
                                EstoqueDAO.AlterarProdutoEstoque(estoque);

                                //Contar Quantidade de Itens que tem no pedido
                                qtdadeItem = qtdadeItem + 1;

                                //Imprime o total do pedido na tela
                                lblTotalPedido.Content = valorTotalPedido;

                                

                            }
                            else
                            {
                                MessageBox.Show("Produto a baixo da margem de segurança",
                                "Controle de Estoque", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                listaItem.Add(new
                                {
                                    CodigoProduto = produto.CodigoProduto,
                                    NomeProduto = produto.DescricaoProduto,
                                    Quantidade = txtQuantidadeProduto.Text,
                                    PrecoUnitario = precoUnitario.ToString("C2"),
                                    SubTotal = subTotal.ToString("C2")

                                });
                                valorTotalPedido = valorTotalPedido + subTotal;

                                iv.Produto = produto;
                                iv.Quantidade = Convert.ToInt32(txtQuantidadeProduto.Text);
                                iv.PrecoUnitario = precoUnitario;

                                ve.Produtos.Add(iv);

                                grdProdutos.ItemsSource = listaItem;
                                grdProdutos.Items.Refresh();

                                //***Estava alterando a quantidade do estoque para o valor que o usuario digitasse na quantidade
                                //estoque.Quantidade = Convert.ToInt32(txtQuantidadeProduto.Text);

                                //Alterar o saldo do item, mas sem dar commit
                                EstoqueDAO.AlterarProdutoEstoque(estoque);

                                //Contar Quantidade de Itens que tem no pedido
                                qtdadeItem = qtdadeItem + 1;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Quantidade indisponivel no estoque!",
                                "Controle de Estoque", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Estoque do produto nao encontrado",
                                "Controle de Estoque", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    }
                }
                else
                {
                    MessageBox.Show("Produto nao econtrado!",
                            "Controle de Estoque", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Digitar produto e quantidade",
                            "Controle de Estoque", MessageBoxButton.OK, MessageBoxImage.Exclamation);
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
            else
            {
                Environment.Exit(0);
            }
        }


        public void LimparCampos()
        {
            txtCodigoVendedor.Clear();
            txtCpfCliente.Clear();
            txtQuantidadeProduto.Clear();
            txtCodigoProduto.Clear();
            grdProdutos.ItemsSource = null;
            grdProdutos.Items.Clear();


        }

        private void menuEnderecoEstoque_Click(object sender, RoutedEventArgs e)
        {
            frmEnderecoEstoque frm = new frmEnderecoEstoque();
            frm.ShowDialog();
        }

        private void menuEstoqueProduto_Click(object sender, RoutedEventArgs e)
        {
            frmEstoque frm = new frmEstoque();
            frm.ShowDialog();
        }

        private void txtCodigoProduto_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void txtQuantidadeProduto_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            if (flag)
            {
                flag = false;
                MessageBox.Show("asdas");
            }
        }

        private void menuFazerVenda_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
