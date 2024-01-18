using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Productos
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.TestbackendNetBSDEntities context = new DL.TestbackendNetBSDEntities())
                {
                    var query = context.ProductosGetAll().ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var registro in query)
                        {
                            ML.Productos productos = new ML.Productos();
                            productos.IdProductos = registro.IdProductos;
                            productos.Nombre = registro.Nombre;
                            productos.NumeroMaterial = registro.NumeroMaterial;
                            productos.SubSubCategorias = new ML.SubSubCategorias();
                            productos.SubSubCategorias.IdSubSubCategorias = registro.IdSubSubCategorias;
                            productos.Inventario = registro.Inventario;
                            result.Objects.Add(productos);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = true;
            }
            return result;
        }
        public static ML.Result GetById(int IdProductos)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.TestbackendNetBSDEntities context = new DL.TestbackendNetBSDEntities())
                {
                    var query = context.ProductosGetById(IdProductos).FirstOrDefault();
                    if (query != null)
                    {
                        ML.Productos productos = new ML.Productos();
                        productos.IdProductos = query.IdProductos;
                        productos.Nombre = query.Nombre;
                        productos.NumeroMaterial = query.NumeroMaterial;
                        productos.SubSubCategorias = new ML.SubSubCategorias();
                        productos.SubSubCategorias.IdSubSubCategorias = query.IdSubSubCategorias;
                        productos.Inventario = query.Inventario;
                        result.Object = productos;

                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;
        }
        public static ML.Result Add(ML.Productos productos)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.TestbackendNetBSDEntities context = new DL.TestbackendNetBSDEntities())
                {
                    var query = context.ProductosAdd(productos.Nombre, productos.NumeroMaterial, productos.SubSubCategorias.IdSubSubCategorias, productos.Inventario);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;
        }
        public static ML.Result Update(ML.Productos productos)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.TestbackendNetBSDEntities context = new DL.TestbackendNetBSDEntities())
                {
                    var query = context.ProductosUpdate(productos.IdProductos, productos.Nombre, productos.NumeroMaterial, productos.SubSubCategorias.IdSubSubCategorias, productos.Inventario);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;
        }
        public static ML.Result Delete(int IdProductos)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.TestbackendNetBSDEntities context = new DL.TestbackendNetBSDEntities())
                {
                    var query = context.ProductosDelete(IdProductos);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result GetByIdSubSubCategorias(int IdSubSubCategorias)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.TestbackendNetBSDEntities context = new DL.TestbackendNetBSDEntities())
                {
                    var query = context.ProductosGetByIdSubSubCategorias(IdSubSubCategorias).ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var registro in query)
                        {
                            ML.Productos productos = new ML.Productos();
                            productos.IdProductos = registro.IdProductos;
                            productos.Nombre = registro.Nombre;
                            productos.NumeroMaterial = registro.NumeroMaterial;
                            productos.SubSubCategorias = new ML.SubSubCategorias();
                            productos.SubSubCategorias.IdSubSubCategorias = registro.IdSubSubCategorias;
                            productos.Inventario = registro.Inventario;
                            result.Objects.Add(productos);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;
        }
    }
}
