using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test_backend.Net_BSD.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        [HttpGet]
        public ActionResult Index()
        {
            ML.Productos productos = new ML.Productos();
            productos.SubSubCategorias = new ML.SubSubCategorias();
            productos.SubSubCategorias.SubCategorias = new ML.SubCategorias();
            productos.SubSubCategorias.SubCategorias.Categorias = new ML.Categorias();
            ML.Result result3 = BL.Categorias.GetAll();
            ML.Result result2 = BL.SubCategorias.GetAll();
            ML.Result result1 = BL.SubSubCategorias.GetAll();
            ML.Result result = BL.Productos.GetAll();
            productos.SubSubCategorias.SubCategorias.Categorias.Categoriasobject = result3.Objects;
            productos.SubSubCategorias.SubCategorias.SubCategoriasObject = result2.Objects;
            productos.SubSubCategorias.SubSubCategoriasObject = result1.Objects;
            productos.ProductosObject = result.Objects;
            return View(productos);
        }
        public JsonResult SubCategoriasGetByIdCategorias(int IdCategorias)
        {
            ML.Result result = BL.SubCategorias.GetByIdCategorias(IdCategorias);
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SubSubCategoriasGetByIdSubCategorias(int IdSubCategorias)
        {
            ML.Result result = BL.SubSubCategorias.GetByIdSubCategorias(IdSubCategorias);
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ProductosGetByIdSubSubCategorias(int IdSubSubCategorias)
        {
            ML.Result result = BL.Productos.GetByIdSubSubCategorias(IdSubSubCategorias);
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Index(ML.SubSubCategorias subSubCategorias)
        {
            return View(subSubCategorias);
        }
        [HttpGet]
        public ActionResult Form(int? IdProductos)
        {
            ML.Productos productos = new ML.Productos();
            productos.SubSubCategorias = new ML.SubSubCategorias();
            ML.Result result1 = BL.SubSubCategorias.GetAll();
            if (IdProductos != null)
            {
                ML.Result result = BL.Productos.GetById(IdProductos.Value);
                if (result.Correct)
                {
                    //UNBOXING
                    productos = (ML.Productos)result.Object;
                    productos.SubSubCategorias.SubSubCategoriasObject = result1.Objects;
                }
            }
            else
            {
                productos.SubSubCategorias.SubSubCategoriasObject = result1.Objects;
            }
            return View(productos);
        }
        [HttpPost]
        public ActionResult Form(ML.Productos productos)
        {
            if (ModelState.IsValid)
            {
                if (productos.IdProductos == 0) //ADD
                {
                    ML.Result result = BL.Productos.Add(productos);
                    if (result.Correct)
                    {
                        ViewBag.Mensaje = "Se ha completado el registro";
                    }
                    else
                    {
                        ViewBag.Mensaje = "Error" + result.ErrorMessage;

                    }
                }
                else //UPDATE
                {
                    ML.Result result = BL.Productos.Update(productos);
                    if (result.Correct)
                    {
                        ViewBag.Mensaje = "Se ha completado la actualizacion";
                    }
                    else
                    {
                        ViewBag.Mensaje = "Error" + result.ErrorMessage;
                    }
                }
            }
            else
            {

            }
            return PartialView("Modal");
        }
        public ActionResult Delete(int IdProductos)
        {
            ML.Result result = BL.Productos.Delete(IdProductos);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Se ha eliminado exitosamente!!!";
            }
            else
            {
                ViewBag.Mensaje = "Error" + result.ErrorMessage;
            }
            return PartialView("Modal");
        }
    }
}