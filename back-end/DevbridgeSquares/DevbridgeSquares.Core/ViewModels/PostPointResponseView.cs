﻿using System.Collections.Generic;

namespace DevbridgeSquares.Core.ViewModels
{
    public class PostPointResponseView
    {
        public List<PointView> CurrentPointList { get; set; }
        public string AddingState { get; set; }
        public PostPointResponseView(string addingState, List<PointView> points)
        {
            AddingState = addingState;
            CurrentPointList = points;
        }
    }
}
