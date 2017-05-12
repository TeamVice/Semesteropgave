using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using JanitorSystem.Common;
using JanitorSystem.Model;
using JanitorSystem.Handlers;

namespace JanitorSystem.ViewModel
{
    public class AssignmentInfoViewModel
    {
        public ICommand FinishAssignmentCommand { get; set; }
        public DeleteAssignmentHandler HandlerDelete { get; set; }
        
        public ViceLists Singleton { get; }
        public AssignmentInfoViewModel()
        { 
            HandlerDelete = new DeleteAssignmentHandler(this);
           Singleton = ViceLists.Instance;
            FinishAssignmentCommand = new RelayCommand(HandlerDelete.DeleteAssignment,null);
        }
    }
}
