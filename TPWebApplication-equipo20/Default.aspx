<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPWebApplication_equipo20._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">CommerceManager System WEB 1.0</h1>
            <p class="lead">Bienvenidos al sitio número 1 de compras online</p>
        </section>


<div class="container align-content-center">
    <div class="row row-cols-1 row-cols-md-3 g-4 justify-content-center">
        <asp:Repeater ID="rptArticulos" runat="server" OnItemCommand="rptArticulos_ItemCommand">
            <ItemTemplate>
                <div class="card mb-4" style="width: 18rem; margin-right: 10px;">
                    <div class="card-body">
                        <h5 class="card-title"><%# Eval("Nombre") %></h5>
                        <h6 class="card-text">$<%# Eval("Precio") %></h6>
                        <h5 class="card-text"><%# Eval("Marca.Descripcion") %></h5>
                    </div>
                    <img src='<%# Eval("ImagenURL") %>' class="card-img-top" alt="Imagen del artículo">
                    <p></p>
                    <asp:Button ID="btnAgregarCarrito" runat="server" CssClass="btn btn-primary btn-sm" Text="Agregar al carrito" CommandName="Agregar" CommandArgument='<%# Eval("ID") %>' />
                    <p></p>
                    <a class="btn btn-secondary btn-sm" href='<%# "DetalleArticulos.aspx?id=" + Eval("ID") %>'>Ver detalle</a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>

    </main>

</asp:Content>
