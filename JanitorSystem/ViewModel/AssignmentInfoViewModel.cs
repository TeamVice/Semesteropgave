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
    /// <summary>
    /// The view model inherits from the class ViewPropertyChanged from the common folder in the system.  
    /// </summary>
    public class AssignmentInfoViewModel : ViewPropertyChanged
    {

        #region Properties af typen ICommand

        public ICommand EditAssignCommentCommand { get; set; }

        public ICommand FinishAssignmentCommand { get; set; }

        #endregion

        #region Properties
        public AssignmentInfoHandler HandlerInfoAssign { get; set; }
        public ViceListsSingleton Singleton { get; }

        private AssignmentSorting selectedAppartment;

        public AssignmentSorting SelectedAppartment
        {
            get { return selectedAppartment; }
            set
            {
                selectedAppartment = value;
                OnPropertyChanged(nameof(SelectedAppartment));
            }
        }


        #endregion

        #region Constructor

        public AssignmentInfoViewModel()
        {
            Singleton = ViceListsSingleton.Instance;

            HandlerInfoAssign = new AssignmentInfoHandler(this);
            EditAssignCommentCommand = new RelayCommand(HandlerInfoAssign.UpdateAssignComment,null);

            FinishAssignmentCommand = new RelayCommand(HandlerInfoAssign.DeleteAssignment,null);
#pragma warning disable 4014
            LoadAppartData();
#pragma warning restore 4014
            
        }
        #endregion

        #region Method to load appartment data

        public async Task LoadAppartData()
        {
            SelectedAppartment = await HandlerInfoAssign.GetAppartmentOwner();
        }

        #endregion

    }
}
