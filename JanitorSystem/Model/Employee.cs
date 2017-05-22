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
        /// <summary
        /// Properties that match the Employee tabel attributs in the database.
        /// </summary>
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeePhone { get; set; }
        public string EmployeeTitle { get; set; }
        #endregion

        #region Tostring method override
        /// <summary>
        /// Method ToString which is overided to show the Employee name 
        /// in the combobox in the Addassignment View.
        /// </summary>

        public override string ToString()
        {
            return $"{EmployeeName}";
        }
        #endregion
    }
}
