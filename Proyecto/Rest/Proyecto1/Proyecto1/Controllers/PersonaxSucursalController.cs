using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proyecto1.Controllers
{
    [RoutePrefix("api/PersonaxSucursal")]
    public class PersonaxSucursalController : ApiController
    {

        [HttpGet]
        [Route("GetAllPersonaxSucursal")]
        public IHttpActionResult GetAllPersonaxSucursal()
        {
            PersonaxSucursalService con = new PersonaxSucursalService();
            return Ok(con.GetAllMedicamentoxSucursal());
        }

        [HttpPost]
        [Route("PostPersonaxSucursal")]
        public void PostMedicamento([FromBody] PersonaxSucursal mxs)
        {
            PersonaxSucursalService con = new PersonaxSucursalService();
            con.PostPersonaxSucursal(mxs);
        }
}
