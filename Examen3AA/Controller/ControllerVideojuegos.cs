using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Examen3AA.Models.DSCarritoTableAdapters;


namespace Examen3AA.Controller
{
    public class ControllerVideojuegos
    {

        public bool Logear(string user, string password)
        {

            try
            {
                using (usuariosTableAdapter users = new usuariosTableAdapter())
                {
                    var filausuario = users.GetDataByUsuario(user.Trim().ToLower());
                    if (filausuario.Rows.Count > 0)
                    {
                        string contrasenaEncriptada = filausuario.Rows[0]["contrasena"].ToString();

                        AESCryptography aES = new AESCryptography();

                        string contrasenaDesencriptada = aES.Decrypt(contrasenaEncriptada);
                        if (contrasenaDesencriptada == password && filausuario.Rows[0]["nombre_usuario"].ToString() == user)
                        {

                            return true;
                        }
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        public bool AgregarVideojuego(string nombre, int cantidad, double precio, string img)
        {
            try
            {
                using (videojuegosTableAdapter videojuegos = new videojuegosTableAdapter())
                {
                    videojuegos.InsertVideojuego(nombre, cantidad, Convert.ToDecimal(precio), img);
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Videojuego> ObtenerCatalogo()
        {
            try
            {
                using (videojuegosTableAdapter videojuegos = new videojuegosTableAdapter())
                {
                    var dt = videojuegos.GetData();
                    if (dt.Rows.Count > 0)
                    {
                        List<Videojuego> lista = new List<Videojuego>();
                        foreach (DataRow row in dt.Rows)
                        {
                            Videojuego v = new Videojuego
                            {
                                Id = Convert.ToInt32(row["id"]),
                                Nombre = row["Nombre"].ToString(),
                                Cantidad = Convert.ToInt32(row["Cantidad"]),
                                Precio = Convert.ToInt32(row["Precio"]),
                                ImagenUrl = row["Imagen"].ToString()
                            };
                            lista.Add(v);
                        }
                        return lista;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error", ex);
            }
        }
    }
}
