using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using JanitorSystem.Common;
using JanitorSystem.Model;
using JanitorSystem.Facade;
using JanitorSystem.Handlers;

namespace JanitorSystem.ViewModel
{
    public class MainViewModel : ViewPropertyChanged
    {


        #region Objects
        public AssignmentHandler InstanceAssignmentHandler { get; set; }
        public AddAssignmentViewModel AddAssignmentViewModel { get; set; } = new AddAssignmentViewModel();
        
        #endregion
        public MainViewModel()
        {
            ViceLists.Instance.ClearAssignmentList();
            ViceLists.Instance.ClearReqAssignmentList();
            InstanceAssignmentHandler = new AssignmentHandler(this, AddAssignmentViewModel, ViceLists.Instance);
            ViceLists.Instance.LoadAssignmentList();
            ViceLists.Instance.LoadRegAssignmentList(); 
        }
    }
}
