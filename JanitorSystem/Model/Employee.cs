using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanitorSystem.Model
{
    public class Employee
    {
        #region Properties
   
        
        
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public int Phone { get; set; }

        public string Title { get; set; }

        #endregion

        // ctor
        public Employee()
        {

        }
    }
}
