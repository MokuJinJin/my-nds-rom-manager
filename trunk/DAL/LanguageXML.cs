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
        private static List<int> languageList;
        private static string stringLanguage = string.Empty;

        /// <summary>
        /// Constructor for LanguageXML
        /// </summary>
        static LanguageXML()
        {
            DicoLanguage = new Dictionary<int, string>();
            DicoLanguage.Add(-1, "All Languages");
            DicoLanguage.Add(1, "French");
            DicoLanguage.Add(2, "English");
            DicoLanguage.Add(4, "Chinese");
            DicoLanguage.Add(8, "Danish");
            DicoLanguage.Add(16, "Dutch");
            DicoLanguage.Add(32, "Finland");
            DicoLanguage.Add(64, "German");
            DicoLanguage.Add(128, "Italian");
            DicoLanguage.Add(256, "Japanese");
            DicoLanguage.Add(512, "Norvegian");
            DicoLanguage.Add(1024, "Polish");
            DicoLanguage.Add(2048, "Portuguese");
            DicoLanguage.Add(4096, "Spanish");
            DicoLanguage.Add(8192, "Swedish");
            DicoLanguage.Add(16384, "English (US)");
            DicoLanguage.Add(32768, "Portuguese (Brazil)");
            DicoLanguage.Add(65536, "Korean");
            DicoLanguage.Add(131072, "Russian");
            DicoLanguage.Add(262144, "Greek");
            DicoLanguage.Add(524288, "Turkish");
            DicoLanguage.Add(1048576, "Czech");
            DicoLanguage.Add(2097152, "Hungarian");

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

        public static Dictionary<int, string> DicoLanguage { get; private set; }

        public static string GetLanguage(int languageCode)
        {
            string ret = "N/A";
            if (DicoLanguage.ContainsKey(languageCode)) 
            {
                ret = DicoLanguage[languageCode].ToString(); 
            }
            else
            {
                SetLanguageString(languageCode, languageList.Count - 1);
                ret = stringLanguage.Remove(stringLanguage.Length - 2, 2);
                stringLanguage = string.Empty;
            }

            return ret;
        }

        private static void SetLanguageString(int i, int index)
        {
            while (i < languageList[index])
            {
                index--;
            }

            stringLanguage += DicoLanguage[languageList[index]] + ", ";
            i = i - languageList[index];
            if (i != 0)
            {
                SetLanguageString(i, index);
            }
        }

        public static List<int> GetLanguagesList(int languages)
        {
            List<int> l = new List<int>();
            if (DicoLanguage.ContainsKey(languages))
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
