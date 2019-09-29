using System;
using System.Collections.Generic;
using System.Text;

namespace NewFeatures
{
    public interface IRoom
    {
        public double length { get; set; }

        public double width { get; set; }

        public double SquareFeet { get => length * width; }
    }
}
