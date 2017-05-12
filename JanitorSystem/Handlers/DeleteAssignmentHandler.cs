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
        public AssignmentInfoViewModel Aiv { get; set; }

        public DeleteAssignmentHandler()
        {
            //aiv = Aiv;
        }

        #region Method to delete assignemtns

        public void DeleteAssignment()
        {
            ViceLists.Instance.RemoveAssignment(ViceLists.Instance.SelectedAssignmentMVM);
            ViceLists.Instance.ClearAssignmentList();
            ViceLists.Instance.LoadAssignmentList();
        }

        #endregion
    }
}
