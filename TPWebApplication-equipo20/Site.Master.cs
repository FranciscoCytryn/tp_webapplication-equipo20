using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPWebApplication_equipo20
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateContadorCarrito();
            }
        }

        public void UpdateContadorCarrito()
        {
            if (Session["carrito"] != null)
            {
                var carrito = (Dictionary<int, int>)Session["carrito"];
                int totalItems = carrito.Values.Sum();
                cartCount.InnerText = totalItems.ToString();
            }
            else
            {
                cartCount.InnerText = "0";
            }
        }
    }
}