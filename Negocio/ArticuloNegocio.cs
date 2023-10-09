using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            try
            {
                datos.setearConsulta("SELECT A.Id, Codigo, Nombre, A.Descripcion, Precio, C.Descripcion CATEGORIA, M.Descripcion Marca, A.IdMarca, A.IdCategoria FROM ARTICULOS A, CATEGORIAS C, MARCAS M WHERE C.Id = A.IdCategoria AND M.id = A.idMarca");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.ID = (int)datos.Lector["Id"];
                    aux.Codigo = datos.Lector["Codigo"]?.ToString();
                    aux.Nombre = datos.Lector["Nombre"]?.ToString();
                    aux.Descripcion = datos.Lector["Descripcion"]?.ToString();
                    aux.Precio = (decimal)(datos.Lector["Precio"] ?? 0);
                    aux.Categoria = new Categoria { Descripcion = datos.Lector["CATEGORIA"]?.ToString(), ID = (int)(datos.Lector["IdCategoria"] ?? 0) };
                    aux.Marca = new Marca { Descripcion = datos.Lector["Marca"]?.ToString(), ID = (int)(datos.Lector["IdMarca"] ?? 0) };
                    
                    
                    aux.Imagenes = imagenNegocio.Listar(aux.ID);

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void modificar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            try
            {
                datos.setearConsulta("UPDATE ARTICULOS SET Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idCategoria, Precio = @precio WHERE id = @id");

                datos.agregarParametro("@codigo", articulo.Codigo);
                datos.agregarParametro("@nombre", articulo.Nombre);
                datos.agregarParametro("@descripcion", articulo.Descripcion);
                datos.agregarParametro("@idMarca", articulo.Marca.ID);
                datos.agregarParametro("@idCategoria", articulo.Categoria.ID);
                datos.agregarParametro("@precio", articulo.Precio);
                datos.agregarParametro("@id", articulo.ID);

                datos.ejecutarAccion();


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void agregar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            ImagenNegocio imagenNegocio = new ImagenNegocio();

            try
            {
                datos.setearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, Precio, IdMarca, IdCategoria) output inserted.Id values(@codigo, @nombre, @descripcion, @precio, @idMarca, @idCategoria)");

                datos.agregarParametro("@codigo", articulo.Codigo);
                datos.agregarParametro("@nombre", articulo.Nombre);
                datos.agregarParametro("@descripcion", articulo.Descripcion);
                datos.agregarParametro("@precio", articulo.Precio);
                datos.agregarParametro("@idMarca", articulo.Marca.ID);
                datos.agregarParametro("@idCategoria", articulo.Categoria.ID);

                var articuloId = (int)datos.ejecutarAccionReturn();



                if (articulo.Imagenes == null || !articulo.Imagenes.Any())
                {
                    articulo.Imagenes = new List<Imagen>();
                    Imagen imagenDefault = new Imagen
                    {
                        ImagenURL = "https://socialistmodernism.com/wp-content/uploads/2017/07/placeholder-image.png?w=640",
                        IdArticulo = articuloId  
                    };
                    articulo.Imagenes.Add(imagenDefault);
                }
                /*foreach (var imagen in articulo.Imagenes) 
                {
                    imagen.IdArticulo = articuloId; 
                    imagenNegocio.Agregar(imagen);
                }*/
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Delete From ARTICULOS Where id = " + id);
  
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
