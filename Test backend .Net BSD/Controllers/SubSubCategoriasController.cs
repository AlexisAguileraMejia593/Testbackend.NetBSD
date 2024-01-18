using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test_backend.Net_BSD.Controllers
{
    public class SubSubCategoriasController : Controller
    {
        // GET: SubSubCategorias
        public ActionResult Index()
        {
            ML.SubSubCategorias subSubCategorias = new ML.SubSubCategorias();
            ML.Result result = BL.SubSubCategorias.GetAll();
            subSubCategorias.SubSubCategoriasObject = result.Objects;
            return View(subSubCategorias);
        }
        [HttpGet]
        public ActionResult Form(int? IdSubSubCategorias)
        {
            ML.SubSubCategorias subSubCategorias = new ML.SubSubCategorias();
            subSubCategorias.SubCategorias = new ML.SubCategorias();
            ML.Result result1 = BL.SubCategorias.GetAll();
            if (IdSubSubCategorias != null)
            {
                ML.Result result = BL.SubSubCategorias.GetById(IdSubSubCategorias.Value);
                if (result.Correct)
                {
                    //UNBOXING
                    subSubCategorias = (ML.SubSubCategorias)result.Object;
                    subSubCategorias.SubCategorias.SubCategoriasObject = result1.Objects;
                }
            }
            else
            {
                subSubCategorias.SubCategorias.SubCategoriasObject = result1.Objects;
            }
            return View(subSubCategorias);
        }
        [HttpPost]
        public ActionResult Form(ML.SubSubCategorias subSubCategorias)
        {
            if (ModelState.IsValid)
            {
                if (subSubCategorias.IdSubSubCategorias == 0) //ADD
                {
                    ML.Result result = BL.SubSubCategorias.Add(subSubCategorias);
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
                    ML.Result result = BL.SubSubCategorias.Update(subSubCategorias);
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
        public ActionResult Delete(int IdSubSubCategorias)
        {
            ML.Result result = BL.SubSubCategorias.Delete(IdSubSubCategorias);
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