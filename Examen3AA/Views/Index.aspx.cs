using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Examen3AA.Models.DSCarritoTableAdapters;

namespace Examen3AA.Views
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                CargarVideojuegos();
            }
        }

        private void CargarVideojuegos()
        {
            videojuegosTableAdapter adapter = new videojuegosTableAdapter();
            var data = adapter.GetData(); 
            gvVideojuegos.DataSource = data;
            gvVideojuegos.DataBind();
        }
    }
}