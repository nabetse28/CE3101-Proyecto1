using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Proyecto1.Services;
using Proyecto1.Classes;


namespace Proyecto1.Controllers
{
    [RoutePrefix("api/Persona")]
    public class PersonaController : ApiController
    {
        [HttpGet]
        [Route("GetAllPersonas")]
        public IHttpActionResult GetAllPersonas()
        {
            PersonaService con = new PersonaService();
            return Ok(con.GetAllPersonas());
        }
         
        [HttpPost]
        [Route("PostPersona")]
        public void PostPersona([FromBody] Persona persona)
        {
            PersonaService con = new PersonaService();
            con.PostPersona(persona);
        }

        [HttpGet]
        [Route("SignInVerification")]
        public IHttpActionResult SignInVerification(int id, string contraseña)
        {
            PersonaService con = new PersonaService();
            return Ok(con.SignInVerification(id,contraseña)); 
        }


    }
}
