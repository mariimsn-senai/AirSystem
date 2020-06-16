using AirSystem2.Models;
using AirSystem2.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirSystem2.Views
{
    public partial class frmListarUsuarios : Form
    {
        UsuarioRepository repository = new UsuarioRepository();
        public frmListarUsuarios()
        {
            InitializeComponent();
        }

        private void frmListarUsuarios_Load(object sender, EventArgs e)
        {
            carregaLista();
        }

        private void btnNovoLista_Click(object sender, EventArgs e)
        {
            new frmNovoUsuario().ShowDialog();
            carregaLista();
        }
        private void dgvListaUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow linha = dataGridView1.Rows[e.RowIndex];

            string nome = linha.Cells[1].Value.ToString();
            string sobrenome = linha.Cells[2].Value.ToString();

            int codigo = Convert.ToInt32(linha.Cells[0].Value.ToString());

            Usuario usuario = new Usuario
            {
                codigo = codigo,
                Nome = nome,
                Sobrenome = sobrenome,
            };

            new frmNovoUsuario(usuario).ShowDialog();

            carregaLista();
        }


        private void carregaLista()
        {
            UsuarioRepository repository = new UsuarioRepository();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = repository.buscarTodos();
            alterarContador();
        }
        private void filtroTextbox_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;

            // filtra as lista recebida do repositório, verificando se o nome, 
            // email, usuario, contém o que está no campo filtro.
            dataGridView1.DataSource = repository.buscarTodos().FindAll(x =>
                x.Nome.ToUpper().Contains(procurarBoxLista.Text.ToUpper()) ||
                x.Sobrenome.ToUpper().Contains(procurarBoxLista.Text.ToUpper())
            );

            alterarContador();

        }
        private void alterarContador()
        {
            procurarBoxLista.Text = $"{dataGridView1.RowCount} itens de {repository.buscarTodos().Count}";
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

        }

        private void lbl2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnVoltarLista_Click(object sender, EventArgs e)
        {

        }

        private void Listar()
        {
            UsuarioRepository rps = new UsuarioRepository();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = rps.buscarTodos();
            alterarContador();
        }


        private void btnDeletarLista_Click(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void btnDeletarLista_Click(object sender, EventArgs e)
        {

        }
  

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
