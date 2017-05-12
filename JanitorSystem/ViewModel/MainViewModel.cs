using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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
            Singleton = ViceLists.Instance;
            Singleton.LoadAssignmentList();
            Singleton.LoadRegAssignmentList();
        }
        public ViceLists Singleton { get; set; }


        





    }
}
