using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using redSocialProgra4.modelos;

namespace redSocialProgra4.controladores
{
    public class controladorAmigo
    {
        public List<Amigo> mostrarAmigos(string usuario1)
        {
            Amigo a = new Amigo();
            List<Amigo> lista = a.amigosHechos(usuario1);

            if (lista != null)
            {
                return lista;
            }
            else
            {
                return null;
            }
        }

        public List<Usuario> mostrarAmigos2(string usuario1)
        {
            Amigo a = new Amigo();
            List<Amigo> lista = a.amigosHechos(usuario1);

            if (lista != null)
            {
                List<Usuario> amigos = new List<Usuario>();

                foreach (Amigo amg in lista)
                {
                    Usuario u2 = new Usuario();
                    u2 = u2.buscaUno(amg.Usuario2);
                    amigos.Add(u2);
                }
                return amigos;
            }
            else
            {
                return null;
            }
        }
    }
}