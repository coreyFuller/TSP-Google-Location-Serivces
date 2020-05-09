using System;
using System.Collections.Generic;
using System.Text;

namespace TravelingSalesman
{
    class TSPImplementation
    {
        public double HaversineDistance(Position pos1, Position pos2)
        {
            double R = 3960;
            double offset = .85;
            var lat = toRadians(pos2.X - pos1.X);
            var lng = toRadians(pos2.Y - pos1.Y);
            double lat1 = toRadians(pos1.X);
            double lat2 = toRadians(pos2.X);
            var a = Math.Sin(lat / 2) * Math.Sin(lat / 2) + Math.Sin(lng / 2) * Math.Sin(lng / 2) * Math.Cos(lat1) * Math.Cos(lat2);
            var c = 2 * Math.Asin(Math.Sqrt(a));
            return R * 2 * Math.Asin(Math.Sqrt(a)) / offset;
        }
        public double toRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }
}
