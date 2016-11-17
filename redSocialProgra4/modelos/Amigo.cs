using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data.MySqlClient;
using redSocialProgra4.conex;

namespace redSocialProgra4.modelos
{
    public class Amigo
    {
        private string usuario1;
        private string usuario2;

        public string Usuario1
        {
            get
            {
                return usuario1;
            }

            set
            {
                usuario1 = value;
            }
        }

        public string Usuario2
        {
            get
            {
                return usuario2;
            }

            set
            {
                usuario2 = value;
            }
        }

        public Amigo() { }

        public List<Amigo> amigosHechos(string user1)
        {
            Conexion con = Conexion.Instance();
            List<Amigo> lista = new List<Amigo>();

            try
            {
                con.abreConexion();
                MySqlCommand comando = new MySqlCommand();
                //comando.CommandText = "SELECT * FROM amigos WHERE usuario1='"+user1+"' ";
                comando.CommandText = "SELECT * from amigos WHERE usuario1='" + user1 + "' or usuario2='" + user1 + "'";
                comando.Connection = con.usaConexion();
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Amigo a = new Amigo();
                    a.usuario1 = reader[0].ToString();
                    a.Usuario2 = reader[1].ToString();

                    lista.Add(a);
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                con.cierraConexion();
            }
            return lista;
        }

        public bool crearAmistad(string miCorreo, string correoAmigo)
        {
            Conexion con = Conexion.Instance();
            try
            {
                con.abreConexion();
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "INSERT INTO amigos VALUES('"+miCorreo+"','"+correoAmigo+"')";
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

    }
}