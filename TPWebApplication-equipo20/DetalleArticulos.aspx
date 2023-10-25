<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleArticulos.aspx.cs" Inherits="TPWebApplication_equipo20.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container py-5">
        <h1 class="text-center mb-5">Detalle del Articulo</h1>
        <div class="row">
            <div class="col-md-1 text-center"></div>
            <div class="col-md-4">

                <% if (Session["IDArt"] != null)    { %>
                <% foreach (Dominio.Articulo articulo in (List<Dominio.Articulo>)Session["ArticuloList"])
                    { %> 
                <% if (articulo.ID == (int)Session["IDArt"])
                    { %>
                <div class="m-4">
                    <h4><strong>Producto:</strong> <%: articulo.Nombre %></h4>
                    <p><strong>Precio:</strong> $<%= articulo.Precio.ToString() %></p>
                    <p><strong>Marca:</strong> <%: articulo.Marca %></p>
                    <p><strong>Descripción:</strong> <%: articulo.Descripcion %></p>
                    <div class="quantity d-flex align-items-center">
                        <asp:Button ID="btnDecrement" runat="server" Text="-" CssClass="btn btn-sm btn-secondary" OnClick="btnDecrement_Click" UseSubmitBehavior="false" />
                        <asp:TextBox ID="quantity" runat="server" CssClass="custom-form-control text-center" Text="1" />
                        <asp:Button ID="btnIncrement" runat="server" Text="+" CssClass="btn btn-sm btn-secondary" OnClick="btnIncrement_Click" UseSubmitBehavior="false" />
                    </div>
                    <p></p>
                    <asp:Button ID="btnAgregarCarrito" runat="server" CssClass="btn btn-primary btn-sm" Text="Agregar al carrito" CommandName="Agregar" CommandArgument='<%# Eval("ID") %>' />
                </div>
                <% } %>
                <% } %>
                <a href="Default.aspx" class="btn btn-secondary btn-sm">Volver</a>
            </div>
            <div class="col-md-6 text-center">
                <% foreach (Dominio.Articulo articulo in  (List<Dominio.Articulo>)Session["ArticuloList"])
                    { %>
                <% if (articulo.ID == (int)Session["IDArt"])
                    { %>
                <div>
                    <% string imagenUrl = articulo.Imagenes[0].ImagenURL; %>
                    <img id="imagenProducto" src="<%= !string.IsNullOrEmpty(imagenUrl) && UrlExists(imagenUrl) ? imagenUrl : "https://upload.wikimedia.org/wikipedia/commons/thumb/d/da/Imagen_no_disponible.svg/1200px-Imagen_no_disponible.svg.png" %>" class="custom-img" alt="Imagen del artículo">
                </div>
                <div>
                    <button type="button" id="btnAnterior" class="btn btn-primary btn-sm">Anterior</button>
                    <button type="button" id="btnSiguiente" class="btn btn-primary btn-sm">Siguiente</button>
                </div>
                <script>
                    var imagenes = [<% foreach (Dominio.Imagen imagen in (List<Dominio.Imagen>)Session["ListImagenes"] )
                    { %> "<%= imagen.ImagenURL %>", <% } %>];
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
                <% } %>
            </div>
            <div class="col-md-1 text-center"></div>
        </div>
    </div>
</asp:Content>
