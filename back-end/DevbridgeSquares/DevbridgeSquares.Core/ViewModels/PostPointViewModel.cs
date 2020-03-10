using DevbridgeSquares.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevbridgeSquares.Core.ViewModels
{
    public class PostPointViewModel
    {
        public List<PointViewModel> CurrentPointList { get; set; }
        public string AddingState;
        public PostPointViewModel(string addingState, List<PointViewModel> currentPointList)
        {
            CurrentPointList = currentPointList;
            AddingState = addingState;
        }
    }
}
