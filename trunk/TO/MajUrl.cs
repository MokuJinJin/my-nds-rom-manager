//-----------------------------------------------------------------------
// <copyright file="MajUrl.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2010
// </copyright>
//-----------------------------------------------------------------------
namespace NdsCRC_III.TO
{
    /// <summary>
    /// Class used for downloading file
    /// </summary>
    public class MajUrl
    {
        /// <summary>
        /// URI of the download
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// File Path where to put the download
        /// </summary>
        public string Filepath { get; set; }
    }
}
