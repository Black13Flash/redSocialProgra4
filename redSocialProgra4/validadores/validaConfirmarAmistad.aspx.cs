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
    public partial class validaConfirmarAmistad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["correo"] != null)
            {
                if (Request["Aceptar"] != null && Request["Amigo"] != null && Request["id"] != null)
                {
                    //Response.Write(Request["Aceptar"]);
                    //Response.Write(Request["Amigo"]);
                    //Response.Write(Request["id"]);

                    string miCorreo = Session["correo"].ToString();
                    string aceptar = Request["Amigo"];
                    string correoAmigo = Request["Amigo"];
                    int idSolicitud = Convert.ToInt32(Request["id"]);

                    //TablaAmigos
                    controladorAmigo ca = new controladorAmigo();

                    if (ca.hacerAmigo(miCorreo,correoAmigo))
                    {
                        Solicitud soli = new Solicitud();

                        if (aceptar.Equals("1"))
                        {
                            if (soli.actualizarEstado(idSolicitud,3))
                            {

                            }else
                            {
                                Response.Redirect("../vistas/index.aspx");
                            }
                        }else
                        {
                            if (soli.actualizarEstado(idSolicitud, 4))
                            {

                            }
                            else
                            {
                                Response.Redirect("../vistas/index.aspx");
                            }
                        }


                        Response.Redirect("../vistas/amigo.aspx?perfil=" + Request["Amigo"] + "");
                    }else
                    {
                        Response.Redirect("../vistas/index.aspx");
                    }


                    
                }
                else
                {
                    Response.Redirect("../vistas/index.aspx");
                }
            }
            else
            {
                Response.Redirect("../vistas/index.aspx");
            }
        }
    }
}