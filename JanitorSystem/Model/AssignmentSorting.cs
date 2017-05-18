using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanitorSystem.Model
{
    public class AssignmentSorting
    {
        #region Properties Assignment

        public int AssignId { get; set; }
        public string AssignTitle { get; set; }
        public string AssignText { get; set; }
        public int AssignRankNo { get; set; }
        public string AssignComment { get; set; }
        public int DepId { get; set; }
        public int EmployeeId { get; set; }
        public int AppartNo { get; set; }

        #endregion

        #region Properties

        public string AppartmentOwner { get; set; }
        public int AppartmentPhone1 { get; set; }
        public int AppartmentPhone2 { get; set; }
        public int BuildingNo { get; set; }

        #endregion 

    }
}
