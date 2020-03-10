using DevbridgeSquares.Core.Models;
using DevbridgeSquares.Core.ViewModels;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DevbridgeSquares.API.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly Application.Application _application;
        public ValuesController()
        {
            _application = new Application.Application();
        }
        // GET api/values/Get
        [HttpGet]
        public List<PointViewModel> GetPoints()
        {
            return _application.GetPointList();
        }
        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }


        // POST api/values/PostPoint
        [HttpPost]
        public PostPointViewModel PostPoint([FromBody] PointModel point)
        {
            _application.SetApplication(point);
            _application.AddPoint();

            return new PostPointViewModel(_application.GetPointAddingState(), _application.GetPointList());
        }

        [HttpPost]
        public async Task<FileUploadViewModel> UploadFile()
        {
            if (!Request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);
            string pointsInString = await provider.Contents[0].ReadAsStringAsync();

            _application.SetApplication(null, pointsInString);
            _application.AddPoints();

            return new FileUploadViewModel(_application.GetFileUploadingState(), _application.GetPointList());
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
