using System;
using GoogleMaps.LocationServices;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TravelingSalesman
{
    class TravelingSalesmanApp
    {
        private const int NUM_CITIES = 10;
        static void Main(string[] args)
        { 
            List<Position> trip = new List<Position>();        
            var location = new GoogleLocationService("AIzaSyBcbePFUz2za7X3CgVF_-QGJIxLb_IYLa8");
            StreamReader r = new StreamReader(@"C:\Users\corey\Desktop\TravelingSalesman\TravelingSalesman\cities.json");
            string json = r.ReadToEnd();
            var names = JsonConvert.DeserializeObject(json);

                for (int i = 0; i < NUM_CITIES; i++)
            {
                var cityName = Console.ReadLine();
                var cityData = location.GetLatLongFromAddress(cityName);
                Position pos = new Position(cityData.Latitude, cityData.Longitude, cityName);
                trip.Add(pos);
            }
            
            TSPImplementation tsp  = new TSPImplementation (trip);
            tsp.fillMatrix();
            Console.Write("Computing trip");
            tsp.ComputeTrip();
            Console.WriteLine("Trip done."); 
            Console.WriteLine(tsp.ToString());
           
        }
    }
}
