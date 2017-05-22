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
using Windows.UI.Composition;
using JanitorSystem.Common;
using JanitorSystem.Facade;
using JanitorSystem.Handlers;
using Windows.UI.Popups;

namespace JanitorSystem.Model
{
    /// <summary>
    /// The ViceListSingleton class inherits from the class ViewPropertyChanged from the common folder in the system.  
    /// </summary>

    public sealed class ViceListsSingleton : ViewPropertyChanged
    {


        #region Instance property. 
        /// <summary>
        /// Instance prop type ViceListSingleton, sealed class with private konstruktør. 
        /// A prop which has a get metoden that returns the variable instance. 
        /// </summary>
        /// 
        private static readonly ViceListsSingleton instance = new ViceListsSingleton();
        public static ViceListsSingleton Instance
        {
            get { return instance; }
        }
        #endregion


        #region Lists in the janitor system

        /// <summary>
        /// This region includes all full props of type observablecollection with a specified class datatype. 
        /// The set methods include Onpropertychanged.
        /// </summary>


        #region PropAssignmentList

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

        #region PropSortingList

        private ObservableCollection<AssignmentSorting> sortingList;

        public ObservableCollection<AssignmentSorting> SortingList
        {
            get { return sortingList; }
            set
            {
                sortingList = value;
                OnPropertyChanged(nameof(SortingList));
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

        #region PropSelectedAssignmentMVM

        /// <summary>
        /// In order for the janitor to select an assignment in the assignment list, 
        /// this property is bound to the list view of the main page for the janitor. 
        /// </summary>
        private AssignmentSorting selectedAssignmentMVM;

        public AssignmentSorting SelectedAssignmentMVM
        {
            get { return selectedAssignmentMVM; }
            set
            {
                selectedAssignmentMVM = value;
                OnPropertyChanged(nameof(SelectedAssignmentMVM));
            }
        }

        #endregion

        #region Singleton // Constructor
        /// <summary>
        /// Private constructor. Assibility is limited to this specific class.
        /// </summary>

        private ViceListsSingleton()
        {
            AssignmentList = new ObservableCollection<Assignment>();
            EmployeeList = new ObservableCollection<Employee>();
            DepartmentsList = new ObservableCollection<Department>();
            AppartmentList = new ObservableCollection<Appartment>();
            SortingList = new ObservableCollection<AssignmentSorting>();

            LoadAllLists();
        }

        #endregion

        #region Method to update DLA ListView

        public void UpdateToDLAListView()
        {
            ClearAssignmentList();
            LoadAssignmentList();
        }

        #endregion

        #region Methods to add and remove assignments

        public async void AddAssignment(Assignment newAssignment)
        {
            await FacadeService.PostAssignment(newAssignment);
            

        }

        public async void EditAssignComment(AssignmentSorting assignCommentToEdit)
        {
            await FacadeService.PutAssignComment(assignCommentToEdit);
        }

        public async void RemoveAssignment(AssignmentSorting deleteAssignment)
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
                ShowSortingList();
                
               
            }
            catch (Exception e)
            {
                Debug.Write($"Exception {e}");
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

        #region ShowSorting list
        public void ShowSortingList()
        {

            ObservableCollection<AssignmentSorting> res = new ObservableCollection<AssignmentSorting>(
                AssignmentList.Join(AppartmentList, p => p.AppartNo, g => g.AppartNo,
                    (p, g) => new AssignmentSorting()
                    {
                        AssignTitle = p.AssignTitle,
                        AssignText = p.AssignText,
                        DepId = p.DepId,
                        BuildingNo = g.BuildingNo,
                        AssignRankNo = p.AssignRankNo,
                        AppartNo = p.AppartNo,
                        AppartmentOwner = g.AppartmentOwner,
                        AppartmentPhone1 = g.AppartmentPhone1,
                        AppartmentPhone2 = g.AppartmentPhone2,
                        AssignComment = p.AssignComment,
                        EmployeeId = p.EmployeeId,
                        AssignId = p.AssignId
                    }));
            SortingList = res;
        }
        #endregion

        #endregion

        #region Method to clear lists

        #region ClearListerMetoder

        public void ClearAssignmentList()
        {
            if (AssignmentList != null)
            {
                AssignmentList.Clear();
            }
        }

        #endregion


        #endregion

        #region Method to load all lists

        public void LoadAllLists()
        {
            LoadAssignmentList();
            LoadAppartmentList();
            LoadDepartmentList();
            LoadEmployeeList();
            ShowSortingList();
        }

        #endregion

        #region SortingMethod
        public void OrderedTimeDB()
        {
            SortingList = new ObservableCollection<AssignmentSorting>(SortingList.OrderBy(i => i.AssignId));
        }
        public void OrderedRankList()
        {
            SortingList = new ObservableCollection<AssignmentSorting>(SortingList.OrderBy(i => i.AssignRankNo).ThenBy(j => j.DepId));

        }

        public void OrderByDepAndBuildingNo()
        {
            SortingList = new ObservableCollection<AssignmentSorting>(SortingList.OrderBy(i => i.DepId).ThenBy(j => j.BuildingNo));
        }


        #endregion

    }
}
