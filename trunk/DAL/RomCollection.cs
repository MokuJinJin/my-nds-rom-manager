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
    public class Collection
    {
        /// <summary>
        /// Constructor for NDSCollection
        /// </summary>
        public Collection()
        {
            NdsDataBase = new List<NDS_Rom>();
        }

        /// <summary>
        /// List of roms
        /// </summary>
        [XmlArray("NDSCollection")]
        [XmlArrayItem("NDS_Rom")]
        public List<NDS_Rom> NdsDataBase { get; set; }
    }
}
