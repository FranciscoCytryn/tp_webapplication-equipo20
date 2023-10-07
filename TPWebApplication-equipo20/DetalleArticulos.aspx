<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleArticulos.aspx.cs" Inherits="TPWebApplication_equipo20.DetalleArticulos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="row row-cols-1 row-cols-md-3 g-4">
                <% 
                    foreach (Dominio.Articulo articulo in ArticuloList)
                    {
                %>

                <%     
                    if (idRecibido == articulo.ID)
                    {
                %>
                    < div class="card" style="width: 18rem;">
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



            <%      } %>
            <%} %>
        </div>
        
    </form>
</body>
</html>
