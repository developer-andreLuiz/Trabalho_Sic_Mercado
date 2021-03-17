using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mercado.Formularios;
using Mercado.Funcoes;
using Mercado.FuncoesDB;
using Mercado.Interface;
using Mercado.Modelos;
using Mercado.VariaveisGlobais;

namespace Mercado.Formularios
{
    public partial class FrmCadastroProduto : Form
    {
        
        int indexAtual = 0;
        bool inserir;
        private const string CONTAINER = "produto";
        public FrmCadastroProduto()
        {
            InitializeComponent();
            OpenForm();
        }
        #region Interface
        void TravarInterface()
        {
            txtCodigoBarra.Enabled = false;
            txtNome.Enabled = false;
            txtNomeVoz.Enabled = false;
            txtCustoUnitario.Enabled = false;
            txtMargemVenda.Enabled = false;
            txtValorVenda.Enabled = false;
            txtMargemPromocao.Enabled = false;
            txtValorPromocao.Enabled = false;
            txtGramatura.Enabled = false;
            cbEmbalagem.Enabled = false;
            txtPesoProduto.Enabled = false;
            txtIgualaProduto.Enabled = false;
            txtIgualaFardo.Enabled = false;
            cbFardo.Enabled = false;
            txtQuantidadeFardo.Enabled = false;
            lblImg.Enabled = false;
            cbCategoriaPai.Enabled = false;
            cbCategoriaFilho.Enabled = false;
            cbCategoriaNeto.Enabled = false;
        }
        void LiberarInterface()
        {
            txtCodigoBarra.Enabled = true;
            txtNome.Enabled = true;
            txtNomeVoz.Enabled = true;
            txtCustoUnitario.Enabled = true;
            txtMargemVenda.Enabled = true;
            txtValorVenda.Enabled = true;
            txtMargemPromocao.Enabled = true;
            txtValorPromocao.Enabled = true;
            txtGramatura.Enabled = true;
            cbEmbalagem.Enabled = true;
            txtPesoProduto.Enabled = true;
            txtIgualaProduto.Enabled = true;
            txtIgualaFardo.Enabled = true;
            cbFardo.Enabled = true;
            txtQuantidadeFardo.Enabled = true;
            lblImg.Enabled = true;
            cbCategoriaPai.Enabled = true;
            cbCategoriaFilho.Enabled = true;
            cbCategoriaNeto.Enabled = true;
            txtNome.Focus();
        }
        void LimparInteface()
        {
            lblCodigo.Text = string.Empty;
            txtCodigoBarra.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtNomeVoz.Text = string.Empty;
            txtCustoUnitario.Text = string.Empty;
            txtMargemVenda.Text = string.Empty;
            txtValorVenda.Text = string.Empty;
            txtMargemPromocao.Text = string.Empty;
            txtValorPromocao.Text = string.Empty;
            txtGramatura.Text = string.Empty;
            cbEmbalagem.Text = string.Empty;
            txtPesoProduto.Text = string.Empty;
            txtIgualaProduto.Text = string.Empty;
            txtIgualaFardo.Text = string.Empty;
            cbFardo.Text = string.Empty;
            txtQuantidadeFardo.Text = string.Empty;
            lblImg.Text = string.Empty;
            cbCategoriaPai.Text = string.Empty;
            cbCategoriaFilho.Text = string.Empty;
            cbCategoriaNeto.Text = string.Empty;

        }
        void GravarDados(ProdutoDB produtoDB)
        {
            if (lblCodigo.Text!=string.Empty)
            {
                produtoDB.codigo = int.Parse(lblCodigo.Text);
            }
            else
            {
                produtoDB.codigo = 0;
            }
            produtoDB.codigo_barra = txtCodigoBarra.Text;
            produtoDB.nome = txtNome.Text;
            produtoDB.nome_voz = txtNomeVoz.Text;
            try
            {
                produtoDB.custo_unitario = float.Parse(txtCustoUnitario.Text);
            }
            catch
            {
                produtoDB.custo_unitario = 0;
            }
            try
            {
                produtoDB.margem_venda = float.Parse(txtMargemVenda.Text);
            }
            catch
            {
                produtoDB.margem_venda = 0;
            }
            try
            {
                produtoDB.valor_venda = float.Parse(txtValorVenda.Text);
            }
            catch
            {
                produtoDB.valor_venda = 0;
            }
            produtoDB.gramatura = txtGramatura.Text;
            try
            {
                produtoDB.margem_promocao = float.Parse(txtMargemPromocao.Text);
            }
            catch
            {
                produtoDB.margem_promocao = 0;
            }
            try
            {
                produtoDB.valor_promocao = float.Parse(txtValorPromocao.Text);
            }
            catch
            {
                produtoDB.valor_promocao = 0;
            }
            produtoDB.embalagem = cbEmbalagem.Text;
            try
            {
                produtoDB.peso_produto = float.Parse(txtPesoProduto.Text);
            }
            catch
            {
                produtoDB.peso_produto = 0;
            }
            try
            {
                produtoDB.iguala_produto = int.Parse(txtIgualaProduto.Text);
            }
            catch
            {
                produtoDB.iguala_produto = 0;
            }
            try
            {
                produtoDB.iguala_fardo = int.Parse(txtIgualaFardo.Text);
            }
            catch
            {
                produtoDB.iguala_fardo = 0;
            }
            produtoDB.fardo = cbFardo.Text;
            try
            {
                produtoDB.quantidade_fardo = int.Parse(txtQuantidadeFardo.Text);
            }
            catch
            {
                produtoDB.quantidade_fardo = 0;
            }
            produtoDB.img = lblImg.Text;
            try
            {
                produtoDB.categoria_pai = int.Parse(cbCategoriaPai.SelectedValue.ToString());
            }
            catch 
            {
                produtoDB.categoria_pai = 0;
            }
            try
            {
                produtoDB.categoria_filho = int.Parse(cbCategoriaFilho.SelectedValue.ToString());
            }
            catch 
            {
                produtoDB.categoria_filho = 0;
            }
            try
            {
                produtoDB.categoria_neto = int.Parse(cbCategoriaNeto.SelectedValue.ToString());
            }
            catch
            {
                produtoDB.categoria_neto = 0;
            }
         
           
           
        }
        void ExibirDados(ProdutoDB produtoDB)
        {
            lblCodigo.Text = produtoDB.codigo.ToString();
            txtCodigoBarra.Text = produtoDB.codigo_barra;
            txtNome.Text = produtoDB.nome;
            txtNomeVoz.Text = produtoDB.nome_voz;
            txtCustoUnitario.Text = produtoDB.custo_unitario.ToString();
            txtMargemVenda.Text = produtoDB.margem_venda.ToString();
            txtValorVenda.Text = produtoDB.valor_venda.ToString();
            txtMargemPromocao.Text = produtoDB.margem_promocao.ToString();
            txtValorPromocao.Text = produtoDB.valor_promocao.ToString();
            txtGramatura.Text = produtoDB.gramatura;
            cbEmbalagem.Text = produtoDB.embalagem;
            txtPesoProduto.Text = produtoDB.peso_produto.ToString();
            txtIgualaProduto.Text = produtoDB.iguala_produto.ToString();
            txtIgualaFardo.Text = produtoDB.iguala_fardo.ToString();
            cbFardo.Text = produtoDB.fardo;
            txtQuantidadeFardo.Text = produtoDB.quantidade_fardo.ToString();
           
            if (produtoDB.img!=null)
            {
                lblImg.Text = produtoDB.img.ToString();
            }
           
            foreach(var a in Singleton.instancia.listaCategoriaPaiGlobal)
            {
                if (produtoDB.categoria_pai == a.id_pai)
                {
                    ComboBoxModel comboBoxModel = new ComboBoxModel {id=a.id_pai, nome=a.nomePai};
                    List<ComboBoxModel> list = new List<ComboBoxModel>();
                    list.Add(comboBoxModel);

                    cbCategoriaPai.DataSource = null;
                    cbCategoriaPai.DataSource = list;
                    cbCategoriaPai.DisplayMember = "nome";
                    cbCategoriaPai.ValueMember = "id";
                    break;
                }
            }
            foreach (var a in Singleton.instancia.listaCategoriaFilhoGlobal)
            {
                if (produtoDB.categoria_filho == a.id_filho && produtoDB.categoria_pai == a.id_pai)
                {
                    ComboBoxModel comboBoxModel = new ComboBoxModel { id = a.id_filho, nome = a.nomeFilho };
                    List<ComboBoxModel> list = new List<ComboBoxModel>();
                    list.Add(comboBoxModel);

                    cbCategoriaFilho.DataSource = null;
                    cbCategoriaFilho.DataSource = list;
                    cbCategoriaFilho.DisplayMember = "nome";
                    cbCategoriaFilho.ValueMember = "id";
                    break;
                }

            }
            foreach (var a in Singleton.instancia.listaCategoriaNetoGlobal)
            {
                if (produtoDB.categoria_neto==a.id_neto && produtoDB.categoria_filho == a.id_filho && produtoDB.categoria_pai == a.id_pai)
                {
                    ComboBoxModel comboBoxModel = new ComboBoxModel { id = a.id_neto, nome = a.nomeNeto };
                    List<ComboBoxModel> list = new List<ComboBoxModel>();
                    list.Add(comboBoxModel);

                    cbCategoriaNeto.DataSource = null;
                    cbCategoriaNeto.DataSource = list;
                    cbCategoriaNeto.DisplayMember = "nome";
                    cbCategoriaNeto.ValueMember = "id";
                    break;
                }
            }
        }
        void PadraoButton()
        {
            btnAlterar.Enabled = true;
            btnCancelar.Enabled = false;
            btnNovo.Enabled = true;
            btnGravar.Enabled = false;
        }
        void EditarButton()
        {
            btnNovo.Enabled = false;
            btnGravar.Enabled = true;
            btnAlterar.Enabled = false;
            btnCancelar.Enabled = true;
        }
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
       
