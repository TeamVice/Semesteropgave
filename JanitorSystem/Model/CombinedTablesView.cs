using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanitorSystem.Model
{
    public class CombinedTablesView
    {
        public int AppartNo { get; set; }
        public string AppartmentOwner { get; set; }
        public int AppartmentPhone1 { get; set; }
        public int AppartmentPhone2 { get; set; }
        public int AssignId { get; set; }
        public string AssignTitle { get; set; }
        public string AssignText { get; set; }
        public int AssignRankNo { get; set; }
        public string AssignComment { get; set; }
        public int EmployeeId { get; set; }
        public override string ToString()
        {
            return $"{AppartmentOwner} {AssignTitle}";
        }
    }
}
