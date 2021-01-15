using System;
using System.Windows.Forms;
using InterfaceUsuario.Log_in;

namespace InterfaceUsuario
{
    public partial class MDIfrm : Form
    {
        public MDIfrm()
        {
            InitializeComponent();
        }

        private void MDIfrm_Load(object sender, EventArgs e)
        {
            foreach (Control control in Controls)
            {
                if (control is MdiClient)
                {
                    control.BackgroundImage = Properties.Resources.fundo;
                    control.BackgroundImageLayout = ImageLayout.Zoom;
                    break;
                }              
            }

            mnsStripPrincipal.Visible = false;
           
            frmLogin login = new frmLogin();
            login.ShowDialog();
            if (!login.bFlagLogin) this.Close();

            mnsStripPrincipal.Visible = true;
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AbrirFormularios(Form form)
        {
            form.WindowState = FormWindowState.Normal;
            form.StartPosition = FormStartPosition.CenterParent
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
