using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Productos
    {
        public int IdProductos { get; set; }
        public string Nombre { get; set; }
        public string NumeroMaterial { get; set; }
        public ML.SubSubCategorias SubSubCategorias { get; set; }
        public int Inventario { get; set; }
        public List<object> ProductosObject { get; set; }
    }
}
