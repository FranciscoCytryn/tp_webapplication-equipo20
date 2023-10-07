<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPWebApplication_equipo20._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">CommerceManager System WEB 1.0</h1>
            <p class="lead">Bienvenidos al sitio número 1 de compras online</p>
        </section>
        <div class="row row-cols-1 row-cols-md-3 g-4">
            <% 
                foreach(Dominio.Articulo articulo in ArticuloList)
            {
          %>
            <div class="card" style="width: 18rem;">
                <div class="card-body">
                    <h5 class="card-title"><%: articulo.Nombre %></h5>
                    <h6 class="card-text">$<%= articulo.Precio.ToString() %></h6>
                    <h5 class="card-text"><%: articulo.Marca %></h5>
                </div>
                <img src="<%: articulo.Imagenes%>" class="card-img-top" alt="...">
                <p></p>
                <button type="button" class="btn btn-primary btn-sm">Agregar al carrito</button>
                <p></p>
                <a class="btn btn-secondary btn-sm" href="DetalleArticulos.aspx?id=<%= articulo.ID %>">Ver detalle</a>
            </div>

           <%  } %>
                
        </div>
    </main>

</asp:Content>
