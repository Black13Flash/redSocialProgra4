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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["correo"] != null)
            {
                // INI MI POST
                if (Request["miPost"] != null)
                {
                    string comentario = Request["miPost"];

                    //Response.Write("<h1>"+comentario+"</h1>");
                    controladorPost miPost = new controladorPost();
                    miPost.controlarPostMiMuro(comentario,Session["correo"].ToString());
                }
                // FIN MI POST
                
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
                Response.Write("<p><a href='index.aspx'>"+nombre+" "+apellido+"</a></p>");
                Response.Write("</div>");
                Response.Write("<div id='barra-notis'>");
                Response.Write("<div id='barra-notis-amistad'>");
                //Response.Write("<span id='iconoAmigos'></span>");
                Solicitud notis = new Solicitud();
                int cantSolicitud = notis.cantidadSolicitud(correo);
                Response.Write("<a href='index.aspx?notificaciones=Amistad'><span id='iconoAmigos'><p id='p-soli'>"+cantSolicitud+"</p></span></a>");
                Response.Write("</div>");
                Response.Write("<div id='barra-notis-notis'>");
                //NOTIS
                Notificacion notis2 = new Notificacion();
                int cantNotis = notis2.cantidadSolicitud(correo);
                Response.Write("<a href='index.aspx'><span id='iconoNotis'><p id='p-noti'>"+cantNotis+"</p></span></a>");
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
                        Response.Write("<td class='td-nom'><a href='amigo.aspx?perfil="+a.Correo+"'>"+a.Nombre+" "+a.Apellido+"</a></td>");
                        Response.Write("</tr>");
                    }

                    Response.Write("</table>");
                }
                Response.Write("</div>");
                //AREA CAMBIANTE
                Response.Write("<div id='der'>");
                // INI AREA TRABAJO

                if (Request["notificaciones"] != null)
                {
                    if (Request["notificaciones"].Equals("Amistad"))
                    {
                        //Response.Write("<h1>VER NOTIFICACIONES DE AMISTAD</h1>");
                        Solicitud s = new Solicitud();
                        List<Solicitud> listaSolicitudes = s.notificaciones(correo);

                        if (listaSolicitudes.Count > 0)
                        {
                            List<Solicitud> listaParaVisto = new List<Solicitud>();

                            Response.Write("<table>");

                            foreach (Solicitud ss in listaSolicitudes)
                            {
                                Response.Write("<tr><td>" + ss.IdSolicitud + "</td><td>" + ss.Emisor + "</td><td>" + ss.Receptor + "</td><td>" + ss.TipoEstado + "</td><td><a href='../validadores/validaConfirmarAmistad.aspx?Aceptar=1&Amigo=" + ss.Emisor + "&id=" + ss.IdSolicitud + "'>Aceptar Amistad</a></td><td><a href='../validadores/validaConfirmarAmistad.aspx?Aceptar=0&Amigo=" + ss.Emisor + "&id=" + ss.IdSolicitud + "'>Rechazar Amistad</a></td></tr>");

                                Solicitud sss = new Solicitud();
                                sss.IdSolicitud = ss.IdSolicitud;
                                listaParaVisto.Add(sss);
                            }

                            if (s.actualizarTodoVisto(listaParaVisto,correo))
                            {

                            }

                            Response.Write("</table>");
                        }else
                        {
                            Response.Write("<center><h1>No tienes ninguna solicitud de amistad</h1></center>");
                        }
                        
                    }

                }
                else
                {
                    Response.Write("<div id='mi-post'>");
                    Response.Write("<div id='post-principal'>");
                    Response.Write("<form action='index.aspx' method='POST'>");
                    Response.Write("<textarea id='miPost' name='miPost' class='areaMiPost' placeholder='Agrega un comentario...'></textarea></br>");
                    Response.Write("<input type='submit' class='btn-post' value='Actualizar' name='btnActualizar' />");
                    Response.Write("</form>");
                    Response.Write("</div>");
                    controladorPost cp = new controladorPost();
                    List<Post> lista = cp.controladorMiMuro(Session["correo"].ToString());

                    List<Notificacion> listaNotiParaVisto = new List<Notificacion>();

                    if (lista[0].Texto.Equals("Su muro se encuentra vacio"))
                    {
                        Response.Write(lista[0].Texto);
                    }
                    else
                    {
                        Response.Write("<table border='1px'>");
                        Response.Write("<tr><td>Creador</td><td>Comentario</td><td>Fecha</td></tr>");
                        for (int i = 0; i < lista.Count; i++)
                        {
                            Response.Write("<tr><td><a href='amigo.aspx?perfil=" + lista[i].Creador + "'>" + lista[i].NombreCreador + "</a></td><td>" + lista[i].Texto + "</td><td>" + lista[i].Fecha + "</td></tr>");
                            Notificacion nose = new Notificacion();
                            nose.IdPost = lista[i].IdPost;
                            listaNotiParaVisto.Add(nose);
                        }

                        Notificacion asd = new Notificacion();
                        if (asd.actualizarTodoVisto(listaNotiParaVisto,correo))
                        {

                        }

                        Response.Write("</table>");
                    }
                    Response.Write("</div>");
                    // FIN AREA TRABAJO
                    Response.Write("</div>");
                    Response.Write("</div>");
                    Response.Write("</div>");
                    Response.Write("</div>");
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