﻿using Proyecto1.Classes;
using Proyecto1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proyecto1.Controllers
{
    [RoutePrefix("api/EnfermedadxPersona")]
    public class EnfermedadxPersonaController : ApiController
    {
        [HttpGet]
        [Route("GetAllEnfermedadxPersona")]
        public IHttpActionResult GetAllMedicamentos()
        {
            EnfermedadxPersonaService con = new EnfermedadxPersonaService();
            return Ok(con.GetAllEnfermedadxPersona());
        }

        [HttpPost]
        [Route("PostMedicamento")]
        public void PostMedicamento([FromBody] EnfermedadxPersona exp)
        {
            EnfermedadxPersonaService con = new EnfermedadxPersonaService();
            con.PostEnfermedadxPersona(exp);
        }
    }
}
