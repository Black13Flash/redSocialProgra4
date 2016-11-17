using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using redSocialProgra4.controladores;
using redSocialProgra4.modelos;

namespace redSocialProgra4.vistas
{
    public partial class amigo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["correo"] != null)
            {
                if (Request["enviarSolicitud"] != null || Request["revocarSolicitud"] != null)
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
                    Response.Write("<form id='form1' action='../vistas/buscarAmigos.aspx' method='POST'>");
                    Response.Write("<div>");
                    Response.Write("<input type='text' name='txtNombre' Width='207px' placeholder='Busca amigos...'>");
                    Response.Write("<input type='submit' ID='Button1' Text='Buscar' value='Buscar' PostBackUrl='../validadores/validaBuscarAmigos.aspx' />");
                    Response.Write("</div>");
                    Response.Write("</form>");
                    Response.Write("</div>");
                    Response.Write("<div id='barra-perso'>");
                    Response.Write("<!-- NOMBRE DEL PERSONAJE -->");
                    Response.Write("<p><a href='index.aspx'>" + nombre + " " + apellido + "</a></p>");
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
                    Response.Write("<div id='caja-amigo'>");

                    //ENVIAR SOLICITUD
                    if (Request["enviarSolicitud"] != null)
                    {
                        Solicitud s = new Solicitud();
                        s.Emisor = correo;
                        s.Receptor = Request["enviarSolicitud"].ToString();
                        s.TipoEstado = 1;

                        if (s.enviarSolicitud(s))
                        {
                            Response.Write("<center><h1>Se envió la solicitud de amistad</h1></center>");
                        }else
                        {
                            Response.Write("<center><h1>Ocurrió un error al enviar la solicitud</h1></center>");
                        }
                    }


                    Response.Write("</div>");
                    // FIN AREA TRABAJO
                    Response.Write("</div>");
                    Response.Write("</div>");
                    Response.Write("</div>");
                    Response.Write("</div>");
                }
                else
                {
                    if (Request["perfil"] != null)
                    {
                        string correoPerfil = Request["perfil"].ToString();

                        if (correoPerfil.Trim() != "")
                        {
                            if (correoPerfil == Session["correo"].ToString())
                            {
                                Response.Redirect("index.aspx");
                            }
                            else
                            {
                                // BUSCAR USUARIO
                                Usuario uP = new Usuario();
                                uP = uP.buscaUno(correoPerfil);

                                string correo = Session["correo"].ToString();
                                string nombre = Session["nombre"].ToString();
                                string apellido = Session["apellido"].ToString();

                                string correoP = uP.Correo;
                                string nombreP = uP.Nombre;
                                string apellidoP = uP.Apellido;
                                //Response.Write("<h1>Bienvenido " + nombre + " " + apellido + "</h1>");

                                Response.Write("<!--BARRA PRINCIPAL-->");
                                Response.Write("<div id='barra'>");
                                Response.Write("<div id='sesenta'>");
                                Response.Write("<div id='barra-logo'>");
                                Response.Write("<span>");
                                Response.Write("</span>");
                                Response.Write("</div>");
                                Response.Write("<div id='barra-search'>");
                                Response.Write("<form id='form1' action='../vistas/buscarAmigos.aspx' method='POST'>");
                                Response.Write("<div>");
                                Response.Write("<input type='text' name='txtNombre' Width='207px' placeholder='Busca amigos...'>");
                                Response.Write("<input type='submit' ID='Button1' Text='Buscar' value='Buscar' PostBackUrl='../validadores/validaBuscarAmigos.aspx' />");
                                Response.Write("</div>");
                                Response.Write("</form>");
                                Response.Write("</div>");
                                Response.Write("<div id='barra-perso'>");
                                Response.Write("<!-- NOMBRE DEL PERSONAJE -->");
                                Response.Write("<p><a href='index.aspx'>" + nombre + " " + apellido + "</a></p>");
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
                                Response.Write("<p>" + nombreP + " " + apellidoP + "</p>");
                                Response.Write("</div>");
                                Response.Write("</div>");
                                Response.Write("<div id='cont-bottom'>");
                                //AMIGOS
                                controladorAmigo ca = new controladorAmigo();
                                List<Usuario> listaAmigos = ca.mostrarAmigos2(correoP);
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
                                        Response.Write("<td class='td-nom'><a href='amigo.aspx?perfil=" + a.Correo + "'>" + a.Nombre + " " + a.Apellido + "</a></td>");
                                        Response.Write("</tr>");
                                    }

                                    Response.Write("</table>");
                                }
                                Response.Write("</div>");
                                //AREA CAMBIANTE
                                Response.Write("<div id='der'>");
                                // INI AREA TRABAJO
                                Response.Write("<div id='caja-amigo'>");

                                // Validar si son amigos
                                controladorUsuario ccuu = new controladorUsuario();

                                Response.Write("<div id='caja-amigo-perfil'>");
                                if (ccuu.sonAmigos(correo,correoP))
                                {
                                    //Response.Write("<h1>son amigis</h1>");
                                    //Mostrar posts

                                    // INI MI POST
                                    if (Request["miPost"] != null)
                                    {
                                        string comentario = Request["miPost"];

                                        //Response.Write("<h1>"+comentario+"</h1>");
                                        controladorPost miPost = new controladorPost();
                                        miPost.controlarPostMiMuro(comentario, Session["correo"].ToString());
                                    }
                                    // FIN MI POST

                                    Response.Write("<div id='mi-post'>");
                                    Response.Write("<div id='post-principal'>");
                                    Response.Write("<form action='amigo.aspx' method='POST'>");
                                    Response.Write("<textarea id='miPost' name='miPost' class='areaMiPost' placeholder='Agrega un comentario...'></textarea></br>");
                                    Response.Write("<input type='submit' class='btn-post' value='Postear' name='btnActualizar' />");
                                    Response.Write("</form>");
                                    Response.Write("</div>");

                                    //controladorPost cp = new controladorPost();
                                    //List<Post> lista = cp.controlarPostMuroAmigo(Session["correo"].ToString());
                                    //if (lista[0].Texto.Equals("Su muro se encuentra vacio"))
                                    //{
                                    //    Response.Write(lista[0].Texto);
                                    //}
                                    //else
                                    //{
                                    //    Response.Write("<table border='1px'>");
                                    //    Response.Write("<tr><td>Creador</td><td>Comentario</td><td>Fecha</td></tr>");
                                    //    for (int i = 0; i < lista.Count; i++)
                                    //    {
                                    //        Response.Write("<tr><td><a href='perfilPersona.aspx?correo=" + lista[i].Creador + "'>" + lista[i].NombreCreador + "</a></td><td>" + lista[i].Texto + "</td><td>" + lista[i].Fecha + "</td></tr>");
                                    //    }
                                    //    Response.Write("</table>");
                                    //}

                                }
                                else
                                {
                                    //Response.Write("<h1>no son amigis</h1>");
                                    //mostrar solicitud
                                    Response.Write("<h2>Aún no eres amigo de <i>"+nombreP+"</i> enviale una solicitud de amistad.</h2>");
                                    Response.Write("<a href='amigo.aspx?enviarSolicitud=" + correoP + "'>Enviar Solicitud de Amistad</a>");
                                }
                                Response.Write("</div>");

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
                            Response.Redirect("index.aspx");
                        }
                    }
                    else
                    {
                        Response.Redirect("index.aspx");
                    }
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