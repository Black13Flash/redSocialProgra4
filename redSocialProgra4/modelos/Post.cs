using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data.MySqlClient;
using redSocialProgra4.conex;

namespace redSocialProgra4.modelos
{
    public class Post
    {
        private int idPost;
        private string fecha;
        private string texto;
        private string creador;
        private string receptor;
        private int tipoPost;
        private string nombreCreador;

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

        public string Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public string Texto
        {
            get
            {
                return texto;
            }

            set
            {
                texto = value;
            }
        }

        public string Creador
        {
            get
            {
                return creador;
            }

            set
            {
                creador = value;
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

        public int TipoPost
        {
            get
            {
                return tipoPost;
            }

            set
            {
                tipoPost = value;
            }
        }

        public string NombreCreador
        {
            get
            {
                return nombreCreador;
            }

            set
            {
                nombreCreador = value;
            }
        }

        public Post() { }

        public List<Post> miMuro(string correo)
        {

            Conexion con = Conexion.Instance();
            List<Post> lista = new List<Post>();
            try
            {
                con.abreConexion();
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "Select * from post where receptor='" + correo + "' order by fecha desc";
                comando.Connection = con.usaConexion();
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Post p = new Post();
                    p.idPost = Convert.ToInt32(reader[0].ToString());
                    //p.fecha = reader[1].ToString();
                    p.texto = reader[2].ToString();
                    p.creador = reader[3].ToString();
                    p.receptor = reader[4].ToString();
                    p.tipoPost = Convert.ToInt32(reader[5].ToString());
                    lista.Add(p);
                }
            }
            finally
            {
                con.cierraConexion();
            }
            return lista;

        }

        // POSTEAR
        public bool posteo(Post p)
        {
            Conexion con = Conexion.Instance();
            String fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //p.Fecha = fecha;

            try
            {
                con.abreConexion();
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "INSERT INTO post (fecha, texto, creador, receptor, tipopost) VALUES('now()', '" + p.Texto + "','" + p.Creador + "','" + p.Receptor + "'," + p.TipoPost + ")";
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