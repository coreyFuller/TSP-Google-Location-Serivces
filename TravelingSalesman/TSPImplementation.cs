using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace TravelingSalesman
{
    class TSPImplementation
    {
        private List<Position> trip;
        private double tripMiles;
        private double localDistance;
        private static Random rng = new Random();
        public TSPImplementation(List<Position> Trip)
        {
            trip = new List<Position>();
            trip = Trip.ToList();
            tripMiles = 0;
            localDistance = 200000;
        }

        public void swap(List<Position> list, int first, int second)
        {
            var temp = list[first];
            list[first] = list[second];
            list[second] = temp;
        }

        public void randomShuffle(List<Position> list)
        {
            for (int n = list.Count - 1; n > 0; n--)
            {
                int swapIndex = rng.Next(0, n);
                swap(list, n, swapIndex);
            }
        }

        public double ComputeTrip()
        {
            localDistance = 200000;
            double tempDistance;
            List<Position> localOptimumTrip = new List<Position>();
            List<Position> randomTrip = new List<Position>();

            localOptimumTrip = trip;
   
            for (int i = 0; i < 1000; i++)
            {
                localDistance = 200000;
                randomTrip.Clear();
                //generate random tour
                while (check(trip))
                {
                    /*
                    for (int i = 0; i < trip.Count; i++)
                    {
                        for (int j = 0; j < trip.Count; j++)
                        {
                            //check tour distance
                            //reverse random trip
                            

                        }
                    }
                    */
                }
            }
            return caluclateTripDistance();
        }
        
        public bool check(List<Position> list)
        {
            double dist = caluclateTripDistance();
            if(dist < localDistance)
            {
                localDistance = dist;
                return true;
            }
            return false;
        }
        public double caluclateTripDistance()
        {
            double distance = 0;
            for (int i = 0; i < trip.Count - 1; i++) distance += HaversineDistance(trip[i], trip[i + 1]);
            tripMiles = distance;
            return distance;
        }
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

        public override string ToString()
        {
            string s = "";
            foreach(var city in trip) s += city.ToString();
            s += "\n";
            s += "Distance of the trip: " + tripMiles + " mi";
            return s;
        }
    }
}
