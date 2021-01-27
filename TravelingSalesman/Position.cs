using System;
using System.Collections.Generic;
using System.Text;

namespace TravelingSalesman
{
    class Position
    {
        public static int order = 0;
        public Position(double x, double y, string city)
        {
            X = x;
            Y = y;
            City = city;
            Order = order++;

        }
        public double X { get; set; }       
        public double Y {get; set;}
        public int Order { get; set; }
        public string City { get; set;}
        public override string ToString()
        {
            return $"{City}: ({X},{Y})";
        }
    }
}
