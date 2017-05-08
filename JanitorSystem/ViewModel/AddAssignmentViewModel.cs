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

        public AddAssignmentViewModel()
        {
            InstanceAssignmentHandler = new AssignmentHandler(MainViewModel,this, ViceLists.Instance);
            Assignment = new Assignment();
            AddAssignmentCommand = new RelayCommand(InstanceAssignmentHandler.AddAssignment,null);

        }

    }
}
