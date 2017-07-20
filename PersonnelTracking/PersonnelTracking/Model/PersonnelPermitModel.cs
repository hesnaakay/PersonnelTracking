using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonnelTracking.Model
{
    public class PersonnelPermitModel
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string startingdate { get; set; }
        public string duedate { get; set; }
    }
}