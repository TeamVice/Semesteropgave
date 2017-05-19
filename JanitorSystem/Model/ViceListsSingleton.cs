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
    public sealed class ViceListsSingleton : ViewPropertyChanged
    {
        #region Singleton // Constructor
        private ViceListsSingleton()
        {
            AssignmentList = new ObservableCollection<Assignment>();
            EmployeeList = new ObservableCollection<Employee>();
            DepartmentsList = new ObservableCollection<Department>();
            AppartmentList = new ObservableCollection<Appartment>();
            SortingList = new ObservableCollection<AssignmentSorting>();

            #region LoadLists
            
            LoadAssignmentList();
            LoadEmployeeList();
            LoadAppartmentList();
            LoadDepartmentList();
            
            LoadSortingList();
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


        public void opdater()
        {
            ClearAssignmentList();
            LoadAssignmentList();
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
                LoadSortingList();
                
                //AppartmentList = new ObservableCollection<Appartment>(AppartmentList.OrderBy(j => j.AppartBuildingNo ));
            }
            catch (Exception e)
            {
                Debug.Write($"Exception {e}");
            }
        }


        #endregion

        public void LoadSortingList()
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

        #region SorterMetoder
       public void OrderedTimeDB()
        {
            SortingList = new ObservableCollection<AssignmentSorting>(SortingList.OrderBy(i => i.AssignId));
        }
        public void OrderedRankList()
        {
            SortingList = new ObservableCollection<AssignmentSorting>(SortingList.OrderBy(i => i.AssignRankNo));

        }

        public void OrderByBuildingNo()
        {
           SortingList = new ObservableCollection<AssignmentSorting>(SortingList.OrderBy(i => i.BuildingNo));
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

        public void ClearAssignmentList()
        {
            if (AssignmentList != null)
            {
                AssignmentList.Clear();
            }
        }

        #endregion



        #endregion

        //var hotelList10 = from r in AssignmentList
        //    join h in AppartmentList
        //    on r.AppartNo equals h.AppartNo
        //    where h.AppartNo.Equals(9)
        //    select r.AssignTitle;
    }
}
