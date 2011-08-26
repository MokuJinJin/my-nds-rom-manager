using System;
using Equin.ApplicationFramework;
using System.Collections.Generic;

namespace NdsCRC_III.BusinessService
{
    public delegate void ChangeFilterEventHandler(object sender, EventArgs e);

    public class Filters<T> : IItemFilter<T> where T : class
    {
        public event ChangeFilterEventHandler ChangeFilter;

        string TitleFilter = string.Empty;
        int LanguageFilter = 0;
        bool DemoRom = true;

        #region IItemFilter<T> Members

        public bool Include(T item)
        {
            bool languageInclude = false;
            bool titleInclude = false;
            bool DemoRomInclude = false;
            if (TitleFilter != string.Empty)
            {
                titleInclude = (item as NDS_Rom).Title.ToLower().Contains(TitleFilter.ToLower());

            }
            else
            {
                titleInclude = true;
            }
            
            if (LanguageFilter != 0)
            {
                languageInclude = (item as NDS_Rom).LanguageCode.Contains(LanguageFilter);
            }
            else
            {
                languageInclude = true;
            }

            if (DemoRom)
            {
                DemoRomInclude = true;
            }
            else
            {
                DemoRomInclude = !(item as NDS_Rom).IsDemo();
            }

            return languageInclude && titleInclude && DemoRomInclude;
        }

        #endregion

        public void SetTitleFilter(string filter)
        {
            TitleFilter = filter;
            ChangeFilter(this, new EventArgs());
        }
        public void SetLanguageFilter(int languageCode)
        {
            LanguageFilter = languageCode;
            ChangeFilter(this, new EventArgs());
        }
        public void ResetLanguageFilter()
        {
            LanguageFilter = 0;
            ChangeFilter(this, new EventArgs());
        }
        public void ResetTitleFilter()
        {
            TitleFilter = string.Empty;
            ChangeFilter(this, new EventArgs());
        }

        internal void SetDemoRomFilter(bool visible)
        {
            DemoRom = visible;
            ChangeFilter(this, new EventArgs());
        }
    }
}
