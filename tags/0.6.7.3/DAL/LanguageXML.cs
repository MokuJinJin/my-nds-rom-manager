//-----------------------------------------------------------------------
// <copyright file="LanguageXML.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2010
// </copyright>
//-----------------------------------------------------------------------
namespace NdsCRC_III.DAL
{
    using System.Collections.Generic;

    /// <summary>
    /// Class for the Languages
    /// </summary>
    public static class LanguageXML
    {
        /// <summary>
        /// List of language code
        /// </summary>
        private static List<int> languageList;

        /// <summary>
        /// Used to construct Language String
        /// </summary>
        private static string stringLanguage = string.Empty;

        /// <summary>
        /// Constructor for LanguageXML
        /// </summary>
        static LanguageXML()
        {
            _dicoLanguage = new Dictionary<int, string>();
            _dicoLanguage.Add(-1, "All Languages");
            _dicoLanguage.Add(1, "French");
            _dicoLanguage.Add(2, "English");
            _dicoLanguage.Add(4, "Chinese");
            _dicoLanguage.Add(8, "Danish");
            _dicoLanguage.Add(16, "Dutch");
            _dicoLanguage.Add(32, "Finland");
            _dicoLanguage.Add(64, "German");
            _dicoLanguage.Add(128, "Italian");
            _dicoLanguage.Add(256, "Japanese");
            _dicoLanguage.Add(512, "Norvegian");
            _dicoLanguage.Add(1024, "Polish");
            _dicoLanguage.Add(2048, "Portuguese");
            _dicoLanguage.Add(4096, "Spanish");
            _dicoLanguage.Add(8192, "Swedish");
            _dicoLanguage.Add(16384, "English (US)");
            _dicoLanguage.Add(32768, "Portuguese (Brazil)");
            _dicoLanguage.Add(65536, "Korean");
            _dicoLanguage.Add(131072, "Russian");
            _dicoLanguage.Add(262144, "Greek");
            _dicoLanguage.Add(524288, "Turkish");
            _dicoLanguage.Add(1048576, "Czech");
            _dicoLanguage.Add(2097152, "Hungarian");

            languageList = new List<int>();
            languageList.Add(1);
            languageList.Add(2);
            languageList.Add(4);
            languageList.Add(8);
            languageList.Add(16);
            languageList.Add(32);
            languageList.Add(64);
            languageList.Add(128);
            languageList.Add(256);
            languageList.Add(512);
            languageList.Add(1024);
            languageList.Add(2048);
            languageList.Add(4096);
            languageList.Add(8192);
            languageList.Add(16384);
            languageList.Add(32768);
            languageList.Add(65536);
            languageList.Add(131072);
            languageList.Add(262144);
            languageList.Add(524288);
            languageList.Add(1048576);
            languageList.Add(2097152);
        }

        /// <summary>
        /// List of all language whith their code
        /// </summary>
        private static Dictionary<int, string> _dicoLanguage { get; set; }

        /// <summary>
        /// List of all language whith their code
        /// </summary>
        public static Dictionary<int, string> Languages
        {
            get
            {
                return _dicoLanguage;
            }
        }

        /// <summary>
        /// Calculate string for display form a language code
        /// </summary>
        /// <param name="languageCode">language code</param>
        /// <returns>N/A if no language found, string with all the language separated by comma</returns>
        public static string GetLanguage(int languageCode)
        {
            string ret = "N/A";
            if (_dicoLanguage.ContainsKey(languageCode)) 
            {
                ret = _dicoLanguage[languageCode].ToString(); 
            }
            else
            {
                SetLanguageString(languageCode, languageList.Count - 1);
                ret = stringLanguage.Remove(stringLanguage.Length - 2, 2);
                stringLanguage = string.Empty;
            }

            return ret;
        }

        /// <summary>
        /// add Language string to the final language string
        /// </summary>
        /// <param name="i">i don't know</param>
        /// <param name="index">only god know</param>
        private static void SetLanguageString(int i, int index)
        {
            while (i < languageList[index])
            {
                index--;
            }

            stringLanguage += _dicoLanguage[languageList[index]] + ", ";
            i = i - languageList[index];
            if (i != 0)
            {
                SetLanguageString(i, index);
            }
        }

        /// <summary>
        /// i don't know
        /// </summary>
        /// <param name="languages">only god know</param>
        /// <returns>whatever</returns>
        public static List<int> GetLanguagesList(int languages)
        {
            List<int> l = new List<int>();
            if (_dicoLanguage.ContainsKey(languages))
            {
                l.Add(languages);
                return l;
            }
            else
            {
                int index = languageList.Count - 1;
                while (languages < languageList[index])
                {
                    index--;
                }

                l.Add(languageList[index]);
                languages -= languageList[index];
                if (languages != 0)
                {
                    l.AddRange(GetLanguagesList(languages));
                }
            }

            return l;
        }
    }
}
