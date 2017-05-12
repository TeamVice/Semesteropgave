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
        public AssignmentInfoViewModel()
        {
            Singleton = ViceLists.Instance;
            HandlerDelete = new DeleteAssignmentHandler();
            FinishAssignmentCommand = new RelayCommand(HandlerDelete.DeleteAssignment,null);
        } // constructor

        #region ICommands

        public ICommand FinishAssignmentCommand { get; set; }

        #endregion

        #region Properties
        public DeleteAssignmentHandler HandlerDelete { get; set; }
        
        public ViceLists Singleton { get; }

        #endregion
    }
}
