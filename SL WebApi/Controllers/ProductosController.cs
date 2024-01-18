using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebApi.Controllers
{
    [RoutePrefix("api/Productos")]
    public class ProductosController : ApiController
    {
        [Route("Add")]
        [HttpPost]
        public IHttpActionResult Add([FromBody] ML.Productos productos)
        {
            ML.Result result = BL.Productos.Add(productos);
            if (result.Correct)
            {
                return Ok(result.ErrorMessage = "Se ha agregado correctamente");
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result.ErrorMessage = "No se encontro el servicio");
            }
        }
        [Route("Update/{idProductos?}")]
        [HttpPut]
        public IHttpActionResult Update(int idProductos, [FromBody] ML.Productos productos)
        {
            productos.IdProductos = idProductos;
            ML.Result result = BL.Productos.Update(productos);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result.ErrorMessage = "Se ha actualizado Correctamente");
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result.ErrorMessage = "No se encontro el servicio");
            }
        }

        [Route("Delete/{idProductos?}")]
        [HttpDelete]
        public IHttpActionResult Delete(int idProductos)
        {
            ML.Result result = BL.Productos.Delete(idProductos);
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
            ML.Result result = BL.Productos.GetAll();
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result.Objects);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result.ErrorMessage = "Error al encontrar los registros");
            }
        }
        [Route("GetById/{idProductos?}")]
        [HttpGet]
        public IHttpActionResult GetById(int idProductos)
        {
            ML.Result result = BL.Productos.GetById(idProductos);
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
