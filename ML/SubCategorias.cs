using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class SubCategorias
    {
        public int IdSubCategorias { get; set; }
        public string Nombre { get; set; }
        public ML.Categorias Categorias { get; set; }
        public List<object> SubCategoriasObject { get; set; }
    }
}
