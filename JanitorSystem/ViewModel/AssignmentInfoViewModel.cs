using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JanitorSystem.Model;
using JanitorSystem.Handlers;

namespace JanitorSystem.ViewModel
{
    public class AssignmentInfoViewModel
    {
       // public Assignment Assignment { get; set; }
        public ViceLists ViceLists { get; } = new ViceLists();

       // public AssignmentHandler InstanceAssignmentHandler { get; set; }

        public AssignmentInfoViewModel()
        {
           // ViceLists = ViceLists.Instance;
            //Assignment = new Assignment();
            //InstanceAssignmentHandler = new AssignmentHandler(this,ViceLists.Instance);
            
        }
    }
}
