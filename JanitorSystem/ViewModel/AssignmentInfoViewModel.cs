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
    public class AssignmentInfoViewModel : ViewPropertyChanged
    {
        public AssignmentInfoViewModel()
        {
            Singleton = ViceListsSingleton.Instance;

            HandlerInfoAssign = new AssignmentInfoHandler(this);
            EditAssignCommentCommand = new RelayCommand(HandlerInfoAssign.UpdateAssignComment,null);

            //FinishAssignmentCommand = new RelayCommand(HandlerDelete.DeleteAssignment,null);

            LoadAppartData();
        } // constructor

        public async void LoadAppartData()
        {
            SelectedAppartment = await HandlerInfoAssign.GetAppartmentOwner();
        }

        #region ICommands

        public ICommand EditAssignCommentCommand { get; set; }

        public ICommand FinishAssignmentCommand { get; set; }

        #endregion

        #region Properties
        public AssignmentInfoHandler HandlerInfoAssign { get; set; }
        public ViceListsSingleton Singleton { get; }

        private Appartment selectedAppartment;

        public Appartment SelectedAppartment
        {
            get { return selectedAppartment; }
            set
            {
                selectedAppartment = value; 
                OnPropertyChanged(nameof(SelectedAppartment));
            }
        }


        #endregion
    }
}
