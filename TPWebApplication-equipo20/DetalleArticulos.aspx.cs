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
                    Session["IDArt"]=IDArt;
                }
                ArticuloNegocio negocio = new ArticuloNegocio();
                ArticuloList = negocio.listar();
                Session["ArticuloList"] = ArticuloList;


               ImagenNegocio ima = new ImagenNegocio();
               ListImagenes = ima.Listar(IDArt);
                Session["ListImagenes"] = ListImagenes;
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
        protected void btnDecrement_Click(object sender, EventArgs e)
        {
            // Obtén el botón que desencadenó el evento.
            Button btnDecrement = (Button)sender;

            // Obtén el TextBox asociado al botón.
            TextBox quantity = (TextBox)btnDecrement.Parent.FindControl("quantity");

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
            // Obtén el botón que desencadenó el evento.
            Button btnIncrement = (Button)sender;

            // Obtén el TextBox asociado al botón.
            TextBox quantity = (TextBox)btnIncrement.Parent.FindControl("quantity");

            if (quantity != null)
            {
                int cantidad = int.Parse(quantity.Text);
                cantidad++;
                quantity.Text = cantidad.ToString();
            }
        }

        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            // Obtén el botón que desencadenó el evento.
            Button btnAgregarCarrito = (Button)sender;

            // Obtén el TextBox asociado al botón.
            TextBox quantity = (TextBox)btnAgregarCarrito.Parent.FindControl("quantity");

            int productoId = (int)Session["IDArt"]; // Obtén el ID del artículo de tu modelo, puede variar según la estructura real.

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

            ((SiteMaster)this.Master).UpdateContadorCarrito();
        }
    }
}