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

            ImagenNegocio ima= new ImagenNegocio();
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



    }
}