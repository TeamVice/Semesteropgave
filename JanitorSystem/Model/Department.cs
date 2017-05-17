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
