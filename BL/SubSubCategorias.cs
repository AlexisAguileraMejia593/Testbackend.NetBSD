using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SubSubCategorias
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.TestbackendNetBSDEntities context = new DL.TestbackendNetBSDEntities())
                {
                    var query = context.SubSubCategoriasGetAll().ToList();
                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var registro in query)
                        { 
                           ML.SubSubCategorias subSubCategorias = new ML.SubSubCategorias();
                           subSubCategorias.IdSubSubCategorias = registro.IdSubSubCategorias;
                           subSubCategorias.Nombre = registro.Nombre;
                           subSubCategorias.SubCategorias = new ML.SubCategorias();
                           subSubCategorias.SubCategorias.IdSubCategorias = registro.IdSubCategorias;
                           result.Objects.Add(subSubCategorias);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros";
                    }
                }
            } catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = true;
            }
            return result;
        }
        public static ML.Result GetById(int IdSubSubCategorias)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.TestbackendNetBSDEntities context = new DL.TestbackendNetBSDEntities())
                {
                    var query = context.SubSubCategoriasGetById(IdSubSubCategorias).FirstOrDefault();
                    if(query != null)
                    {
                        ML.SubSubCategorias subSubCategorias = new ML.SubSubCategorias();
                        subSubCategorias.IdSubSubCategorias = query.IdSubSubCategorias;
                        subSubCategorias.Nombre = query.Nombre;
                        subSubCategorias.SubCategorias = new ML.SubCategorias();
                        subSubCategorias.SubCategorias.IdSubCategorias = query.IdSubCategorias;
                        result.Object = subSubCategorias;

                        result.Correct = true;

                    } else
                    {
                        result.Correct = false;
                    }
                }
            } catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;
        }
        public static ML.Result Add(ML.SubSubCategorias subSubCategorias)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.TestbackendNetBSDEntities context = new DL.TestbackendNetBSDEntities())
                {
                    var query = context.SubSubCategoriasAdd(subSubCategorias.Nombre, subSubCategorias.SubCategorias.IdSubCategorias);
                    if (query >= 1)
                    {
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
                result.Correct = false;
            }
            return result;
        }
        public static ML.Result Update(ML.SubSubCategorias subSubCategorias)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.TestbackendNetBSDEntities context = new DL.TestbackendNetBSDEntities())
                {
                    var query = context.SubSubCategoriasUpdate(subSubCategorias.IdSubSubCategorias, subSubCategorias.Nombre, subSubCategorias.SubCategorias.IdSubCategorias);
                    if(query >= 1)
                    {
                        result.Correct = true;
                    } else
                    {
                        result.Correct = false;
                    }
                }
            } catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;
        }
        public static ML.Result Delete(int IdSubSubCategorias)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.TestbackendNetBSDEntities context = new DL.TestbackendNetBSDEntities())
                {
                    var query = context.SubSubCategoriasDelete(IdSubSubCategorias);
                    if(query >= 1)
                    {
                        result.Correct = true;
                    } else
                    {
                        result.Correct = false;
                    }
                }
            } catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result GetByIdSubCategorias(int IdSubCategorias)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.TestbackendNetBSDEntities context = new DL.TestbackendNetBSDEntities())
                {
                    var query = context.SubSubCategoriasGetByIdSubCategorias(IdSubCategorias).ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var registro in query)
                        {
                            ML.SubSubCategorias subSubCategorias = new ML.SubSubCategorias();
                            subSubCategorias.SubCategorias = new ML.SubCategorias();
                            subSubCategorias.SubCategorias.IdSubCategorias = registro.IdSubCategorias;
                            subSubCategorias.Nombre = registro.Nombre;
                            subSubCategorias.IdSubSubCategorias = registro.IdSubSubCategorias;
                            result.Objects.Add(subSubCategorias);
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
