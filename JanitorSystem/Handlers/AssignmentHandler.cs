using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using JanitorSystem.Facade;
using JanitorSystem.Model;
using JanitorSystem.ViewModel;

namespace JanitorSystem.Handlers
{
    public class AssignmentHandler
    {

        public MainViewModel Mvm { get; set; }

        public ViceLists Vl { get; set; }

        public AddAssignmentViewModel Avm { get; set; }
        public AssignmentHandler(MainViewModel mvm, ViceLists vl)
        {
            //AssignmentInfoViewModel avm
            this.Mvm = mvm;
            this.Vl = vl;
            //this.Avm = avm;
        }

        #region

        public void AddAssignment()
        {
            Assignment tempAssignment = new Assignment();
            tempAssignment.AssignTitle = Avm.Assignment.AssignTitle;
            tempAssignment.AssignText = Avm.Assignment.AssignText;
            tempAssignment.AssignRankNo = Avm.Assignment.AssignRankNo;
            ViceLists.Instance.AddAssignment(tempAssignment);
            ViceLists.Instance.ClearAssignmentList();
            ViceLists.Instance.LoadAssignmentList();
           // tempAssignment.AssignTitle = MainViewModel.

        }

        #endregion

    }
}
