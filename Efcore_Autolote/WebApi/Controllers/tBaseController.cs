using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.DbModels;
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
    public class tBaseController : BaseApiController
    {
        #region Campos

        [Dependency]

        public IBaseRepository _baseRepository { get; set; }

        public tBaseController(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
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
                    var data = _baseRepository.GetAll();
                    
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

        public IActionResult Save([FromBody] Base pbase)
        {
            try
            {
                if (ValidateToken())
                {
                    var exist = _baseRepository.Exist(pbase.Nombre);

                    if (exist)
                    {
                        return BadRequest("El registro ya existe");
                    }

                    var data = _baseRepository.Save(pbase);
                    if (data)
                    {
                        return Created("", data);
                    }
                    else
                    {
                        return Ok(data);
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
        [ActionName("getByid")]

        public IActionResult GetByid([FromQuery] int id)
        {
            try
            {
                if (ValidateToken())
                {

                    var data = _baseRepository.GetbyId(id);
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
