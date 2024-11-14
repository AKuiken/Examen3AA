using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen3AA.Controller
{
    public class Videojuego
    {
        
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public double  Precio { get; set; }
        public string ImagenUrl { get; set; }

    }
}