using System;
using GoogleMaps.LocationServices;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;

namespace TravelingSalesman
{
    class TravelingSalesmanApp
    {
        static void Main(string[] args)
        {
            //Bitmap bitmap = Bitmap.FromFIle()
            TSPImplementation tsp = new TSPImplementation();
            var Greenville = "Greenville, SC";
            var Spartanburg = "Spartanburg, SC";
            var location = new GoogleLocationService("AIzaSyBcbePFUz2za7X3CgVF_-QGJIxLb_IYLa8");
            var greenville = location.GetLatLongFromAddress(Greenville);
            var spartanburg = location.GetLatLongFromAddress(Spartanburg);
            Console.WriteLine($" {Greenville}: {greenville.Latitude} , {greenville.Longitude}");
            Console.WriteLine($"{Spartanburg}: {spartanburg.Latitude} , {spartanburg.Longitude}");
            Position pos1 = new Position(greenville.Latitude, greenville.Longitude, Greenville);
            Position pos2 = new Position(spartanburg.Latitude, spartanburg.Longitude, Spartanburg);
            Console.WriteLine($"Distance between cities: {tsp.HaversineDistance(pos1, pos2)}");
        }
    }
}
