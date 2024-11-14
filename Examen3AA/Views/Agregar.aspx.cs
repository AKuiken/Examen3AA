using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;    
using System.Web.UI;
using System.Web.UI.WebControls;
using Examen3AA.Models.DSCarritoTableAdapters;
using Examen3AA.Models;
using Examen3AA.Controller;


namespace Examen3AA.Views
{
    public partial class Agregar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            int cantidad = int.Parse(txtCantidad.Text);
            decimal precio = decimal.Parse(txtPrecio.Text);
            string na = System.IO.Path.GetFileName(fileImagen.FileName);
            string ruta = "~/images/" + na;
         

            if (fileImagen.HasFile)
            {           
                Response.Redirect("Index.aspx");
            }
            videojuegosTableAdapter productosAdapter = new videojuegosTableAdapter();
            productosAdapter.InsertVideojuego(nombre, cantidad, precio, ruta);
        }
    }
}