using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanitorSystem.Model
{
    public class Department
    {

        #region Properties
        /// <summary
        /// Properties that match the Department tabel attributs in the database.
        /// </summary>
        public int DepId { get; set; }
        public string DepName { get; set; }
        public string DepAddress { get; set; }
        public string DepCity { get; set; }
        public int DepZipCode { get; set; }
        #endregion


        #region Tostring method override
        /// <summary>
        /// Method ToString which is overided to show the Department name 
        /// in the combobox in the Addassignment View.
        /// </summary>

        public override string ToString()
        {
            return $"{DepName}";
        }
        #endregion
    }
}
