using Entidades.Enumeradores;
using System;
using System.Windows.Forms;

namespace InterfaceUsuario.UserControls
{
    public partial class ucStatus : UserControl
    {
        public Status _status;  
        public ucStatus()
        {
            InitializeComponent();
        }

        private void ucStatus_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            IncialiarSituacao(Status.Ativo);
        }

        public void IncialiarSituacao(Status status)
        {
            if (DesignMode) return;
            _status = status;
            if (status == Status.Ativo)
                rdbAtivo.Checked = true;
            else
                rdbDesativo.Checked = true;
        }

        private void rdbAtivo_CheckedChanged(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (rdbAtivo.Checked)
            {
                _status = Status.Ativo;   
            }
            
        }

        private void rdbDesativo_CheckedChanged(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (rdbDesativo.Checked)
            {
                _status = Status.Inativo;
            }
        }
    }
}
