using AirSystem2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirSystem2.Repositories
{
    public class UsuarioRepository
    {
        private static List<Usuario> usuarios;

        private static int contador = 1;

        public UsuarioRepository()
        {
            if (usuarios == null)
            {
                usuarios = new List<Usuario>();

                usuarios.Add(new Usuario
                {
                    codigo = 1,
                    Nome = "nome",
                    Sobrenome = "sobrenome"
                });
                contador++;
            }
        }
        public List<Usuario> buscarTodos()
        {
            return usuarios;
        }
        public void adicionar(Usuario usuario)
        {
            usuario.codigo = contador;

            usuarios.Add(usuario);
            contador++;
        }
        public void editar(Usuario usuario)
        {
            Usuario u = usuarios.Find(x => x.codigo == usuario.codigo);

            usuarios[usuarios.IndexOf(u)] = usuario;
        }

        public List<Usuario> BuscarTodos()
        {
            return usuarios;
        }

        public void deletar(int id)
        {
            Usuario usuario = usuarios.Find(b => b.Id == id);
            usuarios.Remove(usuario);
        }


    }
}
