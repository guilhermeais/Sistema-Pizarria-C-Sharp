using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfaceUsuario.Modulos
{
    public static class Funcoes
    {

        public static void ListViewColor(ListView lvl)
        {
            foreach (ListViewItem item in lvl.Items)
            {
                if ((item.Index % 2) == 0)
                    item.BackColor = System.Drawing.Color.White;
                else
                    item.BackColor = System.Drawing.Color.LightBlue;
            }
        }

        public static void SelecionarCampo(TextBox txtbox)
        {
            txtbox.Focus();
            txtbox.Select();
        }
    }
}
