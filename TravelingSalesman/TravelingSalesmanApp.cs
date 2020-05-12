using System;
using GoogleMaps.LocationServices;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Collections;

namespace TravelingSalesman
{
    class TravelingSalesmanApp
    {
        private const int NUM_CITIES = 20;
        static void Main(string[] args)
        {
            List<Position> trip = new List<Position>();
           
            var location = new GoogleLocationService("AIzaSyBcbePFUz2za7X3CgVF_-QGJIxLb_IYLa8");
            for (int i = 0; i < NUM_CITIES; i++)
            {
                var cityName = Console.ReadLine();
                var cityData = location.GetLatLongFromAddress(cityName);
                Position pos = new Position(cityData.Latitude, cityData.Longitude, cityName);
                trip.Add(pos);
            }

            TSPImplementation tsp  = new TSPImplementation (trip);
            tsp.fillMatrix();
            tsp.ComputeTrip();
            Console.WriteLine(tsp.ToString());
        }
    }
}
