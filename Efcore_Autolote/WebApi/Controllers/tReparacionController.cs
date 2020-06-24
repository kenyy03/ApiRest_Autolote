using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils.Injection;
using Data.Repositories;
using Entity.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Unity;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class tReparacionController : BaseApiController
    {
        [Dependency]

        public IReparacionRepository _reparacionRepository { get; set; }

        public tReparacionController (IReparacionRepository reparacionRepository)
        {
            _reparacionRepository = reparacionRepository;
        }

        [HttpGet]
        [ActionName("getAll")]

        public IActionResult getAll()
        {
            try
            {
                if (ValidateToken())
                {
                    var data = _reparacionRepository.GetAll();

                    return Ok(data);
                }
                else
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, "Token no valido");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
                throw;
            }
        }

        [HttpPost]
        [ActionName("save")]

        public IActionResult Save([FromBody] Reparacion reparacion)
        {
            try
            {
                if (ValidateToken())
                {
                    var exist = _reparacionRepository.Exist(reparacion.Fecha);

                    if (exist)
                    {
                        return BadRequest("El registro ya existe");
                    }

                    var data = _reparacionRepository.Save(reparacion);
                    if (data)
                    {
                        return Ok(data);
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError);
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, "Token no valido");
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
                throw;
            }
        }

        [HttpGet]
        [ActionName("GetByid")]

        public IActionResult GetByid([FromQuery] int id)
        {
            try
            {
                if (ValidateToken())
                {
                    var data = _reparacionRepository.GetbyId(id);
                    var IsDifferentFromNull = data != null ? true : false;

                    if (IsDifferentFromNull)
                    {
                        return Ok(data);
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError);
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, "Token no valido");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

                throw;
            }
        }
    }
}
