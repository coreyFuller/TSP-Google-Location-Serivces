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
        private double bestDistance;
        private static Random rng = new Random();
        private double[ , ] distanceMatrix; 
        public TSPImplementation(List<Position> Trip)
        {
            trip = new List<Position>();
            trip = Trip.ToList();
            tripMiles = 0;
            bestDistance = 200000;
            distanceMatrix = new double[trip.Count, trip.Count];
        }
        
        public void fillMatrix()
        {
            for(int i = 0; i < trip.Count; i++)
            {
                for(int j = 0; j < trip.Count; j++)
                {
                    distanceMatrix[i, j] = Math.Round(HaversineDistance(trip[i], trip[j]), 4, MidpointRounding.AwayFromZero); 
                }
            }
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

        public void printTour(List<Position> tour)
        {
            foreach (var city in tour) Console.WriteLine(city.ToString());
            Console.WriteLine();
        }

        public void ComputeTrip()
        {
            bestDistance = 200000;
            double tempDistance;
            List<Position> localOptimumTrip = new List<Position>();
            List<Position> randomTrip = new List<Position>();

            localOptimumTrip = trip;

            for (int i = 0; i < 500; i++)
            {
                bestDistance = 200000;
                randomTrip.Clear();
                //generate random tour
                randomTrip = new List<Position>(trip);
                randomShuffle(randomTrip);
                while (check(randomTrip))
                {
                    for (int j = 0; j < trip.Count; j++)
                    {
                        for (int k = 0; k < trip.Count; k++)
                        {
                            tempDistance = calculateTripDistance(randomTrip);
                            swap(randomTrip, j, trip.Count - k - 1);
                            if (calculateTripDistance(randomTrip) < tempDistance)
                                //localOptimumTrip = randomTrip;
                                localOptimumTrip = new List<Position>(randomTrip);
                            else
                                swap(randomTrip, j, trip.Count - k - 1);
                        }
                    }
                }
                if (calculateTripDistance(localOptimumTrip) < calculateTripDistance(trip))
                {
                    //trip = localOptimumTrip;
                    trip = new List<Position>(localOptimumTrip);
                    tripMiles = calculateTripDistance(trip);
                }
            }
        }
      
        public bool check(List<Position> list)
        {
            double dist = calculateTripDistance(list);
            if(dist < bestDistance)
            {
                bestDistance = dist;
                //tripMiles = bestDistance;
                return true;
            }
            return false;
        }
        public double calculateTripDistance(List<Position> list)
        {
            double distance = 0;
            for (int i = 0; i < list.Count - 1; i++) distance += distanceMatrix[list[i].Order, list[i + 1].Order];
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
            int i = 1;
            double hours = Math.Round(tripMiles/60, 0);
            double minutes = Math.Round((tripMiles / 60 - Math.Floor(tripMiles / 60)) * 60, 0);
            foreach (var city in trip)
            {
                s += i + ". " + city.ToString() + "\n";
                i++;
            }
            s += "\n";
            s += "\tTotal Route: " + hours + " hr " + minutes + " min - " + tripMiles + " miles\n";
            return s;
        }
    }
}
