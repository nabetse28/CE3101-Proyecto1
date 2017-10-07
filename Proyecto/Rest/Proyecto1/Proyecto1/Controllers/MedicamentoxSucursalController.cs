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
    [RoutePrefix("api/MedicamentoxSucursal")]
    public class MedicamentoxSucursalController : ApiController
    {
        [HttpGet]
        [Route("GetAllMedicamentoxSucursal")]
        public IHttpActionResult GetAllMedicamentoxCasaFarmaceutica()
        {
            MedicamentoxSucursalService con = new MedicamentoxSucursalService();
            return Ok(con.GetAllMedicamentoxSucursal());
        }

        [HttpPost]
        [Route("PostMedicamentoxSucursal")]
        public void PostMedicamento([FromBody] MedicamentoxSucursal mxs)
        {
            MedicamentoxSucursalService con = new MedicamentoxSucursalService();
            con.PostMedicamentoxSucursal(mxs);
        }
    }
}
