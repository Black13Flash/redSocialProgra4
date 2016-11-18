using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using redSocialProgra4.modelos;
using redSocialProgra4.controladores;

namespace redSocialProgra4.vistas
{
    public partial class buscarAmigos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["correo"] != null)
            {
                if(Request["txtNombre"] != null && (Request["txtNombre"].Length > 3))
                {
                    controladorUsuario cu = new controladorUsuario();
                    


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
                    //Response.Write("<form id='form1' action='../validadores/validaBuscarAmigos.aspx' method='POST'>");
                    Response.Write("<form id='form1' action='../vistas/buscarAmigos.aspx' method='POST'>");
                    Response.Write("<div>");
                    Response.Write("<input type='text' name='txtNombre' Width='207px' placeholder='Busca amigos...'>");
                    Response.Write("<input type='submit' ID='Button1' Text='Buscar' value='Buscar' PostBackUrl='../validadores/validaBuscarAmigos.aspx' />");
                    Response.Write("</div>");
                    Response.Write("</form>");
                    Response.Write("</div>");
                    Response.Write("<div id='barra-perso'>");
                    Response.Write("<!-- NOMBRE DEL PERSONAJE -->");
                    Response.Write("<p><a href='#'>" + nombre + " " + apellido + "</a></p>");
                    Response.Write("</div>");
                    Response.Write("<div id='barra-notis'>");
                    Response.Write("<div id='barra-notis-amistad'>");
                    //Response.Write("<span id='iconoAmigos'></span>");
                    Solicitud notis = new Solicitud();
                    int cantSolicitud = notis.cantidadSolicitud(correo);
                    Response.Write("<a href='index.aspx?notificaciones=Amistad'><span id='iconoAmigos'><p>" + cantSolicitud + "</p></span></a>");
                    Response.Write("</div>");
                    Response.Write("<div id='barra-notis-notis'>");
                    Response.Write("<span id='iconoNotis'></span>");
                    Response.Write("</div>");
                    Response.Write("<p><a href='cerrarSesion.aspx'>Salir</a></p>");
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
                    Response.Write("<p>" + nombre + " " + apellido + "</p>");
                    Response.Write("</div>");
                    Response.Write("</div>");
                    Response.Write("<div id='cont-bottom'>");
                    //AMIGOS
                    controladorAmigo ca = new controladorAmigo();
                    List<Usuario> listaAmigos = ca.mostrarAmigos2(correo);
                    Response.Write("<div id='izq'>");
                    Response.Write("<p class='tit-amigo'>" + listaAmigos.Count + " Amigo(s)</p>");
                    if (listaAmigos != null)
                    {
                        Response.Write("<table id='tablaAmigos'>");


                        foreach (Usuario a in listaAmigos)
                        {
                            //Response.Write(a.Usuario2);
                            Response.Write("<tr>");
                            Response.Write("<td class='td-img'></td>");
                            Response.Write("<td class='td-nom'><a href='amigo.aspx?perfil="+a.Correo+"'>" + a.Nombre + " " + a.Apellido + "</a></td>");
                            Response.Write("</tr>");
                        }

                        Response.Write("</table>");
                    }
                    Response.Write("</div>");
                    //AREA CAMBIANTE
                    Response.Write("<div id='der'>");
                    // INI AREA TRABAJO
                    Response.Write("<div id='mi-busqueda'>");

                    controladorUsuario cuu = new controladorUsuario();

                    string nomCompleto = Request["txtNombre"].ToString();
                    string nom = nomCompleto.Split(' ')[0];
                    string ape = nomCompleto.Split(' ')[1];

                    string[] encontrados = cuu.buscaPersonas(correo, nom, ape).Split('>');

                    if (encontrados.Length <= 1)
                    {
                        Response.Write("<h1>No se encontraron coincidencias</h1>");
                    }else
                    {
                        Response.Write("<table>");
                        for (int i = 1; i < encontrados.Length; i++)
                        {
                            string correo2 = encontrados[i].Split('+')[0];
                            string nombre2 = encontrados[i].Split('+')[1];
                            string apellido2 = encontrados[i].Split('+')[2];
                            string boton = encontrados[i].Split('+')[3];

                            //Response.Write("<p>" + correo2 + " " + nombre2 + " " + apellido2 + " "+boton+"</p></br>");
                            if (boton == "0")
                            {
                                Response.Write("<tr><td>" + nombre2 + " " + apellido2 + "</td><td><a href='amigo.aspx?enviarSolicitud=" + correo2 + "'>Enviar Solicitud de Amistad</a></td></tr>");
                            }else
                            {
                                Response.Write("<tr><td>" + nombre2 + " " + apellido2 + "</td><td><a href='amigo.aspx?revocarSolicitud=" + correo2 + "'>Eliminar Amistad</a></td></tr>");
                            }
                            
                        }
                        Response.Write("</table>");
                    }
                    
                    

                    Response.Write("</div>");
                    // FIN AREA TRABAJO
                    Response.Write("</div>");
                    Response.Write("</div>");
                    Response.Write("</div>");
                    Response.Write("</div>");
                }else
                {
                    Response.Redirect("index.aspx");
                }
            }
            else
            {
                Session["mensaje"] = "debe realizar login";
                Response.Redirect("loginRegistrar.aspx");
            }
        }
    }
}