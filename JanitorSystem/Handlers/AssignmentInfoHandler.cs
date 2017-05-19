using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JanitorSystem.Model;
using JanitorSystem.View;
using JanitorSystem.ViewModel;
using JanitorSystem.Facade;
using Windows.UI.Popups;

namespace JanitorSystem.Handlers
{
    public class AssignmentInfoHandler
    {
        public AssignmentInfoHandler(AssignmentInfoViewModel vm)
        {
            this.Aiv = vm;
        } // constructor

        #region Properties

        public AssignmentInfoViewModel Aiv { get; set; }

        #endregion

        #region Http call to get AppartmentOwner // this cannot be in vicelist duo to await operator.

        public async Task<AssignmentSorting> GetAppartmentOwner()
        {
            return await FacadeService.GetAppartmentOwners(Aiv.Singleton.SelectedAssignmentMVM.AppartNo);
        }

        #endregion

        #region Method to update assignment comment

        public void UpdateAssignComment()
        {
            Aiv.Singleton.EditAssignComment(Aiv.Singleton.SelectedAssignmentMVM);

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            new MessageDialog("Du har opdateret opgavekommentaren").ShowAsync();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

        #endregion

        #region Method to delete assignemtns

        public void DeleteAssignment()
        {
            if(ViceListsSingleton.Instance.SelectedAssignmentMVM != null)
            {
                ViceListsSingleton.Instance.RemoveAssignment(ViceListsSingleton.Instance.SelectedAssignmentMVM);
                ViceListsSingleton.Instance.ClearAssignmentList();
                ViceListsSingleton.Instance.LoadAssignmentList();

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                new MessageDialog("Opgaven er nu afsluttet og slette fra din opgaveliste og puttet i databasen over afsluttede opgaver. DLA har adgang til denne liste.").ShowAsync();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            }
            else
            {
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                new MessageDialog("Ingen opgave at slette.").ShowAsync();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            }
        }

        #endregion
    }
}
