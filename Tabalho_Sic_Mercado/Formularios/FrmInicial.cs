using Mercado.Formularios;
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
using Mercado.FuncoesDB;
using Mercado.Funcoes;

namespace Mercado
{
    public partial class FrmInicial : Form
    {
       public FrmInicial()
        {
            InitializeComponent();
         
        }
        
        #region EventosBtns
        private void btnOcorrencia_Click(object sender, EventArgs e)
        {
            FrmRegistroOcorrencia f = new FrmRegistroOcorrencia();
            f.ShowDialog();
        }
        private void btnCadastroFuncionario_Click(object sender, EventArgs e)
        {
            FrmCadastroFuncionario f = new FrmCadastroFuncionario();
            f.ShowDialog();
        }
        private void btnCadastroCliente_Click(object sender, EventArgs e)
        {
            FrmCadastroCliente f = new FrmCadastroCliente();
            f.ShowDialog();
        }
        private void btnCadastroFornecedor_Click(object sender, EventArgs e)
        {
            FrmCadastroFornecedor f = new FrmCadastroFornecedor();
            f.ShowDialog();
        }
        private void btnCadastroProduto_Click(object sender, EventArgs e)
        {
            FrmCadastroProduto f = new FrmCadastroProduto();
            f.ShowDialog();
        }
        private void btnCadastroCategoria_Click(object sender, EventArgs e)
        {
            FrmCadastroCategorias frmCadastroCategorias = new FrmCadastroCategorias();
            frmCadastroCategorias.ShowDialog();
        }
        #endregion

        private void FrmInicial_Load(object sender, EventArgs e)
        {
            ProdutoDB produtoDB = new ProdutoDB();
            CategoriaPaiDB categoriaPai = new CategoriaPaiDB();
            CategoriaFilhoDB categoriaFilho = new CategoriaFilhoDB();
            CategoriaNetoDB categoriaNeto = new CategoriaNetoDB();



            Singleton.instancia.listaProdutoGlobal = produtoDB.ListarProdutos();
            Singleton.instancia.listaCategoriaPaiGlobal = categoriaPai.ListarCategoriaPai();
            Singleton.instancia.listaCategoriaFilhoGlobal = categoriaFilho.ListarCategoriaFilho();
            Singleton.instancia.listaCategoriaNetoGlobal = categoriaNeto.ListarCategoriaNeto();
        }
    }
}
