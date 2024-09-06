using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFMulti
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa();
            List<Pessoa> pes = pessoa.listapessoa();
            dgvPessoa.DataSource = pes;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            this.ActiveControl = txtNome;
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "" || txtIdade.Text == "")

            {
                MessageBox.Show("Por favor preencha todos os campos", "Campos Obrigatórios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Pessoa pessoa = new Pessoa();
                if (pessoa.RegistroRepitido(txtNome.Text, txtIdade.Text))
                {
                    MessageBox.Show("Pessoa já existe na nossa base de dados", "Repetido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNome.Text = string.Empty;
                    txtIdade.Text = string.Empty;
                    return;
                }
                else
                {
                    pessoa.Inserir(txtNome.Text, txtIdade.Text);
                    MessageBox.Show("Pessoa Cadastrada com sucesso", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    List<Pessoa> pessoas = pessoa.listapessoa();
                    dgvPessoa.DataSource = pessoas;
                    txtNome.Text = string.Empty;
                    txtIdade.Text= string.Empty;
                    this.ActiveControl = txtNome;
                }
            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message);
            }

        }
    }
}