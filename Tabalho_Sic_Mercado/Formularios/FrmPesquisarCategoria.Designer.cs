namespace Mercado.Formularios
{
    partial class FrmPesquisarCategoria
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cbNomeNetoFiltroCima = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cbNomePaiFiltroCima = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbNomeFilhoFiltroCima = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbNomeNetoFiltroBaixo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbNomePaiFiltroBaixo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbNomeFilhoFiltroBaixo = new System.Windows.Forms.ComboBox();
            this.dataGridViewCima = new System.Windows.Forms.DataGridView();
            this.dataGridViewBaixo = new System.Windows.Forms.DataGridView();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCima)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBaixo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.cbNomeNetoFiltroCima);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.cbNomePaiFiltroCima);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.cbNomeFilhoFiltroCima);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(905, 76);
            this.groupBox4.TabIndex = 63;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Categorias";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(692, 19);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(73, 15);
            this.label18.TabIndex = 62;
            this.label18.Text = "Nome Neto :";
            // 
            // cbNomeNetoFiltroCima
            // 
            this.cbNomeNetoFiltroCima.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNomeNetoFiltroCima.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNomeNetoFiltroCima.FormattingEnabled = true;
            this.cbNomeNetoFiltroCima.Location = new System.Drawing.Point(608, 37);
            this.cbNomeNetoFiltroCima.Name = "cbNomeNetoFiltroCima";
            this.cbNomeNetoFiltroCima.Size = new System.Drawing.Size(267, 24);
            this.cbNomeNetoFiltroCima.TabIndex = 61;
            this.cbNomeNetoFiltroCima.SelectedIndexChanged += new System.EventHandler(this.cbNomeNetoFiltroCima_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(399, 19);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(74, 15);
            this.label17.TabIndex = 60;
            this.label17.Text = "Nome Filho :";
            // 
            // cbNomePaiFiltroCima
            // 
            this.cbNomePaiFiltroCima.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNomePaiFiltroCima.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNomePaiFiltroCima.FormattingEnabled = true;
            this.cbNomePaiFiltroCima.Location = new System.Drawing.Point(16, 37);
            this.cbNomePaiFiltroCima.Name = "cbNomePaiFiltroCima";
            this.cbNomePaiFiltroCima.Size = new System.Drawing.Size(267, 24);
            this.cbNomePaiFiltroCima.TabIndex = 56;
            this.cbNomePaiFiltroCima.SelectedIndexChanged += new System.EventHandler(this.cbNomePaiFiltroCima_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(109, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 15);
            this.label11.TabIndex = 59;
            this.label11.Text = "Nome Pai :";
            // 
            // cbNomeFilhoFiltroCima
            // 
            this.cbNomeFilhoFiltroCima.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNomeFilhoFiltroCima.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNomeFilhoFiltroCima.FormattingEnabled = true;
            this.cbNomeFilhoFiltroCima.Location = new System.Drawing.Point(308, 37);
            this.cbNomeFilhoFiltroCima.Name = "cbNomeFilhoFiltroCima";
            this.cbNomeFilhoFiltroCima.Size = new System.Drawing.Size(267, 24);
            this.cbNomeFilhoFiltroCima.TabIndex = 57;
            this.cbNomeFilhoFiltroCima.SelectedIndexChanged += new System.EventHandler(this.cbNomeFilhoFiltroCima_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbNomeNetoFiltroBaixo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbNomePaiFiltroBaixo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbNomeFilhoFiltroBaixo);
            this.groupBox1.Location = new System.Drawing.Point(12, 470);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(905, 91);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Categorias";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(692, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 62;
            this.label1.Text = "Nome Neto :";
            // 
            // cbNomeNetoFiltroBaixo
            // 
            this.cbNomeNetoFiltroBaixo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNomeNetoFiltroBaixo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNomeNetoFiltroBaixo.FormattingEnabled = true;
            this.cbNomeNetoFiltroBaixo.Location = new System.Drawing.Point(608, 47);
            this.cbNomeNetoFiltroBaixo.Name = "cbNomeNetoFiltroBaixo";
            this.cbNomeNetoFiltroBaixo.Size = new System.Drawing.Size(267, 24);
            this.cbNomeNetoFiltroBaixo.TabIndex = 61;
            this.cbNomeNetoFiltroBaixo.SelectedIndexChanged += new System.EventHandler(this.cbNomeNetoFiltroBaixo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(399, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 60;
            this.label2.Text = "Nome Filho :";
            // 
            // cbNomePaiFiltroBaixo
            // 
            this.cbNomePaiFiltroBaixo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNomePaiFiltroBaixo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNomePaiFiltroBaixo.FormattingEnabled = true;
            this.cbNomePaiFiltroBaixo.Location = new System.Drawing.Point(16, 47);
            this.cbNomePaiFiltroBaixo.Name = "cbNomePaiFiltroBaixo";
            this.cbNomePaiFiltroBaixo.Size = new System.Drawing.Size(267, 24);
            this.cbNomePaiFiltroBaixo.TabIndex = 56;
            this.cbNomePaiFiltroBaixo.SelectedIndexChanged += new System.EventHandler(this.cbNomePaiFiltroBaixo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(109, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 59;
            this.label3.Text = "Nome Pai :";
            // 
            // cbNomeFilhoFiltroBaixo
            // 
            this.cbNomeFilhoFiltroBaixo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNomeFilhoFiltroBaixo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNomeFilhoFiltroBaixo.FormattingEnabled = true;
            this.cbNomeFilhoFiltroBaixo.Location = new System.Drawing.Point(308, 47);
            this.cbNomeFilhoFiltroBaixo.Name = "cbNomeFilhoFiltroBaixo";
            this.cbNomeFilhoFiltroBaixo.Size = new System.Drawing.Size(267, 24);
            this.cbNomeFilhoFiltroBaixo.TabIndex = 57;
            this.cbNomeFilhoFiltroBaixo.SelectedIndexChanged += new System.EventHandler(this.cbNomeFilhoFiltroBaixo_SelectedIndexChanged);
            // 
            // dataGridViewCima
            // 
            this.dataGridViewCima.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCima.Location = new System.Drawing.Point(12, 94);
            this.dataGridViewCima.Name = "dataGridViewCima";
            this.dataGridViewCima.Size = new System.Drawing.Size(450, 370);
            this.dataGridViewCima.TabIndex = 65;
            this.dataGridViewCima.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewCima_CellMouseDoubleClick);
            // 
            // dataGridViewBaixo
            // 
            this.dataGridViewBaixo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBaixo.Location = new System.Drawing.Point(467, 94);
            this.dataGridViewBaixo.Name = "dataGridViewBaixo";
            this.dataGridViewBaixo.Size = new System.Drawing.Size(450, 370);
            this.dataGridViewBaixo.TabIndex = 66;
            this.dataGridViewBaixo.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewBaixo_CellMouseDoubleClick);
            // 
            // FrmPesquisarCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 567);
            this.Controls.Add(this.dataGridViewBaixo);
            this.Controls.Add(this.dataGridViewCima);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.KeyPreview = true;
            this.Name = "FrmPesquisarCategoria";
            this.Text = "Pesquisar Categoria";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPesquisarCategoria_KeyDown);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCima)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBaixo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbNomeNetoFiltroCima;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cbNomePaiFiltroCima;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbNomeFilhoFiltroCima;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbNomeNetoFiltroBaixo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbNomePaiFiltroBaixo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbNomeFilhoFiltroBaixo;
        private System.Windows.Forms.DataGridView dataGridViewCima;
        private System.Windows.Forms.DataGridView dataGridViewBaixo;
    }
}