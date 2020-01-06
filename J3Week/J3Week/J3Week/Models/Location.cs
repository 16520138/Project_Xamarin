using System;
using System.Collections.Generic;
using System.Text;

namespace J3Week.Models
{
    public class Location : IMultiSelectModel
    {
        public string Name { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
    }
}
