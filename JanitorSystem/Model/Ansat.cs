using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanitorSystem.Model
{
    class Ansat
    {
        public string Afdeling { get; set; }
        public int Arbejdstid { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }

        public int Fødselsdag;
        public int Telefon { get; set; }
        public string Titel { get; set; }
        
    }
}
