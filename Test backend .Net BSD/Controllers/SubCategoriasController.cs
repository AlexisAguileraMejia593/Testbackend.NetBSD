using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test_backend.Net_BSD.Controllers
{
    public class SubCategoriasController : Controller
    {
        // GET: Categorias
        public ActionResult Index()
        {
            ML.SubCategorias subCategorias = new ML.SubCategorias();
            ML.Result result = BL.SubCategorias.GetAll();
            subCategorias.SubCategoriasObject = result.Objects;
            return View(subCategorias);
        }
        [HttpGet]
        public ActionResult Form(int? IdSubCategorias)
        {
            ML.SubCategorias subCategorias = new ML.SubCategorias();
            subCategorias.Categorias = new ML.Categorias();
            ML.Result result1 = BL.Categorias.GetAll();
            if (IdSubCategorias != null)
            {
                ML.Result result = BL.SubCategorias.GetById(IdSubCategorias.Value);
                if (result.Correct)
                {
                    //UNBOXING
                    subCategorias = (ML.SubCategorias)result.Object;
                    subCategorias.Categorias.Categoriasobject = result1.Objects;
                }
            }
            else
            {
                subCategorias.Categorias.Categoriasobject = result1.Objects;
            }
            return View(subCategorias);
        }
        [HttpPost]
        public ActionResult Form(ML.SubCategorias subCategorias)
        {
            if (ModelState.IsValid)
            {
                if (subCategorias.IdSubCategorias == 0) //ADD
                {
                    ML.Result result = BL.SubCategorias.Add(subCategorias);
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
                    ML.Result result = BL.SubCategorias.Update(subCategorias);
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
        public ActionResult Delete(int IdSubCategorias)
        {
            ML.Result result = BL.SubCategorias.Delete(IdSubCategorias);
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