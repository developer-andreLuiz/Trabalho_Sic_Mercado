using Mercado.FuncoesDB;
using Mercado.Modelos;
using Mercado.VariaveisGlobais;
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
    public partial class FrmPesquisarCategoria : Form
    {
        ProdutoDB produtoDB = new ProdutoDB();
        public FrmPesquisarCategoria()
        {
            InitializeComponent();
            OpenForm();
            
        }

        #region Global
        void CarregarCbPai(ComboBox cb)
        {
            List<CategoriaPaiDB> list = new List<CategoriaPaiDB>();
            foreach (var a in Singleton.instancia.listaCategoriaPaiGlobal)
            {
                list.Add(a);
            }
            cb.DataSource = null;
            cb.DataSource = list;
            cb.DisplayMember = "nomePai";
            cb.ValueMember = "id_pai";
        }
        void CarregarCbFilho(ComboBox cb, int idPai)
        {
            List<CategoriaFilhoDB> listaFilho = new List<CategoriaFilhoDB>();

            foreach (var a in Singleton.instancia.listaCategoriaFilhoGlobal)
            {
                if (a.id_pai == idPai)
                {
                    listaFilho.Add(a);
                }
            }

            cb.DataSource = listaFilho;
            cb.DisplayMember = "nomeFilho";
            cb.ValueMember = "id_filho";

        }
        void CarregarCbNeto(ComboBox cb, int idPai, int idFilho)
        {
            List<CategoriaNetoDB> listaNeto = new List<CategoriaNetoDB>();

            foreach (var a in Singleton.instancia.listaCategoriaNetoGlobal)
            {
                if (a.id_filho == idFilho && a.id_pai == idPai)
                {
                    listaNeto.Add(a);
                }
            }
            cb.DataSource = listaNeto;
            cb.DisplayMember = "nomeNeto";
            cb.ValueMember = "id_neto";

        }
        private void FrmPesquisarCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Close();
            }
        }
        void CarregarDataGrid(DataGridView dataGridView, int idPai, int idFilho, int idNeto)
        {
            List<DataGridModeloProduto> list = new List<DataGridModeloProduto>();

            foreach (var a in Singleton.instancia.listaProdutoGlobal)
            {
                if (a.categoria_pai == idPai && a.categoria_filho == idFilho && a.categoria_neto == idNeto)
                {
                    list.Add(new DataGridModeloProduto {id =a.codigo,nome=a.nome});
                }
            }






            dataGridView.DataSource = list;
            dataGridView.Columns[0].Width = 70;
            dataGridView.Columns[1].Width = 330;
        }
        void OpenForm()
        {
            try
            {
                CarregarCbPai(cbNomePaiFiltroCima);
            }
            catch { }
            try
            {
                CarregarCbFilho(cbNomeFilhoFiltroCima, int.Parse(cbNomePaiFiltroCima.SelectedValue.ToString()));
            }
            catch { }
            try
            {
                CarregarCbNeto(cbNomeNetoFiltroCima, int.Parse(cbNomePaiFiltroCima.SelectedValue.ToString()), int.Parse(cbNomeFilhoFiltroCima.SelectedValue.ToString()));
            }
            catch { }
            try
            {
                CarregarCbPai(cbNomePaiFiltroBaixo);
            }
            catch { }
            try
            {
                CarregarCbFilho(cbNomeFilhoFiltroBaixo, int.Parse(cbNomePaiFiltroBaixo.SelectedValue.ToString()));
            }
            catch { }
            try
            {
                CarregarCbNeto(cbNomeNetoFiltroBaixo, int.Parse(cbNomePaiFiltroBaixo.SelectedValue.ToString()), int.Parse(cbNomeFilhoFiltroBaixo.SelectedValue.ToString()));
            }
            catch { }
        }
        ProdutoDB produto(int x)
        {
            ProdutoDB p = new ProdutoDB();
            foreach (var a in Singleton.instancia.listaProdutoGlobal)
            {
                if (a.codigo == x)
                {
                    p = a;
                    break;
                }
            }
            return p;
        }
        #endregion
        #region Categoria Cima 
        private void cbNomePaiFiltroCima_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbNomeFilhoFiltroCima.DataSource = null;
                cbNomeNetoFiltroCima.DataSource = null;
                CarregarCbFilho(cbNomeFilhoFiltroCima, int.Parse(cbNomePaiFiltroCima.SelectedValue.ToString()));
                CarregarCbNeto(cbNomeNetoFiltroCima, int.Parse(cbNomePaiFiltroCima.SelectedValue.ToString()), int.Parse(cbNomeFilhoFiltroCima.SelectedValue.ToString()));
            }
            catch { }
          
        }
        private void cbNomeFilhoFiltroCima_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbNomeNetoFiltroCima.DataSource = null;
                CarregarCbNeto(cbNomeNetoFiltroCima, int.Parse(cbNomePaiFiltroCima.SelectedValue.ToString()), int.Parse(cbNomeFilhoFiltroCima.SelectedValue.ToString()));
            }
            catch { }
        }
        private void cbNomeNetoFiltroCima_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(cbNomeNetoFiltroCima.Text))
                {
                    CarregarDataGrid(dataGridViewCima, int.Parse(cbNomePaiFiltroCima.SelectedValue.ToString()), int.Parse(cbNomeFilhoFiltroCima.SelectedValue.ToString()), int.Parse(cbNomeNetoFiltroCima.SelectedValue.ToString()));
                }
            }
            catch
            {

            }
        }
        private void dataGridViewCima_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int x = int.Parse(dataGridViewCima.Rows[e.RowIndex].Cells[0].Value.ToString());
                
                ProdutoDB p = produto(x);
                int indexAtual = Singleton.instancia.listaProdutoGlobal.FindIndex(a => a.codigo == p.codigo);
                p.categoria_pai = int.Parse(cbNomePaiFiltroBaixo.SelectedValue.ToString());
                p.categoria_filho = int.Parse(cbNomeFilhoFiltroBaixo.SelectedValue.ToString());
                p.categoria_neto = int.Parse(cbNomeNetoFiltroBaixo.SelectedValue.ToString());
                produtoDB.AlterarDados(p);
                Singleton.instancia.listaProdutoGlobal[indexAtual] = p;

                try
                {
                    if (!String.IsNullOrEmpty(cbNomeNetoFiltroCima.Text))
                    {
                        CarregarDataGrid(dataGridViewCima, int.Parse(cbNomePaiFiltroCima.SelectedValue.ToString()), int.Parse(cbNomeFilhoFiltroCima.SelectedValue.ToString()), int.Parse(cbNomeNetoFiltroCima.SelectedValue.ToString()));
                    }
                }
                catch { }

                try
                {
                    if (!String.IsNullOrEmpty(cbNomeNetoFiltroBaixo.Text))
                    {
                        CarregarDataGrid(dataGridViewBaixo, int.Parse(cbNomePaiFiltroBaixo.SelectedValue.ToString()), int.Parse(cbNomeFilhoFiltroBaixo.SelectedValue.ToString()), int.Parse(cbNomeNetoFiltroBaixo.SelectedValue.ToString()));
                    }
                }
                catch { }
            }
            catch { }
        }
        #endregion
        #region Categoria Baixo 
        private void cbNomePaiFiltroBaixo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbNomeFilhoFiltroBaixo.DataSource = null;
                cbNomeNetoFiltroBaixo.DataSource = null;
                CarregarCbFilho(cbNomeFilhoFiltroBaixo, int.Parse(cbNomePaiFiltroBaixo.SelectedValue.ToString()));
                CarregarCbNeto(cbNomeNetoFiltroBaixo, int.Parse(cbNomePaiFiltroBaixo.SelectedValue.ToString()), int.Parse(cbNomeFilhoFiltroBaixo.SelectedValue.ToString()));
            }
            catch { }
           
        }
        private void cbNomeFilhoFiltroBaixo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbNomeNetoFiltroBaixo.DataSource = null;
                CarregarCbNeto(cbNomeNetoFiltroBaixo, int.Parse(cbNomePaiFiltroBaixo.SelectedValue.ToString()), int.Parse(cbNomeFilhoFiltroBaixo.SelectedValue.ToString()));
            }
            catch { }
        }
        private void cbNomeNetoFiltroBaixo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(cbNomeNetoFiltroBaixo.Text))
                {
                    CarregarDataGrid(dataGridViewBaixo, int.Parse(cbNomePaiFiltroBaixo.SelectedValue.ToString()), int.Parse(cbNomeFilhoFiltroBaixo.SelectedValue.ToString()), int.Parse(cbNomeNetoFiltroBaixo.SelectedValue.ToString()));
                }
            }
            catch
            {

            }
        }
        private void dataGridViewBaixo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int x = int.Parse(dataGridViewBaixo.Rows[e.RowIndex].Cells[0].Value.ToString());

                ProdutoDB p = produto(x);
                int indexAtual = Singleton.instancia.listaProdutoGlobal.FindIndex(a => a.codigo == p.codigo);
                p.categoria_pai = int.Parse(cbNomePaiFiltroCima.SelectedValue.ToString());
                p.categoria_filho = int.Parse(cbNomeFilhoFiltroCima.SelectedValue.ToString());
                p.categoria_neto = int.Parse(cbNomeNetoFiltroCima.SelectedValue.ToString());
                produtoDB.AlterarDados(p);
                Singleton.instancia.listaProdutoGlobal[indexAtual] = p;

                try
                {
                    if (!String.IsNullOrEmpty(cbNomeNetoFiltroCima.Text))
                    {
                        CarregarDataGrid(dataGridViewCima, int.Parse(cbNomePaiFiltroCima.SelectedValue.ToString()), int.Parse(cbNomeFilhoFiltroCima.SelectedValue.ToString()), int.Parse(cbNomeNetoFiltroCima.SelectedValue.ToString()));
                    }
                }
                catch { }

                try
                {
                    if (!String.IsNullOrEmpty(cbNomeNetoFiltroBaixo.Text))
                    {
                        CarregarDataGrid(dataGridViewBaixo, int.Parse(cbNomePaiFiltroBaixo.SelectedValue.ToString()), int.Parse(cbNomeFilhoFiltroBaixo.SelectedValue.ToString()), int.Parse(cbNomeNetoFiltroBaixo.SelectedValue.ToString()));
                    }
                }
                catch { }
            }
            catch { }
        }

        #endregion


    }
}
