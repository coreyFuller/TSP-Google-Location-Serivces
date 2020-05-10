using System;
using System.Collections.Generic;
using System.Text;

namespace TravelingSalesman
{
    class Position
    {
        public Position(double x, double y, string city)
        {
            X = x;
            Y = y;
            City = city;

        }
        public double X { get; set; }       
        public double Y {get; set;}
        public string City { get; set;}
        public override string ToString()
        {
            return $" {City}: ({X},{Y})";
        }
    }
}
