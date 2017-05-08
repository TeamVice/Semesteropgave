using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JanitorSystem.Model;

namespace JanitorSystem.ViewModel
{
    public class AddAssignmentViewModel
    {

        public Assignment Assignment { get; set; }

        public AddAssignmentViewModel()
        {
            Assignment = new Assignment();
        }

    }
}
