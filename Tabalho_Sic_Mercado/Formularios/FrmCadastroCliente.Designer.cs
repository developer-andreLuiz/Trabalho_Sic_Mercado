namespace Mercado
{
    partial class FrmCadastroCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.txtRua = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTelefone1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDataNascimento = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCpf = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCep = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPontoReferencia = new System.Windows.Forms.TextBox();
            this.txtCor = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtRuaEntrada = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cbLado = new System.Windows.Forms.ComboBox();
            this.cbPosicao = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDataHora = new System.Windows.Forms.Label();
            this.gbCodigo = new System.Windows.Forms.GroupBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.btnRetroceder = new System.Windows.Forms.Button();
            this.btnAvancar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.txtnome = new System.Windows.Forms.TextBox();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnAvancar2x = new System.Windows.Forms.Button();
            this.btnRetroceder2x = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.Relogio = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.gbCodigo.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 129);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 15);
            this.label2.TabIndex = 23;
            this.label2.Text = "Razão Social / nome";
            // 
            // txtBairro
            // 
            this.txtBairro.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtBairro.Location = new System.Drawing.Point(414, 200);
            this.txtBairro.Margin = new System.Windows.Forms.Padding(4);
            this.txtBairro.MaxLength = 256;
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(85, 21);
            this.txtBairro.TabIndex = 2;
            // 
            // txtRua
            // 
            this.txtRua.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtRua.Location = new System.Drawing.Point(38, 200);
            this.txtRua.Margin = new System.Windows.Forms.Padding(4);
            this.txtRua.MaxLength = 256;
            this.txtRua.Name = "txtRua";
            this.txtRua.Size = new System.Drawing.Size(361, 21);
            this.txtRua.TabIndex = 1;
            this.txtRua.Enter += new System.EventHandler(this.txtRua_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(431, 181);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 25;
            this.label3.Text = "Bairro";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 181);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 15);
            this.label4.TabIndex = 24;
            this.label4.Text = "Rua";
            // 
            // txtCidade
            // 
            this.txtCidade.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtCidade.Location = new System.Drawing.Point(38, 243);
            this.txtCidade.Margin = new System.Windows.Forms.Padding(4);
            this.txtCidade.MaxLength = 256;
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(89, 21);
            this.txtCidade.TabIndex = 3;
            this.txtCidade.Enter += new System.EventHandler(this.txtCidade_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 224);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 15);
            this.label5.TabIndex = 26;
            this.label5.Text = "Cidade";
            // 
            // txtTelefone
            // 
            this.txtTelefone.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtTelefone.Location = new System.Drawing.Point(136, 243);
            this.txtTelefone.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelefone.MaxLength = 14;
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(112, 21);
            this.txtTelefone.TabIndex = 4;
            this.txtTelefone.Text = "(ddd) xxxx-xxxx";
            this.txtTelefone.DoubleClick += new System.EventHandler(this.txtTelefone_DoubleClick);
            this.txtTelefone.Enter += new System.EventHandler(this.txtTelefone_Enter);
            this.txtTelefone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefone_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(158, 224);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 15);
            this.label7.TabIndex = 27;
            this.label7.Text = "Telefone";
            // 
            // txtTelefone1
            // 
            this.txtTelefone1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtTelefone1.Location = new System.Drawing.Point(259, 243);
            this.txtTelefone1.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelefone1.MaxLength = 14;
            this.txtTelefone1.Name = "txtTelefone1";
            this.txtTelefone1.Size = new System.Drawing.Size(117, 21);
            this.txtTelefone1.TabIndex = 5;
            this.txtTelefone1.Text = "(dd) xxxx-xxxx";
            this.txtTelefone1.DoubleClick += new System.EventHandler(this.txtTelefone1_DoubleClick);
            this.txtTelefone1.Enter += new System.EventHandler(this.txtTelefone1_Enter);
            this.txtTelefone1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefone1_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(293, 224);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 15);
            this.label8.TabIndex = 28;
            this.label8.Text = "Telefone";
            // 
            // txtDataNascimento
            // 
            this.txtDataNascimento.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtDataNascimento.Location = new System.Drawing.Point(384, 243);
            this.txtDataNascimento.Margin = new System.Windows.Forms.Padding(4);
            this.txtDataNascimento.MaxLength = 10;
            this.txtDataNascimento.Name = "txtDataNascimento";
            this.txtDataNascimento.Size = new System.Drawing.Size(116, 21);
            this.txtDataNascimento.TabIndex = 6;
            this.txtDataNascimento.Text = "dd/mm/aaaa";
            this.txtDataNascimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDataNascimento.Enter += new System.EventHandler(this.txtDataNascimento_Enter);
            this.txtDataNascimento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDataNascimento_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(381, 224);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 15);
            this.label9.TabIndex = 29;
            this.label9.Text = "Data de Nascimento";
            // 
            // txtCpf
            // 
            this.txtCpf.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtCpf.Location = new System.Drawing.Point(38, 285);
            this.txtCpf.Margin = new System.Windows.Forms.Padding(4);
            this.txtCpf.MaxLength = 14;
            this.txtCpf.Name = "txtCpf";
            this.txtCpf.Size = new System.Drawing.Size(108, 21);
            this.txtCpf.TabIndex = 7;
            this.txtCpf.Text = "xxx.xxx.xxx-xx";
            this.txtCpf.Enter += new System.EventHandler(this.txtCpf_Enter);
            this.txtCpf.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCpf_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(74, 266);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 15);
            this.label10.TabIndex = 30;
            this.label10.Text = "CPF";
            // 
            // txtCep
            // 
            this.txtCep.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtCep.Location = new System.Drawing.Point(161, 285);
            this.txtCep.Margin = new System.Windows.Forms.Padding(4);
            this.txtCep.MaxLength = 9;
            this.txtCep.Name = "txtCep";
            this.txtCep.Size = new System.Drawing.Size(102, 21);
            this.txtCep.TabIndex = 8;
            this.txtCep.Text = "xxxxx-xxx";
            this.txtCep.DoubleClick += new System.EventHandler(this.txtCep_DoubleClick);
            this.txtCep.Enter += new System.EventHandler(this.txtCep_Enter);
            this.txtCep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCep_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(193, 266);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 15);
            this.label11.TabIndex = 31;
            this.label11.Text = "CEP";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(298, 266);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 15);
            this.label12.TabIndex = 32;
            this.label12.Text = "Estado";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(41, 310);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(119, 15);
            this.label13.TabIndex = 33;
            this.label13.Text = "Ponto de Referência";
            // 
            // txtPontoReferencia
            // 
            this.txtPontoReferencia.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtPontoReferencia.Location = new System.Drawing.Point(38, 329);
            this.txtPontoReferencia.Margin = new System.Windows.Forms.Padding(4);
            this.txtPontoReferencia.MaxLength = 999;
            this.txtPontoReferencia.Multiline = true;
            this.txtPontoReferencia.Name = "txtPontoReferencia";
            this.txtPontoReferencia.Size = new System.Drawing.Size(463, 94);
            this.txtPontoReferencia.TabIndex = 10;
            this.txtPontoReferencia.Enter += new System.EventHandler(this.txtPontoReferencia_Enter);
            // 
            // txtCor
            // 
            this.txtCor.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtCor.Location = new System.Drawing.Point(333, 494);
            this.txtCor.Margin = new System.Windows.Forms.Padding(4);
            this.txtCor.MaxLength = 99;
            this.txtCor.Name = "txtCor";
            this.txtCor.Size = new System.Drawing.Size(168, 21);
            this.txtCor.TabIndex = 14;
            this.txtCor.Enter += new System.EventHandler(this.txtCor_Enter);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(330, 476);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 15);
            this.label14.TabIndex = 37;
            this.label14.Text = "Cor do Portão";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(155, 474);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(142, 15);
            this.label15.TabIndex = 36;
            this.label15.Text = "Posição da Casa na Rua";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(42, 474);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(83, 15);
            this.label16.TabIndex = 35;
            this.label16.Text = "Lado da Casa";
            // 
            // txtRuaEntrada
            // 
            this.txtRuaEntrada.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtRuaEntrada.Location = new System.Drawing.Point(38, 446);
            this.txtRuaEntrada.Margin = new System.Windows.Forms.Padding(4);
            this.txtRuaEntrada.MaxLength = 256;
            this.txtRuaEntrada.Name = "txtRuaEntrada";
            this.txtRuaEntrada.Size = new System.Drawing.Size(462, 21);
            this.txtRuaEntrada.TabIndex = 11;
            this.txtRuaEntrada.Enter += new System.EventHandler(this.txtRuaEntrada_Enter);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(42, 428);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(110, 15);
            this.label17.TabIndex = 34;
            this.label17.Text = "Entrando pela Rua";
            // 
            // cbLado
            // 
            this.cbLado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLado.FormattingEnabled = true;
            this.cbLado.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.cbLado.Items.AddRange(new object[] {
            "Direito",
            "Esquerdo"});
            this.cbLado.Location = new System.Drawing.Point(38, 493);
            this.cbLado.Margin = new System.Windows.Forms.Padding(4);
            this.cbLado.Name = "cbLado";
            this.cbLado.Size = new System.Drawing.Size(108, 23);
            this.cbLado.TabIndex = 12;
            this.cbLado.Enter += new System.EventHandler(this.cbLado_Enter);
            // 
            // cbPosicao
            // 
            this.cbPosicao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPosicao.FormattingEnabled = true;
            this.cbPosicao.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.cbPosicao.Items.AddRange(new object[] {
            "Início",
            "Meio",
            "Final"});
            this.cbPosicao.Location = new System.Drawing.Point(158, 493);
            this.cbPosicao.Margin = new System.Windows.Forms.Padding(4);
            this.cbPosicao.Name = "cbPosicao";
            this.cbPosicao.Size = new System.Drawing.Size(162, 23);
            this.cbPosicao.TabIndex = 13;
            this.cbPosicao.Enter += new System.EventHandler(this.cbPosicao_Enter);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Mercado.Properties.Resources.imgPainel;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.lblDataHora);
            this.panel1.Location = new System.Drawing.Point(8, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 124);
            this.panel1.TabIndex = 38;
            // 
            // lblDataHora
            // 
            this.lblDataHora.AutoSize = true;
            this.lblDataHora.BackColor = System.Drawing.Color.Transparent;
            this.lblDataHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataHora.ForeColor = System.Drawing.Color.Black;
            this.lblDataHora.Location = new System.Drawing.Point(298, 105);
            this.lblDataHora.Name = "lblDataHora";
            this.lblDataHora.Size = new System.Drawing.Size(53, 16);
            this.lblDataHora.TabIndex = 0;
            this.lblDataHora.Text = "Data : ";
            // 
            // gbCodigo
            // 
            this.gbCodigo.Controls.Add(this.lblCodigo);
            this.gbCodigo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCodigo.Location = new System.Drawing.Point(10, 127);
            this.gbCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.gbCodigo.Name = "gbCodigo";
            this.gbCodigo.Padding = new System.Windows.Forms.Padding(4);
            this.gbCodigo.Size = new System.Drawing.Size(116, 54);
            this.gbCodigo.TabIndex = 22;
            this.gbCodigo.TabStop = false;
            this.gbCodigo.Text = "Código";
            // 
            // lblCodigo
            // 
            this.lblCodigo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCodigo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.ForeColor = System.Drawing.Color.Red;
            this.lblCodigo.Location = new System.Drawing.Point(18, 22);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(78, 23);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código";
            this.lblCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRetroceder
            // 
            this.btnRetroceder.BackColor = System.Drawing.Color.Gray;
            this.btnRetroceder.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetroceder.ForeColor = System.Drawing.Color.White;
            this.btnRetroceder.Location = new System.Drawing.Point(213, 575);
            this.btnRetroceder.Margin = new System.Windows.Forms.Padding(4);
            this.btnRetroceder.Name = "btnRetroceder";
            this.btnRetroceder.Size = new System.Drawing.Size(50, 44);
            this.btnRetroceder.TabIndex = 20;
            this.btnRetroceder.Text = "<<";
            this.btnRetroceder.UseVisualStyleBackColor = false;
            this.btnRetroceder.Click += new System.EventHandler(this.btnRetroceder_Click);
            // 
            // btnAvancar
            // 
            this.btnAvancar.BackColor = System.Drawing.Color.Gray;
            this.btnAvancar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAvancar.ForeColor = System.Drawing.Color.White;
            this.btnAvancar.Location = new System.Drawing.Point(269, 575);
            this.btnAvancar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAvancar.Name = "btnAvancar";
            this.btnAvancar.Size = new System.Drawing.Size(50, 44);
            this.btnAvancar.TabIndex = 21;
            this.btnAvancar.Text = ">>";
            this.btnAvancar.UseVisualStyleBackColor = false;
            this.btnAvancar.Click += new System.EventHandler(this.btnAvancar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.BackColor = System.Drawing.Color.Gray;
            this.btnAlterar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.ForeColor = System.Drawing.Color.White;
            this.btnAlterar.Location = new System.Drawing.Point(291, 525);
            this.btnAlterar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(92, 44);
            this.btnAlterar.TabIndex = 17;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = false;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnGravar
            // 
            this.btnGravar.BackColor = System.Drawing.Color.Gray;
            this.btnGravar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGravar.ForeColor = System.Drawing.Color.White;
            this.btnGravar.Location = new System.Drawing.Point(165, 525);
            this.btnGravar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(97, 44);
            this.btnGravar.TabIndex = 16;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = false;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Gray;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(406, 524);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(98, 44);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cbEstado
            // 
            this.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.cbEstado.Items.AddRange(new object[] {
            "RJ",
            "SP",
            "-",
            "AC",
            "AL",
            "AP",
            "AM",
            "BA",
            "CE",
            "DF",
            "ES",
            "GO",
            "MA",
            "MT",
            "MS",
            "MG",
            "PA",
            "PB",
            "PR",
            "PE",
            "PI",
            "RJ",
            "RN",
            "RS",
            "RO",
            "RR",
            "SC",
            "SP",
            "SE",
            "TO"});
            this.cbEstado.Location = new System.Drawing.Point(302, 285);
            this.cbEstado.Margin = new System.Windows.Forms.Padding(4);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(85, 23);
            this.cbEstado.TabIndex = 9;
            this.cbEstado.Enter += new System.EventHandler(this.cbEstado_Enter);
            // 
            // txtnome
            // 
            this.txtnome.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtnome.Location = new System.Drawing.Point(134, 144);
            this.txtnome.Margin = new System.Windows.Forms.Padding(4);
            this.txtnome.MaxLength = 256;
            this.txtnome.Name = "txtnome";
            this.txtnome.Size = new System.Drawing.Size(362, 21);
            this.txtnome.TabIndex = 0;
            this.txtnome.Enter += new System.EventHandler(this.txtnome_Enter);
            // 
            // btnNovo
            // 
            this.btnNovo.BackColor = System.Drawing.Color.Gray;
            this.btnNovo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.ForeColor = System.Drawing.Color.White;
            this.btnNovo.Location = new System.Drawing.Point(45, 524);
            this.btnNovo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(88, 44);
            this.btnNovo.TabIndex = 15;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnAvancar2x
            // 
            this.btnAvancar2x.BackColor = System.Drawing.Color.Gray;
            this.btnAvancar2x.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAvancar2x.ForeColor = System.Drawing.Color.White;
            this.btnAvancar2x.Location = new System.Drawing.Point(335, 575);
            this.btnAvancar2x.Margin = new System.Windows.Forms.Padding(4);
            this.btnAvancar2x.Name = "btnAvancar2x";
            this.btnAvancar2x.Size = new System.Drawing.Size(66, 44);
            this.btnAvancar2x.TabIndex = 22;
            this.btnAvancar2x.Text = ">>|";
            this.btnAvancar2x.UseVisualStyleBackColor = false;
            this.btnAvancar2x.Click += new System.EventHandler(this.btnAvancar2x_Click);
            // 
            // btnRetroceder2x
            // 
            this.btnRetroceder2x.BackColor = System.Drawing.Color.Gray;
            this.btnRetroceder2x.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetroceder2x.ForeColor = System.Drawing.Color.White;
            this.btnRetroceder2x.Location = new System.Drawing.Point(130, 575);
            this.btnRetroceder2x.Margin = new System.Windows.Forms.Padding(4);
            this.btnRetroceder2x.Name = "btnRetroceder2x";
            this.btnRetroceder2x.Size = new System.Drawing.Size(64, 44);
            this.btnRetroceder2x.TabIndex = 19;
            this.btnRetroceder2x.Text = "|<<";
            this.btnRetroceder2x.UseVisualStyleBackColor = false;
            this.btnRetroceder2x.Click += new System.EventHandler(this.btnRetroceder2x_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.lblStatus);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblUsuario);
            this.panel2.Location = new System.Drawing.Point(-3, 635);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(551, 25);
            this.panel2.TabIndex = 58;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Lime;
            this.lblStatus.Location = new System.Drawing.Point(438, 4);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 16);
            this.lblStatus.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 32;
            this.label1.Text = "Login :";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.Lime;
            this.lblUsuario.Location = new System.Drawing.Point(47, 4);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(44, 16);
            this.lblUsuario.TabIndex = 31;
            this.lblUsuario.Text = "xxxxxx";
            // 
            // Relogio
            // 
            this.Relogio.Enabled = true;
            this.Relogio.Interval = 1000;
            this.Relogio.Tick += new System.EventHandler(this.Relogio_Tick);
            // 
            // FrmCadastroCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 659);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnRetroceder2x);
            this.Controls.Add(this.btnAvancar2x);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.txtnome);
            this.Controls.Add(this.cbEstado);
            this.Controls.Add(this.btnRetroceder);
            this.Controls.Add(this.btnAvancar);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.gbCodigo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbPosicao);
            this.Controls.Add(this.cbLado);
            this.Controls.Add(this.txtCor);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtRuaEntrada);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtPontoReferencia);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtCep);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCpf);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDataNascimento);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTelefone1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCidade);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBairro);
            this.Controls.Add(this.txtRua);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmCadastroCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.FrmCadastroCliente_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCadastroCliente_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCadastroCliente_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbCodigo.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.TextBox txtRua;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTelefone1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDataNascimento;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCpf;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCep;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPontoReferencia;
        private System.Windows.Forms.TextBox txtCor;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtRuaEntrada;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cbLado;
        private System.Windows.Forms.ComboBox cbPosicao;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbCodigo;
        private System.Windows.Forms.Button btnRetroceder;
        private System.Windows.Forms.Button btnAvancar;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.TextBox txtnome;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnAvancar2x;
        private System.Windows.Forms.Button btnRetroceder2x;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblDataHora;
        private System.Windows.Forms.Timer Relogio;
        private System.Windows.Forms.Label lblStatus;
    }
}