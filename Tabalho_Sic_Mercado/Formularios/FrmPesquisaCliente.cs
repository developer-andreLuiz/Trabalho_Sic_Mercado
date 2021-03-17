using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mercado.FuncoesDB;
using Mercado.VariaveisGlobais;

namespace Mercado.Formularios
{
    public partial class FrmPesquisaCliente : Form
    {
        ClienteDB cliente = new ClienteDB();

        public FrmPesquisaCliente()
        {
            InitializeComponent();
           
            cliente.CarregarDataGrid(dataGridView);
            
        }

      

       

        private void FrmPesquisaCliente_Activated(object sender, EventArgs e) //exibe o grid ao abrir o formulário
        {
            cliente.CarregarDataGrid(dataGridView);
        }

        private void lblEndereco_TextChanged(object sender, EventArgs e) //exibe a pesquisa enquanto escreve
        {
            cliente.BuscarDataGridFiltro(dataGridView,txtFiltro);
        }

        private void FrmPesquisaCliente_KeyDown(object sender, KeyEventArgs e)//define botões personalizados
        {

            if (e.KeyCode == Keys.F1)
            {
                Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                Singleton.instancia.codigoCliente = int.Parse(dataGridView.CurrentRow.Cells[0].Value.ToString());
                Close();
            }


        }

        /// <summary>
        /// Exibe as informações do cliente no formulário Cliente ao clicar duas vezes na pesquisa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Singleton.instancia.codigoCliente = int.Parse(dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());

            Close();
            
        }
    }
}
