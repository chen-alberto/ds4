using System;
using System.Collections.Generic;
using System.Web.Http;
using Proyecto_2.Data;
using Proyecto_2.Models;

namespace Proyecto_2.Controllers
{
    [RoutePrefix("api/operaciones")]
    public class OperacionesController : ApiController
    {
        private readonly OperacionRepository _repository;

        public OperacionesController()
        {
            _repository = new OperacionRepository();
        }

        // GET: api/operaciones
        [HttpGet]
        [Route("")]
        public IHttpActionResult ObtenerTodas()
        {
            try
            {
                var operaciones = _repository.ObtenerTodas();
                return Ok(operaciones);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/operaciones/suma
        [HttpGet]
        [Route("{tipoOperacion}")]
        public IHttpActionResult ObtenerPorTipo(string tipoOperacion)
        {
            try
            {
                string simbolo = MapearOperacion(tipoOperacion.ToLower());

                if (simbolo == null)
                {
                    return BadRequest("Tipo de operación no válido. Use: suma, resta, multiplicacion o division");
                }

                var operaciones = _repository.ObtenerPorTipo(simbolo);

                if (operaciones.Count == 0)
                {
                    return NotFound();
                }

                return Ok(operaciones);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        private string MapearOperacion(string tipoOperacion)
        {
            switch (tipoOperacion)
            {
                case "suma": return "+";
                case "resta": return "-";
                case "multiplicacion": return "*";
                case "division": return "/";
                default: return null;
            }
        }
    }
}