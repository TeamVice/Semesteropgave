using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanitorSystem.Model
{
    public class Appartment
    {
        public int AppartNo { get; set; }
        public int ClientBuildingNo { get; set; }
        public int ClientId { get; set; }
        public int DepId { get; set; }

        public override string ToString()
        {
            return $"{AppartNo}";
        }
    }
}
