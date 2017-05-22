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
        /// <summary
        /// Properties that match the Appartment tabel attributs in the database.
        /// </summary>
        public int AppartNo { get; set; }
        public string AppartmentOwner { get; set; }
        public int AppartmentPhone1 { get; set; }
        public int AppartmentPhone2 { get; set; }
        public int BuildingNo { get; set; }
        public int DepId { get; set; }
        #endregion


        #region Tostring method override
        /// <summary>
        /// Method ToString which is overided to show the appartment No 
        /// in the combobox in the Addassignment View.
        /// </summary>
        public override string ToString()
        {
            return $"{AppartNo}";
        }
        #endregion

    }
}
