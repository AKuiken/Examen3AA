using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Examen3AA.Controller;
using Examen3AA.Models.DSCarritoTableAdapters;

namespace Examen3AA.Views
{
    public partial class Login : System.Web.UI.Page
    {

        ControllerVideojuegos control = new ControllerVideojuegos(); 
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtNombreUsuario.Text;
            string contrasena = txtContrasena.Text;

            //usuariosTableAdapter adapter = new usuariosTableAdapter();
            //var usuario = adapter.GetDataByUsuario(nombreUsuario).FirstOrDefault();
            if (control.Logear(nombreUsuario, contrasena))
            {
                Session["Usuario"] = nombreUsuario;
                Response.Redirect("Agregar.aspx");
            }
            else
            {

            }          
        }
    }
}