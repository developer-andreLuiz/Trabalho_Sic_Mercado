namespace Mercado.Formularios
{
    partial class FrmNavegadorXml
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
            this.btnSite1 = new System.Windows.Forms.Button();
            this.btnRecarregar = new System.Windows.Forms.Button();
            this.btnRetroceder = new System.Windows.Forms.Button();
            this.btnAvancar = new System.Windows.Forms.Button();
            this.lblUrl = new System.Windows.Forms.Label();
            this.btnTesteInternet = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnSite1
            // 
            this.btnSite1.Location = new System.Drawing.Point(12, 12);
            this.btnSite1.Name = "btnSite1";
            this.btnSite1.Size = new System.Drawing.Size(75, 23);
            this.btnSite1.TabIndex = 0;
            this.btnSite1.Text = "Servidor 1";
            this.btnSite1.UseVisualStyleBackColor = true;
            this.btnSite1.Click += new System.EventHandler(this.btnSite1_Click);
            // 
            // btnRecarregar
            // 
            this.btnRecarregar.Location = new System.Drawing.Point(478, 12);
            this.btnRecarregar.Name = "btnRecarregar";
            this.btnRecarregar.Size = new System.Drawing.Size(75, 23);
            this.btnRecarregar.TabIndex = 4;
            this.btnRecarregar.Text = "Recarregar";
            this.btnRecarregar.UseVisualStyleBackColor = true;
            this.btnRecarregar.Click += new System.EventHandler(this.btnRecarregar_Click);
            // 
            // btnRetroceder
            // 
            this.btnRetroceder.Location = new System.Drawing.Point(378, 12);
            this.btnRetroceder.Name = "btnRetroceder";
            this.btnRetroceder.Size = new System.Drawing.Size(44, 23);
            this.btnRetroceder.TabIndex = 5;
            this.btnRetroceder.Text = "<<";
            this.btnRetroceder.UseVisualStyleBackColor = true;
            this.btnRetroceder.Click += new System.EventHandler(this.btnRetroceder_Click);
            // 
            // btnAvancar
            // 
            this.btnAvancar.Location = new System.Drawing.Point(428, 12);
            this.btnAvancar.Name = "btnAvancar";
            this.btnAvancar.Size = new System.Drawing.Size(44, 23);
            this.btnAvancar.TabIndex = 6;
            this.btnAvancar.Text = ">>";
            this.btnAvancar.UseVisualStyleBackColor = true;
            this.btnAvancar.Click += new System.EventHandler(this.btnAvancar_Click);
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.BackColor = System.Drawing.SystemColors.Control;
            this.lblUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUrl.Location = new System.Drawing.Point(9, 549);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(89, 13);
            this.lblUrl.TabIndex = 7;
            this.lblUrl.Text = "www.google.com";
            // 
            // btnTesteInternet
            // 
            this.btnTesteInternet.Location = new System.Drawing.Point(615, 12);
            this.btnTesteInternet.Name = "btnTesteInternet";
            this.btnTesteInternet.Size = new System.Drawing.Size(88, 23);
            this.btnTesteInternet.TabIndex = 10;
            this.btnTesteInternet.Text = "Teste Internet";
            this.btnTesteInternet.UseVisualStyleBackColor = true;
            this.btnTesteInternet.Click += new System.EventHandler(this.btnTesteInternet_Click);
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.Location = new System.Drawing.Point(12, 41);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(732, 505);
            this.panel.TabIndex = 11;
            // 
            // FrmNavegadorXml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(756, 571);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.btnTesteInternet);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.btnAvancar);
            this.Controls.Add(this.btnRetroceder);
            this.Controls.Add(this.btnRecarregar);
            this.Controls.Add(this.btnSite1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "FrmNavegadorXml";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Download NF-e Navegador";
            this.Load += new System.EventHandler(this.FrmNavegadorXml_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSite1;
        private System.Windows.Forms.Button btnRecarregar;
        private System.Windows.Forms.Button btnRetroceder;
        private System.Windows.Forms.Button btnAvancar;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.Button btnTesteInternet;
        private System.Windows.Forms.Panel panel;
    }
}