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
    public partial class _Default : Page
    {
        public List<Articulo> ArticuloList;
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            ArticuloList = negocio.listar();
        }
    }
}