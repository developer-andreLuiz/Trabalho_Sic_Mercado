using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercado.Interface
{
    /// <summary>
    /// Declaração e definição dos botões de interface
    /// </summary>
    class BotaoUI
    {

        public Button btnGravar;
        public Button btnAlterar;
        public Button btnCancelar;
        public Button btnNovo;

        public Button btnRetroceder;
        public Button btnRetroceder2x;
        public Button btnAvancar;
        public Button btnAvancar2x;

        /// <summary>
        /// Define a disponibilidade de botões ao clicar em Gravar
        /// </summary>
        public void UIBtnGravar()
        {
            btnNovo.Enabled = true;
            btnGravar.Enabled = false;
            btnAlterar.Enabled = true;
            btnCancelar.Enabled = false;
            btnRetroceder.Enabled = true;
            btnRetroceder2x.Enabled = true;
            btnAvancar.Enabled = true;
            btnAvancar2x.Enabled = true;

        }

        /// <summary>
        /// Define a disponibilidade de botões ao clicar em Alterar
        /// </summary>
        public void UIBtnAlterar()
        {
            btnNovo.Enabled = false;
            btnGravar.Enabled = true;
            btnAlterar.Enabled = false;
            btnCancelar.Enabled = true;
            btnRetroceder.Enabled = false;
            btnRetroceder2x.Enabled = false;
            btnAvancar.Enabled = false;
            btnAvancar2x.Enabled = false;

        }

        /// <summary>
        /// Define a disponibilidade de botões ao clicar em Cancelar
        /// </summary>
        public void UIBtnCancelar()
        {
            btnNovo.Enabled = true;
            btnGravar.Enabled = false;
            btnAlterar.Enabled = true;
            btnCancelar.Enabled = false;
            btnRetroceder.Enabled = true;
            btnRetroceder2x.Enabled = true;
            btnAvancar.Enabled = true;
            btnAvancar2x.Enabled = true;

        }

        /// <summary>
        /// Define a disponibilidade de botões ao clicar em Novo
        /// </summary>
        public void UIBtnNovo()
        {
            btnNovo.Enabled = false;
            btnGravar.Enabled = true;
            btnAlterar.Enabled = false;
            btnCancelar.Enabled = true;
            btnRetroceder.Enabled = false;
            btnRetroceder2x.Enabled = false;
            btnAvancar.Enabled = false;
            btnAvancar2x.Enabled = false;

        }

        /// <summary>
        /// Define a disposição dos botões ao abrir o formulãrio
        /// </summary>
        public void UIBtnOpenForm()
        {
            btnNovo.Enabled = true;
            btnGravar.Enabled = false;
            btnAlterar.Enabled = true;
            btnCancelar.Enabled = false;
            btnRetroceder.Enabled = true;
            btnRetroceder2x.Enabled = true;
            btnAvancar.Enabled = true;
            btnAvancar2x.Enabled = true;

        }



    }
}
