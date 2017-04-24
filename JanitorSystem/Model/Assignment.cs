using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanitorSystem.Model
{
    class Assignment
    {
        public string clientFirstName { get; set; }
        public string clientLastName { get; set; }
        public string clientAddress { get; set; }
        public int assignId { get; set; }
        public string assignTitle { get; set; }
        public string assignDescription { get; set; }

        public Assignment()
        {

        }

        //public override string ToString()
        //{
        //    return null;
        //}
    }
}
