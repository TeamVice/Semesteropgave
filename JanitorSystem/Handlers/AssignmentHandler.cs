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
        public Assignment Test { get; set; }

        public AddAssignmentViewModel Avm { get; set; }
        public AssignmentHandler(MainViewModel mvm, AddAssignmentViewModel avm, ViceLists vl)
        {
           
            Mvm = mvm;
            Vl = vl;
            Avm = avm;


        }

        #region AddAssignment Metode

        public void AddAssignment()
        {
            Assignment tempAssignment = new Assignment();
            
            tempAssignment.AssignTitle = Avm.Assignment.AssignTitle;
            tempAssignment.AssignText = Avm.Assignment.AssignText;
            tempAssignment.AssignRankNo = 1;
            tempAssignment.EmployeeId = ViceLists.Instance.SelectedEmployeeId.EmployeeId;
            tempAssignment.DepId = ViceLists.Instance.SelectedDepartmentId.DepId;
            
            

            ViceLists.Instance.AddAssignment(tempAssignment);
            ViceLists.Instance.ClearAssignmentList();
            ViceLists.Instance.LoadAssignmentList();
           // tempAssignment.AssignTitle = MainViewModel.

        }

        #endregion

        #region Delete assignment metode
        public void DeleteAssignment()
        {
            ViceLists.Instance.RemoveAssignment(ViceLists.Instance.SelectedAssignmentAddAssignVm);

        }

        #endregion

        public void EditAssignment()
        {
            ViceLists.Instance.AlterAssignment(ViceLists.Instance.SelectedAssignmentAddAssignVm);
        }
    }
}
