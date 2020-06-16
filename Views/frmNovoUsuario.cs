using AirSystem2.Models;
using AirSystem2.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirSystem2.Views
{
    public partial class frmNovoUsuario : Form
    {
        private Usuario usuario = null;
        public frmNovoUsuario()
        {
            InitializeComponent();
        }
        public frmNovoUsuario(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string pattern = "[A-Z]{1}[a-z]{1,}[0-9]{1,}";
            lblSenha.Visible = !Regex.IsMatch(textBox6.Text, pattern);
        }

        private void frmNovoUsuario_Load(object sender, EventArgs e)
        {
            textBox1.Text = usuario.Nome;
            textBox2.Text = usuario.Sobrenome;
            textBox4.Text = usuario.Endereco;
            dateTimePicker1.Value = usuario.DataNascimento;
            textBox5.Text = usuario.Usuarios;
            textBox5.Text = usuario.Senha;
            textBox6.Text = usuario.ConfirmarSenha;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!Utils.temCamposVazio(this))

            {
                UsuarioRepository repository = new UsuarioRepository();
                if (this.usuario == null)
                {
                    Usuario usuario = new Usuario
                    {
                        Id = 0,
                        Nome = textBox1.Text,
                        Sobrenome = textBox2.Text,
                        Endereco = textBox4.Text,
                        DataNascimento = dateTimePicker1.Value,
                        Usuarios = textBox5.Text,
                        Senha = textBox5.Text,
                        ConfirmarSenha = textBox6.Text,
                        IsAdmin = Convert.ToBoolean(checkBoxAdm.Checked)
                    };

                    repository.adicionar(usuario);


                    MessageBox.Show("Dados Salvos.",
                                    "Aviso", MessageBoxButtons.OK,
                                     MessageBoxIcon.Information);

                }
                else
                {
                    this.usuario.Id = 0;
                    this.usuario.Nome = textBox1.Text;
                    this.usuario.Sobrenome = textBox2.Text;
                    this.usuario.Endereco = textBox4.Text;
                    this.usuario.DataNascimento = dateTimePicker1.Value;
                    this.usuario.Usuarios = textBox5.Text;
                    this.usuario.Senha = textBox5.Text;
                    this.usuario.ConfirmarSenha = textBox6.Text;
                    this.usuario.IsAdmin = checkBoxAdm.Checked;

                    repository.editar(usuario);
                }
                this.Close();

            }
            else
            {   //Texto , Título, Botões, Ícone
                MessageBox.Show("Todos os campos são obrigatórios.",
                                "Aviso", MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
            }
        }
    }
}
