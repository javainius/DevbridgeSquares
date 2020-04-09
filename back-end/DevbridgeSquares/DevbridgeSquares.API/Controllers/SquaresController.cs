using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevbridgeSquares.Core.Interfaces;
using DevbridgeSquares.Core.Models;
using DevbridgeSquares.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevbridgeSquares.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SquaresController : ControllerBase
    {
        private readonly IApplication _application;
        public SquaresController(IApplication application)
        {
            _application = application;
        }
        // GET api/Square

        [HttpGet]
        public List<SquareView> GetSquares() => _application.GetSquareList();
    }
}