        void OpenForm()
        {
           
            ExibirDados(Singleton.instancia.listaProdutoGlobal[0]);

            PadraoButton();
            TravarInterface();
        }
        #endregion
        #region Regras Matematicas

        public double Valor(string custo,string margem)
        {
            if (float.TryParse(custo,out float a) && float.TryParse(margem, out float b))
            {
                float fCusto = float.Parse(custo);
                float fMargem = float.Parse(margem);
                float fValor = (fCusto / 100) * (100 + fMargem);
                return Math.Round(fValor,2);
            }
            else
            {
                return 0;
            }
        }
        public double Margem(string custo,string valor)
        {
            if (float.TryParse(custo, out float a) && float.TryParse(valor, out float b))
            {
                float fCusto = float.Parse(custo);
                float fValor = float.Parse(valor);
                float fLucro = fValor - fCusto;
                float fMargem = (fLucro / fValor) * 100;

                if (fValor>fCusto)
                {
                    return Math.Round(fMargem, 2);
                }
                else
                {
                    return 0;
                }
               
               
               
            }
            else
            {
                return 0;
            }
        }




        #endregion
        #region Button
        private void btnNovo_Click(object sender, EventArgs e)
        {
            ProdutoDB produtoDB = new ProdutoDB();
            GravarDados(produtoDB);
            indexAtual = Singleton.instancia.listaProdutoGlobal.FindIndex(a => a.codigo == produtoDB.codigo);
            inserir = true;
            LimparInteface();
            LiberarInterface();
            EditarButton();
        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            ProdutoDB produtoDB = new ProdutoDB();
            GravarDados(produtoDB);
            if (inserir)
            {
                try
                {
                    produtoDB.InserirDados(produtoDB);
                    produtoDB = produtoDB.BuscarUltimoRegistro();
                    produtoDB.AlterarDados(produtoDB);
                    produtoDB = produtoDB.BuscarUltimoRegistro();
                    Singleton.instancia.listaProdutoGlobal.Add(produtoDB);
                    indexAtual = Singleton.instancia.listaProdutoGlobal.FindIndex(a => a.codigo == produtoDB.codigo);
                    ExibirDados(Singleton.instancia.listaProdutoGlobal[indexAtual]);
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            BlobStorageHelper.UploadBlockBlob(CONTAINER, lblCodigo.Text, openFileDialog.FileName);
                        }
                    }
                    TravarInterface();
                    PadraoButton();
                    

                }
                catch
                {

                }
            }
            else
            {   
                produtoDB.AlterarDados(produtoDB);
                Singleton.instancia.listaProdutoGlobal[indexAtual] = produtoDB;
                ExibirDados(Singleton.instancia.listaProdutoGlobal[indexAtual]);

                TravarInterface();
                PadraoButton();
            }
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            inserir = false;
            ProdutoDB produtoDB = new ProdutoDB();
         
