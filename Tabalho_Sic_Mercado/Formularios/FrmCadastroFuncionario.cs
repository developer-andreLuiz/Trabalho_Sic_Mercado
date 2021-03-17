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
using Mercado.FuncoesDB;
using Mercado.Interface;
using Mercado.VariaveisGlobais;

namespace Mercado
{
    public partial class FrmCadastroFuncionario : Form
    {
        FuncionarioDB funcionario = new FuncionarioDB();
        BotaoUI botaoUI = new BotaoUI();
        FrmPesquisaFuncionario frmPesquisaFuncionario = new FrmPesquisaFuncionario();
        int Inatividade = 1200;
        int Rep { get; set; }
        string TelefoneVerif { get; set;}
        bool inserir = false;
        bool atualizar = false;
        bool verifDTAdmissao = false;
        bool verifnome = false;
        bool verifLimite = false;
        bool verifRua = false;
        bool verifBairro = false;
        bool verifSalario = false;
        bool verifCidade = false;
        bool verifTel = false;
        bool verifTel1 = false;
        bool verifHabilitado = false;
        bool verifCargo = false;
        bool verifSenhaLogin = false;
        bool verifSenhaCompra = false;
        bool verifTelefoneFormato = false;
        bool verifTelefone1Formato = false;
        string verifCampos = "Atenção! Campos Obrigatórios não preenchidos:\n";

        private void Relogio_Tick(object sender, EventArgs e)
        {
            lblUsuario.Text = Usuario.user.nome;

            lblDataHora.Text = "Data: " + DateTime.Now.ToString("dd/MM/yyyy") + "  Hora: " + DateTime.Now.ToString("HH:mm:ss"); //Exibe data e hora atual, e verifica o tempo de inatividade
            lblInatividade.Text = "Timer : " + Inatividade.ToString();
            if (Inatividade == 0)
            {
                Close();
            }
            if (Inatividade > 0)
            {
                Inatividade--;
            }
        }

        public FrmCadastroFuncionario()
        {
            InitializeComponent();
            ComponentesOpenForm();
            InicializarBotaoUI();
            Singleton.instancia.tela = "";
            Singleton.instancia.codigoFuncionario = 1;
            funcionario.CarregarComboBoxCargo(cbCargo);
        }
       
        #region EventosBtn


