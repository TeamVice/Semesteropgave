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
        public AssignmentHandler(AddAssignmentViewModel avm)
        {
            Avm = avm;
        }

        #region Properties

        public AddAssignmentViewModel Avm { get; set; }

        #endregion

        #region AddAssignment Method

        public void AddAssignment()
        {
            Assignment tempAssignment = new Assignment();
            
            tempAssignment.AssignTitle = Avm.Assignment.AssignTitle;
            tempAssignment.AssignText = Avm.Assignment.AssignText;
            tempAssignment.AssignRankNo = Avm.Assignment.AssignRankNo;
            tempAssignment.AppartNo = Avm.SelectedAppartmentId.AppartNo;
            tempAssignment.AssignComment = "Kommentar: ";
            tempAssignment.DepId = Avm.SelectedDepartmentId.DepId;
            tempAssignment.EmployeeId = Avm.SelectedEmployeeId.EmployeeId;
            Avm.Singleton.AddAssignment(tempAssignment);
            Avm.Singleton.ClearAssignmentList();
            Avm.Singleton.LoadAssignmentList();

           // OutPutToUser = "Opgave blev oprettet!";
        }

        public void testy()
        {
            Avm.Assignment.AssignRankNo = 1;
        }

        public void testy2()
        {
            Avm.Assignment.AssignRankNo = 2;
        }

        public void testy3()
        {
            Avm.Assignment.AssignRankNo = 3;
        }

        #endregion

        #region Delete assignment method
        public void DeleteAssignment()
        {
            Avm.Singleton.RemoveAssignment(ViceListsSingleton.Instance.SelectedAssignmentMVM);
        }

        #endregion
    }
}
