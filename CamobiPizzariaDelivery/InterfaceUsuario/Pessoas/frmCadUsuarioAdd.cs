using Entidades.Enumeradores;
using InterfaceUsuario.Pesquisas;
using Negocio.Pessoas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using InterfaceUsuario.Modulos;
using System.Windows.Forms;
using Entidades.Pessoas;
using Entidades.Sistema;

namespace InterfaceUsuario.Pessoas
{
    public partial class frmCadUsuarioAdd : Form
    {
        private bool Novo;

        public frmCadUsuarioAdd()
        {
            InitializeComponent();
            MascaraCampoCodigo.AplicarEventos(txtCodUsu);
            MascaraCampoCodigo.AplicarEventos(txtCodTipoUsu);
        }

        private void btnBscTipoUsu_Click(object sender, EventArgs e)
        {
            var lista = new TipoUsuarioNG().ListarEntidasdessViewPesquisa();

            if (lista.Count < 1)
            {
                MessageBox.Show("Sem dados para serem exibidos!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var frmPesquisa = new frmPesquisaGenerica("Listagem de Tipos de Usuários", Status.Todos);
            frmPesquisa.lista = lista;
            frmPesquisa.ShowDialog();

            var iRetorno = frmPesquisa.iRetorno;
            if (iRetorno < 1) return;

            txtCodTipoUsu.Text = iRetorno.ToString();
            txtCodTipoUsu_Validating(txtCodTipoUsu, new CancelEventArgs());
            MascaraCampoCodigo.RetornarMascara(txtCodTipoUsu, new EventArgs());
            btnBscTipoUsu.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            this.Close();
        }

        private void btnBscUsu_Click(object sender, EventArgs e)
        {
            var lista = new UsuarioNG().ListarEntidasdessViewPesquisa(Status.Todos);

            if (lista.Count < 1)
            {
                MessageBox.Show("Sem dados para serem exibidos!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var frmPesquisa = new frmPesquisaGenerica("Listagem de Usuários", Status.Todos);
            frmPesquisa.lista = lista;
            frmPesquisa.ShowDialog();

            var iRetorno = frmPesquisa.iRetorno;
            if (iRetorno < 1) return;

            txtCodUsu.Text = iRetorno.ToString();
            txtCodUsu_Validating(txtCodUsu, new CancelEventArgs());
            btnBscUsu.Focus();

        }

        private void txtCodUsu_Validating(object sender, CancelEventArgs e)
        {
            if (txtCodUsu.Text.Trim() == "") 
                return;

            var usu = new UsuarioNG().Buscar(int.Parse(txtCodUsu.Text.Trim()));
            if(usu == null)
            {
                btnExluir.Enabled = false;
                return;
            }

            Novo = false;
            txtNomeUsu.Text = usu.Nome;
            txtLoginUsu.Text = usu.Login;
            txtSenhaUsu.Text = usu.Senha;
            txtCodTipoUsu.Text = usu.TipoUsuario.Codigo.ToString();

            txtCodTipoUsu_Validating(txtCodTipoUsu, new CancelEventArgs());
            MascaraCampoCodigo.RetornarMascara(txtCodUsu, new EventArgs());
            MascaraCampoCodigo.RetornarMascara(txtCodTipoUsu, new EventArgs());

            ucStatus.IncialiarSituacao(usu.Status);
            btnExluir.Enabled = true;

        }

        public void LimparCampos()
        {
            txtCodUsu.Text = new UsuarioNG().BuscarProximoCodigo().ToString();
            txtNomeUsu.Text = "";
            txtLoginUsu.Text = "";
            txtSenhaUsu.Text = "";
            txtCodTipoUsu.Text = "";
            lblTipoUsuario.Text = "";
            btnExluir.Enabled = false;
            ucStatus.IncialiarSituacao(Status.Ativo);
            MascaraCampoCodigo.RetornarMascara(txtCodUsu, new EventArgs());
            MascaraCampoCodigo.RetornarMascara(txtCodTipoUsu, new EventArgs());
            Novo = true;
            Funcoes.SelecionarCampo(txtNomeUsu);
        }

        private void frmCadUsuarioAdd_Load(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnExluir_Click(object sender, EventArgs e)
        {

        }

        private bool VerificarCampos()
        {
            if (txtNomeUsu.Text.Trim() == "")
            {
                MessageBox.Show("Você precisa informar o nome do usuário!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtLoginUsu.Text.Trim() == "")
            {
                MessageBox.Show("Você precisa informar o login do usuário!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtSenhaUsu.Text.Trim() == "")
            {
                MessageBox.Show("Você precisa informar a senha do usuário!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtCodTipoUsu.Text.Trim() == "")
            {
                MessageBox.Show("Você precisa informar o tipo do usuário!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!VerificarCampos())
                return;
            var usuario = new Usuario();
            var usuarioNG = new UsuarioNG();
            usuario.Nome = txtNomeUsu.Text.Trim();
            usuario.Login = txtLoginUsu.Text.Trim();
            usuario.Senha = txtSenhaUsu.Text.Trim();
            usuario.TipoUsuario.Codigo = int.Parse(txtCodUsu.Text.Trim());
            usuario.Status = ucStatus._status;
            usuario.CodigoUsrAlteracao = Sessao.Usuario.Codigo;
            if (Novo)
            {
               if (usuarioNG.Inserir(usuario))
                {
                    MessageBox.Show("Usuário cadastrado com sucesso!",this.Text ,MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Falha ao inserir o usuário! Tente novamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {

            }
        }

        private void txtCodTipoUsu_Validating(object sender, CancelEventArgs e)
        {
            if (txtCodTipoUsu.Text.ToString() == "")
            {
                lblTipoUsuario.Text = "";
                return;
            }
            var oTipoUsuario = new TipoUsuarioNG().Buscar(int.Parse(txtCodTipoUsu.Text.Trim()));
            if(oTipoUsuario == null)
            {
                MessageBox.Show("Tipo de Usuário não encontrado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodTipoUsu.Select();
                return;
            }
            lblTipoUsuario.Text = oTipoUsuario.Descricao;
        }
    }
}
