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
    public partial class FrmCadastroCliente : Form
    {

        ClienteDB cliente = new ClienteDB();
        BotaoUI botaoUI = new BotaoUI();
        FrmPesquisaCliente frmPesquisaCliente = new FrmPesquisaCliente();

        /// <summary>
        /// Exibe nome do usuário, data e hora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Relogio_Tick(object sender, EventArgs e)
        {
            lblUsuario.Text = Usuario.user.nome;

            lblDataHora.Text = "Data: " + DateTime.Now.ToString("dd/MM/yyyy") + "  Hora: " + DateTime.Now.ToString("HH:mm:ss");
        }
        bool inserir = false;
        bool atualizar = false;
        bool verifnome = false;
        bool verifRua = false;
        bool verifBairro = false;
        bool verifCpf = false;
        bool verifCpfTam = false;
        bool verifPosicao = false;
        bool verifIdadeFormato = false;
        bool verifEstado = false;
        bool verifTelefoneFormato = false;
        int Rep { get; set; }
        string TelefoneVerif { get; set; }
        string VerifCampos = "Atenção! Campos Obrigatórios não preenchidos:\n";
        public FrmCadastroCliente()
        {
            InitializeComponent();
            Singleton.instancia.tela = "";
            ComponentesOpenForm();
            InicializarBotaoUI();
            Singleton.instancia.codigoCliente = 0;


        }


        #region EventosFrms
        //Define os comandos personalizados do formulário
        private void FrmCadastroCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {

                frmPesquisaCliente.ShowDialog();
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

        private void FrmCadastroCliente_Activated(object sender, EventArgs e)//Exibe os clientes e informa se é o último
        {
            if (atualizar == false && inserir == false)
            {
                GravarCodigoGlobal();
                cliente.ObjVazio();
                Rep = 0;

                while (cliente.nome == null && Rep < 100)
                {
                    cliente.BuscarDados();

                    if (cliente.nome != null)
                    {
                        ExibirDadosForm();
                        Rep = 0;
                    }
                    if (Rep == 100)
                    {
                        MessageBox.Show("Esse é o Ultimo");
                    }
                    Rep++;
                    cliente.codigo++;
                }
            }


        }

        private void FrmCadastroCliente_FormClosed(object sender, FormClosedEventArgs e)//retorna o cliente para o primeiro ao fechar o formulário
        {
            Singleton.instancia.codigoCliente = 1;
        }

        #endregion

        #region EventosBtns

        private void btnNovo_Click(object sender, EventArgs e)
        {

            inserir = true;
            botaoUI.UIBtnNovo();
            ComponentesbtnNovo();
            LimparForm();
            txtnome.Focus();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            atualizar = true;
            botaoUI.UIBtnAlterar();
            ComponentesbtnAlterar();
            txtnome.Focus();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            #region Campos Obrigatórios
            //Verifica se todos os campos obrigatórios estão preenchidos
            if (txtnome.Text.Equals(string.Empty) == true)
            {
                verifnome = false;
                VerifCampos += " nome\n";
            }
            else
            {
                verifnome = true;
            }

            if (txtRua.Text.Equals(string.Empty) == true)
            {
                verifRua = false;
                VerifCampos += " Rua\n";
            }
            else
            {
                verifRua = true;
            }

            if (txtBairro.Text.Equals(string.Empty) == true)
            {
                verifBairro = false;
                VerifCampos += " Bairro\n";
            }
            else
            {
                verifBairro = true;
            }
            if (txtCpf.Text.Equals(string.Empty) == true)
            {
                verifCpf = false;
                VerifCampos += "Cpf\n";
            }
            else
            {
                verifCpf = true;
            }

            if (cbPosicao.SelectedItem == null || cbPosicao.SelectedItem.ToString().ToUpper() != "INÍCIO" && cbPosicao.SelectedItem.ToString().ToUpper() != "MEIO" && cbPosicao.SelectedItem.ToString().ToUpper() != "FINAL")
            {
                verifPosicao = false;
                VerifCampos += "Posição da casa na rua\n";
            }
            else
            {
                verifPosicao = true;
            }
            if (cbEstado.SelectedItem == null || cbEstado.SelectedItem.ToString() == "-")
            {
                verifEstado = false;
                VerifCampos += "Estado\n";
            }
            else
            {
                verifEstado = true;
            }

            #endregion
            if (verifnome == true && verifRua == true && verifBairro == true && verifCpf == true && verifPosicao == true && verifEstado == true && verifTelefoneFormato == true)
            {

                GravarDadosObj();

                if (inserir == true)
                {
                    VerificaCampos();
                    if (verifCpfTam == true && verifIdadeFormato == true)
                    {

                        cliente.InserirDados();
                        ComponentesbtnGravar();
                        botaoUI.UIBtnGravar();
                    }

                }
                if (atualizar == true)
                {
                    VerificaCampos();
                    if (verifCpfTam == true && verifIdadeFormato == true)
                    {
                        GravarCodigoLocal();
                        GravarCodigoGlobal();
                        cliente.AlterarDados();
                        cliente.InserirRegistro();
                        ComponentesbtnGravar();
                        botaoUI.UIBtnGravar();
                    }
                }


            }
            else
            {
                MessageBox.Show(VerifCampos, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                VerifCampos = "Atenção! Campos Obrigatórios não preenchidos:\n";
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Singleton.instancia.codigoCliente = 1;
            botaoUI.UIBtnCancelar();
            ComponentesbtnCancelar();
            cliente.BuscarPrimeiroRegistro();
            ExibirDadosForm();
            inserir = false;
            atualizar = false;
        }

        private void btnAvancar_Click(object sender, EventArgs e)
        {
            GravarCodigoLocal();
            GravarCodigoGlobal();
            cliente.ObjVazio();
            int Rep = 0;

            while (cliente.nome == null && Rep < 100)
            {
                Rep++;
                cliente.codigo++;
                cliente.BuscarDados();
                if (cliente.nome != null)
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
            cliente.ObjVazio();
            Rep = 0;

            while (cliente.nome == null && Rep < 100)
            {
                Rep++;
                cliente.codigo--;
                cliente.BuscarDados();
                if (cliente.nome != null)
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
            cliente.BuscarUltimoRegistro();
            ExibirDadosForm();
            GravarCodigoLocal();
            GravarCodigoGlobal();

        }

        private void btnRetroceder2x_Click(object sender, EventArgs e)
        {
            cliente.BuscarPrimeiroRegistro();
            ExibirDadosForm();
            GravarCodigoLocal();
            GravarCodigoGlobal();

        }





        #endregion

        #region ControleInterface
        /// <summary>
        /// Envia o código de cliente para a classe singleton e depois retorna o codigo da mesma
        /// </summary>
        void GravarCodigoLocal()

        {
            try
            {
                Singleton.instancia.codigoCliente = int.Parse(lblCodigo.Text.ToUpper().Trim());
                cliente.codigo = Singleton.instancia.codigoCliente;
            }
            catch
            {
                cliente.codigo = 1;
            }
        }
        /// <summary>
        /// retorna o código da classe singleton
        /// </summary>
        void GravarCodigoGlobal()
        {
            cliente.codigo = Singleton.instancia.codigoCliente;
        }


        /// <summary>
        /// insere os valores das textbox nas propriedas referentes
        /// </summary>
        void GravarDadosObj()
        {
            //cliente.codigo = int.Parse(lblCodigo.Text.Trim());
            cliente.nome = txtnome.Text.ToUpper().Trim();
            cliente.Endereco = txtRua.Text.ToUpper().Trim();
            cliente.Bairro = txtBairro.Text.ToUpper().Trim();
            cliente.Cidade = txtCidade.Text.ToUpper().Trim();
            cliente.Estado = cbEstado.Text.ToUpper().Trim();
            cliente.Cep = txtCep.Text.ToUpper().Trim();
            cliente.Telefone = txtTelefone.Text.ToUpper().Trim();
            cliente.Telefone1 = txtTelefone1.Text.ToUpper().Trim();
            cliente.Cpf = txtCpf.Text.ToUpper().Trim();
            cliente.PontoReferencia = txtPontoReferencia.Text.ToUpper().Trim();
            cliente.Cor = txtCor.Text.ToUpper().Trim();
            cliente.Lado = cbLado.Text.ToUpper().Trim();
            cliente.Posicao = cbPosicao.Text.ToUpper().Trim();
            cliente.RuaEntrada = txtRuaEntrada.Text.ToUpper().Trim();
            cliente.DataNascimento = txtDataNascimento.Text.ToUpper().Trim();




        }
        /// <summary>
        /// Exibe as informações contidas nas propriedades de cliente
        /// </summary>
        void ExibirDadosForm()
        {

            txtnome.Text = cliente.nome;
            txtRua.Text = cliente.Endereco;
            txtBairro.Text = cliente.Bairro;
            txtCidade.Text = cliente.Cidade;
            cbEstado.Text = cliente.Estado;
            txtCep.Text = cliente.Cep;
            txtTelefone.Text = cliente.Telefone;
            txtTelefone1.Text = cliente.Telefone1;
            txtCpf.Text = cliente.Cpf;
            txtPontoReferencia.Text = cliente.PontoReferencia;
            txtCor.Text = cliente.Cor;
            cbLado.Text = cliente.Lado;
            cbPosicao.Text = cliente.Posicao;
            txtRuaEntrada.Text = cliente.RuaEntrada;
            txtDataNascimento.Text = cliente.DataNascimento;
            lblCodigo.Text = cliente.codigo.ToString();




        }



        /// <summary>
        /// atribui as funcionalizades aos botões referentes
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
        /// Padrão de disponibilidade de campos quando o formulário for aberto
        /// </summary>
        void ComponentesOpenForm()
        {
            txtnome.Enabled = false;
            txtRua.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtTelefone.Enabled = false;
            txtTelefone1.Enabled = false;
            txtDataNascimento.Enabled = false;
            txtCpf.Enabled = false;
            txtCep.Enabled = false;
            cbEstado.Enabled = false;
            txtPontoReferencia.Enabled = false;
            txtRuaEntrada.Enabled = false;
            cbLado.Enabled = false;
            cbPosicao.Enabled = false;
            txtCor.Enabled = false;
            btnGravar.Enabled = false;
            btnCancelar.Enabled = false;
        }
        /// <summary>
        /// Disponibilidade de campos quando o botão "Novo" for clicado
        /// </summary>
        void ComponentesbtnNovo()
        {
            txtnome.Enabled = true;
            txtRua.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            txtTelefone.Enabled = true;
            txtTelefone1.Enabled = true;
            txtDataNascimento.Enabled = true;
            txtCpf.Enabled = true;
            txtCep.Enabled = true;
            cbEstado.Enabled = true;
            txtPontoReferencia.Enabled = true;
            txtRuaEntrada.Enabled = true;
            cbLado.Enabled = true;
            cbPosicao.Enabled = true;
            txtCor.Enabled = true;
        }
        /// <summary>
        /// Disponibilidade de campos quando o botão "Alterar" for clicado
        /// </summary>
        void ComponentesbtnAlterar()
        {
            txtnome.Enabled = true;
            txtRua.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            txtTelefone.Enabled = true;
            txtTelefone1.Enabled = true;
            txtDataNascimento.Enabled = true;
            txtCpf.Enabled = true;
            txtCep.Enabled = true;
            cbEstado.Enabled = true;
            txtPontoReferencia.Enabled = true;
            txtRuaEntrada.Enabled = true;
            cbLado.Enabled = true;
            cbPosicao.Enabled = true;
            txtCor.Enabled = true;
        }

        /// <summary>
        /// Disponibilidade de campos quando o botão "Gravar" for clicado
        /// </summary>
        void ComponentesbtnGravar()
        {
            txtnome.Enabled = false;
            txtRua.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtTelefone.Enabled = false;
            txtTelefone1.Enabled = false;
            txtDataNascimento.Enabled = false;
            txtCpf.Enabled = false;
            txtCep.Enabled = false;
            cbEstado.Enabled = false;
            txtPontoReferencia.Enabled = false;
            txtRuaEntrada.Enabled = false;
            cbLado.Enabled = false;
            cbPosicao.Enabled = false;
            txtCor.Enabled = false;

            inserir = false;
            atualizar = false;
        }

        /// <summary>
        /// Disponibilidade de campos quando o botão "Cancelar" for clicado
        /// </summary>
        void ComponentesbtnCancelar()
        {

            txtnome.Enabled = false;
            txtRua.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtTelefone.Enabled = false;
            txtTelefone1.Enabled = false;
            txtDataNascimento.Enabled = false;
            txtCpf.Enabled = false;
            txtCep.Enabled = false;
            cbEstado.Enabled = false;
            txtPontoReferencia.Enabled = false;
            txtRuaEntrada.Enabled = false;
            cbLado.Enabled = false;
            cbPosicao.Enabled = false;
            txtCor.Enabled = false;
        }


        /// <summary>
        /// limpa todas as informações do formulário ou pro valor padrão (formato) do campo
        /// </summary>
        void LimparForm()
        {
            lblCodigo.Text = string.Empty;
            txtnome.Text = string.Empty;
            txtRua.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtTelefone.Text = "(ddd) xxxx-xxxx";
            txtTelefone1.Text = "(ddd) xxxx-xxxx";
            txtDataNascimento.Text = "dd/mm/aaaa";
            txtCpf.Text = string.Empty;
            txtCep.Text = string.Empty;
            cbEstado.Text = "RJ";
            txtPontoReferencia.Text = string.Empty;
            txtRuaEntrada.Text = string.Empty;
            cbLado.Text = "Escolha o lado";
            cbPosicao.Text = "Escolha a posição";
            txtCor.Text = string.Empty;
        }


        #endregion



        #region Entrar Selecionando o Campo
        private void txtnome_Enter(object sender, EventArgs e)
        {
            txtnome.SelectAll();
        }

        private void txtRua_Enter(object sender, EventArgs e)
        {
            txtRua.SelectAll();
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
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) //Limita o campo a receber somente números e Backspace
            {
                e.Handled = true;
            }
            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (txtTelefone.TextLength) //Máscara de Telefone
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
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) //Limita o campo a receber somente números e Backspace
            {
                e.Handled = true;
            }
            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (txtTelefone1.TextLength) //Máscara de Telefone1
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

        private void txtDataNascimento_Enter(object sender, EventArgs e)
        {
            txtDataNascimento.SelectAll();
        }

        private void txtDataNascimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) //Limita o campo a receber somente números e Backspace
            {
                e.Handled = true;
            }
            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (txtDataNascimento.TextLength) //Máscara de data de nascimento
                {
                    case 0:
                        txtDataNascimento.Text = "";
                        break;

                    case 2:
                        txtDataNascimento.Text += "/";
                        txtDataNascimento.SelectionStart = 4;
                        break;

                    case 5:
                        txtDataNascimento.Text += "/";
                        txtDataNascimento.SelectionStart = 7;
                        break;
                }
            }
        }


        private void txtCpf_Enter(object sender, EventArgs e)
        {
            txtCpf.SelectAll();
        }

        private void txtCpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) //Limita o campo a receber somente números e Backspace
            {
                e.Handled = true;
            }

            if (char.IsNumber(e.KeyChar) == true)
            {

                switch (txtCpf.TextLength) //Máscara de Cpf
                {
                    case 0:
                        txtCpf.Text = "";
                        break;

                    case 3:
                        txtCpf.Text += ".";
                        txtCpf.SelectionStart = 5;
                        break;

                    case 7:
                        txtCpf.Text += ".";
                        txtCpf.SelectionStart = 9;
                        break;

                    case 11:
                        txtCpf.Text += "-";
                        txtCpf.SelectionStart = 13;
                        break;
                }
            }

        }

        private void txtCep_Enter(object sender, EventArgs e)
        {
            txtCep.SelectAll();
        }

        private void txtCep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) //Limita o campo a receber somente números e Backspace
            {
                e.Handled = true;
            }
            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (txtCep.TextLength) //Máscara de Cep
                {
                    case 0:
                        txtCep.Text = "";
                        break;

                    case 5:
                        txtCep.Text += "-";
                        txtCep.SelectionStart = 7;
                        break;
                }
            }
        }

        private void txtCep_DoubleClick(object sender, EventArgs e)
        {
            txtCep.SelectAll();
        }

        private void cbEstado_Enter(object sender, EventArgs e)
        {
            cbEstado.SelectAll();
        }

        private void txtPontoReferencia_Enter(object sender, EventArgs e)
        {
            txtPontoReferencia.SelectAll();
        }

        private void txtRuaEntrada_Enter(object sender, EventArgs e)
        {
            txtRuaEntrada.SelectAll();
        }

        private void cbLado_Enter(object sender, EventArgs e)
        {
            cbLado.SelectAll();
        }

        private void cbPosicao_Enter(object sender, EventArgs e)
        {
            cbPosicao.SelectAll();
        }

        private void txtCor_Enter(object sender, EventArgs e)
        {
            txtCor.SelectAll();
        }
        #endregion

        /// <summary>
        ///Verifica se os campos estão corretamente preenchidos(Idade, CPF)
        /// </summary>
        private void VerificaCampos()
        {
            #region Verificar CPF
            verifCpfTam = false;
            string cpfVerif = txtCpf.Text;
            cpfVerif = cpfVerif.Replace(".", "").Replace("-", ""); //verifica se o cpf possui 11 números
            if (cpfVerif.Length == 11)
            {
                verifCpfTam = true;
            }
            else
            {
                MessageBox.Show("CPF inválido! deve conter 11 números!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            #endregion
            #region Verificar Idade
            verifIdadeFormato = false;
            string idadeVerif = txtDataNascimento.Text;
            idadeVerif = idadeVerif.Replace("/", ""); //Verifica se a idade possui 8 números
            if (idadeVerif.Length == 8)
            {
                int idadeVerifDia = int.Parse(idadeVerif.Substring(0, 2)); //Verifica se o dia é diferente de 00 e menor que 31
                if (idadeVerifDia != 00 && idadeVerifDia < 31)
                {
                    int idadeVerifMes = int.Parse(idadeVerif.Substring(2, 2)); //Verifica se o mês é diferente de 00 e menor que 13
                    if (idadeVerifMes != 00 && idadeVerifMes < 13)
                    {
                        int idadeVerifAno = int.Parse(idadeVerif.Substring(4, 4));
                        if (DateTime.Now.Year - idadeVerifAno < 110 && DateTime.Now.Year - idadeVerifAno > 8) //Verifica a idade a partir do ano atual
                        {
                            verifIdadeFormato = true;
                        }
                        else
                            MessageBox.Show("Ano(DT.Nascimento) inválido! deve conter entre 9 anos e 110 anos!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Mês(DT.Nascimento) inválido! deve conter entre 01 e 12!" + idadeVerifMes);
                }
                else
                    MessageBox.Show("Dia(DT.Nascimento) inválido! deve conter entre 01 e 30!");


            }
            else
                MessageBox.Show("Idade inválida! deve conter 8 dígitos!!!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            #endregion

            #region Verificar Telefone
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
            #endregion 
        }
    }
}