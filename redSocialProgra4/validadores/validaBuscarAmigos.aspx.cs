using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using redSocialProgra4.controladores;
using redSocialProgra4.modelos;

namespace redSocialProgra4.validadores
{
    public partial class validaBuscarAmigos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string nombre = Request["txtNombre"].ToString();
            controladorUsuario cu = new controladorUsuario();
            string mensaje = cu.validaBuscarAmigo(nombre);
            string[] aux = mensaje.Split('<');
            if (aux[0].Equals("exito"))
            {//buscar la lista porque si existe esa persona
                Usuario u = new Usuario();
                List<Usuario> lista = u.buscaTodosNombreApellido(aux[1], aux[2]);
                if (lista == null)
                {
                    Session["mensaje"] = "No hay coincidencia.";
                    Response.Redirect("../vistas/buscarAmigos.aspx");
                }
                else
                {
                    Session["lista"] = lista;
                    Response.Redirect("../vistas/buscarAmigos.aspx");
                }

            }
            else
            {
                //GG
                Session["mensaje"] = mensaje;
                Response.Redirect("index.aspx");
            }
        }
    }
}