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
    public class MainViewModel : ViewPropertyChanged
    {
        public MainViewModel()
        {
            Singleton = ViceListsSingleton.Instance;
            #region Iniates Clear methods // To avoid a bug when changing from assignmentinfo view to AssignmentListFrontPage

            
            Singleton.ClearAssignmentList();
            Singleton.LoadAssignmentList();
            #endregion
            Singleton.Testy();

            SortAssignListByRankCommand = new RelayCommand(Singleton.OrderedRankList, null);
            SortDepAndApparCommand = new RelayCommand(Singleton.OrderedAppartNo, null);
            SortOwnerAndCommentCommand = new RelayCommand(Singleton.Testy,null);
            
        } // constructor

        #region Properties
        public ViceListsSingleton Singleton { get; set; }

        #endregion

        #region ICommands

        public ICommand SortAssignListByRankCommand { get; set; }

       public ICommand SortDepAndApparCommand { get; set; }

        public ICommand SortOwnerAndCommentCommand { get; set; }

        #endregion
    }
}
