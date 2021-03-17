using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;
using Mercado.FuncoesDB;
using Mercado.VariaveisGlobais;
using Mercado.Formularios;

namespace Mercado
{
    

    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
       
        //nivel 1 = venda//pedir produto//relatorio vale (ver só o dele) (caixa)
        //nivel 2 = 
        //nivel 3 = Cadastro de clientes // Cadastro de Fornecedor 
        //nivel 4 = Tudo menos o cadastro de Funcionário
        //nivel 5 = Todo o sistema


        #region EventosBtns

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            TodasFuncoesLogin();

        }
        
        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }


        #endregion

        #region Funções Login

        void TodasFuncoesLogin()
        {
            try
            {
                Usuario.user.ObjVazio();
                GravarDadosObjLogin();
                Usuario.user.VerificarLogin();

                IniciandoSistema();
                CadastroFuncionario();
                CadastroCliente();
                CadastroFornecedor();
                CadastroProduto();


                InvalidoDesabilitato();
            }
            catch
            {
               
                Close(); 
            }
        }

        void IniciandoSistema()
        {
            //sucesso login
            if (Usuario.user.nome.Equals(string.Empty) == false && Usuario.user.nivel > 0 && Singleton.instancia.inicioSistema && Usuario.user.habilitado.Equals("SIM"))
            {
                StatusSucesso();
                this.Hide();
                Form f = new FrmInicial();
                f.ShowDialog();
            }


         
        }

        void CadastroFuncionario()
        {
            //sucesso login
            if (Usuario.user.nome.Equals(string.Empty) == false && Usuario.user.nivel > 4 && Singleton.instancia.inicioSistema == false && Usuario.user.habilitado.Equals("SIM") && Singleton.instancia.tela.Equals("cadastrofuncionario") && Usuario.user.cargo.Equals("DONO"))
            {
                StatusSucesso();
                this.Hide();
                Form f = new FrmCadastroFuncionario();
                f.ShowDialog();
            }
            if (Usuario.user.nome.Equals(string.Empty) == false && Usuario.user.nivel > 4 && Singleton.instancia.inicioSistema == false && Usuario.user.habilitado.Equals("SIM") && Singleton.instancia.tela.Equals("cadastrofuncionario") && Usuario.user.cargo.Equals("DONO")==false)
            {
                StatusNivel();
                txtLogin.Text = string.Empty;
            }
            if (Usuario.user.nome.Equals(string.Empty) == false && Usuario.user.nivel < 5 && Singleton.instancia.inicioSistema == false && Usuario.user.habilitado.Equals("SIM") && Singleton.instancia.tela.Equals("cadastrofuncionario"))
            {
                StatusNivel();
                txtLogin.Text = string.Empty;

            }




        }

        void CadastroCliente()
        {
            //sucesso login
            if (Usuario.user.nome.Equals(string.Empty) == false && Usuario.user.nivel > 2 && Singleton.instancia.inicioSistema == false && Usuario.user.habilitado.Equals("SIM") && Singleton.instancia.tela.Equals("cadastrocliente"))
            {
                StatusSucesso();
                this.Hide();
                Form f = new FrmCadastroCliente();
                f.ShowDialog();
            }

            if (Usuario.user.nome.Equals(string.Empty) == false && Usuario.user.nivel < 3 && Singleton.instancia.inicioSistema == false && Usuario.user.habilitado.Equals("SIM") && Singleton.instancia.tela.Equals("cadastrocliente"))
            {
                StatusNivel();
                txtLogin.Text = string.Empty;

            }




        }

        void CadastroFornecedor()
        {
            //sucesso login
            if (Usuario.user.nome.Equals(string.Empty) == false && Usuario.user.nivel > 2 && Singleton.instancia.inicioSistema == false && Usuario.user.habilitado.Equals("SIM") && Singleton.instancia.tela.Equals("cadastrofornecedor"))
            {
                StatusSucesso();
                this.Hide();
                Form f = new FrmCadastroFornecedor();
                f.ShowDialog();
            }

            if (Usuario.user.nome.Equals(string.Empty) == false && Usuario.user.nivel < 3 && Singleton.instancia.inicioSistema == false && Usuario.user.habilitado.Equals("SIM") && Singleton.instancia.tela.Equals("cadastrofornecedor"))
            {
                StatusNivel();
                txtLogin.Text = string.Empty;

            }




        }

        void CadastroProduto()
        {
            //sucesso login
            if (Usuario.user.nome.Equals(string.Empty) == false && Usuario.user.nivel > 2 && Singleton.instancia.inicioSistema == false && Usuario.user.habilitado.Equals("SIM") && Singleton.instancia.tela.Equals("cadastroproduto"))
            {
                StatusSucesso();
                this.Hide();
                Form f = new FrmCadastroProduto();
                f.ShowDialog();
            }

            if (Usuario.user.nome.Equals(string.Empty) == false && Usuario.user.nivel < 3 && Singleton.instancia.inicioSistema == false && Usuario.user.habilitado.Equals("SIM") && Singleton.instancia.tela.Equals("cadastroproduto"))
            {
                StatusNivel();
                txtLogin.Text = string.Empty;

            }




        }



        void InvalidoDesabilitato()
        {
            //tratamentos de erro
            if (Usuario.user.nome.Equals(string.Empty) == true)
            {
                StatusInvalido();
                txtLogin.Text = string.Empty;
            }

            if (Usuario.user.habilitado.Equals("NÃO") == true)
            {
                StatusDesabilitado();
                txtLogin.Text = string.Empty;
            }

        }

        #endregion




        #region EventosInterface
        void GravarDadosObjLogin()
        {
            Usuario.user.login = txtLogin.Text;

        }
        #endregion

        #region Status

        void StatusSucesso()
        {
            lblStatus.Text = "Login Realizado com Sucesso";
        }

        void StatusInvalido()
        {
            lblStatus.Text = "Login Invalido";
        }

        void StatusDesabilitado()
        {
            lblStatus.Text = "Login Desabilitado";
        }

        void StatusVazio()
        {
            lblStatus.Text = string.Empty;
        }

        void StatusNivel()
        {
            lblStatus.Text = "Sem Permissão para Acessar";
        }

        #endregion

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
         
            if (e.KeyCode == Keys.F1)
            {
                Close();
            }
            if (e.KeyCode == Keys.Return)
            {
                TodasFuncoesLogin();
            }
        }
    }
}
