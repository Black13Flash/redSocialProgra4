﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using redSocialProgra4.modelos;
using redSocialProgra4.controladores;

namespace redSocialProgra4.vistas
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["correo"] != null)
            {
                string correo = Session["correo"].ToString();
                string nombre = Session["nombre"].ToString();
                string apellido = Session["apellido"].ToString();
                //Response.Write("<h1>Bienvenido " + nombre + " " + apellido + "</h1>");

                Response.Write("<!--BARRA PRINCIPAL-->");
                Response.Write("<div id='barra'>");
                Response.Write("<div id='sesenta'>");
                Response.Write("<div id='barra-logo'>");
                Response.Write("<span>");
                Response.Write("</span>");
                Response.Write("</div>");
                Response.Write("<div id='barra-search'>");
                Response.Write("<form id='form1' action='../validadores/validaBuscarAmigos.aspx' method='POST'>");
                Response.Write("<div>");
                Response.Write("<input type='text' name='txtNombre' Width='207px' placeholder='Busca amigos...'>");
                Response.Write("<input type='submit' ID='Button1' Text='Buscar' value='Buscar' PostBackUrl='../validadores/validaBuscarAmigos.aspx' />");
                Response.Write("</div>");
                Response.Write("</form>");
                Response.Write("</div>");
                Response.Write("<div id='barra-perso'>");
                Response.Write("<!-- NOMBRE DEL PERSONAJE -->");
                Response.Write("<p><a href='#'>"+nombre+" "+apellido+"</a></p>");
                Response.Write("</div>");
                Response.Write("<div id='barra-notis'>");
                Response.Write("<div id='barra-notis-amistad'>");
                Response.Write("<span id='iconoAmigos'></span>");
                Response.Write("</div>");
                Response.Write("<div id='barra-notis-notis'>");
                Response.Write("<span id='iconoNotis'></span>");
                Response.Write("</div>");
                Response.Write("<p><a href='#'>Salir</a></p>");
                Response.Write("</div>");
                Response.Write("</div>");
                Response.Write("</div>");
                //DESPUES DE LA BARRA
                Response.Write("<div id='caja'>");
                Response.Write("<div id='contenido'>");
                Response.Write("<div id='cont-top'>");
                Response.Write("<div id='cont-top-left'>");
                Response.Write("<img class='fotoPerfil' src='../img/user.png' />");
                Response.Write("</div>");
                Response.Write("<div id='cont-top-rigth'>");
                Response.Write("<p>"+nombre+" "+apellido+"</p>");
                Response.Write("</div>");
                Response.Write("</div>");
                Response.Write("<div id='cont-bottom'>");
                //AMIGOS
                controladorAmigo ca = new controladorAmigo();
                List<Usuario> listaAmigos = ca.mostrarAmigos2(correo);
                Response.Write("<div id='izq'>");
                Response.Write("<p class='tit-amigo'>"+listaAmigos.Count+" Amigo(s)</p>");
                if (listaAmigos != null)
                {
                    Response.Write("<table id='tablaAmigos'>");
                    

                    foreach (Usuario a in listaAmigos)
                    {
                        //Response.Write(a.Usuario2);
                        Response.Write("<tr>");
                        Response.Write("<td class='td-img'></td>");
                        Response.Write("<td class='td-nom'><a href='#'>"+a.Nombre+" "+a.Apellido+"</a></td>");
                        Response.Write("</tr>");
                    }

                    Response.Write("</table>");
                }
                Response.Write("</div>");
                //AREA CAMBIANTE
                Response.Write("<div id='der'>");
                Response.Write("</div>");
                Response.Write("</div>");
                Response.Write("</div>");
                Response.Write("</div>");
            }
            else
            {
                Session["mensaje"] = "debe realizar login";
                Response.Redirect("loginRegistrar.aspx");
            }
        }
    }
}