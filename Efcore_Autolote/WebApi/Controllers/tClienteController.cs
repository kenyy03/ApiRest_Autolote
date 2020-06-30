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
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class tClienteController : BaseApiController
    {
        [Dependency]
        public IClienteRepository _clienteRepository { get; set; }

        public tClienteController (IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        [ActionName("getAll")]

        public IActionResult getAll()
        {
            try
            {
                if (ValidateToken())
                {
                    var data = _clienteRepository.GetAll();
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

        public IActionResult Save([FromBody] Cliente cliente)
        {
            try
            {
                if (ValidateToken())
                {

                    var exist = _clienteRepository.Exist(cliente.Nombre);

                    if (exist)
                    { 
                        return BadRequest("El registro ya existe");
                    }

                    var data = _clienteRepository.Save(cliente);
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
        [ActionName("GetByid")]

        public IActionResult GetByid ([FromQuery] int id)
        {
            try
            {
                if (ValidateToken())
                {
                    var data = _clienteRepository.GetbyId(id);
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
                return StatusCode(StatusCodes.Status500InternalServerError, "No se encontro el registro");
                throw;
            }
        }

        [HttpDelete]
        [ActionName("Delete")]

        public IActionResult Delete([FromQuery] int id)
        {
            try
            {
                if (ValidateToken())
                {
                    var exist = _clienteRepository.Exist(id);

                    if (exist)
                    {
                        var data = _clienteRepository.Delete(id);
                        return Ok(data);
                    }
                    else
                    {
                        return BadRequest("No se pudo eliminar el registro");
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

        [HttpPut]
        [ActionName("Update")]

        public IActionResult Update([FromBody] Cliente cliente)
        {
            try
            {
                if (ValidateToken())
                {
                    var exist = _clienteRepository.Exist(cliente.IdCliente);

                    if (exist)
                    {
                        var data = _clienteRepository.Update(cliente);
                        return Ok(data);
                    }
                    else
                    {
                        return BadRequest("No se actualizo el registro");
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
