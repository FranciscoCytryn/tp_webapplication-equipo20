using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio
{
    public class Marca
    {
        public Marca() { }
        public Marca(int id, string descripcion)
        {
            ID = id;
            Descripcion = descripcion;
        }
        public int ID { get; set; }
        public string Descripcion { get; set; }
        

        public override string ToString()
        {
            return Descripcion;
        }
    }
}