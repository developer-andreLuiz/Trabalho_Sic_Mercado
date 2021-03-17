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
    public partial class FrmCadastroFornecedor : Form
    {
        
        bool inserir = false;
        bool atualizar = false;
        BotaoUI botaoUI = new BotaoUI();
        FornecedorDB fornecedor = new FornecedorDB();
        FrmPesquisaFornecedor frmPesquisaFornecedor = new FrmPesquisaFornecedor();

        string verifCampos = "Atenção! Campos obrigatórios não preenchidos!:\n";
        bool verifnome = false;
        bool verifCpf = false;
        bool verifRua = false;
        bool verifBairro = false;
        bool verifCidade = false;
        bool verifEstado = false;
        bool verifCep = false;
        bool verifTel = false;
        bool verifRepre = false;
        bool verifNota = false;
        bool verifCpfTam = false;
        bool verifTelefoneFormato = false;
        public string CpfVerif { get; set; }
        public string TelefoneVerif { get; set; }
        public int Rep { get; set; }
        private void Relogio_Tick(object sender, EventArgs e)
        {
            lblUsuario.Text = Usuario.user.nome;

            lblDataHora.Text = "Data: " + DateTime.Now.ToString("dd/MM/yyyy") + "  Hora: " + DateTime.Now.ToString("HH:mm:ss");

        }
        public FrmCadastroFornecedor()
        {
            InitializeComponent();
            ComponentesOpenForm();
            InicializarBotaoUI();
            Singleton.instancia.tela = "";
            Singleton.instancia.codigoFornecedor = 0;
        }



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
            if (txtnome.Text.Equals(string.Empty) == true)
            {
                verifnome = false;
                verifCampos += "nome\n";
            }
            else
            {
                verifnome = true;
            }
                    
                    
            if (txtCpf.Text.Equals(string.Empty) == true)
            {
                verifCpf = false;
                verifCampos += "CNPJ/CPF\n";
            }
            else 
            {
                verifCpf = true;
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

            if (txtCidade.Text.Equals(string.Empty) == true)
            {
                verifCidade = false;
                verifCampos += "Cidade\n";
            }
            else
            {
                verifCidade = true;
            }

            if (cbEstado.SelectedItem == null || cbEstado.SelectedItem.ToString() == "-")
            {
                verifEstado = false;
                verifCampos += "Estado\n";
            }
            else
            {
                verifEstado = true;
            }

            if (txtCep.Text.Equals(string.Empty) == true)
            {
                verifCep = false;
                verifCampos += "CEP\n";
            }
            else
            {
                verifCep = true;
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

            if (txtRepresentante.Text.Equals(string.Empty) == true)
            {
                verifRepre = false;
                verifCampos += "Representante\n";
            }
            else
            {
                verifRepre = true;
            }

            if (cbNota.SelectedItem.ToString() == "-" || cbNota.SelectedItem == null)
            {
                verifNota = false;
                verifCampos += "Nota\n";
            }
            else
            {
                verifNota = true;
            }
            #endregion
            if (verifnome == true && verifCpf == true && verifRua == true && verifBairro == true && verifCidade == true && verifEstado == true
                && verifCep == true && verifTel == true && verifRepre == true && verifNota == true)
            {
                GravarDadosObj();
                /*if (cbNota.Text.Equals("SIM") == false && cbNota.Text.Equals("sim") == false && cbNota.Text.Equals("Sim") == false)
                {
                    cbNota.Text = "NÃO";
                }*/
                
                if (inserir == true)
                {
                    VerificaCampos();
                    if (verifCpfTam == true && verifTelefoneFormato == true)

                    {
                        fornecedor.InserirDados();
                        botaoUI.UIBtnGravar();
                        ComponentesbtnGravar();
                    }
                    
                }
                if (atualizar == true)
                {
                    VerificaCampos();
                    if (verifCpfTam == true && verifTelefoneFormato == true)
                    {
                        GravarCodigoLocal();
                        GravarCodigoGlobal();
                        fornecedor.AlterarDados();
                        fornecedor.InserirRegistro();
                        botaoUI.UIBtnGravar();
                        ComponentesbtnGravar();
                    }

                    if (fornecedor.nomeCodigo.Equals(string.Empty) == false && fornecedor.CnpjCodigo.Equals(string.Empty) == false)
                    {
                        fornecedor.InserirDadosCodigo();
                        LimparFormCodigo();
                    }
                }

               
            }
            else
            {
                MessageBox.Show(verifCampos, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                verifCampos = "Atenção! Campos obrigatórios não preenchidos:\n";
            }
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Singleton.instancia.codigoFornecedor = 1;
            botaoUI.UIBtnCancelar();
            ComponentesbtnCancelar();

            
            fornecedor.BuscarPrimeiroRegistro();
            ExibirDadosForm();
            inserir = false;
            atualizar = false;

        }

        private void btnRetroceder_Click(object sender, EventArgs e)
        {
            GravarCodigoLocal();
            GravarCodigoGlobal();
            fornecedor.ObjVazio();
            Rep = 0;

            while (fornecedor.nome == null && Rep < 100)
            {
                Rep++;
                fornecedor.codigo--;
                fornecedor.BuscarDados();
                if (fornecedor.nome != null)
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

        private void btnAvancar_Click(object sender, EventArgs e)
        {

            GravarCodigoLocal();
            GravarCodigoGlobal();
            fornecedor.ObjVazio();
            Rep = 0;

            while (fornecedor.nome == null && Rep < 100)
            {
                Rep++;
                fornecedor.codigo++;
                fornecedor.BuscarDados();
                if (fornecedor.nome != null)
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

        private void btnRetroceder2x_Click(object sender, EventArgs e)
        {
            fornecedor.BuscarPrimeiroRegistro();
            ExibirDadosForm();
            GravarCodigoLocal();
            GravarCodigoGlobal();
        }

        private void btnAvancar2x_Click(object sender, EventArgs e)
        {
            fornecedor.BuscarUltimoRegistro();
            ExibirDadosForm();
            GravarCodigoLocal();
            GravarCodigoGlobal();
        }

        #endregion

       
        #region EventosFrms

        private void FrmCadastroFornecedor_Activated(object sender, EventArgs e)
        {
            if (inserir == false && atualizar == false)
            {
                GravarCodigoGlobal();
                fornecedor.ObjVazio();
                int rep = 0;

                while (fornecedor.nome == null && rep < 100)
                {

                    fornecedor.BuscarDados();


                    if (fornecedor.nome != null)
                    {

                        ExibirDadosForm();
                        rep = 0;
                    }
                    if (rep == 100)
                    {
                        MessageBox.Show("Esse é o ultimo");
                    }
                    rep++;
                    fornecedor.codigo++;
                }
            }
            
        }

        private void FrmCadastroFornecedor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Singleton.instancia.codigoFornecedor = 0;
        }

        private void FrmCadastroFornecedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {

                frmPesquisaFornecedor.ShowDialog();
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


        #region ControleInterface

        void GravarCodigoGlobal()
        {
            fornecedor.codigo = Singleton.instancia.codigoFornecedor;
        }
        void GravarCodigoLocal()

        {
            try
            {
                Singleton.instancia.codigoFornecedor = int.Parse(lblCodigo.Text.ToUpper().Trim());
                fornecedor.codigo = Singleton.instancia.codigoFornecedor;
            }
            catch
            {
               fornecedor.codigo = 1;
            }
        }

        /// <summary>
        /// Insere os valores contidos nos textbox para as propriedades de fornecedor
        /// </summary>
        void GravarDadosObj()
        {
            //fornecedor.codigo = int.Parse(lblCodigo.Text.Trim());
            fornecedor.Registro = txtRegistro.Text.ToUpper().Trim();
            fornecedor.nome = txtnome.Text.ToUpper().Trim();
            fornecedor.Endereco = txtRua.Text.ToUpper().Trim();
            fornecedor.Bairro = txtBairro.Text.ToUpper().Trim();
            fornecedor.Cidade = txtCidade.Text.ToUpper().Trim();
            fornecedor.Telefone = txtTelefone.Text.ToUpper().Trim();
            fornecedor.Telefone1 = txtTelefone1.Text.ToUpper().Trim();
            fornecedor.CnpjCpf = txtCpf.Text.ToUpper().Trim();
            fornecedor.Cep = txtCep.Text.ToUpper().Trim();
            fornecedor.Estado = cbEstado.Text.ToUpper().Trim();
            fornecedor.Representante = txtRepresentante.Text.ToUpper().Trim();
            fornecedor.Observacao = txtObservacao.Text.ToUpper().Trim();
            fornecedor.Nota = cbNota.Text.ToUpper().Trim();

            fornecedor.nomeCodigo = txtDescricao.Text.ToUpper().Trim();
            fornecedor.CnpjCodigo = txtCpf2.Text.ToUpper().Trim();
        }

        /// <summary>
        /// Exibe as informações contidas nas propriedades de fornecedor nos textbox
        /// </summary>
        void ExibirDadosForm()
        {
            lblCodigo.Text = fornecedor.codigo.ToString();
            txtRegistro.Text = fornecedor.Registro;
            txtnome.Text = fornecedor.nome;
            txtRua.Text = fornecedor.Endereco;
            txtBairro.Text = fornecedor.Bairro;
            txtCidade.Text = fornecedor.Cidade;
            txtTelefone.Text = fornecedor.Telefone;
            txtTelefone1.Text = fornecedor.Telefone1;
            txtCpf.Text = fornecedor.CnpjCpf;
            txtCep.Text = fornecedor.Cep;
            cbEstado.Text = fornecedor.Estado;
            txtRepresentante.Text = fornecedor.Representante;
            txtObservacao.Text = fornecedor.Observacao;
            cbNota.Text = fornecedor.Nota;
            
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
        /// Disponibilidade de campos ao abrir o formulário
        /// </summary>
        void ComponentesOpenForm()
        {
            txtnome.Enabled = false;
            txtCpf.Enabled = false;
            txtRegistro.Enabled = false;
            txtRua.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            cbEstado.Enabled = false;
            txtCep.Enabled = false;
            txtTelefone.Enabled = false;
            txtTelefone1.Enabled = false;
            txtRepresentante.Enabled = false;
            txtObservacao.Enabled = false;
            cbNota.Enabled = false;
            txtDescricao.Enabled = false;
            txtCpf2.Enabled = false;

            btnGravar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        /// <summary>
        /// Disponibilidade de campos ao clicar no botão "Novo"
        /// </summary>
        void ComponentesbtnNovo()
        {
            txtnome.Enabled = true;
            txtCpf.Enabled = true;
            txtRegistro.Enabled = true;
            txtRua.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            cbEstado.Enabled = true;
            txtCep.Enabled = true;
            txtTelefone.Enabled = true;
            txtTelefone1.Enabled = true;
            txtRepresentante.Enabled = true;
            txtObservacao.Enabled = true;
            cbNota.Enabled = true;
            txtDescricao.Enabled = true;
            txtCpf2.Enabled = true;
        }
        /// <summary>
        /// Disponibilidade de campos ao clicar no botão "Alterar"
        /// </summary>
        void ComponentesbtnAlterar()
        {
            txtnome.Enabled = true;
            txtCpf.Enabled = true;
            txtRegistro.Enabled = true;
            txtRua.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            cbEstado.Enabled = true;
            txtCep.Enabled = true;
            txtTelefone.Enabled = true;
            txtTelefone1.Enabled = true;
            txtRepresentante.Enabled = true;
            txtObservacao.Enabled = true;
            cbNota.Enabled = true;
            txtDescricao.Enabled = true;
            txtCpf2.Enabled = true;
        }

        /// <summary>
        /// Disponibilidade de campos ao clicar no botão "Gravar"
        /// </summary>
        void ComponentesbtnGravar()
        {
            txtnome.Enabled = false;
            txtCpf.Enabled = false;
            txtRegistro.Enabled = false;
            txtRua.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            cbEstado.Enabled = false;
            txtCep.Enabled = false;
            txtTelefone.Enabled = false;
            txtTelefone1.Enabled = false;
            txtRepresentante.Enabled = false;
            txtObservacao.Enabled = false;
            cbNota.Enabled = false;
            txtDescricao.Enabled = false;
            txtCpf2.Enabled = false;

            inserir = false;
            atualizar = false;
        }

        /// <summary>
        /// Disponibilidade de campos ao clicar no botão "Cancelar"
        /// </summary>
        void ComponentesbtnCancelar()
        {

            txtnome.Enabled = false;
            txtCpf.Enabled = false;
            txtRegistro.Enabled = false;
            txtRua.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            cbEstado.Enabled = false;
            txtCep.Enabled = false;
            txtTelefone.Enabled = false;
            txtTelefone1.Enabled = false;
            txtRepresentante.Enabled = false;
            txtObservacao.Enabled = false;
            cbNota.Enabled = false;
            txtDescricao.Enabled = false;
            txtCpf2.Enabled = false;
        }

        /// <summary>
        /// Remove todas as informações dos textbox do formulário de fornecedor
        /// </summary>
        void LimparForm()
        {
            lblCodigo.Text = string.Empty;
            txtRegistro.Text = string.Empty;
            txtnome.Text = string.Empty;
            txtRua.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtTelefone.Text = "(ddd) xxxx-xxxx";
            txtTelefone1.Text = "(ddd) xxxx-xxxx";
            txtCpf.Text = string.Empty;
            txtCep.Text = string.Empty;
            cbEstado.Text = "RJ";
            txtRepresentante.Text = string.Empty;
            txtObservacao.Text = string.Empty;
            cbNota.Text = "-";
            

            txtDescricao.Text = string.Empty;
            txtCpf2.Text = string.Empty;
           
        }

        /// <summary>
        /// Remove todas as informações da parte de recadastramento
        /// </summary>
        void LimparFormCodigo()
        {
            txtDescricao.Text = string.Empty;
            txtCpf2.Text = string.Empty;

        }


        #endregion


        #region Entrar Selecionando os campos
        
        private void txtnome_Enter(object sender, EventArgs e)
        {
            txtnome.SelectAll();
        }

        private void txtCpf_Enter(object sender, EventArgs e)
        {
            txtCpf.SelectAll();
        }

        private void txtRegistro_Enter(object sender, EventArgs e)
        {
            txtRegistro.SelectAll();
        }

        private void txtRua_Enter(object sender, EventArgs e)
        {
            txtRua.SelectAll();
        }
        private void txtBairro_Enter(object sender, EventArgs e)
        {
            txtBairro.SelectAll();
        }

        private void txtCidade_Enter(object sender, EventArgs e)
        {
            txtCidade.SelectAll();
        }

        private void cbEstado_Enter(object sender, EventArgs e)
        {
            cbEstado.SelectAll();
        }

        private void txtCep_Enter(object sender, EventArgs e)
        {
            txtCep.SelectAll();
        }

        private void txtTelefone_Enter(object sender, EventArgs e)
        {
            txtTelefone.SelectAll();
        }

        private void txtTelefone_DoubleClick(object sender, EventArgs e)
        {
            txtTelefone.SelectAll();
        }

        private void txtTelefone1_Enter(object sender, EventArgs e)
        {
            txtTelefone1.SelectAll();
        }

        private void txtTelefone1_DoubleClick(object sender, EventArgs e)
        {
            txtTelefone1.SelectAll();
        }

        private void txtRepresentante_Enter(object sender, EventArgs e)
        {
            txtRepresentante.SelectAll();
        }

        private void txtObservacao_Enter(object sender, EventArgs e)
        {
            txtObservacao.SelectAll();
        }

        private void cbNota_Enter(object sender, EventArgs e)
        {
            cbNota.SelectAll();
        }

        private void txtDescricao_Enter(object sender, EventArgs e)
        {
            txtDescricao.SelectAll();
        }

        private void txtCpf2_Enter(object sender, EventArgs e)
        {
            txtCpf2.SelectAll();
        }
        #endregion

        #region formatação de dados  




        private void txtCep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) //limita o textbox somente a números e backspace
            {
                e.Handled = true;
            }
            if (char.IsNumber(e.KeyChar) == true)
            {
                switch (txtCep.TextLength) // máscara de Cep
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

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) //limita o textbox somente a números e backspace
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

        private void txtTelefone1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) //limita o textbox somente a números e backspace
            {
                e.Handled = true;
            }
            if (char.IsNumber(e.KeyChar) == true) 
            {
                switch (txtTelefone1.TextLength) //máscara de Telefone1
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

        private void txtCpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) //limita o textbox somente a números e backspace
            {
                e.Handled = true;
            }
        }




        private void txtCpf2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) //limita o textbox somente a números e backspace
            {
                e.Handled = true;
            }
        }

        #endregion
        /// <summary>
        /// Verifica se os dados CPF e Telefone estão no formato correto
        /// </summary>
        public void VerificaCampos()
        {
            #region Verificar Cpf
            verifCpfTam = false;
            CpfVerif = txtCpf.Text;
            CpfVerif = CpfVerif.Replace(".", "").Replace("-", "").Replace("/", ""); //verifica se o cpf possui 11 números ou se o cnpj possui 14 números
            if (CpfVerif.Length == 11 || CpfVerif.Length == 14)
            {
                verifCpfTam = true;
            }
            else
            {
                MessageBox.Show("CNPJ/CPF inválido! deve conter 14 ou 11 números respectivamente!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
