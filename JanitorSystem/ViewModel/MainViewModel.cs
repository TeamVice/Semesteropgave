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
        public MainViewModel()
        {
            Singleton = ViceListsSingleton.Instance;
            #region Iniates Clear methods // To avoid a bug when changing from assignmentinfo view to AssignmentListFrontPage

            Singleton.ClearAssignmentList();
            Singleton.ClearReqAssignmentList();

            #endregion
            Singleton.LoadAssignmentList();
            Singleton.LoadRegAssignmentList();
        } // constructor

        #region Properties
        public ViceListsSingleton Singleton { get; set; }

        #endregion
    }
}
