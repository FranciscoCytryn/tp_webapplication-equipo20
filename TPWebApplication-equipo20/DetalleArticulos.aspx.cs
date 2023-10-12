using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPWebApplication_equipo20
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public List<Articulo> ArticuloList;
        public int IDArt { get; set; }
        public List<Imagen> ListImagenes { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string idParametro = Request.QueryString["id"];

                if (!string.IsNullOrEmpty(idParametro))
                {
                    IDArt = Convert.ToInt32(idParametro);

                }
            }
            ArticuloNegocio negocio = new ArticuloNegocio();
            ArticuloList = negocio.listar();

            ImagenNegocio ima = new ImagenNegocio();
            ListImagenes = ima.Listar(IDArt);



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
        protected void btnDecrement_Click(object sender, EventArgs e)
        {
            if (quantity != null)
            {
                int cantidad = int.Parse(quantity.Text);
                if (cantidad > 0)
                {
                    cantidad--;
                    quantity.Text = cantidad.ToString();
                }
            }
        }

        protected void btnIncrement_Click(object sender, EventArgs e)
        {
            if (quantity != null)
            {
                int cantidad = int.Parse(quantity.Text);
                cantidad++;
                quantity.Text = cantidad.ToString();
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
    }
}