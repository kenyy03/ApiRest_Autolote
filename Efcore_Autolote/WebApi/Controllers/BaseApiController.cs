using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        public Guid TokenServer = new Guid("4c814c94-dc96-439a-93fc-a07ae1e10a4d");
        public bool ValidateToken()
        {
            var req = Request.Headers[HeaderNames.Authorization];
            var sreq = req.ToString();
            sreq = sreq.Replace("Bearer", "");
            var tokenRequest = new Guid(sreq);

            if (tokenRequest == TokenServer)
                return true;
            else
                return false;
        }
    }
}
