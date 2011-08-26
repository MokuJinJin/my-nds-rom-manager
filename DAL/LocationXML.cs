
namespace NdsCRC_III.DAL
{
    using System.Collections.Generic;

    /// <summary>
    /// Class for location
    /// </summary>
    public static class LocationXML
    {
        private static Dictionary<int, string> dicoLocation = new Dictionary<int, string>();

        /// <summary>
        /// Constructor for LocationXML
        /// </summary>
        static LocationXML()
        {
            dicoLocation.Add(0, "Europe");
            dicoLocation.Add(1, "USA");
            dicoLocation.Add(2, "Germany");
            dicoLocation.Add(3, "China");
            dicoLocation.Add(4, "Spain");
            dicoLocation.Add(5, "France");
            dicoLocation.Add(6, "Italy");
            dicoLocation.Add(7, "Japan");
            dicoLocation.Add(8, "Nederland");
            dicoLocation.Add(9, "England");
            dicoLocation.Add(10, "Denmark");
            dicoLocation.Add(11, "Finland");
            dicoLocation.Add(12, "Norway");
            dicoLocation.Add(13, "Poland");
            dicoLocation.Add(14, "Portugal");
            dicoLocation.Add(15, "Sweden");
            dicoLocation.Add(16, "USA and Europe");
            dicoLocation.Add(17, "Japan, USA and Europe");
            dicoLocation.Add(18, "Japan and USA");
            dicoLocation.Add(19, "Australia");
            dicoLocation.Add(20, "North Korea");
            dicoLocation.Add(21, "Brazil");
            dicoLocation.Add(22, "Korea");
            dicoLocation.Add(23, "Europe and Brazil");
            dicoLocation.Add(24, "Europe, USA and Brazil");
            dicoLocation.Add(25, "USA and Brazil");
            dicoLocation.Add(26, "Russia");
            dicoLocation.Add(27, "Russia");
            dicoLocation.Add(28, "Greece");
            dicoLocation.Add(29, "Turkey");
            dicoLocation.Add(30, "Czech Republic");
            dicoLocation.Add(31, "Hungary");
        }
        
        public static string GetStringLocation(int locationCode)
        {
            string ret = "N/A";
            if (dicoLocation.ContainsKey(locationCode))
            {
                ret = dicoLocation[locationCode];
            }

            return ret;
        }
    }
}
