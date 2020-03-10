using DevbridgeSquares.Core.Entities;
using DevbridgeSquares.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevbridgeSquares.Core.ViewModels
{
    public class FileUploadViewModel
    {
        public FileUploadViewModel(FileUploadingStateModel uploadingState, List<PointViewModel> currentPointList)
        {
            UploadingState = uploadingState;
            CurrentPointList = currentPointList;
        }
        public FileUploadingStateModel UploadingState { get; set; }
        public List<PointViewModel> CurrentPointList { get; set; }
    }
}