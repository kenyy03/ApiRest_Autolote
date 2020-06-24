using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Repositories;
using Entity.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Unity;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class tAutoController : BaseApiController
    {
        #region Campos

        [Dependency]
        public IAutoRepository _autoRepository { get; set; }

        public tAutoController(IAutoRepository autoRepository)
        {
            this._autoRepository = autoRepository;
        }

        #endregion

        #region Acciones

        [HttpGet]
        [ActionName("getAll")]

        public IActionResult getAll()
        {
            try
            {
                if (ValidateToken())
                {
                    var data = _autoRepository.GetAll();

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

        public IActionResult Save([FromBody] Auto auto)
        {
            try
            {
                if (ValidateToken())
                {
                    var exist = _autoRepository.Exist(auto.Marca);
                    
                    if (exist)
                    {
                        return BadRequest("El registro ya existe");
                    }

                    var data = _autoRepository.Register(auto);
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
                    var data = _autoRepository.SearchToId(id);
                    var IsDifferentFromNull = data != null ? true : false;

                    if (IsDifferentFromNull)
                    {
                        return Ok(data);
                    }
                    else
                    {
                        return BadRequest("No se encontro el registro");
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, "Token no valido");
                }
            }
            catch (Exception)
            {
                return BadRequest("No se encontro el registro");
                throw;
            }
        }

        #endregion 
    }
}
