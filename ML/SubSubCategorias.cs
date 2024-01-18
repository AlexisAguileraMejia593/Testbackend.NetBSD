using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class SubSubCategorias
    {
        public int IdSubSubCategorias { get; set; }
        public string Nombre { get; set; }
        public ML.SubCategorias SubCategorias { get; set; }
        public List<object> SubSubCategoriasObject { get; set; }
    }
}
