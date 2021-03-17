using Mercado.FuncoesDB;
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
    public partial class FrmRegistroOcorrencia : Form
    {
        bool buscar = false;
        OcorrenciaDB o = new OcorrenciaDB();
        FuncionarioDB f = new FuncionarioDB();

        public FrmRegistroOcorrencia()
        {
            InitializeComponent();
        }
        
        #region Eventos Btns

        private void btnAdd_Click(object sender, EventArgs e)
        {
            o.AddTipoOcorrencia(cbTipo.Text);
            o.CarregarComboBoxOcorrencia(cbTipo);
            cbTipo.Text = string.Empty;
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            o.DeletarTipoOcorrencia(cbTipo.Text);
            o.CarregarComboBoxOcorrencia(cbTipo);
            cbTipo.Text = string.Empty;
        }
        private void btnBuscarRegistro_Click(object sender, EventArgs e)
        {
            FrmConsultaOcorrencia f = new FrmConsultaOcorrencia();
            f.Show();
        }
        private void btnBuscarFuncionario_Click(object sender, EventArgs e)
        {
            buscar = true;
            FrmPesquisaFuncionario f = new FrmPesquisaFuncionario();
            f.ShowDialog();
        }
        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (int.TryParse(lblCodigo.Text,out int a)==false)
            {
                lblCodigo.Text = "00";
            }
            if (int.Parse(lblCodigo.Text)>0)
            {
                GravarDadosObj();
                o.InserirDados();
                LimparForm();
            }
        }

        #endregion

        #region Eventos Form
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblUsuario.Text = Usuario.user.nome;
            lblDataHora.Text = "Data: " + DateTime.Now.ToString("dd/MM/yyyy") + "  Hora: " + DateTime.Now.ToString("HH:mm:ss");
        }
        private void FrmRegistroOcorrencia_Load(object sender, EventArgs e)
        {
            o.CarregarComboBoxOcorrencia(cbTipo);
            if (buscar == true)
            {
                buscar = false;
            }
        }
        private void FrmRegistroOcorrencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Close();
            }
            if (e.KeyCode == Keys.F5)
            {
                buscar = true;
                FrmPesquisaFuncionario f = new FrmPesquisaFuncionario();
                f.ShowDialog();
            }
        }
        private void FrmRegistroOcorrencia_Activated(object sender, EventArgs e)
        {
            if (buscar == true)
            {
                GravarCodigoGlobal();
                f.BuscarDados();
                ExibirFuncionario();
                buscar = false;
            }
        }
        #endregion

        #region RegraNegocio
        public void LimparForm()
        {
            txtnome.Text = string.Empty;
            txtCargo.Text = string.Empty;
            cbTipo.Text = string.Empty;
            dateTime.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtRegistro.Text = string.Empty;
            lblCodigo.Text = "00";
        }
        public void GravarDadosObj()
        {
            o.responsavel = "Responsável";
            o.dataRegistro = DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("HH:mm:ss");
            o.nomeFuncionario = txtnome.Text.Trim().ToUpper();
            o.cargoFuncionario = txtCargo.Text.Trim().ToUpper();
            o.tipoOcorrencia = cbTipo.Text.Trim().ToUpper();
            o.dataOcorrencia = dateTime.Text.Trim().ToUpper();
            o.observacao = txtRegistro.Text.Trim().ToUpper();
            try
            {
                o.codigoFuncionario = int.Parse(lblCodigo.Text);
            }
            catch
            {
                o.codigoFuncionario = 0;
            }
            try
            {
                o.mes = int.Parse(dateTime.Text.Substring(3, 2));
            }
            catch
            {
                o.mes = 0;
            }
            try
            {
                o.ano = int.Parse(dateTime.Text.Substring(6, 4));
            }
            catch
            {
                o.ano = 0;
            }

        }
        public void GravarCodigoGlobal()
        {
            f.Codigo = Singleton.instancia.codigoFuncionario;
        }
        public void ExibirFuncionario()
        {
            lblCodigo.Text = f.Codigo.ToString();
            txtnome.Text = f.nome;
            txtCargo.Text = f.Cargo;
        }


        #endregion

       
    }
}
