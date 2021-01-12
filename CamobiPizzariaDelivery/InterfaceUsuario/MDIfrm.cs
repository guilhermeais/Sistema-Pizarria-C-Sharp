using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            frmLogin login = new frmLogin();
            login.ShowDialog();
            if (!login.bFlagLogin) this.Close();
            
        }
    }
}
