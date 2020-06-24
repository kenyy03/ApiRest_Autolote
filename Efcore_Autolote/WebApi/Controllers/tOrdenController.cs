using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Repositories;
using Utils.Injection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Unity;
using Entity.DBModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class tOrdenController : BaseApiController
    {
        [Dependency]
        public IOrdenRepository _ordenRepository { get; set; }


        public tOrdenController (IOrdenRepository ordenRepository)
        {
            _ordenRepository = ordenRepository;
        }


        [HttpGet]
        [ActionName("getAll")]

        public IActionResult getAll()
        {
            try
            {
                if (ValidateToken())
                {
                    var data = _ordenRepository.GetAll();
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

        public IActionResult Save([FromBody] Orden orden)
        {
            try
            {
                if (ValidateToken())
                {
                    var exist = _ordenRepository.Exist(orden.Fecha);
                    if (exist)
                    {
                        return BadRequest("El registro ya existe");
                    }

                    var data = _ordenRepository.Save(orden);
                    if (data)
                    {
                        return Created("", data);
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
                    var data = _ordenRepository.GetbyId(id);
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
