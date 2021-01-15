﻿using Entidades.Enumeradores;
using Negocio.Pessoas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfaceUsuario.Pessoas
{
    public partial class frmCadUsuarioAdd : Form
    {
        public frmCadUsuarioAdd()
        {
            InitializeComponent();
        }

        private void btnBscUsu_Click(object sender, EventArgs e)
        {

        }

        private void btnBscTipoUsu_Click(object sender, EventArgs e)
        {
            var lista = new UsuarioNG().ListarEntidasdessViewPesquisa(Status.Todos);
            
            if (lista.Count < 1)
            {
                MessageBox.Show("Sem dados para serem exibidos!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }
    }
}