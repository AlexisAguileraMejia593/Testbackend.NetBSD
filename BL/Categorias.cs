using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Categorias
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.TestbackendNetBSDEntities context = new DL.TestbackendNetBSDEntities())
                {
                    var query = context.CategoriasGetAll().ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var registro in query)
                        {
                            ML.Categorias categoria = new ML.Categorias();
                            categoria.IdCategoria = registro.IdCategorias;
                            categoria.Nombre = registro.Nombre;
                            result.Objects.Add(categoria);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "NO SE PUDO MOSTRAR TODA LA TABLA";
                    }
                }
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.Message;
                result.Correct = false;
            }
            return result;
        }
    }
}
