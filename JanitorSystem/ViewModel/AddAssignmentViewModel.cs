using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JanitorSystem.Handlers;
using JanitorSystem.Model;
using System.Windows.Input;
using JanitorSystem.Common;

namespace JanitorSystem.ViewModel
{
    public class AddAssignmentViewModel
    {

        public Assignment Assignment { get; set; }
        public AssignmentHandler InstanceAssignmentHandler { get; set; }
        public MainViewModel MainViewModel { get; set; }
        
        public ICommand AddAssignmentCommand { get; set; }

        public ICommand DeleteAssignemntCommand { get; set; }
        public ICommand EditAssignmentCommand { get; set; }

        public AddAssignmentViewModel()
        {
            InstanceAssignmentHandler = new AssignmentHandler(MainViewModel,this, ViceLists.Instance);
            ViceLists.Instance.LoadEmployeeList();
            ViceLists.Instance.LoadDepartmentList();
            ViceLists.Instance.LoadAppartmentList();
            
            Assignment = new Assignment();
            AddAssignmentCommand = new RelayCommand(InstanceAssignmentHandler.AddAssignment,null);
            DeleteAssignemntCommand = new RelayCommand(InstanceAssignmentHandler.DeleteAssignment, null);
            EditAssignmentCommand = new RelayCommand(InstanceAssignmentHandler.EditAssignment, null);


        }

    }
}
