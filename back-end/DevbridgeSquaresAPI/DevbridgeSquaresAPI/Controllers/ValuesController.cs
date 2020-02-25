using APIApplication;
using Database.Models;
using DevbridgeSquaresAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace DevbridgeSquaresAPI.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly Application _application;
        public ValuesController()
        {
            _application = new Application();
        }
        // GET api/values
        public IEnumerable<PointModel> Get()
        {
            return _application.GetPoints();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] PointsModel points)
        {
            _application.Add(null, points.Points);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
