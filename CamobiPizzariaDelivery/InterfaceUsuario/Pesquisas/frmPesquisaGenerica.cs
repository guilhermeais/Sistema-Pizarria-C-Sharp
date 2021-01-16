using Entidades.Entidades;
using Entidades.Enumeradores;
using InterfaceUsuario.Modulos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InterfaceUsuario.Pesquisas
{
    public partial class frmPesquisaGenerica : Form
    {
        public List<EntidadeViewPesquisa> lista = new List<EntidadeViewPesquisa>();
        public int iRetorno = 0;

        public frmPesquisaGenerica(string strTitulo, Status status)
        {
            InitializeComponent();

            this.Text = strTitulo;
            if (status == Status.Ativo)
                rdbAtivos.Checked = true;
            else if (status == Status.Inativo)
                rdbInativos.Checked = true;
            else
                rdbTodos.Checked = true;
        }

        private void frmPesquisaGenerica_Load(object sender, System.EventArgs e)
        {
            var form = new Form() {
                FormBorderStyle = FormBorderStyle.None,
                ShowInTaskbar = false,
                StartPosition = FormStartPosition.CenterScreen,
                TopMost = true,
                Top = 0,
                Left = 0
            };
            PreencherLista(lista);
        }

        private void PreencherLista(List<EntidadeViewPesquisa> list)
        {
            lvlListagem.Clear();
            lvlListagem.View = View.Details;

            lvlListagem.Columns.Add("Código", 80, HorizontalAlignment.Right);
            lvlListagem.Columns.Add("Descrição", 280, HorizontalAlignment.Left);

            foreach (var item in list)
            {
                if (!rdbTodos.Checked)
                {
                    if (rdbAtivos.Checked && item.Status != Entidades.Enumeradores.Status.Ativo)
                        continue;
                    else if (rdbAtivos.Checked && item.Status != Entidades.Enumeradores.Status.Inativo)
                        continue;
                }
                var linha = new string[2];
                linha[0] = item.Codigo.ToString();
                linha[1] = item.Descricao;
                var itemX = new ListViewItem(linha);
                lvlListagem.Items.Add(itemX);
            }
            Funcoes.ListViewColor(lvlListagem);
        }
    }
}
