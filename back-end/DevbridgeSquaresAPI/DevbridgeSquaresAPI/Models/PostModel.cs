using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevbridgeSquaresAPI.Models
{
    public class PostModel
    {
        public PostModel(List<string> responseMessage, IEnumerable<PointModel> currentPointList)
        {
            ResponseMessage = responseMessage;
            CurrentPointList = currentPointList;
        }
        public List<string> ResponseMessage { get; set; }
        public IEnumerable<PointModel> CurrentPointList { get; set; }
    }
}