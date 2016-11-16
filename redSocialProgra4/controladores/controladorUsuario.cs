using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using redSocialProgra4.modelos;

namespace redSocialProgra4.controladores
{
    public class controladorUsuario
    {
        public string validaRegistrar(string correo, string nombre, string apellido, string clave, string rClave)
        {
            if (correo == "" || nombre == "" || apellido == "" || clave == "" || rClave == "")
            {
                return "Hay un campo vacio";
            }
            else
            {
                int cont = 0;
                char x;//clave
                char[] a = clave.ToCharArray();
                string abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                char[] b = abc.ToCharArray();
                char y;//abecedario

                for (int i = 0; i < a.Count(); i++)
                {
                    x = a[i];
                    for (int z = 0; z < b.Count(); z++)
                    {
                        y = b[z];
                        if (x == y)
                        {
                            cont++;
                            //cont = cont + 1;
                        }
                    }
                }
                if (clave.Length < 8 || cont == 0)
                {
                    return "La contraseña debe contener al menos 8 caracteres y una letra mayuscula";
                }
                else
                {
                    if (clave.Equals(rClave))
                    {
                        String expresion;
                        expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                        if (Regex.IsMatch(correo, expresion))
                        {
                            if (Regex.Replace(correo, expresion, String.Empty).Length == 0)
                            {
                                Usuario u = new Usuario();
                                Usuario u2 = u.buscaUno(correo);
                                if (u2 == null)
                                {
                                    u.Correo = correo;
                                    u.Nombre = nombre;
                                    u.Apellido = apellido;
                                    u.Clave = clave;
                                    if (u.insertaUsuario(u))
                                    {
                                        return "Usuario Registrado";
                                    }
                                    else
                                    {
                                        return "Error al registrar usuario";
                                    }
                                }
                                else
                                {
                                    return "El correo ya esta registrado";
                                }
                            }
                            else
                            {
                                return "El correo no existe";
                            }
                        }
                        else
                        {
                            return "El correo no existe";
                        }
                    }
                    else
                    {
                        return "La clave no coincide";
                    }
                }
            }

        }


        public string validaLogin(string correo, string clave)
        {
            if (correo == "" || clave == "")
            {
                return "Hay campo vacios";

            }
            else
            {
                Usuario u = new Usuario();
                Usuario u2 = u.buscaLogin(correo, clave);
                if (u2 == null)
                {
                    return "El correo no existe o la contraseña es incorrecta";
                }
                else
                {
                    string nombre = u2.Nombre;
                    string apellido = u2.Apellido;
                    return "a<" + correo + "<" + nombre + "<" + apellido + "";
                }
            }
        }

        public string validaBuscarAmigo(string nombre)
        {
            if (nombre == "")
            {
                return "Debe ingresar un nombre";
            }
            else
            {
                string[] aux = nombre.Split(' ');
                if (aux.Length == 1)
                {
                    return "Debe ingresar nombre y apellido";
                }
                else
                {
                    string nombresito = aux[0];
                    string apellido = aux[1];
                    return "exito<" + nombresito + "<" + apellido + "";
                }
            }
        }

        public string buscaPersonas(string miCorreo, string nombre, string apellido) 
        {
            string unaLinea = "";

            Usuario u = new Usuario();
            List<Usuario> listaUsuario = u.buscaTodosNombreApellido(nombre, apellido);

            foreach (Usuario uu in listaUsuario)
            {
                Usuario nn = uu.buscaUno(uu.Correo);

                string amigos = "";

                if (nn.sonAmigos(miCorreo,nn.Correo))
                {
                    amigos = "1";
                }
                else
                {
                    //enviarSolicitud
                    amigos = "0";
                }


                unaLinea+=">"+nn.Correo+"+"+nn.Nombre+"+"+nn.Apellido+"+"+amigos;

            }

            return unaLinea;
        }


    }

}