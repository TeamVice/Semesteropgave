using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using JanitorSystem.Facade;
using JanitorSystem.Model;
using JanitorSystem.ViewModel;

namespace JanitorSystem.Handlers
{
    public class AssignmentHandler
    {

        public MainViewModel Mvm { get; set; }

        public ViceLists Vl { get; set; }
        public AssignmentHandler(MainViewModel mvm, ViceLists vl)
        {
            this.Mvm = mvm;
            this.Vl = vl;

            LoadAssignmentList();
        }

        public async void LoadAssignmentList()
        {
            try
            {
                Vl.AssignmentList = await FacadeService.GetAssignmentList();

            }
            catch (Exception e)
            {
                Debug.Write($"Exception {e}");
            }
        }

      
    }
}