        private void btnNovo_Click(object sender, EventArgs e)
        {
            inserir = true;
            botaoUI.UIBtnNovo();
            ComponentesbtnNovo();
            LimparForm();
            txtnome.Focus();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            #region Campos Obrigatórios
            //verifica se todos os campos obrigatórios estão preenchidos
            if (txtDataAdmissao.Text.Equals(string.Empty) == true)
            {
                verifDTAdmissao = false;
                verifCampos += "Data de Admissão\n";
            }
            else
            {
                verifDTAdmissao = true;
            }
                
            if (txtnome.Text.Equals(string.Empty) == true)
            {
                verifnome = false;
                verifCampos += "nome\n";
            }
            else
            {
                verifnome = true;
            }
                
                    
            if (cbLimite.Text.Equals(string.Empty) == true)
            {
                verifLimite = false;
                verifCampos += "Limite de Compra\n";
            }
            else
            {
                verifLimite = true;
            }
                
            if (txtRua.Text.Equals(string.Empty) == true)
            {
                verifRua = false;
                verifCampos += "Rua\n";
            }
            else
            {
                verifRua = true;
            }
                    
            if (txtBairro.Text.Equals(string.Empty) == true)
            {
                verifBairro = false;
                verifCampos += "Bairro\n";
            }
            else
            {
                verifBairro = true;
            }
            if (txtSalario.Text.Equals(string.Empty) == true)
            {
                verifSalario = false;
                verifCampos += "Salário\n";
            }
            else
            {
                verifSalario = true;
            }

            if (txtCidade.Text.Equals(string.Empty) == true)
            {
                verifCidade = false;
                verifCampos += "Cidade\n";
            }
            else
            {
                verifCidade = true;
            }
             
            if (txtTelefone.Text.Equals(string.Empty) == true)
            {
                verifTel = false;
                verifCampos += "Telefone(1)\n";
            }    
            else
            {
                verifTel = true;
            }
                
            if (txtTelefone1.Text.Equals(string.Empty) == true)
            {
                verifTel1 = false;
                verifCampos += "Telefone(2)\n";
            }
            else
            {
                verifTel1 = true;
            }
                    
            if (cbHabilitado.SelectedItem == null)
            {
                verifHabilitado = false;
                verifCampos += "Habilitado\n";
            }
            else
            {
                verifHabilitado = true;
            }

            if (cbCargo.SelectedItem == null)
            {
                verifCargo = false;
                verifCampos += "Cargo \n";
            }
            else
            {
                verifCargo = true;
            }
            
            if (txtSenhaLogin.Text.Equals(string.Empty) == true)
            {
                verifSenhaLogin = false;
                verifCampos += "Senha de Login\n";
            }
            else
            {
                verifSenhaLogin = true;
            }
             
            if (txtSenhaCompra.Text.Equals(string.Empty) == true)
            {
                verifSenhaCompra = false;
                verifCampos += "Senha de Compra\n";
            }
            else
            {
                verifSenhaCompra = true;
            }
            #endregion

            if ( verifDTAdmissao == true && verifnome == true && verifLimite == true && verifRua == true && verifBairro == true && verifSalario == true
                && verifCidade == true && verifTel == true && verifTel1 == true && verifHabilitado == true && verifCargo == true && verifSenhaLogin == true
                && verifSenhaCompra == true)
            {
                GravarDadosObj();
                if (inserir == true)
                {
                    VerificaCampos();
                    if (verifTelefoneFormato == true && verifTelefone1Formato == true)
                    {

                        if (funcionario.verificarDadosSenha(0) == true || funcionario.verificarDadosSenhaAcesso(0) == true)
                        {
                            MessageBox.Show("Senha  Já Cadastrada");
                        }


                        if (funcionario.verificarDadosSenha(0) == false && funcionario.verificarDadosSenhaAcesso(0) == false)
                        {
                            if (funcionario.verificarDadosnome(0)==true)
                            {
                                MessageBox.Show("nome ja Cadastrado");
                            }
                            else
                            {
                                botaoUI.UIBtnGravar();
                                GravarDadosObj();
                                funcionario.InserirDados();
                                ComponentesbtnGravar();
                            }
                       
                        }

                    }
                }
                if (atualizar == true)//atualizando dados
                {

                    VerificaCampos();
                    if (verifTelefoneFormato == true && verifTelefone1Formato == true)
                    {


                        if (funcionario.verificarDadosSenha(1) == true || funcionario.verificarDadosSenhaAcesso(1) == true )
                        {
                            MessageBox.Show("Senha  Já Cadastrada");
                        }
                        if (funcionario.verificarDadosSenha(1) == false && funcionario.verificarDadosSenhaAcesso(1) == false)
                        {
                            GravarCodigoLocal();
                            GravarCodigoGlobal();
                            botaoUI.UIBtnGravar();
                            GravarDadosObj();
                            funcionario.AlterarDados();
                            ComponentesbtnGravar();
                            funcionario.InserirRegistro();
                        }


                    }
                }
               
            }
            else
            {
                MessageBox.Show(verifCampos, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                verifCampos = "Atenção! Campos Obrigatórios não preenchidos:\n";
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            atualizar = true;
            botaoUI.UIBtnAlterar();
            ComponentesbtnAlterar();
            txtnome.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Singleton.instancia.codigoFuncionario = 1;
            botaoUI.UIBtnCancelar();
            ComponentesbtnCancelar();

            funcionario.BuscaPrimeiroRegistro();
            ExibirDadosForm();
            inserir = false;
            atualizar = false;
        }

        private void btnAvancar_Click(object sender, EventArgs e)
        {
            GravarCodigoLocal();
            GravarCodigoGlobal();
            funcionario.ObjVazio();
            Rep = 0;

            while (funcionario.nome == null && Rep < 100)
            {
                Rep++;
                funcionario.Codigo++;
                funcionario.BuscarDados();
                if (funcionario.nome != null)
                {
                    ExibirDadosForm();
                    Rep = 0;
                }
                if (Rep == 100)
                {
                    MessageBox.Show("Esse é o ultimo");
                }

            }
            
        }

        private void btnRetroceder_Click(object sender, EventArgs e)
        {
            GravarCodigoLocal();
            GravarCodigoGlobal();
            funcionario.ObjVazio();
            Rep = 0;

            while (funcionario.nome == null && Rep < 100)
            {
                Rep++;
                funcionario.Codigo--;
                funcionario.BuscarDados();
                if (funcionario.nome != null)
                {
                    ExibirDadosForm();
                    Rep = 0;
                }
                if (Rep == 100)
                {
                    MessageBox.Show("Esse é o Primeiro");
                }

            }
        }

        private void btnAvancar2x_Click(object sender, EventArgs e)
        {
            funcionario.BuscaUltimoRegistro();
            ExibirDadosForm();
            GravarCodigoLocal();
            GravarCodigoGlobal();
        }

        private void btnRetroceder2x_Click(object sender, EventArgs e)
        {
            funcionario.BuscaPrimeiroRegistro();
            ExibirDadosForm();
            GravarCodigoLocal();
            GravarCodigoGlobal();
        }


        // categoria
        private void btnAddCargo_Click(object sender, EventArgs e)
        {
            GravarCargoObJ();
            funcionario.InserirCargo();
            funcionario.CarregarComboBoxCargo(cbCargo);
            
        }

        private void btnDelCargo_Click(object sender, EventArgs e)
        {
            GravarCargoObJ();
            funcionario.DelCargo();
            funcionario.CarregarComboBoxCargo(cbCargo);
           
        }

        #endregion
       
        #region EventosFrms

        private void FrmCadastroFuncionario_KeyDown(object sender, KeyEventArgs e)
        {
            Inatividade = 1200;
            if (e.KeyCode == Keys.F5)
            {
                frmPesquisaFuncionario.ShowDialog();
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

        private void FrmCadastroFuncionario_FormClosed(object sender, FormClosedEventArgs e)
        {
            Singleton.instancia.codigoFuncionario = 0;
        }

        private void FrmCadastroFuncionario_Activated(object sender, EventArgs e)
        {
            if (inserir==false && atualizar == false)
            {
                GravarCodigoGlobal();
                funcionario.ObjVazio();
                Rep = 0;

                while (funcionario.nome == null && Rep < 100)
                {

                    funcionario.BuscarDados();


                    if (funcionario.nome != null)
                    {

                        ExibirDadosForm();
                        Rep = 0;
                    }
                    if (Rep == 100)
                    {
                        MessageBox.Show("Esse é o ultimo");
                    }
                    Rep++;
                    funcionario.Codigo++;
                }
            }
           
        }


        #endregion
        
        #region ControleInterface

        /// <summary>
        /// insere um novo cargo caso o inserido não exista
        /// </summary>
        void GravarCargoObJ()
        {
            funcionario.NewCargo = cbCargo.Text.ToUpper().Trim();
        }

        /// <summary>
        /// insere os dados da tela nas propriedades referentes
        /// </summary>
        void GravarDadosObj()
        {
            if (float.TryParse(cbLimite.Text.Trim(), out funcionario.compras)==false)
            {
                cbLimite.Text = "0.00";
            }
            if (float.TryParse(txtSalario.Text.Trim(), out funcionario.salario) == false)
            {
                txtSalario.Text = "0.00";
            }
            if (int.TryParse(cbNivel.Text.Trim(), out funcionario.nivel) == false)
            {
                cbNivel.Text = "1";
            }
       

            //funcionario.Codigo =int.Parse(lblCodigo.Text.Trim());
            funcionario.nome = txtnome.Text.ToUpper().Trim();
            funcionario.compras = float.Parse(cbLimite.Text.ToUpper().Trim());//
            funcionario.salario = float.Parse(txtSalario.Text.ToUpper().Trim());//
            funcionario.Endereco = txtRua.Text.ToUpper().Trim();
            funcionario.Bairro = txtBairro.Text.ToUpper().Trim();
            funcionario.Cidade = txtCidade.Text.ToUpper().Trim();
            funcionario.Telefone = txtTelefone.Text.ToUpper().Trim();
            funcionario.Telefone1 = txtTelefone1.Text.ToUpper().Trim();
            funcionario.Habilitado = cbHabilitado.Text.ToUpper().Trim();
            funcionario.Cargo = cbCargo.Text.ToUpper().Trim();
            funcionario.Observacao = txtObservacao.Text.ToUpper().Trim();
            funcionario.Senha = txtSenhaLogin.Text.ToUpper().Trim();
            funcionario.SenhaAcesso = txtSenhaCompra.Text.ToUpper().Trim();
            funcionario.Apagador = txtSenhaApagador.Text.ToUpper().Trim();
            funcionario.nivel= int.Parse(cbNivel.Text.ToUpper().Trim());//
            funcionario.DataAdmissao = txtDataAdmissao.Text.ToUpper().Trim();//

        }

        /// <summary>
        /// Exibe as informações presentes nas propriedades nos campos referentes
        /// </summary>
        void ExibirDadosForm()
        {
            lblCodigo.Text = funcionario.Codigo.ToString();
            txtnome.Text = funcionario.nome;
            cbLimite.Text = funcionario.compras.ToString();
            txtSalario.Text = funcionario.salario.ToString();
            txtRua.Text = funcionario.Endereco;
            txtBairro.Text = funcionario.Bairro;
            txtCidade.Text = funcionario.Cidade;
            txtTelefone.Text = funcionario.Telefone;
            txtTelefone1.Text = funcionario.Telefone1;
            cbHabilitado.Text = funcionario.Habilitado;
            cbCargo.Text = funcionario.Cargo;
            txtObservacao.Text = funcionario.Observacao;
            txtSenhaLogin.Text = funcionario.Senha;
            txtSenhaCompra.Text = funcionario.SenhaAcesso;
            txtSenhaApagador.Text = funcionario.Apagador;
            cbNivel.Text = funcionario.nivel.ToString();
            txtDataAdmissao.Text = funcionario.DataAdmissao;
            
        }

        /// <summary>
        /// retorna o código da classe singleton
        /// </summary>
        void GravarCodigoGlobal()
        {
            funcionario.Codigo = Singleton.instancia.codigoFuncionario;
        }

        /// <summary>
        /// Envia o código de cliente para a classe singleton e depois retorna o codigo da mesma
        /// </summary>
        void GravarCodigoLocal()

        {
            try
            {
                Singleton.instancia.codigoFuncionario = int.Parse(lblCodigo.Text.ToUpper().Trim());
                funcionario.Codigo = Singleton.instancia.codigoFuncionario;
            }
            catch
            {
                funcionario.Codigo = 1;
            }
        }



        /// <summary>
        /// Atribui as funcionalidades de todos os botões presentes na tela
        /// </summary>
        void InicializarBotaoUI()
        {
            botaoUI.btnAlterar = btnAlterar;
            botaoUI.btnAvancar = btnAvancar;
            botaoUI.btnAvancar2x = btnAvancar2x;
            botaoUI.btnCancelar = btnCancelar;
            botaoUI.btnGravar = btnGravar;
            botaoUI.btnNovo = btnNovo;
            botaoUI.btnRetroceder = btnRetroceder;
            botaoUI.btnRetroceder2x = btnRetroceder2x;
        }
        /// <summary>
        /// Define os campos habilitados ao abrir a tela
        /// </summary>
        void ComponentesOpenForm()
        {
            txtnome.Enabled = false;
            cbLimite.Enabled = false;
            txtRua.Enabled = false;
            txtBairro.Enabled = false;
            txtSalario.Enabled = false;
            txtCidade.Enabled = false;
            txtTelefone.Enabled = false;
            txtTelefone1.Enabled = false;
            cbHabilitado.Enabled = false;
            cbCargo.Enabled = false;
            txtObservacao.Enabled = false;
            txtSenhaLogin.Enabled = false;
            txtSenhaCompra.Enabled = false;
            txtSenhaApagador.Enabled = false;
            cbNivel.Enabled = false;
            txtDataAdmissao.Enabled = false;

            btnAddCargo.Enabled = false;
            btnDelCargo.Enabled = false;
            btnGravar.Enabled = false;
            btnCancelar.Enabled = false;
        }
        /// <summary>
        /// Define os campos habilitados ao clicar no botão Novo
        /// </summary>
        void ComponentesbtnNovo()
        {
            txtnome.Enabled = true;
            cbLimite.Enabled = true;
            txtRua.Enabled = true;
            txtBairro.Enabled = true;
            txtSalario.Enabled = true;
            txtCidade.Enabled = true;
            txtTelefone.Enabled = true;
            txtTelefone1.Enabled = true;
            cbHabilitado.Enabled = true;
            cbCargo.Enabled = true;
            txtObservacao.Enabled = true;
            txtSenhaLogin.Enabled = true;
            txtSenhaCompra.Enabled = true;
            txtSenhaApagador.Enabled = true;
            cbNivel.Enabled = true;
            btnAddCargo.Enabled = true;
            btnDelCargo.Enabled = true;
            txtDataAdmissao.Enabled = true;


        }
        /// <summary>
        /// Define os campos habilitados ao clicar no botão Alterar
        /// </summary>
        void ComponentesbtnAlterar()
        {
            txtnome.Enabled = true;
            cbLimite.Enabled = true;
            txtRua.Enabled = true;
            txtBairro.Enabled = true;
            txtSalario.Enabled = true;
            txtCidade.Enabled = true;
            txtTelefone.Enabled = true;
            txtTelefone1.Enabled = true;
            cbHabilitado.Enabled = true;
            cbCargo.Enabled = true;
            txtObservacao.Enabled = true;
            txtSenhaLogin.Enabled = true;
            txtSenhaCompra.Enabled = true;
            txtSenhaApagador.Enabled = true;
            txtDataAdmissao.Enabled = true;
            cbNivel.Enabled = true;
            btnAddCargo.Enabled = true;
            btnDelCargo.Enabled = true;


        }
        /// <summary>
        /// Define os campos habilitados ao clicar no botão Gravar
        /// </summary>
        void ComponentesbtnGravar()
        {
            txtnome.Enabled = false;
            cbLimite.Enabled = false;
            txtRua.Enabled = false;
            txtBairro.Enabled = false;
            txtSalario.Enabled = false;
            txtCidade.Enabled = false;
            txtTelefone.Enabled = false;
            txtTelefone1.Enabled = false;
            cbHabilitado.Enabled = false;
            cbCargo.Enabled = false;
            txtObservacao.Enabled = false;
            txtSenhaLogin.Enabled = false;
            txtSenhaCompra.Enabled = false;
            txtSenhaApagador.Enabled = false;
            txtDataAdmissao.Enabled = false;
            cbNivel.Enabled = false;
            btnAddCargo.Enabled = false;
            btnDelCargo.Enabled = false;

            inserir = false;
            atualizar = false;
           

        }
        /// <summary>
        /// Define os campos habilitados ao clicar no botão Cancelar
        /// </summary>
        void ComponentesbtnCancelar()
        {
            txtnome.Enabled = false;
            cbLimite.Enabled = false;
            txtRua.Enabled = false;
            txtBairro.Enabled = false;
            txtSalario.Enabled = false;
            txtCidade.Enabled = false;
            txtTelefone.Enabled = false;
            txtTelefone1.Enabled = false;
            cbHabilitado.Enabled = false;
            cbCargo.Enabled = false;
            txtObservacao.Enabled = false;
            txtSenhaLogin.Enabled = false;
            txtSenhaCompra.Enabled = false;
            txtSenhaApagador.Enabled = false;
            cbNivel.Enabled = false;
            btnAddCargo.Enabled = false;
            btnDelCargo.Enabled = false;
            txtDataAdmissao.Enabled = false;


        }
        /// <summary>
        /// Remove ou reseta para o padrão todas as informações inseridas nos campos
        /// </summary>
        void LimparForm()
        {
            lblCodigo.Text = string.Empty;
            txtnome.Text = string.Empty;
            cbLimite.Text = "0.00";
            txtSalario.Text = "0.00";
            txtRua.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtTelefone.Text = "(ddd) xxxx-xxxx";
            txtTelefone1.Text = "(ddd) xxxx-xxxx";
            cbHabilitado.Text = "Sim";
            cbCargo.Text = string.Empty;
            txtObservacao.Text = string.Empty;
            txtSenhaLogin.Text = string.Empty;
            txtSenhaCompra.Text = string.Empty;
            txtSenhaApagador.Text = string.Empty;
            cbNivel.Text = "1";
            txtDataAdmissao.Text = "dd/mm/aaaa";


        }



        #endregion

        #region Selecionar Campos




        private void txtnome_Enter(object sender, EventArgs e)
        {
            txtnome.SelectAll();
        }

        private void cbLimite_Enter(object sender, EventArgs e)
        {
            cbLimite.SelectAll();
        }

        private void txtRua_Enter(object sender, EventArgs e)
        {
            txtRua.SelectAll();
        }

        private void txtBairro_Enter(object sender, EventArgs e)
        {
            txtBairro.SelectAll();
        }

        private void txtSalario_Enter(object sender, EventArgs e)
        {
            txtSalario.SelectAll();
        }

        private void txtCidade_Enter(object sender, EventArgs e)
        {
            txtCidade.SelectAll();
        }

        private void txtTelefone_Enter(object sender, EventArgs e)
        {
            txtTelefone.SelectAll();
        }

        private void txtTelefone_DoubleClick(object sender, EventArgs e)
        {
            txtTelefone.SelectAll();
        }

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (txtTelefone.TextLength)
                {
                    case 0:
                        txtTelefone.Text += "(";
                        txtTelefone.SelectionStart = 2;
                        break;

                    case 1:
                        txtTelefone.Text = "(" + txtTelefone.Text;
                        txtTelefone.SelectionStart = 2;
                        break;

                    case 3:
                        txtTelefone.Text += ")";
                        txtTelefone.SelectionStart = 5;
                        break;
                    case 9:
                        txtTelefone.Text += "-";
                        txtTelefone.SelectionStart = 11;
                        break;


                }
            }
        }

        private void txtTelefone1_Enter(object sender, EventArgs e)
        {
            txtTelefone1.SelectAll();
        }

        private void txtTelefone1_DoubleClick(object sender, EventArgs e)
        {
            txtTelefone1.SelectAll();
        }

        private void txtTelefone1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (txtTelefone1.TextLength)
                {
                    case 0:
                        txtTelefone1.Text += "(";
                        txtTelefone1.SelectionStart = 2;
                        break;

                    case 1:
                        txtTelefone1.Text = "(" + txtTelefone1.Text;
                        txtTelefone1.SelectionStart = 2;
                        break;

                    case 3:
                        txtTelefone1.Text += ")";
                        txtTelefone1.SelectionStart = 5;
                        break;
                    case 9:
                        txtTelefone1.Text += "-";
                        txtTelefone1.SelectionStart = 11;
                        break;


                }
            }
        }

