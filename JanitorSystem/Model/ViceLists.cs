using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JanitorSystem.Common;
using JanitorSystem.Facade;
using JanitorSystem.Handlers;

namespace JanitorSystem.Model
{
    public sealed class ViceLists : Inotify
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

        #region SelectedAssignment
        private Assignment selectedAssignment;

        public Assignment SelectedAssignment
        {
            get { return selectedAssignment; }
            set
            {
                selectedAssignment = value;
                OnPropertyChanged(nameof(SelectedAssignment));
            }
        }

        #endregion

        #region SelectedToDeleteAssignmentProp
        private Assignment selectedToDeleteAssignment;

        public Assignment SelectedToDeleteAssignment
        {
            get { return selectedToDeleteAssignment; }
            set
            {
                selectedToDeleteAssignment = value; 
                OnPropertyChanged(nameof(SelectedToDeleteAssignment));
            }
        }

        #endregion



        public ViceLists()
        {
            AssignmentList = new ObservableCollection<Assignment>();
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
        
        #region LoadRegAssignments

        /// <summary>
        /// Metoder til RegAssignments 
        /// </summary>

        public async void LoadRegAssignmentList()
        {
            try
            {
                RegAssignmentList = await FacadeService.GetRegAssignmentList();

            }
            catch (Exception e)
            {
                Debug.Write($"Exception {e}");
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
    }
}
