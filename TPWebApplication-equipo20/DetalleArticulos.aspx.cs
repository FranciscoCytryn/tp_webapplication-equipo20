using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TPWebApplication_equipo20
{
    public partial class DetalleArticulos : System.Web.UI.Page
    {
        public List<Articulo> ArticuloList;
        public int idRecibido;
        protected void Page_Load(object sender, EventArgs e)
        {
            Articulo articulo = new Articulo();
            string idString = Request.QueryString["id"].ToString();
            ArticuloNegocio negocio = new ArticuloNegocio();
            ArticuloList = negocio.listar();
            idRecibido = int.Parse(idString);       
        }
    }
}