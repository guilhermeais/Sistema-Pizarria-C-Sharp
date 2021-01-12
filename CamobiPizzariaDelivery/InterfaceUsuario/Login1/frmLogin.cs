using Entidades.Sistema;
using Negocio.Pessoas;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace InterfaceUsuario.Log_in
{
    public partial class frmLogin : Form
    {
        public bool bFlagLogin;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //Colocar versão no lblVersao usando o versionamento semântico (assembly)
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            lblVersao.Text = string.Format(lblVersao.Text, version.Major, version.Minor, version.Build, version.Revision);
            CarregarUsuarios();
        }
        private void CarregarUsuarios()
        {
            var lista = new UsuarioNG().ListarUsuarios();
            if (lista.Count > 0 )
            {
                foreach (var i in lista)
                {
                    cmbUsuarios.Items.Add(new ComboBoxItemUsuario(i.Login, i.Codigo, i.Senha));
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (cmbUsuarios.Text.Trim() == "")
            {
                MessageBox.Show("Você deve selecionar um login para acessar o sistema!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtSenha.Text.Trim() == "")
            {
                MessageBox.Show("Você deve informar a senha do login para acessar o sistema!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var item = (ComboBoxItemUsuario)cmbUsuarios.SelectedItem;
            if (item.Senha != txtSenha.Text.Trim())
            {
                MessageBox.Show("Senha incorreta!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bFlagLogin = true;

            this.Close();
        }
    }
}
