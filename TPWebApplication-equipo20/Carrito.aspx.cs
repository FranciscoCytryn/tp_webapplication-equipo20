﻿using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPWebApplication_equipo20
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["carrito"] != null)
                {
                    BindGrid();
                }
            }

        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {

        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        private void CargarProductosCarrito()
        {
            if (Session["carrito"] != null)
            {
                List<int> carrito = (List<int>)Session["carrito"];
                ArticuloNegocio negocio = new ArticuloNegocio();

                // Obtener todos los productos
                List<Articulo> todosLosProductos = negocio.listar();

                // Filtrar aquellos que están en el carrito
                List<Articulo> productosCarrito = todosLosProductos.Where(art => carrito.Contains(art.ID)).ToList();

                // Asigna la lista filtrada al GridView
                gvCarrito.DataSource = productosCarrito;
                gvCarrito.DataBind();
            }
        }

        private DataTable ObtenerProductosPorIds(Dictionary<int, int> carrito)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            List<Articulo> todosLosProductos = negocio.listar();
            List<Articulo> productosCarrito = todosLosProductos.Where(art => carrito.Keys.Contains(art.ID)).ToList();

            // Convertir la lista de Articulo a DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Codigo", typeof(string));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Descripcion", typeof(string));
            dt.Columns.Add("Precio", typeof(decimal));
            dt.Columns.Add("Cantidad", typeof(int)); 
            dt.Columns.Add("Categoria", typeof(string));
            dt.Columns.Add("Marca", typeof(string));

            foreach (var art in productosCarrito)
            {
                dt.Rows.Add(art.ID, art.Codigo, art.Nombre, art.Descripcion, art.Precio, carrito[art.ID], art.Categoria.Descripcion, art.Marca.Descripcion);
            }

            return dt;
        }

        protected void gvCarrito_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int productoId = Convert.ToInt32(gvCarrito.DataKeys[e.RowIndex].Value);

            var carrito = (Dictionary<int, int>)Session["carrito"];
                 
            carrito.Remove(productoId);
            

            BindGrid();
        }

        protected void gvCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
        {
   
        }

        private void BindGrid()
        {
            if (Session["carrito"] != null)
            {
                var carrito = (Dictionary<int, int>)Session["carrito"];
                DataTable dtProductosCarrito = ObtenerProductosPorIds(carrito);
                gvCarrito.DataSource = dtProductosCarrito;
                gvCarrito.DataBind();

                // Actualiza el total del carrito
                decimal total = dtProductosCarrito.AsEnumerable().Sum(row => row.Field<decimal>("Precio") * row.Field<int>("Cantidad"));
                lblTotal.Text = "Total: " + total.ToString("C");
            }
        }

       
    }
}