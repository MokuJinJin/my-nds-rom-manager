using System.Collections.Generic;

namespace NdsCRC_III.DAL
{
    static class LocationXML
    {
        static private Dictionary<int, string> DicoLocation = new Dictionary<int, string>();
        static LocationXML()
        {
            DicoLocation.Add(0, "Europe");
            DicoLocation.Add(1, "USA");
            DicoLocation.Add(2, "Germany");
            DicoLocation.Add(3, "China");
            DicoLocation.Add(4, "Spain");
            DicoLocation.Add(5, "France");
            DicoLocation.Add(6, "Italy");
            DicoLocation.Add(7, "Japan");
            DicoLocation.Add(8, "Nederland");
            DicoLocation.Add(9, "England");
            DicoLocation.Add(10, "Denmark");
            DicoLocation.Add(11, "Finland");
            DicoLocation.Add(12, "Norway");
            DicoLocation.Add(13, "Poland");
            DicoLocation.Add(14, "Portugal");
            DicoLocation.Add(15, "Sweden");
            DicoLocation.Add(16, "USA and Europe");
            DicoLocation.Add(17, "Japan, USA and Europe");
            DicoLocation.Add(18, "Japan and USA");
            DicoLocation.Add(19, "Australia");
            DicoLocation.Add(20, "North Korea");
            DicoLocation.Add(21, "Brazil");
            DicoLocation.Add(22, "Korea");
            DicoLocation.Add(23, "Europe and Brazil");
            DicoLocation.Add(24, "Europe, USA and Brazil");
            DicoLocation.Add(25, "USA and Brazil");
            DicoLocation.Add(26, "Russia");
            DicoLocation.Add(27, "Russia");
            DicoLocation.Add(28, "Greece");
            DicoLocation.Add(29, "Turkey");
            DicoLocation.Add(30, "Czech Republic");
            DicoLocation.Add(31, "Hungary");
        }
        static public string getStringLocation(int LocationCode)
        {
            string ret = "N/A";
            if (DicoLocation.ContainsKey(LocationCode))
            {
                ret = DicoLocation[LocationCode];
            }
            return ret;
        }
    }
}
