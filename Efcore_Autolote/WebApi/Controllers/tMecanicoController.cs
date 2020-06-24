using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utils.Injection;
using Unity;
using Data.Repositories;
using Entity.DBModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class tMecanicoController : BaseApiController
    {
        [Dependency]

        public IMecanicoRepository _mecanicoRepository { get; set; }

        public tMecanicoController(IMecanicoRepository mecanicoRepository)
        {
            _mecanicoRepository = mecanicoRepository;
        }

        [HttpGet]
        [ActionName("getAll")]

        public IActionResult getAll()
        {
            try
            {
                if (ValidateToken())
                {
                    var data = _mecanicoRepository.GetAll();
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

        public IActionResult Save([FromBody] Mecanico mecanico)
        {
            try
            {
                var exist = _mecanicoRepository.Exist(mecanico.Nombre);

                if (exist)
                {
                    return BadRequest("El Registro ya existe");
                }

                var data = _mecanicoRepository.Save(mecanico);

                if (data)
                {
                    return Ok(data);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
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
                    var data = _mecanicoRepository.GetbyId(id);
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
