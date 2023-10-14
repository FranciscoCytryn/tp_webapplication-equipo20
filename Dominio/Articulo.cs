using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Dominio
{
    public class Articulo
    {
        public int ID { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public decimal Precio { get; set; }
        public List<Imagen> Imagenes { get; set; }
        public string ImagenURL
        {
            get
            {
                if (Imagenes != null && Imagenes.Count > 0 && !string.IsNullOrEmpty(Imagenes[0].ImagenURL))
                    return Imagenes[0].ImagenURL;
                return "https://upload.wikimedia.org/wikipedia/commons/thumb/d/da/Imagen_no_disponible.svg/1200px-Imagen_no_disponible.svg.png";
            }
        }
    }
}
