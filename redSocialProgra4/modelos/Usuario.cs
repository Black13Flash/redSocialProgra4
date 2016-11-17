using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using redSocialProgra4.conex;

namespace redSocialProgra4.modelos
{
    public class Usuario
    {

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string apellido;

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        private string correo;

        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }

        private string clave;

        public string Clave
        {
            get { return clave; }
            set { clave = value; }
        }

        public bool insertaUsuario(Usuario u)
        {
            Conexion con = Conexion.Instance();
            try
            {
                con.abreConexion();
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "INSERT INTO usuarios VALUES('" + u.Correo + "','" + u.Nombre + "','" + u.Apellido + "','" + u.Clave + "')";
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

        public Usuario buscaUno(string correo)
        {
            Conexion con = Conexion.Instance();
            Usuario u2 = null;
            try
            {
                con.abreConexion();
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "SELECT * FROM usuarios WHERE correo='" + correo + "'";
                comando.Connection = con.usaConexion();
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    u2 = new Usuario();
                    u2.Correo = reader[0].ToString();
                    u2.Nombre = reader[1].ToString();
                    u2.Apellido = reader[2].ToString();
                    u2.Clave = reader[3].ToString();
                }
            }
            finally
            {
                con.cierraConexion();
            }
            return u2;
        }

        public Usuario buscaLogin(string correo, string clave)
        {
            Conexion con = Conexion.Instance();
            Usuario u2 = null;
            try
            {
                con.abreConexion();
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "SELECT * FROM usuarios WHERE correo='" + correo + "' AND clave='" + clave + "'";
                comando.Connection = con.usaConexion();
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    u2 = new Usuario();
                    u2.Correo = reader[0].ToString();
                    u2.Nombre = reader[1].ToString();
                    u2.Apellido = reader[2].ToString();
                    u2.Clave = reader[3].ToString();
                }
            }
            finally
            {
                con.cierraConexion();
            }
            return u2;
        }

        //BUSCA PERSONA
        public List<Usuario> buscaTodosNombreApellido(string nombre, string apellido)
        {
            Conexion con = Conexion.Instance();
            List<Usuario> lista = new List<Usuario>();
            try
            {
                con.abreConexion();
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "SELECT * FROM usuarios WHERE nombre='" + nombre + "' AND apellido='" + apellido + "'";
                comando.Connection = con.usaConexion();
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Usuario u2 = new Usuario();
                    u2.correo = reader[0].ToString();
                    u2.Nombre = reader[1].ToString();
                    u2.Apellido = reader[2].ToString();
                    lista.Add(u2);
                }
            }
            finally
            {
                con.cierraConexion();
            }
            return lista;
        }
        //busca todos los amigos del usuario logeado
        public List<Usuario> buscaTodosAmigos(string correo)
        {
            Conexion con = Conexion.Instance();
            List<Usuario> lista = new List<Usuario>();
            try
            {
                con.abreConexion();
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "SELECT * FROM usuarios WHERE correo=" + correo + "";
                comando.Connection = con.usaConexion();
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Usuario u2 = new Usuario();
                    u2.correo = reader[0].ToString();
                    u2.Nombre = reader[1].ToString();
                    u2.Apellido = reader[2].ToString();
                    u2.clave = reader[3].ToString();
                    lista.Add(u2);
                }
            }
            finally
            {
                con.cierraConexion();
            }
            return lista;
        }

        public bool sonAmigos(string correoSession, string correoPerfil)
        {
            Conexion con = Conexion.Instance();
            bool bandera = false;
            // string mensaje = "No Son Amigos";
            try
            {
                con.abreConexion();
                MySqlCommand comando = new MySqlCommand();
                //comando.CommandText = "SELECT * FROM amigos WHERE (usuario1='" + correoSession + "' AND usuario2='" + correoPerfil + "') OR (usuario1='" + correoPerfil + "' AND usuario2='" + correoSession + "')";
                comando.CommandText = "SELECT * from amigos where (usuario1='" + correoSession + "' or usuario2='" + correoSession + "') and (usuario1='" + correoPerfil + "' or usuario2='" + correoPerfil + "')";
                comando.Connection = con.usaConexion();
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    bandera = true;
                }
            }
            finally
            {
                con.cierraConexion();
            }
            return bandera;
        }
        

    }

}