using System;
using GeoCoordinatePortable;
using System.Collections.Generic;

namespace ABCNet
{
    public class FoodSourceLocation
    {
        public GeoCoordinate GeoCoordinate { get; set; }

        public static FoodSourceLocation GenerateWithValues(double latitude, double longitude) {
            var fs = new FoodSourceLocation();
            fs.GeoCoordinate = new GeoCoordinate(latitude, longitude);
            return fs;
        }

        public static FoodSourceLocation GenerateRandom(Random rand) {
            var fs = new FoodSourceLocation();
            int lat = rand.Next(516400146, 630304598);
            int lon = rand.Next(224464416, 341194152);
            fs.GeoCoordinate = new GeoCoordinate(18d + lat / 1000000000d, -72d - lon / 1000000000d);
            return fs;
        }
    }

    public class LocationFoodSource : IFoodSource
    {
        public LocationFoodSource(FoodSourceLocation location) {
            Location = location;
        }
        public FoodSourceLocation Location { get; set; }
        public int TrialsCount { get; set; }
        public double Fitness { get; set; }
        public bool IsAbandoned { get; set; }

        private string uniqueName = Guid.NewGuid().ToString("N");

		public override string ToString()
		{
			return uniqueName;
		}

        public double CalculateDistance(IFoodSource other)
        {
            return Location.GeoCoordinate.GetDistanceTo((other as LocationFoodSource).Location.GeoCoordinate);
        }

        public double CalculateFitness(Bee bee)
        {
            return Location.GeoCoordinate.Latitude;
        }
    }
}