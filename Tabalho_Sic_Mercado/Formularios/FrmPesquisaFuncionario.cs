using Mercado.FuncoesDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mercado.VariaveisGlobais;

namespace Mercado.Formularios
{
    public partial class FrmPesquisaFuncionario : Form
    {

        FuncionarioDB funcionario = new FuncionarioDB();

        public FrmPesquisaFuncionario()
        {
            InitializeComponent();
            funcionario.CarregarDataGrid(dataGridView);

        }

      

        private void FrmPesquisaFuncionario_Activated(object sender, EventArgs e)
        {
            funcionario.CarregarDataGrid(dataGridView);
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            funcionario.DataGridFuncionarioFiltro(dataGridView, txtFiltro);
        }

       

        private void FrmPesquisaFuncionario_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1)
            {
                Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                Singleton.instancia.codigoFuncionario = int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString());
                Close();
            }
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            Singleton.instancia.codigoFuncionario = int.Parse(dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());

            Close();
        }
    }
}
