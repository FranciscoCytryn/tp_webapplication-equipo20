<%@ Page Title="Carrito de Compras" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TPWebApplication_equipo20.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %></h2>

        <h3>Productos en tu carrito:</h3>

        <!-- Tabla para mostrar los productos en el carrito -->
        <div class="table-responsive">
            <asp:GridView ID="gvCarrito" runat="server" CssClass="table table-dark table-striped" AutoGenerateColumns="false" DataKeyNames="ID" EmptyDataText="No hay productos en el carrito." OnRowDeleting="gvCarrito_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre del Producto" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio Unitario" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />

                    <asp:TemplateField HeaderText="Cantidad">
                        <ItemTemplate>
                            <asp:TextBox ID="txtCantidad" runat="server" Text='<%# Bind("Cantidad") %>' Width="40"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField ButtonType="Button" CommandName="Actualizar" Text="Actualizar" />
                    <asp:CommandField ShowDeleteButton="True" DeleteText="Eliminar" HeaderText="Acciones" />
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <asp:Label ID="lblTotal" runat="server" Text="Total: "></asp:Label>
        <br />
        <asp:Button ID="btnCheckout" runat="server" Text="Proceder al Pago" OnClick="btnCheckout_Click" />
    </main>
</asp:Content>

