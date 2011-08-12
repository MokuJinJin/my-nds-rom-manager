//-----------------------------------------------------------------------
// <copyright file="RomCollection.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2011
// </copyright>
//-----------------------------------------------------------------------
namespace NdsCRC_III.DAL
{
    using System.Collections.Generic;
    using System.Xml.Serialization;
    
    [XmlRoot("NDSCollection")]
    public class NDSCollection
    {
        public NDSCollection()
        {
            DataBase = new List<NDS_Rom>();
        }

        [XmlArray("Collection")]
        [XmlArrayItem("NdsRom")]
        public List<NDS_Rom> DataBase { get; set; }

    }
}
