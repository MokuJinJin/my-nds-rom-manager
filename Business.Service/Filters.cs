using System;
using Equin.ApplicationFramework;
using System.Collections.Generic;

namespace NdsCRC_III.BusinessService
{
    /// <summary>
    /// ChangeFilterEventHandler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">EventArgs</param>
    public delegate void ChangeFilterEventHandler(object sender, EventArgs e);

    /// <summary>
    /// ??
    /// </summary>
    /// <typeparam name="T">??</typeparam>
    public class Filters<T> : IItemFilter<T> where T : class
    {
        
        /// <summary>
        /// Event
        /// </summary>
        public event ChangeFilterEventHandler ChangeFilter;

        private string _titleFilter = string.Empty;
        private int _languageFilter = 0;
        private bool _demoRomFilter = true;

        #region IItemFilter<T> Members

        /// <summary>
        /// IItemFilter Member
        /// </summary>
        /// <param name="item">item</param>
        /// <returns>bool</returns>
        public bool Include(T item)
        {
            bool languageInclude = false;
            bool titleInclude = false;
            bool DemoRomInclude = false;
            if (_titleFilter != string.Empty)
            {
                titleInclude = (item as NDS_Rom).Title.ToLower().Contains(_titleFilter.ToLower());

            }
            else
            {
                titleInclude = true;
            }
            
            if (_languageFilter != 0)
            {
                languageInclude = (item as NDS_Rom).LanguageCode.Contains(_languageFilter);
            }
            else
            {
                languageInclude = true;
            }

            if (_demoRomFilter)
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

        /// <summary>
        /// Set the title filter
        /// </summary>
        /// <param name="title">title</param>
        public void SetTitleFilter(string title)
        {
            _titleFilter = title;
            ChangeFilter(this, new EventArgs());
        }
        
        /// <summary>
        /// Set Language Filter
        /// </summary>
        /// <param name="languageCode">language Code</param>
        public void SetLanguageFilter(int languageCode)
        {
            _languageFilter = languageCode;
            ChangeFilter(this, new EventArgs());
        }

        /// <summary>
        /// Reset the language filter
        /// </summary>
        public void ResetLanguageFilter()
        {
            _languageFilter = 0;
            ChangeFilter(this, new EventArgs());
        }

        /// <summary>
        /// Reset the title filter
        /// </summary>
        public void ResetTitleFilter()
        {
            _titleFilter = string.Empty;
            ChangeFilter(this, new EventArgs());
        }

        /// <summary>
        /// Set demo rom visible
        /// </summary>
        /// <param name="visible">True to set it visible, false to hide it</param>
        public void SetDemoRomFilter(bool visible)
        {
            _demoRomFilter = visible;
            ChangeFilter(this, new EventArgs());
        }
    }
}
