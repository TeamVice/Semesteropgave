using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments.DataProvider;
using JanitorSystem.Common;
using JanitorSystem.Facade;
using JanitorSystem.Handlers;

namespace JanitorSystem.Model
{
    public sealed class ViceLists : ViewPropertyChanged
    {
        #region Singleton

        private static ViceLists instance;

        public static ViceLists Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ViceLists();
                }
                return instance;
            }
        }

        #endregion

        #region PropAssignmentList

        /// <summary>
        /// Denne prop er initieseret af assignmenthandler.
        /// </summary>

        private ObservableCollection<Assignment> assignmentList;

        public ObservableCollection<Assignment> AssignmentList
        {
            get { return assignmentList; }
            set
            {
                assignmentList = value;
                OnPropertyChanged(nameof(AssignmentList));
            }

        }

        #endregion

        #region PropRegAssignmentList

        /// <summary>
        /// Denne prop er initieseret af assignmenthandler.
        /// </summary>

        private ObservableCollection<RegAssignment> regAssignmentList;

        public ObservableCollection<RegAssignment> RegAssignmentList
        {
            get { return regAssignmentList; }
            set
            {
                regAssignmentList = value;
                OnPropertyChanged(nameof(RegAssignmentList));
            }

        }

        #endregion

        #region PropEmployeeList

        private ObservableCollection<Employee> employeeList;

        public ObservableCollection<Employee> EmployeeList
        {
            get { return employeeList; }
            set { employeeList = value; OnPropertyChanged(nameof(EmployeeList)); }
        }



        #endregion

        #region PropAppartmentList

        private ObservableCollection<Appartment> appartmentList;

        public ObservableCollection<Appartment> AppartmentList
        {
            get { return appartmentList; }
            set { appartmentList = value; OnPropertyChanged(nameof(AppartmentList)); }
        }

        #endregion

        #region PropDepartmentList
        private ObservableCollection<Department> departmentsList;

        public ObservableCollection<Department> DepartmentsList
        {
            get { return departmentsList; }
            set { departmentsList = value; OnPropertyChanged(nameof(DepartmentsList)); }
        }

        #endregion

        #region SelectedAssignmentMVM
        private Assignment selectedAssignmentMVM;

        public Assignment SelectedAssignmentMVM
        {
            get { return selectedAssignmentMVM; }
            set
            {
                selectedAssignmentMVM = value;
                OnPropertyChanged(nameof(SelectedAssignmentMVM));
            }
        }

        #endregion

        #region SelectedToDeleteAssignmentProp
        private Assignment selectedAssignmentAddAssignVM;

        public Assignment SelectedAssignmentAddAssignVm
        {
            get { return selectedAssignmentAddAssignVM; }
            set
            {
                selectedAssignmentAddAssignVM = value; 
                OnPropertyChanged(nameof(SelectedAssignmentAddAssignVm));
            }
        }

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

        public ViceLists()
        {
            AssignmentList = new ObservableCollection<Assignment>();
            EmployeeList = new ObservableCollection<Employee>();
            DepartmentsList = new ObservableCollection<Department>();
            AppartmentList = new ObservableCollection<Appartment>();
        }

        #region Methods

        #region ClearListerMetoder

        public void ClearReqAssignmentList()
        {
            if (RegAssignmentList != null)
            {
                RegAssignmentList.Clear();
            }
        }

        public void ClearAssignmentList()
        {
            if (AssignmentList != null)
            {
                AssignmentList.Clear();
            }
        }

        #endregion

        #region LoadAssignmentList
        public async void LoadAssignmentList()
        {
            try
            {
                AssignmentList = await FacadeService.GetAssignmentList();

            }
            catch (Exception e)
            {
                Debug.Write($"Exception {e}");
            }
        }
        #endregion

        #region ProgressRing
        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }
        #endregion
        #region LoadRegAssignments

        /// <summary>
        /// Metoder til RegAssignments 
        /// </summary>

        public async void LoadRegAssignmentList()
        {
            try
            {
                IsBusy = true;

                RegAssignmentList = await FacadeService.GetRegAssignmentList();
            }
            catch (Exception e)
            {
                Debug.Write($"Exception {e}");
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion

        public async void AddAssignment(Assignment newAssignment)
        {
            await FacadeService.PostAssignment(newAssignment);
            

        }

        public async void RemoveAssignment(Assignment deleteAssignment)
        {
            await FacadeService.DeleteAssignment(deleteAssignment);
            //ClearAssignmentList();
            //LoadAssignmentList();
        }

        #endregion

        #region EditAssignment

        public async void AlterAssignment(Assignment editAssignment)
        {
            await FacadeService.EditAssignment(editAssignment);
        }

        #endregion

        #region LoadEmployeeList

        public async void LoadEmployeeList()
        {
            try
            {
               EmployeeList = await FacadeService.GetEmployeeList();

            }
            catch (Exception e)
            {
                Debug.Write($"Exception {e}");
            }
        }

        #endregion

        #region LoadAppartmentList

        public async void LoadAppartmentList()
        {
            try
            {
                AppartmentList = await FacadeService.GetAppartmentList();

            }
            catch (Exception e)
            {
                Debug.Write($"Exception {e}");
            }
        }

        #endregion

        #region LoadDepartmentList

        public async void LoadDepartmentList()
        {
            try
            {
                DepartmentsList = await FacadeService.GetDepartmentList();

            }
            catch (Exception e)
            {
                Debug.Write($"Exception {e}");
            }
        }

        #endregion
        
    }
}
