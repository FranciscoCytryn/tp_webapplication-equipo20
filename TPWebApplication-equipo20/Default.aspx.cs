using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using System.Net;

namespace TPWebApplication_equipo20
{
    public partial class _Default : Page
    {
        public List<Articulo> ArticuloList;
        protected void Page_Load(object sender, EventArgs e)
        {
            //ArticuloNegocio negocio = new ArticuloNegocio();
            //ArticuloList = negocio.listar();

            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                ArticuloList = negocio.listar();

                rptArticulos.DataSource = ArticuloList;
                rptArticulos.DataBind();
            }
        }
        public bool UrlExists(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "HEAD";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    return (response.StatusCode == HttpStatusCode.OK);
                }
            }
            catch
            {
                return false;
            }
        }

        protected void rptArticulos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Agregar")
            {
                int productoId = Convert.ToInt32(e.CommandArgument);

                // Inicializa el carrito como un diccionario si aún no se ha hecho.
                if (Session["carrito"] == null)
                {
                    Session["carrito"] = new Dictionary<int, int>();
                }

                var carrito = (Dictionary<int, int>)Session["carrito"];

                if (carrito.ContainsKey(productoId))
                {
                    carrito[productoId] += 1; // Incrementa la cantidad si ya existe en el carrito.
                }
                else
                {
                    carrito[productoId] = 1; // Si es la primera vez que se agrega, la cantidad es 1.
                }
            }
        }



    }
}