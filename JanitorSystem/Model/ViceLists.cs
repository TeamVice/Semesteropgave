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
        public ViceLists()
        {
            AssignmentList = new ObservableCollection<Assignment>();

            LoadAssignmentList();
            //LoadRegAssignmentList();


        }
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

        private static ViceLists instance;

        public static ViceLists Instance
        {
            get {
                if (instance == null)
                {
                    instance = new ViceLists();
                }
                return instance;}
        }


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

    }
}
