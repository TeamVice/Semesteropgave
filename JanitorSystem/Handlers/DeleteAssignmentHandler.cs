using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JanitorSystem.Model;
using JanitorSystem.View;
using JanitorSystem.ViewModel;

namespace JanitorSystem.Handlers
{
    public class DeleteAssignmentHandler
    {
        #region Properties

        public AssignmentInfoViewModel Aiv { get; set; }

        #endregion
        
        #region Method to delete assignemtns

        public void DeleteAssignment()
        {
            ViceListsSingleton.Instance.RemoveAssignment(ViceListsSingleton.Instance.SelectedAssignmentMVM);
            ViceListsSingleton.Instance.ClearAssignmentList();
            ViceListsSingleton.Instance.LoadAssignmentList();
        }

        #endregion
    }
}
