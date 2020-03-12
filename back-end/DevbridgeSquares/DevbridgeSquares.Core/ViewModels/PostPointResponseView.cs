using System.Collections.Generic;

namespace DevbridgeSquares.Core.ViewModels
{
    public class PostPointResponseView
    {
        public List<PointViewModel> CurrentPointList { get; set; }
        public string AddingState { get; set; }
        public PostPointResponseView(string addingState, List<PointViewModel> points)
        {
            AddingState = addingState;
            CurrentPointList = points;
        }
    }
}
