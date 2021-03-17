namespace Mercado.Formularios
{
    partial class FrmPesquisaProduto
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbCategoriaPai = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.cbCategoriaNeto = new System.Windows.Forms.ComboBox();
            this.cbCategoriaFilho = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 106);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(776, 332);
            this.dataGridView.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbCategoriaPai);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.cbCategoriaNeto);
            this.groupBox3.Controls.Add(this.cbCategoriaFilho);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(776, 88);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Categorias";
            // 
            // cbCategoriaPai
            // 
            this.cbCategoriaPai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoriaPai.FormattingEnabled = true;
            this.cbCategoriaPai.Location = new System.Drawing.Point(62, 37);
            this.cbCategoriaPai.Name = "cbCategoriaPai";
            this.cbCategoriaPai.Size = new System.Drawing.Size(180, 21);
            this.cbCategoriaPai.TabIndex = 0;
            this.cbCategoriaPai.SelectedIndexChanged += new System.EventHandler(this.cbCategoriaPai_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(127, 15);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(25, 13);
            this.label16.TabIndex = 118;
            this.label16.Text = "Pai ";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(373, 17);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(32, 13);
            this.label19.TabIndex = 121;
            this.label19.Text = "Filho ";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(603, 21);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(33, 13);
            this.label20.TabIndex = 122;
            this.label20.Text = "Neto ";
            // 
            // cbCategoriaNeto
            // 
            this.cbCategoriaNeto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoriaNeto.FormattingEnabled = true;
            this.cbCategoriaNeto.Location = new System.Drawing.Point(528, 37);
            this.cbCategoriaNeto.Name = "cbCategoriaNeto";
            this.cbCategoriaNeto.Size = new System.Drawing.Size(180, 21);
            this.cbCategoriaNeto.TabIndex = 2;
            this.cbCategoriaNeto.SelectedIndexChanged += new System.EventHandler(this.cbCategoriaNeto_SelectedIndexChanged);
            // 
            // cbCategoriaFilho
            // 
            this.cbCategoriaFilho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoriaFilho.FormattingEnabled = true;
            this.cbCategoriaFilho.Location = new System.Drawing.Point(300, 37);
            this.cbCategoriaFilho.Name = "cbCategoriaFilho";
            this.cbCategoriaFilho.Size = new System.Drawing.Size(180, 21);
            this.cbCategoriaFilho.TabIndex = 1;
            this.cbCategoriaFilho.SelectedIndexChanged += new System.EventHandler(this.cbCategoriaFilho_SelectedIndexChanged);
            // 
            // FrmPesquisaProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 632);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmPesquisaProduto";
            this.Text = "Pesquisa Produto";
            this.Load += new System.EventHandler(this.FrmPesquisaProduto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPesquisaProduto_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbCategoriaPai;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cbCategoriaNeto;
        private System.Windows.Forms.ComboBox cbCategoriaFilho;
    }
}