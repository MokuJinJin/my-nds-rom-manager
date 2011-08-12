//-----------------------------------------------------------------------
// <copyright file="LanguageXML.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2010
// </copyright>
//-----------------------------------------------------------------------
namespace NdsCRC_III.DAL
{
    using System.Collections.Generic;

    public static class LanguageXML
    {
        static public Dictionary<int, string> DicoLanguage = new Dictionary<int, string>();
        static private List<int> LanguageList = new List<int>();
        static private string StringLanguage = "";
        static public string getLanguage(int LanguageCode)
        {
            string ret = "N/A";
            if (DicoLanguage.ContainsKey(LanguageCode)) { ret = DicoLanguage[LanguageCode].ToString(); }
            else
            {
                setLanguageString(LanguageCode, LanguageList.Count - 1);
                ret = StringLanguage.Remove(StringLanguage.Length - 2, 2);
                StringLanguage = "";
            }

            return ret;
        }
        private static void setLanguageString(int i, int index)
        {
            while (i < LanguageList[index])
            {
                index--;
            }
            StringLanguage += DicoLanguage[LanguageList[index]] + ", ";
            i = i - LanguageList[index];
            if (i != 0)
            {
                setLanguageString(i, index);
            }
        }
        public static List<int> getLanguagesList(int languages)
        {
            
            List<int> l = new List<int>();
            if (DicoLanguage.ContainsKey(languages))
            {
                l.Add(languages);
                return l;
            }
            else
            {
                int index = LanguageList.Count - 1;
                while (languages < LanguageList[index])
                {
                    index--;
                }
                l.Add(LanguageList[index]);
                languages -= LanguageList[index];
                if (languages != 0)
                {
                    l.AddRange(getLanguagesList(languages));
                }
            }
            return l;
        }
        static LanguageXML()
        {
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

            LanguageList.Add(1);
            LanguageList.Add(2);
            LanguageList.Add(4);
            LanguageList.Add(8);
            LanguageList.Add(16);
            LanguageList.Add(32);
            LanguageList.Add(64);
            LanguageList.Add(128);
            LanguageList.Add(256);
            LanguageList.Add(512);
            LanguageList.Add(1024);
            LanguageList.Add(2048);
            LanguageList.Add(4096);
            LanguageList.Add(8192);
            LanguageList.Add(16384);
            LanguageList.Add(32768);
            LanguageList.Add(65536);
            LanguageList.Add(131072);
            LanguageList.Add(262144);
            LanguageList.Add(524288);
            LanguageList.Add(1048576);
            LanguageList.Add(2097152);

        }
    }
}
