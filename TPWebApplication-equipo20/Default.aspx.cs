using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using System.Net;
using System.Diagnostics;
using System.Drawing;
using System.Web.Configuration;

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
                TextBox quantity = e.Item.FindControl("quantity") as TextBox;
                int cantidadAgregada = int.Parse(quantity.Text);

                // Inicializa el carrito como un diccionario si aún no se ha hecho.
                if (Session["carrito"] == null)
                {
                    Session["carrito"] = new Dictionary<int, int>();
                }

                var carrito = (Dictionary<int, int>)Session["carrito"];

                if (carrito.ContainsKey(productoId))
                {
                    carrito[productoId] += cantidadAgregada; // Incrementa la cantidad si ya existe en el carrito.
                }
                else
                {
                    carrito[productoId] = cantidadAgregada; // Si es la primera vez que se agrega, la cantidad es 1.
                }
            }
        }
        protected void btnDecrement_Click(object sender, EventArgs e)
        {
            Button btnDecrement = (Button)sender;
            RepeaterItem item = (RepeaterItem)btnDecrement.NamingContainer;
            TextBox quantity = (TextBox)item.FindControl("quantity");
            if (quantity != null)
            {
                int currentValue = int.Parse(quantity.Text);
                if (currentValue > 0)
                {
                    currentValue--;
                    quantity.Text = currentValue.ToString();
                }
            }
        }

        protected void btnIncrement_Click(object sender, EventArgs e)
        {
            Button btnIncrement = (Button)sender;
            RepeaterItem item = (RepeaterItem)btnIncrement.NamingContainer;
            TextBox quantity = (TextBox)item.FindControl("quantity");

            if (quantity != null)
            {
                int currentValue = int.Parse(quantity.Text);
                currentValue++;
                quantity.Text = currentValue.ToString();
            }
        }

    }
}





