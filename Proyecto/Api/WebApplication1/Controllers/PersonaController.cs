using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.DataBase;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api/persona")]
    public class PersonaController : ApiController
    {
        [HttpGet]
        [Route("get")]
        public IHttpActionResult Get()
        {
            dbPersona con = new dbPersona();
            return Ok(con.getPersonas());
        }
    }
}
