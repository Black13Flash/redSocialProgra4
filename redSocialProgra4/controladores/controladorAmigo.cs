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
    }
}