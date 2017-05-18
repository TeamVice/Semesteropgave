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
    public class AddAssignmentViewModel : ViewPropertyChanged
    {
        public AddAssignmentViewModel()
        {
            Singleton = ViceListsSingleton.Instance;
            InstanceAssignmentHandler = new AssignmentHandler(this);          
            Assignment = new Assignment();
            AddAssignmentCommand = new RelayCommand(InstanceAssignmentHandler.AddAssignment,null);
            OpdaterAssignemntCommand = new RelayCommand(Singleton.opdater,null);
        } // constructor

        #region Properties
         public Assignment Assignment { get; set; }
        public AssignmentHandler InstanceAssignmentHandler { get; set; }
        public ViceListsSingleton Singleton { get; set; }
        #endregion
       
        #region ICommands
        public ICommand AddAssignmentCommand { get; set; }

        public ICommand OpdaterAssignemntCommand { get; set; }
        #endregion

        #region SelectedEmployeeId
        /// <summary>
        /// This select will give the neccecary ID associated with the employer that is picked in the combobox, it will then be used in AddAssignment() to pass on the ID to a tempassigment.
        /// </summary>
        private Employee selectedEmployeeId;

        public Employee SelectedEmployeeId
        {
            get { return selectedEmployeeId; }
            set
            {
                selectedEmployeeId = value;
                OnPropertyChanged(nameof(SelectedEmployeeId));
            }
        }
        #endregion

        #region SelectedDepartmentId
        /// <summary>
        /// This select will give the neccecary ID associated with the Department that is picked in the combobox, it will then be used in AddAssignment() to pass on the ID to a tempassigment.
        /// </summary>
        private Department selectedDepartmentId;

        public Department SelectedDepartmentId
        {
            get { return selectedDepartmentId; }
            set
            {
                selectedDepartmentId = value;
                OnPropertyChanged(nameof(SelectedDepartmentId));
            }
        }

        #endregion

        #region SelectedAppartmentId

        private Appartment selectedAppartmentId;

        public Appartment SelectedAppartmentId
        {
            get { return selectedAppartmentId; }
            set
            {
                selectedAppartmentId = value;
                OnPropertyChanged(nameof(SelectedAppartmentId));
            }
        }
        #endregion
    }
}
