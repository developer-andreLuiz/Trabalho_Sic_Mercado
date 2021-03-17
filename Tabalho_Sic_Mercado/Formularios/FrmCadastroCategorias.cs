using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mercado.Funcoes;
using Mercado.FuncoesDB;
using Mercado.ModelAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;
using Mercado.VariaveisGlobais;
using Mercado.Modelos;

namespace Mercado.Formularios
{
    public partial class FrmCadastroCategorias : Form
    {
        #region Variaveis

        int idPaiRetorno = 0;
        int idFilhoRetorno = 0;
        int idNetoRetorno = 0;

        bool inserirPai;
        bool inserirFilho;
        bool inserirNeto;

        string conteinerPai = "categoriapai";
        string conteinerFilho = "categoriafilho";
        string conteinerNeto = "categorianeto";

        #endregion
        public FrmCadastroCategorias()
        {
            InitializeComponent();
            OpenForm();
        }
        #region Pai
        #region Função Pai
        string nomePai(int id)
        {
            string nome = string.Empty;
            foreach (var a in Singleton.instancia.listaCategoriaPaiGlobal)
            {
                if (a.id_pai == id)
                {
                    nome = a.nomePai;
                    break;
                }
            }
            return nome;
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
        CategoriaPaiDB pai(int id)
        {
            CategoriaPaiDB c = new CategoriaPaiDB();
            foreach (var a in Singleton.instancia.listaCategoriaPaiGlobal)
            {
                if (a.id_pai == id)
                {
                    c = a;
                    break;
                }

            }
            return c;
        }
        void ExibirPai(CategoriaPaiDB categoriaPai)
        {
            lblIdPai.Text = categoriaPai.id_pai.ToString();
            txtnomePaiPai.Text = categoriaPai.nomePai;
            txtUrlPai.Text = categoriaPai.img;
            nudOrdemPai.Value = categoriaPai.ordem;
        }
        void AlimentarPai(CategoriaPaiDB categoriaPai)
        {
            categoriaPai.id_pai = int.Parse(lblIdPai.Text);
            categoriaPai.nomePai = txtnomePaiPai.Text;
            categoriaPai.img = "https://imgapkstorage.blob.core.windows.net/" + conteinerPai + "/" + txtnomePaiPai.Text;
            categoriaPai.ordem = int.Parse(nudOrdemPai.Value.ToString());
        }
        int ultimaOrdemPai()
        {
            int c = 0;
            foreach (var a in Singleton.instancia.listaCategoriaPaiGlobal)
            {
                if (a.ordem >= c)
                {
                    c = a.ordem;
                }
            }

            return c += 1;
        }
        void LimparPai()
        {
            lblIdPai.Text = "0";
            txtnomePaiPai.Text = string.Empty;
            txtUrlPai.Text = string.Empty;
            nudOrdemPai.Value = 0;
        }
        #endregion
        private void cbNomePaiFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbNomeFilhoFiltro.DataSource = null;
                cbNomeNetoFiltro.DataSource = null;
                CarregarCbFilho(cbNomeFilhoFiltro, int.Parse(cbNomePaiFiltro.SelectedValue.ToString()));
                CarregarCbNeto(cbNomeNetoFiltro, int.Parse(cbNomePaiFiltro.SelectedValue.ToString()), int.Parse(cbNomeFilhoFiltro.SelectedValue.ToString()));
            }
            catch { }
            try
            {
                CategoriaPaiDB categoriaPaiDB = new CategoriaPaiDB();
                categoriaPaiDB = pai(int.Parse(cbNomePaiFiltro.SelectedValue.ToString()));
                ExibirPai(categoriaPaiDB);
            }
            catch { }
        }
        private void btnNovoPai_Click(object sender, EventArgs e)
        {
            try
            {
                idPaiRetorno = int.Parse(lblIdPai.Text);
                inserirPai = true;
                LimparPai();
                gbPai.Enabled = true;
                btnNovoPai.Enabled = false;
                btnGravarPai.Enabled = true;
                btnAlterarPai.Enabled = false;
                btnCancelarPai.Enabled = true;
                btnImgPai.Enabled = true;
                nudOrdemPai.Value = ultimaOrdemPai();
            }
            catch { }
        }
        private void btnAlterarPai_Click(object sender, EventArgs e)
        {
            try
            {
                idPaiRetorno = int.Parse(lblIdPai.Text);
                inserirPai = false;
                gbPai.Enabled = true;
                btnNovoPai.Enabled = false;
                btnGravarPai.Enabled = true;
                btnAlterarPai.Enabled = false;
                btnCancelarPai.Enabled = true;
                btnImgPai.Enabled = true;
            }
            catch { }
        }
        private void btnGravarPai_Click(object sender, EventArgs e)
        {
            CategoriaPaiDB categoriaPaiDB = new CategoriaPaiDB();
            AlimentarPai(categoriaPaiDB);
            if (inserirPai)
            {
                bool valido = !String.IsNullOrWhiteSpace(txtnomePaiPai.Text);
                if (valido)
                {
                    try
                    {
                        categoriaPaiDB.Inserir(categoriaPaiDB);
                        categoriaPaiDB = categoriaPaiDB.BuscarUltimo();
                        categoriaPaiDB.Atualizar(categoriaPaiDB);
                        Singleton.instancia.listaCategoriaPaiGlobal.Add(categoriaPaiDB);
                        ExibirPai(categoriaPaiDB);
                        using (OpenFileDialog openFileDialog = new OpenFileDialog())
                        {
                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                BlobStorageHelper.UploadBlockBlob(conteinerPai, lblIdPai.Text, openFileDialog.FileName);
                            }
                        }
                    }
                    catch{}
                    gbPai.Enabled = false;
                    btnNovoPai.Enabled = true;
                    btnGravarPai.Enabled = false;
                    btnAlterarPai.Enabled = true;
                    btnCancelarPai.Enabled = false;
                    btnImgPai.Enabled = true;
                }
            }
            else
            {
                int indexAtual = Singleton.instancia.listaCategoriaPaiGlobal.FindIndex(a => a.id_pai == categoriaPaiDB.id_pai);
                Singleton.instancia.listaCategoriaPaiGlobal[indexAtual] = categoriaPaiDB;
                categoriaPaiDB.Atualizar(categoriaPaiDB);

                gbPai.Enabled = false;
                btnNovoPai.Enabled = true;
                btnGravarPai.Enabled = false;
                btnAlterarPai.Enabled = true;
                btnCancelarPai.Enabled = false;
                btnImgPai.Enabled = true;
            }
            CarregarCbPai(cbNomePaiFiltro);
        }
        private void btnCancelarPai_Click(object sender, EventArgs e)
        {
            try
            {
                gbPai.Enabled = false;
                btnNovoPai.Enabled = true;
                btnGravarPai.Enabled = false;
                btnAlterarPai.Enabled = true;
                btnCancelarPai.Enabled = false;
                btnImgPai.Enabled = true;
                ExibirPai(pai(idPaiRetorno));
            }
            catch { }
        }
        private void btnImgPai_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            BlobStorageHelper.DeleteBlockBlob(conteinerPai, lblIdPai.Text);
                        }
                        catch (Exception z)
                        {
                            //MessageBox.Show(z.Message);
                        }
                        try
                        {
                            BlobStorageHelper.UploadBlockBlob(conteinerPai, lblIdPai.Text, openFileDialog.FileName);
                            MessageBox.Show("Imagem Atualizada");
                        }
                        catch (Exception z)
                        {
                            //MessageBox.Show(z.Message);
                        }
                    }
                }
            }
            catch{}
        }
        #endregion
        #region Filho
        #region função Filho
        CategoriaFilhoDB filho(int id)
        {
            CategoriaFilhoDB c = new CategoriaFilhoDB();
            foreach (var a in Singleton.instancia.listaCategoriaFilhoGlobal)
            {
                if (a.id_filho == id)
                {
                    c = a;
                    break;
                }
            }
            return c;
        }
        int ultimaOrdemFilho(int idPailocal)
        {
            int c = 0;
            foreach (var a in Singleton.instancia.listaCategoriaFilhoGlobal)
            {
                if (a.ordem >= c && a.id_pai == idPailocal)
                {
                    c = a.ordem;
                }
            }

            return c += 1;
        }
        void LimparFilho()
        {
            lblIdFilho.Text = "0";
            txtnomeFilhoFilho.Text = string.Empty;
            CarregarCbPai(cbnomePaiFilho);
            txtUrlFilho.Text = string.Empty;
            nudOrdemFilho.Value = 0;

        }
        string nomeFilho(int id)
        {
            string nome = string.Empty;
            foreach (var a in Singleton.instancia.listaCategoriaFilhoGlobal)
            {
                if (a.id_filho == id)
                {
                    nome = a.nomeFilho;
                    break;
                }
            }
            return nome;
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
        void ExibirFilho(CategoriaFilhoDB categoriaFilhoDB)
        {
            lblIdFilho.Text = categoriaFilhoDB.id_filho.ToString();
            txtnomeFilhoFilho.Text = categoriaFilhoDB.nomeFilho;
            cbnomePaiFilho.DataSource = null;

            ComboBoxModel comboBoxModel = new ComboBoxModel();
            comboBoxModel.nome = nomePai(categoriaFilhoDB.id_pai);
            comboBoxModel.id = categoriaFilhoDB.id_pai;

            List<ComboBoxModel> list = new List<ComboBoxModel>();
            list.Add(comboBoxModel);

            cbnomePaiFilho.DataSource = list;
            cbnomePaiFilho.DisplayMember = "nome";
            cbnomePaiFilho.ValueMember = "id";


            txtUrlFilho.Text = categoriaFilhoDB.img;
            nudOrdemFilho.Value = categoriaFilhoDB.ordem;
        }
        void AlimentarFilho(CategoriaFilhoDB categoriaFilhoDB)
        {
            categoriaFilhoDB.id_filho = int.Parse(lblIdFilho.Text);
            categoriaFilhoDB.id_pai = int.Parse(cbnomePaiFilho.SelectedValue.ToString());
            categoriaFilhoDB.nomeFilho = txtnomeFilhoFilho.Text;
            categoriaFilhoDB.img = "https://imgapkstorage.blob.core.windows.net/" + conteinerFilho + "/" + txtnomeFilhoFilho.Text;
            categoriaFilhoDB.ordem = int.Parse(nudOrdemFilho.Value.ToString());

        }
        #endregion
        private void cbNomeFilhoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbNomeNetoFiltro.DataSource = null;
                CarregarCbNeto(cbNomeNetoFiltro, int.Parse(cbNomePaiFiltro.SelectedValue.ToString()), int.Parse(cbNomeFilhoFiltro.SelectedValue.ToString()));
            }
            catch { }
            try
            {
                CategoriaFilhoDB categoriaFilhoDB = new CategoriaFilhoDB();
                categoriaFilhoDB = filho(int.Parse(cbNomeFilhoFiltro.SelectedValue.ToString()));
                ExibirFilho(categoriaFilhoDB);
            }
            catch { }
        }
        private void cbnomePaiFilho_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                nudOrdemFilho.Value = ultimaOrdemFilho(int.Parse(cbnomePaiFilho.SelectedValue.ToString()));
            }
            catch { }
        }
        private void btnNovoFilho_Click(object sender, EventArgs e)
        {
            try
            {
                idFilhoRetorno = int.Parse(lblIdFilho.Text);
                inserirFilho = true;
                LimparFilho();
                gbFilho.Enabled = true;

                btnNovoFilho.Enabled = false;
                btnGravarFilho.Enabled = true;
                btnAlterarFilho.Enabled = false;
                btnCancelarFilho.Enabled = true;
                btnImgFilho.Enabled = true;

                nudOrdemFilho.Value = ultimaOrdemFilho(int.Parse(cbNomePaiFiltro.SelectedValue.ToString()));

                cbnomePaiFilho.SelectedValue = cbNomePaiFiltro.SelectedValue;
            }
            catch { }
        }
        private void btnAlterarFilho_Click(object sender, EventArgs e)
        {
            try
            {
                idFilhoRetorno = int.Parse(lblIdFilho.Text);

                inserirFilho = false;
                gbFilho.Enabled = true;
                btnNovoFilho.Enabled = false;
                btnGravarFilho.Enabled = true;
                btnAlterarFilho.Enabled = false;
                btnCancelarFilho.Enabled = true;
                btnImgFilho.Enabled = true;
            }
            catch { }
        }
        private void btnCancelarFilho_Click(object sender, EventArgs e)
        {
            try
            {
                gbFilho.Enabled = false;
                btnNovoFilho.Enabled = true;
                btnGravarFilho.Enabled = false;
                btnAlterarFilho.Enabled = true;
                btnCancelarFilho.Enabled = false;
                btnImgFilho.Enabled = true;
                ExibirFilho(filho(idFilhoRetorno));
            }
            catch { }
        }
        private void cbnomePaiFilho_Click(object sender, EventArgs e)
        {
            try
            {
                if (gbFilho.Enabled)
                {
                    CarregarCbPai(cbnomePaiFilho);
                }
            }
            catch { }
        }
        private void btnGravarFilho_Click(object sender, EventArgs e)
        {
            CategoriaFilhoDB categoriaFilhoDB = new CategoriaFilhoDB();
            AlimentarFilho(categoriaFilhoDB);
            if (inserirFilho)
            {
                bool valido = !String.IsNullOrWhiteSpace(txtnomeFilhoFilho.Text);
                if (valido)
                {
                    try
                    {
                        categoriaFilhoDB.Inserir(categoriaFilhoDB);
                        categoriaFilhoDB = categoriaFilhoDB.BuscarUltimo();
                        categoriaFilhoDB.Atualizar(categoriaFilhoDB);
                        Singleton.instancia.listaCategoriaFilhoGlobal.Add(categoriaFilhoDB);
                        ExibirFilho(categoriaFilhoDB);
                        using (OpenFileDialog openFileDialog = new OpenFileDialog())
                        {
                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                BlobStorageHelper.UploadBlockBlob(conteinerFilho, lblIdFilho.Text, openFileDialog.FileName);
                            }
                        }
                    }
                    catch { }
                    gbFilho.Enabled = false;
                    btnNovoFilho.Enabled = true;
                    btnGravarFilho.Enabled = false;
                    btnAlterarFilho.Enabled = true;
                    btnCancelarFilho.Enabled = false;
                    btnImgFilho.Enabled = true;
                }
            }
            else
            {
                int indexAtual = Singleton.instancia.listaCategoriaFilhoGlobal.FindIndex(a => a.id_filho == categoriaFilhoDB.id_filho);
                Singleton.instancia.listaCategoriaFilhoGlobal[indexAtual] = categoriaFilhoDB;
                categoriaFilhoDB.Atualizar(categoriaFilhoDB);
                gbFilho.Enabled = false;
                btnNovoFilho.Enabled = true;
                btnGravarFilho.Enabled = false;
                btnAlterarFilho.Enabled = true;
                btnCancelarFilho.Enabled = false;
                btnImgFilho.Enabled = true;
            }
            CarregarCbFilho(cbNomeFilhoFiltro,categoriaFilhoDB.id_pai);
        }
        private void btnImgFilho_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            BlobStorageHelper.DeleteBlockBlob(conteinerFilho, lblIdFilho.Text);
                        }
                        catch (Exception z)
                        {
                            //MessageBox.Show(z.Message);
                        }
                        try
                        {
                            BlobStorageHelper.UploadBlockBlob(conteinerFilho, lblIdFilho.Text, openFileDialog.FileName);
                            MessageBox.Show("Imagem Atualizada");
                        }
                        catch (Exception z)
                        {
                            //MessageBox.Show(z.Message);
                        }
                    }
                }
            }
            catch { }
        }
        #endregion
        #region Neto
        #region Função Neto
        CategoriaNetoDB neto(int id)
        {
            CategoriaNetoDB c = new CategoriaNetoDB();
            foreach (var a in Singleton.instancia.listaCategoriaNetoGlobal)
            {
                if (a.id_neto == id)
                {
                    c = a;
                    break;
                }
            }
            return c;
        }
        int ultimaOrdemNeto(int idPailocal, int idFilholocal)
        {
            int c = 0;
            foreach (var a in Singleton.instancia.listaCategoriaNetoGlobal)
            {
                if (a.ordem >= c && a.id_pai == idPailocal && a.id_filho == idFilholocal)
                {
                    c = a.ordem;
                }
            }

            return c += 1;
        }
        void LimparNeto()
        {
            lblIdNeto.Text = "0";
            txtnomeNetoNeto.Text = string.Empty;
            CarregarCbPai(cbnomePaiNeto);
            CarregarCbFilho(cbnomeFilhoNeto, int.Parse(cbnomePaiNeto.SelectedValue.ToString()));
            txtUrlNeto.Text = string.Empty;
            nudOrdemNeto.Value = 0;
        }
        string nomeNeto(int id)
        {
            string nome = string.Empty;
            foreach (var a in Singleton.instancia.listaCategoriaNetoGlobal)
            {
                if (a.id_neto == id)
                {
                    nome = a.nomeNeto;
                    break;
                }
            }
            return nome;
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
        void ExibirNeto(CategoriaNetoDB categoriaNetoDB)
        {
            lblIdNeto.Text = categoriaNetoDB.id_neto.ToString();
            txtnomeNetoNeto.Text = categoriaNetoDB.nomeNeto;

            //Alimenta o combo box cbnomePaiNeto
            cbnomePaiNeto.DataSource = null;
            List<ComboBoxModel> listPai = new List<ComboBoxModel>();
            ComboBoxModel comboBoxModelPai = new ComboBoxModel();
            comboBoxModelPai.nome = nomePai(categoriaNetoDB.id_pai);
            comboBoxModelPai.id = categoriaNetoDB.id_pai;
            listPai.Add(comboBoxModelPai);
            cbnomePaiNeto.DataSource = listPai;
            cbnomePaiNeto.DisplayMember = "nome";
            cbnomePaiNeto.ValueMember = "id";

            //Alimenta o combo box cbnomeFilhoNeto
            cbnomeFilhoNeto.DataSource = null;
            List<ComboBoxModel> listFilho = new List<ComboBoxModel>();
            ComboBoxModel comboBoxModelFilho = new ComboBoxModel();
            comboBoxModelFilho.nome = nomeFilho(categoriaNetoDB.id_filho);
            comboBoxModelFilho.id = categoriaNetoDB.id_filho;
            listFilho.Add(comboBoxModelFilho);
            cbnomeFilhoNeto.DataSource = listFilho;
            cbnomeFilhoNeto.DisplayMember = "nome";
            cbnomeFilhoNeto.ValueMember = "id";

            txtUrlNeto.Text = categoriaNetoDB.img;
            nudOrdemNeto.Value = categoriaNetoDB.ordem;
        }
        void AlimentarNeto(CategoriaNetoDB categoriaNetoDB)
        {
            categoriaNetoDB.id_neto = int.Parse(lblIdNeto.Text);
            categoriaNetoDB.id_filho = int.Parse(cbnomeFilhoNeto.SelectedValue.ToString());
            categoriaNetoDB.id_pai = int.Parse(cbnomePaiNeto.SelectedValue.ToString());
            categoriaNetoDB.nomeNeto = txtnomeNetoNeto.Text;
            categoriaNetoDB.img = "https://imgapkstorage.blob.core.windows.net/" + conteinerNeto + "/" + txtnomeNetoNeto.Text;
            categoriaNetoDB.ordem = int.Parse(nudOrdemNeto.Value.ToString());
        }
        #endregion


        private void cbNomeNetoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CategoriaNetoDB categoriaNetoDB = new CategoriaNetoDB();
                categoriaNetoDB = neto(int.Parse(cbNomeNetoFiltro.SelectedValue.ToString()));
                ExibirNeto(categoriaNetoDB);
            }
            catch { }
        }
        private void cbnomePaiNeto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CarregarCbFilho(cbnomeFilhoNeto, int.Parse(cbnomePaiNeto.SelectedValue.ToString()));
            }
            catch { }
            try
            {
                nudOrdemNeto.Value = ultimaOrdemNeto(int.Parse(cbnomePaiNeto.SelectedValue.ToString()), int.Parse(cbnomeFilhoNeto.SelectedValue.ToString()));
            }
            catch { }
        }
        private void btnNovoNeto_Click(object sender, EventArgs e)
        {
            try
            {
                idNetoRetorno = int.Parse(lblIdNeto.Text);
                inserirNeto = true;
                LimparNeto();
                gbNeto.Enabled = true;
                btnNovoNeto.Enabled = false;
                btnGravarNeto.Enabled = true;
                btnAlterarNeto.Enabled = false;
                btnCancelarNeto.Enabled = true;
                btnImgNeto.Enabled = true;
                nudOrdemNeto.Value = ultimaOrdemNeto(int.Parse(cbNomePaiFiltro.SelectedValue.ToString()), int.Parse(cbNomeFilhoFiltro.SelectedValue.ToString()));
                cbnomePaiNeto.SelectedValue = cbNomePaiFiltro.SelectedValue;
                cbnomeFilhoNeto.SelectedValue = cbNomeFilhoFiltro.SelectedValue;
            }
            catch { }
        }
        private void btnAlterarNeto_Click(object sender, EventArgs e)
        {
            try
            {
                idNetoRetorno = int.Parse(lblIdNeto.Text);
                inserirNeto = false;
                gbNeto.Enabled = true;
                btnNovoNeto.Enabled = false;
                btnGravarNeto.Enabled = true;
                btnAlterarNeto.Enabled = false;
                btnCancelarNeto.Enabled = true;
                btnImgNeto.Enabled = true;
            }
            catch { }
        }
        private void btnCancelarNeto_Click(object sender, EventArgs e)
        {
            try
            {
                gbNeto.Enabled = false;
                btnNovoNeto.Enabled = true;
                btnGravarNeto.Enabled = false;
                btnAlterarNeto.Enabled = true;
                btnCancelarNeto.Enabled = false;
                btnImgNeto.Enabled = true;
                ExibirNeto(neto(idNetoRetorno));
            }
            catch { }
        }
        private void cbnomePaiNeto_Click(object sender, EventArgs e)
        {
            try
            {
                if (gbNeto.Enabled)
                {
                    CarregarCbPai(cbnomePaiNeto);
                }
            }
            catch { }
        }
        private void btnGravarNeto_Click(object sender, EventArgs e)
        {
            CategoriaNetoDB categoriaNetoDB = new CategoriaNetoDB();
            AlimentarNeto(categoriaNetoDB);
            if (inserirNeto)
            {
                bool valido = !String.IsNullOrWhiteSpace(txtnomeNetoNeto.Text);
                if (valido)
                {
                    try
                    {
                        categoriaNetoDB.Inserir(categoriaNetoDB);
                        categoriaNetoDB = categoriaNetoDB.BuscarUltimo();
                        categoriaNetoDB.Atualizar(categoriaNetoDB);
                        Singleton.instancia.listaCategoriaNetoGlobal.Add(categoriaNetoDB);
                        ExibirNeto(categoriaNetoDB);
                        using (OpenFileDialog openFileDialog = new OpenFileDialog())
                        {
                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                BlobStorageHelper.UploadBlockBlob(conteinerNeto, lblIdNeto.Text, openFileDialog.FileName);
                            }
                        }
                    }
                    catch { }
                    gbNeto.Enabled = false;
                    btnNovoNeto.Enabled = true;
                    btnGravarNeto.Enabled = false;
                    btnAlterarNeto.Enabled = true;
                    btnCancelarNeto.Enabled = false;
                    btnImgNeto.Enabled = true;
                }
            }
            else
            {
                int indexAtual = Singleton.instancia.listaCategoriaNetoGlobal.FindIndex(a => a.id_neto == categoriaNetoDB.id_neto);
                Singleton.instancia.listaCategoriaNetoGlobal[indexAtual] = categoriaNetoDB;
                categoriaNetoDB.Atualizar(categoriaNetoDB);
                gbNeto.Enabled = false;
                btnNovoNeto.Enabled = true;
                btnGravarNeto.Enabled = false;
                btnAlterarNeto.Enabled = true;
                btnCancelarNeto.Enabled = false;
                btnImgNeto.Enabled = true;
            }
            CarregarCbNeto(cbNomeNetoFiltro, categoriaNetoDB.id_pai,categoriaNetoDB.id_filho);
        }
        private void btnImgNeto_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            BlobStorageHelper.DeleteBlockBlob(conteinerNeto, lblIdNeto.Text);
                        }
                        catch (Exception z)
                        {
                            //MessageBox.Show(z.Message);
                        }
                        try
                        {
                            BlobStorageHelper.UploadBlockBlob(conteinerNeto, lblIdNeto.Text, openFileDialog.FileName);
                            MessageBox.Show("Imagem Atualizada");
                        }
                        catch (Exception z)
                        {
                            //MessageBox.Show(z.Message);
                        }
                    }
                }
            }
            catch { }
        }

        #endregion
        #region Global
        void OpenForm()
        {
            gbPai.Enabled = false;
            gbFilho.Enabled = false;
            gbNeto.Enabled = false;
            try
            {
                CarregarCbPai(cbNomePaiFiltro);
            }
            catch { }
            try
            {
                CarregarCbFilho(cbNomeFilhoFiltro, int.Parse(cbNomePaiFiltro.SelectedValue.ToString()));
            }
            catch { }
            try
            {
                CarregarCbNeto(cbNomeNetoFiltro, int.Parse(cbNomePaiFiltro.SelectedValue.ToString()), int.Parse(cbNomeFilhoFiltro.SelectedValue.ToString()));
            }
            catch { }
           
           

            //btn pai
            btnNovoPai.Enabled = true;
            btnGravarPai.Enabled = false;
            btnAlterarPai.Enabled = true;
            btnCancelarPai.Enabled = false;
            btnImgPai.Enabled = true;
          

        }
        private void FrmCadastroCategorias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {

                FrmPesquisarCategoria frmPesquisarCategoria = new FrmPesquisarCategoria();
                frmPesquisarCategoria.ShowDialog();
            }
            if (e.KeyCode == Keys.F1)
            {
                Close();
            }
            if (e.KeyCode == Keys.Return)
            {

                SendKeys.Send("{Tab}");
            }
        }


        #endregion


    }
}


           
            
               