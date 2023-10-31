<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPWebApplication_equipo20._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">CommerceManager System WEB 1.0</h1>
            <p class="lead">Bienvenidos al sitio número 1 de compras online</p>
        </section>

    <div class="container">
        <h3>Filtros</h3>
        <div class="row">
            <div class="col-md-3">
                <div class="form-group">
                    <label for="marcaDropdown">Marca</label>
                    <asp:DropDownList ID="marcaDropdown" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-md-3">
                <div class="form-group">
                    <label for="categoriaDropdown">Categoría</label>
                    <asp:DropDownList ID="categoriaDropdown" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-md-3">
                <div class="form-group">
                    <label for="precioTextBox">Precio Máximo</label>
                    <asp:TextBox ID="precioTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
         
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Button ID="btnFiltrar" runat="server" CssClass="btn btn-primary" Text="Aplicar Filtros" OnClick="btnFiltrar_Click" />
            </div>
        </div>
    </div>
    <hr>


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
                            <p></p>
                            <div class="quantity d-flex justify-content-center align-items-center">
                                <asp:Button ID="btnDecrement" runat="server" Text="-" CssClass="btn btn-sm btn-secondary" OnClick="btnDecrement_Click" UseSubmitBehavior="false"/>
                                <asp:TextBox ID="quantity" runat="server" CssClass="custom-form-control text-center" Text="1" />
                                <asp:Button ID="btnIncrement" runat="server" Text="+" CssClass="btn btn-sm btn-secondary" OnClick="btnIncrement_Click" UseSubmitBehavior="false"/>
                            </div>
                            <p></p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>

    </main>

</asp:Content>
