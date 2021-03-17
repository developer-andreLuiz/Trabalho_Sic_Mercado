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
    public partial class FrmPesquisaFornecedor : Form
    {
        FornecedorDB fornecedor = new FornecedorDB();
        string referencia;
        public FrmPesquisaFornecedor()
        {
            InitializeComponent();
            fornecedor.CarregarDataGrid(dataGridView);
            TotalLinha();
        }
        private void FrmPesquisaFornecedor_Activated(object sender, EventArgs e)
        {
            fornecedor.CarregarDataGrid(dataGridView);
            TotalLinha();
        }
        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            fornecedor.BuscarDadosDataGridFiltro(dataGridView, txtFiltro);
            TotalLinha();
        }
        private void FrmPesquisaFornecedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Close();
            }
            if (e.KeyCode==Keys.Enter)
            {

                Singleton.instancia.codigoFornecedor = int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString());

                Close();
            }
            if (e.KeyCode == Keys.Delete)
            {
                if (chkMesmonome.Checked)
                {
                    try
                    {
                        referencia = dataGridView.CurrentRow.Cells[2].Value.ToString();
                        fornecedor.DeletarDados(referencia);
                        fornecedor.InserirRegistroFornecedorCodigo(referencia);
                        dataGridView.Rows.RemoveAt(dataGridView.CurrentRow.Index);
                        TotalLinha();

                    }
                    catch
                    {

                    }
                }
            }
        }
        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Singleton.instancia.codigoFornecedor = int.Parse(dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
                Close();
            }
            catch
            {

            }
           
        }
        private void chkMesmonome_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMesmonome.Checked)
            {
                txtFiltro.Text = string.Empty;
                fornecedor.CarregarDataGridMesmonome(dataGridView);
                TotalLinha();
                btnDelete.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
                if (txtFiltro.Text.Equals(string.Empty))
                {
                    fornecedor.CarregarDataGrid(dataGridView);
                    TotalLinha();
                }
                else
                {
                    fornecedor.BuscarDadosDataGridFiltro(dataGridView, txtFiltro);
                    TotalLinha();
                }
            }
        }
        private void FrmPesquisaFornecedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            txtFiltro.Text = string.Empty;
            chkMesmonome.Checked = false;
            btnDelete.Enabled = false;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                referencia = dataGridView.CurrentRow.Cells[2].Value.ToString();
                fornecedor.DeletarDados(referencia);
                fornecedor.InserirRegistroFornecedorCodigo(referencia);
                dataGridView.Rows.RemoveAt(dataGridView.CurrentRow.Index);
                TotalLinha();

            }
            catch
            {

            }
        }
        void TotalLinha()
        {
            lblItens.Text = (int.Parse(dataGridView.RowCount.ToString()) - 1).ToString();
        }
    }
}
