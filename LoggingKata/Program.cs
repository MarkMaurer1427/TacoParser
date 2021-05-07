using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");


            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            var locations = lines.Select(parser.Parse).ToArray();

            ITrackable PointA = null;
            ITrackable PointB = null;

            double distance = 0;

            for (int i = 0; i < locations.Length; i++)
            {
                GeoCoordinate locA = new GeoCoordinate();
                locA.Latitude = locations[i].Location.Latitude;
                locA.Longitude = locations[i].Location.Longitude;

                for (int j = 0; j < locations.Length; j++)
                {
                    GeoCoordinate locB = new GeoCoordinate();
                    locB.Latitude = locations[i].Location.Latitude;
                    locB.Longitude = locations[i].Location.Longitude;
                    double localDistance = locA.GetDistanceTo(locB);

                    if (localDistance > distance)
                    {
                        distance = localDistance;
                        PointA = locations[i];
                        PointB = locations[j];

                    }

                }
                
            }
            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)

            // Create a new corA Coordinate with your locA's lat and long

            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)

            // Create a new Coordinate with your locB's lat and long

            // Now, compare the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.


            
        }
    }
}
