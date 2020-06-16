using AirSystem2.Models;
using AirSystem2.Repositories;
using AirSystem2.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirSystem2
{
    public partial class frmLogin : Form
    {
       // private object textBox1;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new frmNovoUsuario().ShowDialog();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
                UsuarioRepository usuarioRepository = new UsuarioRepository();
                List<Usuario> usuarios = usuarioRepository.BuscarTodos();

                foreach (var item in usuarios)
                {
                    if (item.Usuarios == textBox1.Text && item.Senha == textBoxSenha.Text)
                    {
                        if (item.IsAdmin)
                        {

                            frmPagAdm frm = new frmPagAdm();
                            frm.Show();
                            this.WindowState = FormWindowState.Minimized;

                            if (textBox1.Text.Trim().Length == 0)
                            {
                                SystemSounds.Beep.Play();
                                MessageBox.Show("Digite o usuário.", "Erro");
                            }

                            else 
                            {
                                MessageBox.Show("Bem Vindo", "Entrada");
                                new frmListarUsuarios().ShowDialog();

                            }
                        } 
                        else
                        {
                            frmTelaPrincipalUsuario frm = new frmTelaPrincipalUsuario();
                            frm.Show();
                            this.WindowState = FormWindowState.Minimized;
                        }

                    }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
