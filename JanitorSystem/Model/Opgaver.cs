using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanitorSystem.Model
{
    class Opgaver
    {
        public string Adresse { get; set; }
        public string AnmelderFornavn { get; set; }
        public string AnmelderEfternavn { get; set; }
        public string OpgaveBeskrivelse { get; set; }
        public int Opgave_Id { get; set; }
        public string Titel { get; set; }
    }
}
