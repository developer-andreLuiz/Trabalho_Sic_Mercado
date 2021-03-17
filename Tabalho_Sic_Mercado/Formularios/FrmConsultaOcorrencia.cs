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
    public partial class FrmConsultaOcorrencia : Form
    {
        FuncionarioDB f = new FuncionarioDB();
        OcorrenciaDB o = new OcorrenciaDB();
        bool buscar = false;
        public FrmConsultaOcorrencia()
        {
            InitializeComponent();
        }

       

        #region Evetos Btns
        private void btnBuscarFuncionario_Click(object sender, EventArgs e)
        {
            buscar = true;
            FrmPesquisaFuncionario f = new FrmPesquisaFuncionario();
            f.ShowDialog();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Cod + Ano + Mes
            if (int.Parse(lblCodigo.Text) > 0 && cbAno.Text.Equals(string.Empty) == false && cbMes.Text.Equals(string.Empty) == false && cbOcorrencia.Text.Equals(string.Empty))//
            {
                o.CarregarDataGridFiltroCodMesAno(dataGridView, lblCodigo, cbMes, cbAno);
                ExibirNumeroLinhasGrid();
            }
            //Cod
            if (int.Parse(lblCodigo.Text) > 0 && cbAno.Text.Equals(string.Empty) && cbMes.Text.Equals(string.Empty) && cbOcorrencia.Text.Equals(string.Empty))//
            {
                o.CarregarDataGridFiltroCod(dataGridView,lblCodigo);
                ExibirNumeroLinhasGrid();
            }
            //Cod + Ano
            if (int.Parse(lblCodigo.Text) > 0 && cbAno.Text.Equals(string.Empty) == false && cbMes.Text.Equals(string.Empty) && cbOcorrencia.Text.Equals(string.Empty))//
            {
                o.CarregarDataGridFiltroCodAno(dataGridView, lblCodigo, cbAno);
                ExibirNumeroLinhasGrid();
            }
            //Cod + Mes
            if (int.Parse(lblCodigo.Text) > 0 && cbAno.Text.Equals(string.Empty) && cbMes.Text.Equals(string.Empty) == false && cbOcorrencia.Text.Equals(string.Empty))//
            {
                o.CarregarDataGridFiltroCodMes(dataGridView,lblCodigo,cbMes);
                ExibirNumeroLinhasGrid();
            }
            //Ano + Mes
            if (int.Parse(lblCodigo.Text) == 0 && cbAno.Text.Equals(string.Empty) == false && cbMes.Text.Equals(string.Empty) == false && cbOcorrencia.Text.Equals(string.Empty))//
            {
                o.CarregarDataGridFiltroMesAno(dataGridView,cbMes,cbAno);
                ExibirNumeroLinhasGrid();
            }
            //Mes
            if (int.Parse(lblCodigo.Text) == 0 && cbAno.Text.Equals(string.Empty) && cbMes.Text.Equals(string.Empty) == false && cbOcorrencia.Text.Equals(string.Empty))//
            {
                o.CarregarDataGridFiltroMes(dataGridView,cbMes);
                ExibirNumeroLinhasGrid();
            }
            //Ano
            if (int.Parse(lblCodigo.Text) == 0 && cbAno.Text.Equals(string.Empty)==false && cbMes.Text.Equals(string.Empty) && cbOcorrencia.Text.Equals(string.Empty))//
            {
                o.CarregarDataGridFiltroAno(dataGridView,cbAno);
                ExibirNumeroLinhasGrid();
            }
            //Ocorrencia
            if (int.Parse(lblCodigo.Text) == 0 && cbAno.Text.Equals(string.Empty) && cbMes.Text.Equals(string.Empty) && cbOcorrencia.Text.Equals(string.Empty)==false)//
            {
                o.CarregarDataGridFiltroOcorrencia(dataGridView, cbOcorrencia);
                ExibirNumeroLinhasGrid();
            }


            //Cod + Ano + Mes + Ocorrencia
            if (int.Parse(lblCodigo.Text) > 0 && cbAno.Text.Equals(string.Empty) == false && cbMes.Text.Equals(string.Empty) == false && cbOcorrencia.Text.Equals(string.Empty))//
            {
                o.CarregarDataGridFiltroCodMesAnoOcorrencia(dataGridView, lblCodigo, cbMes, cbAno, cbOcorrencia);
                ExibirNumeroLinhasGrid();
            }
            //Cod + Ocorrencia
            if (int.Parse(lblCodigo.Text) > 0 && cbAno.Text.Equals(string.Empty) && cbMes.Text.Equals(string.Empty) && cbOcorrencia.Text.Equals(string.Empty) == false)//
            {
                o.CarregarDataGridFiltroCodOcorrencia(dataGridView, lblCodigo, cbOcorrencia);
                ExibirNumeroLinhasGrid();
            }
            //Cod + Ano + Ocorrencia
            if (int.Parse(lblCodigo.Text) > 0 && cbAno.Text.Equals(string.Empty) == false && cbMes.Text.Equals(string.Empty) && cbOcorrencia.Text.Equals(string.Empty) == false)//
            {
                o.CarregarDataGridFiltroCodAnoOcorrencia(dataGridView, lblCodigo, cbAno, cbOcorrencia);
                ExibirNumeroLinhasGrid();
            }
            //Cod + Mes + Ocorrencia
            if (int.Parse(lblCodigo.Text) > 0 && cbAno.Text.Equals(string.Empty) && cbMes.Text.Equals(string.Empty) == false && cbOcorrencia.Text.Equals(string.Empty) == false)//
            {
                o.CarregarDataGridFiltroCodMesOcorrencia(dataGridView, lblCodigo, cbMes, cbOcorrencia);
                ExibirNumeroLinhasGrid();
            }
            //Ano + Mes + Ocorrencia
            if (int.Parse(lblCodigo.Text) == 0 && cbAno.Text.Equals(string.Empty) == false && cbMes.Text.Equals(string.Empty) == false && cbOcorrencia.Text.Equals(string.Empty) == false)//
            {
                o.CarregarDataGridFiltroMesAnoOcorrencia(dataGridView, cbMes, cbAno, cbOcorrencia);
                ExibirNumeroLinhasGrid();
            }
            //Mes + Ocorrencia
            if (int.Parse(lblCodigo.Text) == 0 && cbAno.Text.Equals(string.Empty) && cbMes.Text.Equals(string.Empty) == false && cbOcorrencia.Text.Equals(string.Empty) == false)//
            {
                o.CarregarDataGridFiltroMesOcorrencia(dataGridView, cbMes, cbOcorrencia);
                ExibirNumeroLinhasGrid();
            }
            //Ano + Ocorrencia
            if (int.Parse(lblCodigo.Text) == 0 && cbAno.Text.Equals(string.Empty) == false && cbMes.Text.Equals(string.Empty) && cbOcorrencia.Text.Equals(string.Empty) == false)//
            {
                o.CarregarDataGridFiltroAnoOcorrencia(dataGridView, cbAno,cbOcorrencia);
                ExibirNumeroLinhasGrid();
            }



        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparForm();
        }
        #endregion

        #region Eventos Forms

        private void FrmConsultaOcorrencia_Load(object sender, EventArgs e)
        {
            o.CarregarComboBoxOcorrencia(cbOcorrencia);
           
           
            o.CarregarDataGridCompleto(dataGridView);
            ExibirNumeroLinhasGrid();
        }

        private void FrmConsultaOcorrencia_Activated(object sender, EventArgs e)
        {
            if (buscar==true)
            {
                GravarCodigoGlobal();
                f.BuscarDados();
                ExibirFuncionario();
                buscar = false;
            }
        }

        private void FrmConsultaOcorrencia_KeyDown(object sender, KeyEventArgs e)
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


        #endregion

        #region RegrasInterface
        public void ExibirNumeroLinhasGrid()
        {
            lblContador.Text = "Total : " + (int.Parse(dataGridView.RowCount.ToString()) - 1).ToString();
        }
        public void LimparForm()
        {
            o.CarregarComboBoxOcorrencia(cbOcorrencia);
            cbAno.Text =string.Empty;
            cbMes.Text = string.Empty;
            lblCodigo.Text = "00";
            lblnome.Text = "XXXXXXXXXXXXXXXXXXXXXXXXX";
            o.CarregarDataGridCompleto(dataGridView);
            ExibirNumeroLinhasGrid();
        }
        public void ExibirFuncionario()
        {
            lblCodigo.Text = f.Codigo.ToString();
            lblnome.Text = f.nome;
        }
        void GravarCodigoGlobal()
        {
            f.Codigo = Singleton.instancia.codigoFuncionario;
        }

        #endregion

        private void dataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            o.ObjVazio();
            int a;
            a = int.Parse(dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
            o.CarregarDados(a);
            MessageBox.Show("Codigo do Funcionário : " + o.codigoFuncionario + "\n" +"nome do Funcionário : " + o.nomeFuncionario + "\n"+ "Cargo do Funcionário : " + o.cargoFuncionario + "\n" + "Tipo de Ocorrência : " + o.tipoOcorrencia + "\n" + "Data da Ocorrência : " + o.dataOcorrencia + "\n" + "Observação : " + o.observacao + "\n\n\n" + "Data de Registro : " + o.dataRegistro + "\n" + "Responsável : " + o.responsavel,"Informação Ocorrência",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
