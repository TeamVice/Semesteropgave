using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments.DataProvider;
using JanitorSystem.Common;
using JanitorSystem.Facade;
using JanitorSystem.Handlers;

namespace JanitorSystem.Model
{
    public sealed class ViceListsSingleton : ViewPropertyChanged
    {
        #region Singleton // Constructor
        private ViceListsSingleton()
        {
            AssignmentList = new ObservableCollection<Assignment>();
            EmployeeList = new ObservableCollection<Employee>();
            DepartmentsList = new ObservableCollection<Department>();
            AppartmentList = new ObservableCollection<Appartment>();
            #region LoadLists

            LoadAssignmentList();
            LoadRegAssignmentList();
            LoadEmployeeList();
            LoadAppartmentList();
            LoadDepartmentList();

            #endregion
        } // constructor 

        private static readonly ViceListsSingleton instance = new ViceListsSingleton();

        public static ViceListsSingleton Instance
        {
            get { return instance; }
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

        #region Lister

        
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

        #region Methods to add and remove assignments

        public async void AddAssignment(Assignment newAssignment)
        {
            await FacadeService.PostAssignment(newAssignment);
            

        }

        public async void RemoveAssignment(Assignment deleteAssignment)
        {
            await FacadeService.DeleteAssignment(deleteAssignment);
        }

        #endregion
        
        #region Methods to Load lists

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
        #endregion
        
        #region Methods to clear lists

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



        #endregion
    }
}
