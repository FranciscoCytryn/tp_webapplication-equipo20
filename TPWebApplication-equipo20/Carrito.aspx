﻿<%@ Page Title="Carrito de Compras" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TPWebApplication_equipo20.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %></h2>

        <h3>Productos en tu carrito:</h3>

        <!-- Tabla para mostrar los productos en el carrito -->
        <div class="table-responsive">
            <asp:GridView ID="gvCarrito" runat="server" CssClass="table table-dark table-striped" AutoGenerateColumns="false" DataKeyNames="ID" EmptyDataText="No hay productos en el carrito." OnRowDeleting="gvCarrito_RowDeleting" OnRowCommand="gvCarrito_RowCommand">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre del Producto" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio Unitario" DataFormatString="{0:C}" />
                    <asp:TemplateField HeaderText="Cantidad">
                        <ItemTemplate>
                            <asp:Button ID="btnDecrement" runat="server" Text="-" CommandName="Decrement" CommandArgument='<%# Eval("ID") %>' CssClass="btn btn-secondary btn-sm" OnClientClick="return confirmDecrement(this);"/>
                            <asp:Label ID="lblCantidad" runat="server" Text='<%# Eval("Cantidad") %>'></asp:Label>
                            <asp:Button ID="btnIncrement" runat="server" Text="+" CommandName="Increment" CommandArgument='<%# Eval("ID") %>' CssClass="btn btn-secondary btn-sm" />
                         </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowDeleteButton="True" DeleteText="Eliminar" HeaderText="Acciones" />
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <asp:Label ID="lblTotal" runat="server" Text="Total: "></asp:Label>
        <br />
        <asp:Button ID="btnCheckout" runat="server" Text="Proceder al Pago" OnClientClick="mostrarMensaje(); return false;" />
        <script type="text/javascript">
            function mostrarMensaje() {
                alert("Función aún no disponible. Versión de prueba.");
            }
        </script>
        <p></p>
        <asp:Button ID="btnVolver" runat="server" Text="Volver al catalogo" OnClick="btnVolver_Click" />
    </main>
</asp:Content>

