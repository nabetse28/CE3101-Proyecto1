using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.DataBase;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api/enfermedad")]
    public class EnfermedadController : ApiController
    {
        [HttpGet]
        [Route("get")]
        public IHttpActionResult Get()
        {
            DataBase.dbEnferemedad con = new DataBase.dbEnferemedad();
            return Ok(con.getEnfermedades());
        }
    }
}
