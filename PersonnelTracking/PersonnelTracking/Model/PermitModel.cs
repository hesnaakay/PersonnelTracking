using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonnelTracking.Model
{
    public class PermitModel
    {
        public int id { get; set; }
        public DateTime startingdate { get; set; }
        public DateTime duedate { get; set; }
        
    }
}