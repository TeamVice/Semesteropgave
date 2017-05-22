using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.Windows.Input;
using JanitorSystem.Common;
using JanitorSystem.Model;
using JanitorSystem.Facade;
using JanitorSystem.Handlers;

namespace JanitorSystem.ViewModel
{
    /// <summary>
    /// The view model inherits from the class ViewPropertyChanged from the common folder in the system.  
    /// </summary>
    public class MainViewModel : ViewPropertyChanged
    {
        #region Properties
        public ViceListsSingleton Singleton { get; set; }

        #endregion

        #region Properties af typen ICommand
        public ICommand SortByTimeDbCommand { get; set; }
        public ICommand SortByRankNoCommand { get; set; }

        public ICommand SortByBuildingNoCommand { get; set; }

        public ICommand UpdateSortingListCommand { get; set; }

        #endregion

        #region Contructor
        public MainViewModel()
        {

            Singleton = ViceListsSingleton.Instance;
            #region Iniates Clear methods // To avoid a bug when changing from assignmentinfo view to AssignmentListFrontPage

            
            Singleton.ClearAssignmentList();
            Singleton.LoadAssignmentList();
            #endregion
            Singleton.LoadSortingList();

            SortByTimeDbCommand = new RelayCommand(Singleton.OrderedTimeDB,null);
            SortByRankNoCommand = new RelayCommand(Singleton.OrderedRankList, null);
            SortByBuildingNoCommand = new RelayCommand(Singleton.OrderByBuildingNo, null);
            UpdateSortingListCommand = new RelayCommand(Singleton.LoadSortingList,null);
            
        }
        #endregion


    }
}
