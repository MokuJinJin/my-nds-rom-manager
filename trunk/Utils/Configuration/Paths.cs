//-----------------------------------------------------------------------
// <copyright file="Paths.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2010
// </copyright>
//-----------------------------------------------------------------------
namespace Utils.Configuration
{
    using System.Xml.Serialization;

    /// <summary>
    /// Application's Path
    /// </summary>
    public class Paths
    {
        /// <summary>
        /// True (default value) if all path are in under Application StartupPath, false otherwise
        /// </summary>
        private bool _underStartupPath = true;

        /// <summary>
        /// True (default value)  if all path are in under Application StartupPath, false otherwise
        /// </summary>
        [XmlAttribute("StartupPath")]
        public bool UnderStartupPath
        {
            get
            {
                return _underStartupPath;
            }

            set
            {
                _underStartupPath = value;
            }
        }

        /// <summary>
        /// Image's Directory
        /// </summary>
        [XmlElement("img")]
        public string DirImage
        {
            get
            {
                if (Parameter.Config.SerializationOntheWay)
                {
                    return _dirImage.Remove(0, Parameter.StartupPath.Length);
                }
                else
                {
                    return _dirImage;
                }
            }

            set
            {
                if (UnderStartupPath)
                {
                    _dirImage = string.Format("{0}{1}", Parameter.StartupPath, value);
                }
                else
                {
                    _dirImage = value;
                }
            }
        }

        /// <summary>
        /// Image's Directory
        /// </summary>
        private string _dirImage { get; set; }

        /// <summary>
        /// Nfo's Directory
        /// </summary>
        [XmlElement("nfo")]
        public string DirNFO
        {
            get
            {
                if (Parameter.Config.SerializationOntheWay)
                {
                    return _dirNfo.Remove(0, Parameter.StartupPath.Length);
                }
                else
                {
                    return _dirNfo;
                }
            }

            set
            {
                if (UnderStartupPath)
                {
                    _dirNfo = string.Format("{0}{1}", Parameter.StartupPath, value);
                }
                else
                {
                    _dirNfo = value;
                }
            }
        }

        /// <summary>
        /// Nfo's Directory
        /// </summary>
        private string _dirNfo { get; set; }

        /// <summary>
        /// NDS Rom's Directory
        /// </summary>
        [XmlElement("rom")]
        public string DirNdsRom
        {
            get
            {
                if (Parameter.Config.SerializationOntheWay)
                {
                    return _dirNdsRom.Remove(0, Parameter.StartupPath.Length);
                }
                else
                {
                    return _dirNdsRom;
                }
            }

            set
            {
                if (UnderStartupPath)
                {
                    _dirNdsRom = string.Format("{0}{1}", Parameter.StartupPath, value);
                }
                else
                {
                    _dirNdsRom = value;
                }
            }
        }

        /// <summary>
        /// NDS Rom's Directory
        /// </summary>
        private string _dirNdsRom { get; set; }

        /// <summary>
        /// Trash Directory
        /// </summary>
        [XmlElement("trash")]
        public string DirTrash
        {
            get
            {
                if (Parameter.Config.SerializationOntheWay)
                {
                    return _dirTrash.Remove(0, Parameter.StartupPath.Length);
                }
                else
                {
                    return _dirTrash;
                }
            }

            set
            {
                if (UnderStartupPath)
                {
                    _dirTrash = string.Format("{0}{1}", Parameter.StartupPath, value);
                }
                else
                {
                    _dirTrash = value;
                }
            }
        }

        /// <summary>
        /// Trash Directory
        /// </summary>
        private string _dirTrash { get; set; }

        /// <summary>
        /// Temporary Directory
        /// </summary>
        [XmlElement("temp")]
        public string DirTemp
        {
            get
            {
                if (Parameter.Config.SerializationOntheWay)
                {
                    return _dirTemp.Remove(0, Parameter.StartupPath.Length);
                }
                else
                {
                    return _dirTemp;
                }
            }

            set
            {
                if (UnderStartupPath)
                {
                    _dirTemp = string.Format("{0}{1}", Parameter.StartupPath, value);
                }
                else
                {
                    _dirTemp = value;
                }
            }
        }

        /// <summary>
        /// Temporary Directory
        /// </summary>
        private string _dirTemp { get; set; }

        /// <summary>
        /// New Rom Directory
        /// </summary>
        [XmlElement("newrom")]
        public string DirNewRom
        {
            get
            {
                if (Parameter.Config.SerializationOntheWay)
                {
                    return _dirNewRom.Remove(0, Parameter.StartupPath.Length);
                }
                else
                {
                    return _dirNewRom;
                } 
            }

            set
            {
                if (UnderStartupPath)
                {
                    _dirNewRom = string.Format("{0}{1}", Parameter.StartupPath, value);
                }
                else
                {
                    _dirNewRom = value;
                }
            }
        }

