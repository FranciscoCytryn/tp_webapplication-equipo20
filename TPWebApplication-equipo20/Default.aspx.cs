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
                LlenarMarcas();
                LlenarCategorias();

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

                // Actualizar el contador del carrito en el nav
                ((SiteMaster)this.Master).UpdateContadorCarrito();
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
        private void LlenarMarcas()
        {
            MarcaNegocio negocio = new MarcaNegocio();
            marcaDropdown.DataSource = negocio.Listar();
            marcaDropdown.DataTextField = "Descripcion";
            marcaDropdown.DataValueField = "ID";
            marcaDropdown.DataBind();
            marcaDropdown.Items.Insert(0, new ListItem("Todas las marcas", "0"));
        }
        private void LlenarCategorias()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            categoriaDropdown.DataSource = negocio.Listar();
            categoriaDropdown.DataTextField = "Descripcion";
            categoriaDropdown.DataValueField = "ID";
            categoriaDropdown.DataBind();
            categoriaDropdown.Items.Insert(0, new ListItem("Todas las categorías", "0"));
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string marcaSeleccionada = marcaDropdown.SelectedValue;
            string categoriaSeleccionada = categoriaDropdown.SelectedValue;
            decimal? precioMaximo = null;
            if (decimal.TryParse(precioTextBox.Text, out decimal result))
            {
                precioMaximo = result;
            }
            string descripcion = descripcionTextBox.Text;

            ArticuloNegocio negocio = new ArticuloNegocio();
            List<Articulo> articulosFiltrados = negocio.ListarConFiltro(marcaSeleccionada, categoriaSeleccionada, precioMaximo, descripcion);

            rptArticulos.DataSource = articulosFiltrados;
            rptArticulos.DataBind();
        }
    }
}





