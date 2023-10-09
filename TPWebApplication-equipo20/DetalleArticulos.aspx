<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleArticulos.aspx.cs" Inherits="TPWebApplication_equipo20.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



<div class="row row-cols-1 row-cols-md-3 g-4">
    <% foreach (Dominio.Articulo articulo in ArticuloList) { %>
        <% if (articulo.ID == ID) { %>
            <div class="card" style="width: 18rem;">
                <div class="card-body">
                    <h5 class="card-title"><%: articulo.Nombre %></h5>
                    <h6 class="card-text">$<%= articulo.Precio.ToString() %></h6>
                    <h5 class="card-text"><%: articulo.Marca %></h5>
                </div>
                <% string imagenUrl = articulo.Imagenes.FirstOrDefault()?.ImagenURL; %>
                <img src="<%: !string.IsNullOrEmpty(imagenUrl) && UrlExists(imagenUrl) ? imagenUrl : "https://upload.wikimedia.org/wikipedia/commons/thumb/d/da/Imagen_no_disponible.svg/1200px-Imagen_no_disponible.svg.png" %>" class="card-img-top" alt="Imagen del artículo">
                <p></p>
                <button type="button" class="btn btn-primary btn-sm">Agregar al carrito</button>
                <p></p>
                <a class="btn btn-secondary btn-sm" href="DetalleArticulos.aspx?id=<%= articulo.ID %>">Ver detalle</a>
            </div>
        <% } %>
    <% } %>
</div>



</asp:Content>