        /// <summary>
        /// New Rom Directory
        /// </summary>
        private string _dirNewRom { get; set; }

        /// <summary>
        /// Unknown Rom Directory
        /// </summary>
        [XmlElement("unknowrom")]
        public string DirUnknowRom
        {
            get
            {
                if (Parameter.Config.SerializationOntheWay)
                {
                    return _dirUnknowRom.Remove(0, Parameter.StartupPath.Length);
                }
                else
                {
                    return _dirUnknowRom;
                }
            }

            set
            {
                if (UnderStartupPath)
                {
                    _dirUnknowRom = string.Format("{0}{1}", Parameter.StartupPath, value);
                }
                else
                {
                    _dirUnknowRom = value;
                }
            }
        }

        /// <summary>
        /// Unknown Rom Directory
        /// </summary>
        private string _dirUnknowRom { get; set; }

        /// <summary>
        /// Already Have Rom Directory
        /// </summary>
        [XmlElement("AlreadyHave")]
        public string DirAlreadyHave
        {
            get
            {
                if (Parameter.Config.SerializationOntheWay)
                {
                    return _dirAlreadyHave.Remove(0, Parameter.StartupPath.Length);
                }
                else
                {
                    return _dirAlreadyHave;
                } 
            }

            set
            {
                if (UnderStartupPath)
                {
                    _dirAlreadyHave = string.Format("{0}{1}", Parameter.StartupPath, value);
                }
                else
                {
                    _dirAlreadyHave = value;
                }
            }
        }

        /// <summary>
        /// Already Have Rom Directory
        /// </summary>
        private string _dirAlreadyHave { get; set; }

        /// <summary>
        /// Image Flag's Directory
        /// </summary>
        [XmlElement("Flags")]
        public string DirImageFlag
        {
            get
            {
                if (Parameter.Config.SerializationOntheWay)
                {
                    return _dirImageFlag.Remove(0, Parameter.StartupPath.Length);
                }
                else
                {
                    return _dirImageFlag;
                }
            }

            set
            {
                if (UnderStartupPath)
                {
                    _dirImageFlag = string.Format("{0}{1}", Parameter.StartupPath, value);
                }
                else
                {
                    _dirImageFlag = value;
                }
            }
        }

        /// <summary>
        /// Image Flag's Directory
        /// </summary>
        private string _dirImageFlag { get; set; }

        /// <summary>
        /// Language Xml's Directory
        /// </summary>
        [XmlElement("Language")]
        public string DirLanguage
        {
            get
            {
                if (Parameter.Config.SerializationOntheWay)
                {
                    return _dirLanguage.Remove(0, Parameter.StartupPath.Length);
                }
                else
                {
                    return _dirLanguage;
                }
            }

            set
            {
                if (UnderStartupPath)
                {
                    _dirLanguage = string.Format("{0}{1}", Parameter.StartupPath, value);
                }
                else
                {
                    _dirLanguage = value;
                }
            }
        }

        /// <summary>
        /// Language Xml's Directory
        /// </summary>
        private string _dirLanguage { get; set; }

        /// <summary>
        /// Collection's XML full path
        /// </summary>
        [XmlElement("HaveDB")]
        public string XmlCollection
        {
            get
            {
                if (Parameter.Config.SerializationOntheWay)
                {
                    return _xmlCollection.Remove(0, Parameter.StartupPath.Length);
                }
                else
                {
                    return _xmlCollection;
                }
            }

            set
            {
                if (UnderStartupPath)
                {
                    _xmlCollection = string.Format("{0}{1}", Parameter.StartupPath, value);
                }
                else
                {
                    _xmlCollection = value;
                }
            }
        }

        /// <summary>
        /// Collection's XML full path
        /// </summary>
        private string _xmlCollection { get; set; }

        /// <summary>
        /// Database's XML full path
        /// </summary>
        [XmlElement("DB")]
        public string XmlDataBase
        {
            get
            {
                if (Parameter.Config.SerializationOntheWay)
                {
                    return _xmlDataBase.Remove(0, Parameter.StartupPath.Length);
                }
                else
                {
                    return _xmlDataBase;
                } 
            }

            set
            {
                if (UnderStartupPath)
                {
                    _xmlDataBase = string.Format("{0}{1}", Parameter.StartupPath, value);
                }
                else
                {
                    _xmlDataBase = value;
                }
            }
        }

        /// <summary>
        /// Database's XML full path
        /// </summary>
        private string _xmlDataBase { get; set; }
    }
}
