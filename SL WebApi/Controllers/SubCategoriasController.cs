using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebApi.Controllers
{
    [RoutePrefix("api/SubCategorias")]
    public class SubCategoriasController : ApiController
    {
        [Route("Add")]
        [HttpPost]
        public IHttpActionResult Add([FromBody] ML.SubCategorias subCategorias)
        {
            ML.Result result = BL.SubCategorias.Add(subCategorias);
            if (result.Correct)
            {
                return Ok(result.ErrorMessage = "Se ha agregado correctamente");
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result.ErrorMessage = "No se encontro el servicio");
            }
        }
        [Route("Update/{idSubCategorias?}")]
        [HttpPut]
        public IHttpActionResult Update(int idSubCategorias, [FromBody] ML.SubCategorias subCategorias)
        {
            subCategorias.IdSubCategorias = idSubCategorias;
            ML.Result result = BL.SubCategorias.Update(subCategorias);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result.ErrorMessage = "Se ha actualizado Correctamente");
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result.ErrorMessage = "No se encontro el servicio");
            }
        }

        [Route("Delete/{idSubCategorias?}")]
        [HttpDelete]
        public IHttpActionResult Delete(int idSubCategorias)
        {
            ML.Result result = BL.SubCategorias.Delete(idSubCategorias);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result.ErrorMessage = "Se a eliminado correctamente");
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.SubCategorias.GetAll();
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result.Objects);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result.ErrorMessage = "Error al encontrar los registros");
            }
        }
        [Route("GetById/{idSubCategorias?}")]
        [HttpGet]
        public IHttpActionResult GetById(int idSubCategorias)
        {
            ML.Result result = BL.SubCategorias.GetById(idSubCategorias);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result.Object);

            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result.ErrorMessage = "Error al encontrar los registros");
            }
        }
    }
}
