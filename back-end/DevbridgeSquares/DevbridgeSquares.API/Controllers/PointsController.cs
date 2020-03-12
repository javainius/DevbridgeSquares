﻿using DevbridgeSquares.App;
using DevbridgeSquares.Core.Models;
using DevbridgeSquares.Core.ViewModels;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DevbridgeSquares.API.Controllers
{
    public class PointsController : ApiController
    {
        private readonly Application _application;
        public PointsController()
        {
            _application = new Application();
        }
        // GET api/values/Get
        [HttpGet]
        public List<PointViewModel> GetPoints()
        {
            return _application.GetPointList();
        }

        // POST api/values/PostPoint
        [HttpPost]
        public PostPointResponseView PostPoint([FromBody] PointModel point)
        {
            _application.AddPoint(point);

            return new PostPointResponseView(_application.GetPointAddingState(), _application.GetPointList());
        }
    }
}