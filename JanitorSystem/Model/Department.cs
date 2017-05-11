using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanitorSystem.Model
{
    /// <summary>
    /// Denne klasse indeholde 2 tabeller i databasen "Department" og "DepZipCode"
    /// </summary>
    public class Department
    {
        #region props
        public int DepId { get; set; }
        public string DepName { get; set; }

        public string DepAddress { get; set; }

        public string DepCity { get; set; }

        public int DepZipCode { get; set; }
#endregion

        public override string ToString()
        {
            return $"{DepName}";
        }
    }
   
}