        private void txtDataAdmissao_Enter(object sender, EventArgs e)
        {
            txtDataAdmissao.SelectAll();
        }

        private void txtDataAdmissao_DoubleClick(object sender, EventArgs e)
        {
            txtDataAdmissao.SelectAll();
        }

        private void txtDataAdmissao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (txtDataAdmissao.TextLength)
                {
                    case 0:
                        txtDataAdmissao.Text = "";
                        break;

                    case 2:
                        txtDataAdmissao.Text += "/";
                        txtDataAdmissao.SelectionStart = 4;
                        break;

                    case 5:
                        txtDataAdmissao.Text += "/";
                        txtDataAdmissao.SelectionStart = 7;
                        break;
                }
            }
        }

        private void cbCargo_Enter(object sender, EventArgs e)
        {
            cbCargo.SelectAll();
        }

        private void txtObservacao_Enter(object sender, EventArgs e)
        {
            txtObservacao.SelectAll();
        }

        private void txtSenhaLogin_Enter(object sender, EventArgs e)
        {
            txtSenhaLogin.SelectAll();
        }

        private void txtSenhaCompra_Enter(object sender, EventArgs e)
        {
            txtSenhaCompra.SelectAll();
        }

        private void txtSenhaApagador_Enter(object sender, EventArgs e)
        {
            txtSenhaApagador.SelectAll();
        }

        private void cbNivel_Enter(object sender, EventArgs e)
        {
            cbNivel.SelectAll();    
        }

        private void cbHabilitado_Enter(object sender, EventArgs e)
        {
            cbHabilitado.SelectAll();
        }

        #endregion

        private void FrmCadastroFuncionario_MouseMove(object sender, MouseEventArgs e) //Reseta o tempo de inatividae ao mover o mouse
        {
            Inatividade = 1200;
        }

        private void VerificaCampos()
        {
            verifTelefoneFormato = false;
            TelefoneVerif = txtTelefone.Text;
            TelefoneVerif = TelefoneVerif.Replace("(", "").Replace(")", "").Replace("-", ""); //Verifica se o Telefone possui um mínimo de números válidos
            if (TelefoneVerif.Length > 9 && TelefoneVerif.Length < 12)
            {
                try
                {
                    double telefoneNum = double.Parse(TelefoneVerif);
                    verifTelefoneFormato = true;
                }
                catch
                {
                    MessageBox.Show("Telefone(1) não pode conter letras!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Telefone(1) deve conter no mínimo (DDD) + 8 digitos!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);

            verifTelefone1Formato = false;
            TelefoneVerif = txtTelefone1.Text;
            TelefoneVerif = TelefoneVerif.Replace("(", "").Replace(")", "").Replace("-", ""); //Verifica se o Telefone possui um mínimo de números válidos
            if (TelefoneVerif.Length > 9 && TelefoneVerif.Length < 12)
            {
                try
                {
                    double telefoneNum = double.Parse(TelefoneVerif);
                    verifTelefone1Formato = true;
                }
                catch
                {
                    MessageBox.Show("Telefone(2) não pode conter letras!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Telefone(2) deve conter no mínimo (DDD) + 8 digitos!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }

}
