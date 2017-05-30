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
    /// <summary>
    /// The view model inherits from the class ViewPropertyChanged from the common folder in the system.  
    /// </summary>

    public class AddAssignmentViewModel : ViewPropertyChanged
    {
        #region Properties
        public Assignment Assignment { get; set; }
        public AssignmentHandler InstanceAssignmentHandler { get; set; }
        public ViceListsSingleton Singleton { get; set; }
        #endregion

        #region Properties af typen ICommand
        public ICommand AddAssignmentCommand { get; set; }
        public ICommand OpdaterAssignemntCommand { get; set; }
        public ICommand SetRankNoOneCommand { get; set; }
        public ICommand SetRankNoTwoCommand { get; set; }
        public ICommand SetRankNoThreeCommand { get; set; }

        #endregion 

        #region SelectedEmployeeId full property
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

        #region SelectedDepartmentId full property
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

        #region SelectedAppartmentId full property

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

        #region Constructor

        public AddAssignmentViewModel()
        {
            Singleton = ViceListsSingleton.Instance;
            InstanceAssignmentHandler = new AssignmentHandler(this);          
            Assignment = new Assignment();
            AddAssignmentCommand = new RelayCommand(InstanceAssignmentHandler.AddAssignment,null);
            OpdaterAssignemntCommand = new RelayCommand(Singleton.UpdateToDLAListView,null);
            SetRankNoOneCommand = new RelayCommand(InstanceAssignmentHandler.SetPriorityToOne,null);
            SetRankNoTwoCommand = new RelayCommand(InstanceAssignmentHandler.SetPriorityToTwo,null);
            SetRankNoThreeCommand = new RelayCommand(InstanceAssignmentHandler.SetPriorityToThree,null);

            SelectedAppartmentId = new Appartment();
            SelectedDepartmentId = new Department();
            SelectedEmployeeId = new Employee();
        }

        #endregion
    }
}
