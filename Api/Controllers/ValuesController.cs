using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class ValuesController : ApiController
    {
        private DashboardRepository _repo = new DashboardRepository();


        [HttpGet]
        [Route("ping")]
        public IHttpActionResult NotSecured()
        {
            return this.Ok();
        }

        [Authorize]
        [HttpGet]
        [Route("secured/ping")]
        public IHttpActionResult Secured()
        {
            return this.Ok("All good. You only get this message if you are authenticated.");
        }

        
    }
}
