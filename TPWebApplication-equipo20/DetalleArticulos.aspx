<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleArticulos.aspx.cs" Inherits="TPWebApplication_equipo20.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


<div class="container py-5">
    <h1 class="text-center mb-5">Detalle del Articulo</h1>
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
                    <div>
                        <% string imagenUrl = articulo.Imagenes[0].ImagenURL; %>
                        <img id="imagenProducto" src="<%= !string.IsNullOrEmpty(imagenUrl) && UrlExists(imagenUrl) ? imagenUrl : "https://upload.wikimedia.org/wikipedia/commons/thumb/d/da/Imagen_no_disponible.svg/1200px-Imagen_no_disponible.svg.png" %>" class="custom-img" alt="Imagen del artículo">
                    </div>
                    <div>
                        <button type="button" id="btnAnterior" class="btn btn-primary btn-sm">Anterior</button>
                        <button type="button" id="btnSiguiente" class="btn btn-primary btn-sm">Siguiente</button>
                    </div>
                    <script>
                        var imagenes = [<% foreach (Dominio.Imagen imagen in articulo.Imagenes) { %> "<%= imagen.ImagenURL %>", <% } %>];
                        var imagenActual = 0;

                        document.getElementById('btnAnterior').addEventListener('click', function () {
                            imagenActual = (imagenActual - 1 + imagenes.length) % imagenes.length;
                            var nuevaImagen = new Image();
                            nuevaImagen.onload = function () {
                                document.getElementById('imagenProducto').src = imagenes[imagenActual];
                            };
                            nuevaImagen.onerror = function () {
                                document.getElementById('imagenProducto').src = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/da/Imagen_no_disponible.svg/1200px-Imagen_no_disponible.svg.png";
                            };
                            nuevaImagen.src = imagenes[imagenActual];
                        });

                        document.getElementById('btnSiguiente').addEventListener('click', function () {
                            imagenActual = (imagenActual + 1 + imagenes.length) % imagenes.length;
                            var nuevaImagen = new Image();
                            nuevaImagen.onload = function () {
                                document.getElementById('imagenProducto').src = imagenes[imagenActual];
                            };
                            nuevaImagen.onerror = function () {
                                document.getElementById('imagenProducto').src = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/da/Imagen_no_disponible.svg/1200px-Imagen_no_disponible.svg.png";
                            };
                            nuevaImagen.src = imagenes[imagenActual];
                        });
                    </script>
                <% } %>
            <% } %>
        </div>
        <div class="col-md-1 text-center"></div>
    </div>
</div>






</asp:Content>
