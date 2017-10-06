﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Proyecto1.Services;
using Proyecto1.Classes;

namespace Proyecto1.Controllers
{
    [RoutePrefix("api/Sucursal")]
    public class SucursalController : ApiController
    {
        [HttpGet]
        [Route("GetAllSucursales")]
        public IHttpActionResult GetAllSucursales()
        {
            SucursalService con = new SucursalService();
            return Ok(con.GetAllSucursales());
        }

        [HttpPost]
        [Route("PostSucursal")]
        public void PostSucursal([FromBody] Sucursal sucursal)
        {
            SucursalService con = new SucursalService();
            con.PostSucursal(sucursal);
        }
    }
}