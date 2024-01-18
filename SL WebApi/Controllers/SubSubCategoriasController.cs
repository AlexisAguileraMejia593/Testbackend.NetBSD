using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebApi.Controllers
{
    [RoutePrefix("api/SubSubCategorias")]
    public class SubSubCategoriasController : ApiController
    {
        [Route("Add")]
        [HttpPost]
        public IHttpActionResult Add([FromBody] ML.SubSubCategorias subSubCategorias)
        {
            ML.Result result = BL.SubSubCategorias.Add(subSubCategorias);
            if (result.Correct)
            {
                return Ok(result.ErrorMessage = "Se ha agregado correctamente");
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result.ErrorMessage = "No se encontro el servicio");
            }
        }
        [Route("Update/{idSubSubCategorias?}")]
        [HttpPut]
        public IHttpActionResult Update(int idSubSubCategorias, [FromBody] ML.SubSubCategorias subSubCategorias)
        {
            subSubCategorias.IdSubSubCategorias = idSubSubCategorias;
            ML.Result result = BL.SubSubCategorias.Update(subSubCategorias);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result.ErrorMessage = "Se ha actualizado Correctamente");
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result.ErrorMessage = "No se encontro el servicio");
            }
        }

        [Route("Delete/{idSubSubCategorias?}")]
        [HttpDelete]
        public IHttpActionResult Delete(int idSubSubCategorias)
        {
            ML.Result result = BL.SubSubCategorias.Delete(idSubSubCategorias);
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
            ML.Result result = BL.SubSubCategorias.GetAll();
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result.Objects);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result.ErrorMessage = "Error al encontrar los registros");
            }
        }
        [Route("GetById/{idSubSubCategorias?}")]
        [HttpGet]
        public IHttpActionResult GetById(int idSubSubCategorias)
        {
            ML.Result result = BL.SubSubCategorias.GetById(idSubSubCategorias);
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
