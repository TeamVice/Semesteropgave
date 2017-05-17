using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using JanitorSystem.Common;
using JanitorSystem.Model;
using JanitorSystem.Facade;
using JanitorSystem.Handlers;

namespace JanitorSystem.ViewModel
{
    public class MainViewModel : ViewPropertyChanged
    {
        public MainViewModel()
        {
            Singleton = ViceListsSingleton.Instance;
            #region Iniates Clear methods // To avoid a bug when changing from assignmentinfo view to AssignmentListFrontPage

            Singleton.ClearAssignmentList();

            #endregion
            Singleton.LoadAssignmentList();

            SortAssignListByRankCommand = new RelayCommand(Singleton.LoadOrderedRankList, null);
            
        } // constructor

        #region Properties
        public ViceListsSingleton Singleton { get; set; }

        #endregion

        #region ICommands

        public ICommand SortAssignListByRankCommand { get; set; }

       



        #endregion
    }
}
