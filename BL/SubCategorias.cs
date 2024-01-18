using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SubCategorias
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.TestbackendNetBSDEntities context = new DL.TestbackendNetBSDEntities())
                {
                    var query = context.SubCategoriasGetAll().ToList();
                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var registro in query)
                        {
                            ML.SubCategorias subCategorias = new ML.SubCategorias();
                            subCategorias.IdSubCategorias = registro.IdSubCategorias;
                            subCategorias.Nombre = registro.Nombre;
                            subCategorias.Categorias = new ML.Categorias();
                            subCategorias.Categorias.IdCategoria = registro.IdCategorias;
                            result.Objects.Add(subCategorias);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron los registros";
                    }
                }
            } catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;
        }
        public static ML.Result GetById(int IdSubCategorias)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.TestbackendNetBSDEntities context = new DL.TestbackendNetBSDEntities())
                {
                    var query = context.SubCategoriasGetById(IdSubCategorias).FirstOrDefault();
                    if (query != null)
                    {
                        ML.SubCategorias subCategorias = new ML.SubCategorias();
                        subCategorias.IdSubCategorias = query.IdSubCategorias;
                        subCategorias.Nombre = query.Nombre;
                        subCategorias.Categorias = new ML.Categorias();
                        subCategorias.Categorias.IdCategoria = query.IdCategorias;
                        result.Object = subCategorias;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            } catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Add(ML.SubCategorias subCategorias)
        {
            ML.Result result = new ML.Result();
            try
            {
                //modificacion de prueba
                using (DL.TestbackendNetBSDEntities context = new DL.TestbackendNetBSDEntities())
                {
                    var query = context.SubCategoriasAdd(
                                                   subCategorias.Nombre,
                                                   subCategorias.Categorias.IdCategoria
                                                   );
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
            }
            return result;
        }
        public static ML.Result Update(ML.SubCategorias subCategorias)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.TestbackendNetBSDEntities context = new DL.TestbackendNetBSDEntities())
                {
                    var query = context.SubCategoriasUpdate(
                        subCategorias.IdSubCategorias,
                        subCategorias.Nombre,
                        subCategorias.Categorias.IdCategoria
                        );
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizó el status de la credencial";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Delete(int IdSubCategorias)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.TestbackendNetBSDEntities context = new DL.TestbackendNetBSDEntities())
                {
                    var registro = context.SubCategoriasDelete(IdSubCategorias);
                    if (registro >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No rows were affected by the delete operation.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetByIdCategorias(int IdCategorias)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.TestbackendNetBSDEntities context = new DL.TestbackendNetBSDEntities())
                {
                    var query = context.SubCategoriasGetByIdCategorias(IdCategorias).ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var registro in query)
                        {
                            ML.SubCategorias subCategorias = new ML.SubCategorias();
                            subCategorias.IdSubCategorias = registro.IdSubCategorias;
                            subCategorias.Nombre = registro.Nombre;
                            subCategorias.Categorias = new ML.Categorias();
                            subCategorias.Categorias.IdCategoria = registro.IdCategorias;
                            result.Objects.Add(subCategorias);
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
            }
            return result;
        }
    }
}
