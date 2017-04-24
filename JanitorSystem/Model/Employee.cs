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
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string department { get; set; }
        public int workHours { get; set; }
        public int phone { get; set; }
        public string title { get; set; }
        #endregion

        // ctor
        public Employee()
        {

        }
    }
}
