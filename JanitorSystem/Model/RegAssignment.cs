using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanitorSystem.Model
{
    public class RegAssignment
    {
        #region Properties

         public int RegAssignId { get; set; }

        public string RegAssignTitle { get; set; }

        public string RegAssignText { get; set; }

        #endregion

        public override string ToString()
        {
            return RegAssignTitle;
        }
    }
}
