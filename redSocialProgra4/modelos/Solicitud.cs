using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data.MySqlClient;
using redSocialProgra4.conex;   

namespace redSocialProgra4.modelos
{
    public class Solicitud
    {
        private int idSolicitud;
        private string emisor;
        private string receptor;
        private int tipoEstado;

        public int IdSolicitud
        {
            get
            {
                return idSolicitud;
            }

            set
            {
                idSolicitud = value;
            }
        }

        public string Emisor
        {
            get
            {
                return emisor;
            }

            set
            {
                emisor = value;
            }
        }

        public string Receptor
        {
            get
            {
                return receptor;
            }

            set
            {
                receptor = value;
            }
        }

        public int TipoEstado
        {
            get
            {
                return tipoEstado;
            }

            set
            {
                tipoEstado = value;
            }
        }

        public Solicitud() { }

        public bool enviarSolicitud(Solicitud s)
        {

            Conexion con = Conexion.Instance();
            try
            {
                con.abreConexion();
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "INSERT INTO solicitud (idsolicitud, emisor, receptor, tipoestado) VALUES('','" + s.Emisor + "', '" + s.Receptor + "','" + s.TipoEstado + "')";
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

        public bool actualizarEstado(int idSolicitud, int estado)
        {
            Conexion con = Conexion.Instance();
            try
            {
                con.abreConexion();
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "UPDATE solicitud SET tipoestado='" + estado + "' WHERE idsolicitud='"+idSolicitud+"' ";
                // 1 -> NO VISTO
                // 2 -> VISTO
                // 3 -> ACEPTADA
                // 4 -> RECHAZADA
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

        public List<Solicitud> notificaciones(string correo)
        {

            Conexion con = Conexion.Instance();
            List<Solicitud> lista = new List<Solicitud>();
            try
            {
                con.abreConexion();
                MySqlCommand comando = new MySqlCommand();
                // 1 -> NO VISTO
                // 2 -> VISTO
                // 3 -> ACEPTADA
                // 4 -> RECHAZADA
                comando.CommandText = "SELECT * FROM solicitud where receptor='" + correo + "' and (tipoestado=1 or tipoestado=2)";
                comando.Connection = con.usaConexion();
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Solicitud s = new Solicitud();
                    s.IdSolicitud = Convert.ToInt32(reader[0].ToString());
                    s.Emisor = reader[1].ToString();
                    s.Receptor = reader[2].ToString();
                    s.TipoEstado = Convert.ToInt32(reader[3].ToString());
                    lista.Add(s);
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
                comando.CommandText = "select count(*) from solicitud where receptor='" + correo + "' and tipoestado=1";
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

        //actualiza lista de solicitudes de no visto a visto
        public bool actualizarTodoVisto(List<Solicitud> lista, string correo)
        {
            int contador = 0;
            Conexion con = Conexion.Instance();
            for (int i = 0; i < lista.Count; i++)
            {
                try
                {
                    con.abreConexion();
                    MySqlCommand comando = new MySqlCommand();
                    comando.CommandText = "UPDATE solicitud SET tipoestado='2' WHERE idsolicitud='" + lista[i].IdSolicitud + "'"; //1=no visto, 2=visto, 3=aceptado, 4=rechazado
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