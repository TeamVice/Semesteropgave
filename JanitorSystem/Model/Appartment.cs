using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanitorSystem.Model
{
    public class Appartment
    {
        #region Properties
        public  int AppartNo { get; set; }
        public string AppartmentOwner { get; set; }
        public int AppartmentPhone1 { get; set; }
        public int AppartmentPhone2 { get; set; }
        public int AppartBuildingNo { get; set; }
        public int DepId { get; set; }
        #endregion

        

        public override string ToString()
        {
            return $"{AppartNo}";
        }
    }
}
