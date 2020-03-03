using APIApplication;
using Database.Models;
using DevbridgeSquaresAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
        // GET api/values/Get
        [HttpGet]
        public IEnumerable<PointModel> Get()
        {
            return _application.GetPoints();
        }
        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }


        // POST api/values/PostPoint
        [HttpPost]
        public PostModel PostPoint([FromBody] PointModel point)
        {
            return new PostModel(_application.AddPoint(point), Get());
        }

        //POST api/values/PostList
        //[HttpPost]
        //public PostModel PostList([FromBody] List<PointModel> points)
        //{
        //    return new PostModel(_application.AddPoints(points), Get());
        //}

        [HttpPost]
        public async Task<PostModel> UploadFile()
        {
            if (!Request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);
            string pointsInString = await provider.Contents[0].ReadAsStringAsync();


            return new PostModel(_application.AddPoints(pointsInString), Get());
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
