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

        public AddAssignmentViewModel Avm { get; set; }
        public AssignmentHandler(AddAssignmentViewModel avm)
        {
            Avm = avm;
        }

        #region AddAssignment Metode

        public void AddAssignment()
        {
            Assignment tempAssignment = new Assignment();
            
            tempAssignment.AssignTitle = Avm.Assignment.AssignTitle;
            tempAssignment.AssignText = Avm.Assignment.AssignText;
            tempAssignment.AssignRankNo = 1;
            tempAssignment.AppartNo = Avm.SelectedAppartmentId.AppartNo;
            tempAssignment.DepId = Avm.SelectedDepartmentId.DepId;
            tempAssignment.EmployeeId = Avm.SelectedEmployeeId.EmployeeId;
            ViceLists.Instance.AddAssignment(tempAssignment);
            ViceLists.Instance.LoadAssignmentList();
        }

        #endregion

        #region Delete assignment metode
        public void DeleteAssignment()
        {
            ViceLists.Instance.RemoveAssignment(ViceLists.Instance.SelectedAssignmentMVM);

        }

        #endregion

        //public void EditAssignment()
        //{
        //    ViceLists.Instance.AlterAssignment(ViceLists.Instance.SelectedAssignmentAddAssignVm);
        //}
    }
}
