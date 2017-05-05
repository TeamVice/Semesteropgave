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
    public class MainViewModel
    {
        

        #region Objects
        public AssignmentHandler InstanceAssignmentHandler { get; set; }
        
        #endregion
        public MainViewModel()
        {
            InstanceAssignmentHandler = new AssignmentHandler(this, new ViceLists());
           
        }
    }
}
