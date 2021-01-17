using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfaceUsuario.Modulos
{
    public static class MascaraCampoCodigo
    {
        public static void RetornarMascara(object sender, EventArgs e)
        {
            // vai aplicar uma mascara para um campo
            TextBox txt = (TextBox)sender; /* Converteu o sender para um TextBox */
            if (txt.Text.Trim() == "")
                return;
            txt.Text = Int32.Parse(txt.Text).ToString("00000");
            // se eu digitar 1, vai ficar 00001
        }

        public static void TirarMascara(object sender, EventArgs e )
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text.Trim() == "")
                return;
            txt.Text = Int32.Parse(txt.Text.Trim()).ToString();
            txt.Focus();
            txt.Select(0, txt.Text.Length);
        }

        public static void ApenasNumeros(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back))
                e.Handled = true;
        }

        public static void AplicarEventos(TextBox txt)
        {
            txt.Enter += TirarMascara;
            txt.Leave += RetornarMascara;
            txt.KeyPress += ApenasNumeros;
        }
    }
}
