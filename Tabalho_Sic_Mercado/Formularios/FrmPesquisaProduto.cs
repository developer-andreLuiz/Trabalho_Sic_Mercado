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

namespace Mercado.Formularios
{
    public partial class FrmPesquisaProduto : Form
    {
        CategoriaPaiDB categoriaPaiDB = new CategoriaPaiDB();
        CategoriaFilhoDB categoriaFilhoDB = new CategoriaFilhoDB();
        CategoriaNetoDB categoriaNetoDB = new CategoriaNetoDB();
        ProdutoDB produtoDB = new ProdutoDB();
        string nomepai = null;
        public FrmPesquisaProduto()
        {
            InitializeComponent();
           
        }
        private void FrmPesquisaProduto_Load(object sender, EventArgs e)
        {
            categoriaPaiDB.CarregarComboBoxPai(cbCategoriaPai);
            nomepai = cbCategoriaPai.Text;
        }
        private void cbCategoriaPai_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idpai = categoriaPaiDB.BuscarID(cbCategoriaPai.Text);
            categoriaFilhoDB.CarregarComboBoxFilhoFiltro(cbCategoriaFilho, idpai);
            int idfilho = categoriaFilhoDB.BuscarID(cbCategoriaFilho.Text, idpai);
            categoriaNetoDB.CarregarComboBoxNetoFiltro(cbCategoriaNeto, idfilho, idpai);
        }

        private void cbCategoriaFilho_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idpai = categoriaPaiDB.BuscarID(cbCategoriaPai.Text);
            int idfilho = categoriaFilhoDB.BuscarID(cbCategoriaFilho.Text, idpai);
            categoriaNetoDB.CarregarComboBoxNetoFiltro(cbCategoriaNeto, idfilho, idpai);
        }

        private void cbCategoriaNeto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idpai = categoriaPaiDB.BuscarID(cbCategoriaPai.Text);
            int idfilho = categoriaFilhoDB.BuscarID(cbCategoriaFilho.Text, idpai);
            int idneto = categoriaNetoDB.BuscarID(cbCategoriaNeto.Text, idpai, idfilho);
            
        
           

            produtoDB.BuscarDataGridFiltroCategoriaNeto(dataGridView, idneto);
        }

        private void FrmPesquisaProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Close();
            }
        }

    
    }
}
