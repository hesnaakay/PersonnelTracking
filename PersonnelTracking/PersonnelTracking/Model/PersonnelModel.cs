﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonnelTracking.Model
{
    public class PersonnelModel
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string phonenumber { get; set; }
        public string address { get; set; }
        public int totalpermit { get; set; }
        public int usedpermit { get; set; }
    }
}