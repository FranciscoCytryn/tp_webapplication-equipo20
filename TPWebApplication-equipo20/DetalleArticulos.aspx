<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleArticulos.aspx.cs" Inherits="TPWebApplication_equipo20.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


<div class="container py-5">
     <h1 class="text-center mb-5"> Detalle del Articulo</h1>
    <div class="row">
                <div class="col-md-1 text-center"></div>
        <div class="col-md-4">
            <% foreach (Dominio.Articulo articulo in ArticuloList) { %>
                <% if (articulo.ID == IDArt) { %>
                    <div class="m-4">
                        <h4><strong>Producto:</strong> <%: articulo.Nombre %></h4>
                        <p><strong>Precio:</strong> $<%= articulo.Precio.ToString() %></p>
                        <p><strong>Marca:</strong> <%: articulo.Marca %></p>
                        <p><strong>Descripción:</strong> <%: articulo.Descripcion %></p>
                        <button type="button" class="btn btn-primary btn-sm">Agregar al carrito</button>
                    </div>
                <% } %>
            <% } %>
            <a href="javascript:history.back()" class="btn btn-secondary btn-sm">Volver</a>
        </div>
        <div class="col-md-6 text-center">
            <% foreach (Dominio.Articulo articulo in ArticuloList) { %>
                <% if (articulo.ID == IDArt) { %>
                    <% string imagenUrl = articulo.Imagenes.FirstOrDefault()?.ImagenURL; %>
                    <img src="<%: !string.IsNullOrEmpty(imagenUrl) && UrlExists(imagenUrl) ? imagenUrl : "https://upload.wikimedia.org/wikipedia/commons/thumb/d/da/Imagen_no_disponible.svg/1200px-Imagen_no_disponible.svg.png" %>" class="img-fluid" alt="Imagen del artículo" style="max-width: 100%;">
                <% } %>
            <% } %>
        </div>
        <div class="col-md-1 text-center"></div>
    </div>
</div>




</asp:Content>
