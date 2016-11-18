using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using redSocialProgra4.conex;
using MySql.Data.MySqlClient;

namespace redSocialProgra4.modelos
{
    public class Notificacion
    {
        private int idNotificacion;
        private int visto;
        private int idPost;
        private string usuario; //vendria siendo el correo

        public int IdNotificacion
        {
            get
            {
                return idNotificacion;
            }

            set
            {
                idNotificacion = value;
            }
        }

        public int Visto
        {
            get
            {
                return visto;
            }

            set
            {
                visto = value;
            }
        }

        public int IdPost
        {
            get
            {
                return idPost;
            }

            set
            {
                idPost = value;
            }
        }

        public string Usuario
        {
            get
            {
                return usuario;
            }

            set
            {
                usuario = value;
            }
        }

        public Notificacion() { }

        public bool enviarNotificacion(int idpost, string correo)
        {

            Conexion con = Conexion.Instance();
            try
            {
                con.abreConexion();
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "INSERT INTO notificaciones VALUES('','0', '" + idpost + "','" + correo + "')";
                comando.Connection = con.usaConexion();
                if (comando.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.cierraConexion();
            }
        }

        public bool vistoUpdate(int idNotificacion)
        {
            Conexion con = Conexion.Instance();
            try
            {
                con.abreConexion();
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "UPDATE notificaciones SET visto='1' where idnotificacion='" + idNotificacion + "'";
                comando.Connection = con.usaConexion();
                if (comando.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.cierraConexion();
            }
        }

        //trae todas las solicitudes vistas y no vistas

        //este metodo trae todas las notificaciones sin orden
        public List<Notificacion> notificaciones(string correo)
        {

            Conexion con = Conexion.Instance();
            List<Notificacion> lista = new List<Notificacion>();
            try
            {
                con.abreConexion();
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "SELECT * FROM notificaciones where usuario='" + correo + "' and (visto=0 or visto=1)";//notificaciones hay que mostrar todas los no vistos y un par vistos??
                comando.Connection = con.usaConexion();
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Notificacion n = new Notificacion();
                    n.IdNotificacion = Convert.ToInt32(reader[0].ToString());
                    n.visto = Convert.ToInt32(reader[1].ToString());
                    n.IdPost = Convert.ToInt32(reader[2].ToString());
                    n.Usuario = reader[3].ToString();
                    lista.Add(n);
                }
            }
            finally
            {
                con.cierraConexion();
            }
            return lista;

        }
        //trae el numero de las solicitudes no vistas
        public int cantidadSolicitud(string correo)
        {
            Conexion con = Conexion.Instance();
            int cantidad = 0;
            try
            {
                con.abreConexion();
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "select count(*) from notificaciones where usuario='" + correo + "' and visto=0";
                comando.Connection = con.usaConexion();
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    cantidad = Convert.ToInt32(reader[0]);
                }
            }
            finally
            {
                con.cierraConexion();
            }
            return cantidad;


        }



        public bool actualizarTodoVisto(List<Notificacion> lista, string correo)
        {
            int contador = 0;
            Conexion con = Conexion.Instance();
            for (int i = 0; i < lista.Count; i++)
            {
                try
                {
                    con.abreConexion();
                    MySqlCommand comando = new MySqlCommand();
                    comando.CommandText = "UPDATE notificaciones SET visto='1' where idnotificacion='" + lista[i].IdNotificacion + "'";//0 no visto 1 visto
                    comando.Connection = con.usaConexion();
                    if (comando.ExecuteNonQuery() > 0)
                        contador++;
                }
                catch
                {

                }
                finally
                {
                    con.cierraConexion();
                }
            }

            if (contador == lista.Count)
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