            GravarDados(produtoDB);


            indexAtual = Singleton.instancia.listaProdutoGlobal.FindIndex(a => a.codigo == produtoDB.codigo);
            LiberarInterface();
            EditarButton();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparInteface();
            PadraoButton();
            TravarInterface();
            ExibirDados(Singleton.instancia.listaProdutoGlobal[indexAtual]);
        }
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                ProdutoDB produtoDB = new ProdutoDB();
                GravarDados(produtoDB);
                indexAtual = Singleton.instancia.listaProdutoGlobal.FindIndex(a => a.codigo == produtoDB.codigo);
                produtoDB.DeletarProduto(int.Parse(lblCodigo.Text));
                BlobStorageHelper.DeleteBlockBlob(CONTAINER, lblCodigo.Text);
                Singleton.instancia.listaProdutoGlobal.Remove(produtoDB);
                LimparInteface();
                ExibirDados(Singleton.instancia.listaProdutoGlobal[0]);
            }
            catch
            {

            }
        }
        private void btnAtualizarImg_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            BlobStorageHelper.DeleteBlockBlob(CONTAINER, lblCodigo.Text);
                        }
                        catch (Exception z)
                        {
                           // MessageBox.Show(z.Message);
                        }
                        try
                        {
                            BlobStorageHelper.UploadBlockBlob(CONTAINER, lblCodigo.Text, openFileDialog.FileName);
                            MessageBox.Show("Imagem Atualizada");
                        }
                        catch (Exception z)
                        {
                           // MessageBox.Show(z.Message);
                        }
                    }
                }
            }
            catch(Exception z)
            {
                MessageBox.Show(z.Message);
            }
        }
        private void FrmCadastroProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Close();
            }
            if (e.KeyCode == Keys.F5)
            {
                FrmPesquisaProduto frmPesquisaProduto = new FrmPesquisaProduto();
                frmPesquisaProduto.ShowDialog();
            }
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{Tab}");
            }
        }
        private void txtCustoUnitario_TextChanged(object sender, EventArgs e)
        {
            txtValorVenda.Text = Valor(txtCustoUnitario.Text, txtMargemVenda.Text).ToString();
            txtValorPromocao.Text = Valor(txtCustoUnitario.Text, txtMargemPromocao.Text).ToString();
        }
        private void txtMargemVenda_TextChanged(object sender, EventArgs e)
        {
            if (txtMargemVenda.Focused)
            {
                txtValorVenda.Text = Valor(txtCustoUnitario.Text, txtMargemVenda.Text).ToString();
            }
        }
        private void txtValorVenda_TextChanged(object sender, EventArgs e)
        {
            if (txtValorVenda.Focused)
            {
                txtMargemVenda.Text = Margem(txtCustoUnitario.Text, txtValorVenda.Text).ToString();
            }
        }
        private void txtMargemPromocao_TextChanged(object sender, EventArgs e)
        {
            if (txtMargemPromocao.Focused)
            {
                txtValorPromocao.Text = Valor(txtCustoUnitario.Text, txtMargemPromocao.Text).ToString();
            }
        }
        private void txtValorPromocao_TextChanged(object sender, EventArgs e)
        {
            if (txtValorPromocao.Focused)
            {
                txtMargemPromocao.Text = Margem(txtCustoUnitario.Text, txtValorPromocao.Text).ToString();
            }
        }
        private void btnRetroceder2x_Click(object sender, EventArgs e)
        {
            indexAtual = 0;
            ExibirDados(Singleton.instancia.listaProdutoGlobal[indexAtual]);
        }
        private void btnAvancar2x_Click(object sender, EventArgs e)
        {
            indexAtual = Singleton.instancia.listaProdutoGlobal.Count - 1;
            ExibirDados(Singleton.instancia.listaProdutoGlobal[indexAtual]);
        }
        private void btnRetroceder1x_Click(object sender, EventArgs e)
        {
            if (indexAtual > 0)
            {
                indexAtual--;
                ExibirDados(Singleton.instancia.listaProdutoGlobal[indexAtual]);
            }
        }
        private void btnAvancar1x_Click(object sender, EventArgs e)
        {
            if (indexAtual < Singleton.instancia.listaProdutoGlobal.Count-1)
            {
                indexAtual++;
                ExibirDados(Singleton.instancia.listaProdutoGlobal[indexAtual]);
            }
        }





        private void cbCategoriaPai_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbCategoriaFilho.DataSource = null;
                cbCategoriaNeto.DataSource = null;
                CarregarCbFilho(cbCategoriaFilho, int.Parse(cbCategoriaPai.SelectedValue.ToString()));
                CarregarCbNeto(cbCategoriaNeto, int.Parse(cbCategoriaPai.SelectedValue.ToString()), int.Parse(cbCategoriaFilho.SelectedValue.ToString()));
            }
            catch { }
        }
        private void cbCategoriaFilho_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbCategoriaNeto.DataSource = null;
                CarregarCbNeto(cbCategoriaNeto, int.Parse(cbCategoriaPai.SelectedValue.ToString()), int.Parse(cbCategoriaFilho.SelectedValue.ToString()));
               }
            catch { }
        }


        #endregion

        private void cbCategoriaPai_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbCategoriaPai.Enabled)
                {
                    CarregarCbPai(cbCategoriaPai);
                }
            }
            catch { }
        }
        private void cbCategoriaFilho_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbCategoriaFilho.Enabled)
                {
                    CarregarCbFilho(cbCategoriaFilho, int.Parse(cbCategoriaPai.SelectedValue.ToString()));
                }
            }
            catch { }
        }
        private void cbCategoriaNeto_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbCategoriaNeto.Enabled)
                {
                    CarregarCbNeto(cbCategoriaNeto, int.Parse(cbCategoriaPai.SelectedValue.ToString()), int.Parse(cbCategoriaFilho.SelectedValue.ToString()));
                }
            }
            catch { }
        }
    }
}
