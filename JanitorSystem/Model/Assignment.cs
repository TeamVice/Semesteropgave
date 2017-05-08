using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanitorSystem.Model
{
    public class Assignment
    {
        #region props
        public int AssignId { get; set; }
        public string AssignTitle { get; set; }
        public string AssignText { get; set; }
        public DateTime Datetime { get; set; } 
        public DateTimeOffset Date { get; set; }
        public TimeSpan Time { get; set; }
        public int AssignRankNo { get; set; }
        public int DepId { get; set; }
        public int EmployeeId { get; set; }
        public ObservableCollection<Assignment> Assignments { get; set; }
#endregion

        public Assignment()
        {    

        }

        public override string ToString()
        {
            return $"{AssignTitle} ";
        }
    }
}
