namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log that and return null
                // Do not fail if one record parsing fails, return null
                return null; // TODO Implement
            }

            double latitude = double.Parse(cells[0]);
            double longitude = double.Parse(cells[1]);
            string name = cells[2];

            Point loc = new Point();
            loc.Latitude = latitude;
            loc.Longitude = longitude;

            var tb = new TacoBell(loc, name);

            return tb;
        }
    }
}