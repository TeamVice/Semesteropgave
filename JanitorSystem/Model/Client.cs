using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanitorSystem.Model
{
    public class Client
    {
        #region props
        public int ClientId { get; set; }

        public int ClientBuildingNo { get; set; }

        public string ClientName { get; set; }
        
        public int ClientPhone1 { get; set; }

        public int ClientPhone2 { get; set; }
#endregion

        public Client()
        {

        }

        public override string ToString()
        {
            return $"{ClientPhone1}";
        }
    }
}
