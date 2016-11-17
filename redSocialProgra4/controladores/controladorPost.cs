using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using redSocialProgra4.modelos;

namespace redSocialProgra4.controladores
{
    public class controladorPost
    {
        public List<Post> controladorMiMuro(string correo)
        {
            Post p = new Post();
            List<Post> lista = p.miMuro(correo);
            if (lista.Count == 0)
            {
                p.Texto = "Su muro se encuentra vacio";
                lista.Add(p);
            }
            else
            {
                for (int i = 0; i < lista.Count; i++)
                {
                    Usuario u = new Usuario();
                    Usuario u2 = u.buscaUno(lista[i].Creador);
                    lista[i].NombreCreador = u2.Nombre + " " + u2.Apellido;
                }
            }
            return lista;
        }

        public List<Post> controladorMuroAmigo(string correo)
        {
            Post p = new Post();
            List<Post> lista = p.miMuro(correo);
            if (lista.Count == 0)
            {
                p.Texto = "El muro se encuentra vacío.";
                lista.Add(p);
            }
            else
            {
                for (int i = 0; i < lista.Count; i++)
                {
                    Usuario u = new Usuario();
                    Usuario u2 = u.buscaUno(lista[i].Creador);
                    lista[i].NombreCreador = u2.Nombre + " " + u2.Apellido;
                }
            }
            return lista;
        }

        public bool controlarPostMiMuro(string miComentario, string miCorreo)
        {
            Post p = new Post();
            p.Texto = miComentario;
            p.Receptor = miCorreo;
            p.Creador = miCorreo;
            p.TipoPost = 1;

            if (p.posteo(p))
            {
                return true;
            }else
            {
                return false;
            }
        }

        public bool controlarPostMuroAmigo(string miComentario, string miCorreo, string correoAmigo)
        {
            Post p = new Post();
            p.Texto = miComentario;
            p.Receptor = correoAmigo;
            p.Creador = miCorreo;
            p.TipoPost = 2;

            if (p.posteo(p))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}