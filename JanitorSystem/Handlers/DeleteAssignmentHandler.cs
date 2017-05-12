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
        public DeleteAssignmentHandler(AssignmentInfoViewModel vm)
        {
            this.Aiv = vm;
        } // constructor

        #region Properties

        public AssignmentInfoViewModel Aiv { get; set; }

        #endregion

        #region Http call to get AppartmentOwner // this cannot be in vicelist duo to await operator.

                public async Task<Appartment> GetAppartmentOwner()
        {
            return await Facade.FacadeService.GetAppartmentOwners(Aiv.Singleton.SelectedAssignmentMVM.AppartNo);
        }

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
