using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mercado.Funcoes;

using CefSharp;
using CefSharp.WinForms;
using CefSharp.WinForms.Internals;

namespace Mercado.Formularios
{
    public partial class FrmNavegadorXml : Form
    {
        Internet internet = new Internet();
        ChromiumWebBrowser chrome;

        public FrmNavegadorXml()
        {
            InitializeComponent();
        }

        private void btnSite1_Click(object sender, EventArgs e)
        {
          chrome.Load("www.fsist.com.br/");
        }

        private void btnRetroceder_Click(object sender, EventArgs e)
        {
            try
            {
                chrome.Back();
            }
            catch
            {

            }
        }

        private void btnAvancar_Click(object sender, EventArgs e)
        {
            try
            {
                chrome.Forward();
            }
            catch
            {

            }
        }

        private void btnRecarregar_Click(object sender, EventArgs e)
        {
            chrome.Refresh();
        }

        private void btnTesteInternet_Click(object sender, EventArgs e)
        {
            try
            {
                if (internet.TesteInternet())
                {
                    MessageBox.Show("Conexão com a Internet LIGADA", "Internet OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Conexão com a Internet DESLIGADA", "Sem Internet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Sem Conexão com a Internet", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmNavegadorXml_Load(object sender, EventArgs e)
        {
            try
            {
                CefSettings setting = new CefSettings();
                Cef.Initialize(setting);
            }
            catch
            {

            }
          

            chrome = new ChromiumWebBrowser("www.fsist.com.br/");
            this.panel.Controls.Add(chrome);
            chrome.Dock = DockStyle.Fill;
            chrome.AddressChanged += Chrome_AddressChanged;
        }
        private void Chrome_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                lblUrl.Text = e.Address;
            }));
        }

      
    }
}
