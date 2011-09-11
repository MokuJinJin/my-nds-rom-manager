//-----------------------------------------------------------------------
// <copyright file="RomCollection.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2011
// </copyright>
//-----------------------------------------------------------------------
namespace NdsCRC_III.DAL
{
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using NdsCRC_III.TO;
    
    /// <summary>
    /// Collection of Nds Rom
    /// </summary>
    [XmlRoot("NDSCollection")]
    public class NDSCollection
    {
        /// <summary>
        /// Constructor for NDSCollection
        /// </summary>
        public NDSCollection()
        {
            DataBase = new List<NDS_Rom>();
        }

        /// <summary>
        /// List of roms
        /// </summary>
        [XmlArray("Collection")]
        [XmlArrayItem("NdsRom")]
        public List<NDS_Rom> DataBase { get; set; }
    }
}
