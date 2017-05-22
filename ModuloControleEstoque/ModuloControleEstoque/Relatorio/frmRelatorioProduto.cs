using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModuloControleEstoque.Relatorio
{
    public partial class frmRelatorioProduto : Form
    {
        public frmRelatorioProduto()
        {
            InitializeComponent();
        }

        private void frmRelatorioProduto_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.estoqueAtual' table. You can move, or remove it, as needed.
            this.estoqueAtualTableAdapter.Fill(this.dataSet1.estoqueAtual);

            this.reportViewer1.RefreshReport();
        }
    }
}
