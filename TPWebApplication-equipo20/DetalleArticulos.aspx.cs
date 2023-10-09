using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPWebApplication_equipo20
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public List<Articulo> ArticuloList;
        public int ID { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
           
                if (!IsPostBack)
                {
                    string idParametro = Request.QueryString["id"];

                    if (!string.IsNullOrEmpty(idParametro))
                    {
                        ID = Convert.ToInt32(idParametro);

                    }
                }
            




            ArticuloNegocio negocio = new ArticuloNegocio();
            ArticuloList = negocio.listar();


        }
    }
}