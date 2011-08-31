//-----------------------------------------------------------------------
// <copyright file="Filters.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2010
// </copyright>
//-----------------------------------------------------------------------
namespace NdsCRC_III.BusinessService
{
    using System;
    using Equin.ApplicationFramework;
    using NdsCRC_III.TO;

    /// <summary>
    /// ChangeFilterEventHandler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">EventArgs</param>
    public delegate void ChangeFilterEventHandler(object sender, EventArgs e);

    /// <summary>
    /// Unknown
    /// </summary>
    /// <typeparam name="T">whatever</typeparam>
    public class Filters<T> : IItemFilter<T> where T : class
    {
        /// <summary>
        /// Title Filter
        /// </summary>
        private string _titleFilter = string.Empty;
        
        /// <summary>
        /// Language Filter
        /// </summary>
        private int _languageFilter = 0;
        
        /// <summary>
        /// Demo Filter
        /// </summary>
        private bool _demoRomFilter = true;

        /// <summary>
        /// Event
        /// </summary>
        public event ChangeFilterEventHandler ChangeFilter;

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
            bool demoRomInclude = false;
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
                demoRomInclude = true;
            }
            else
            {
                demoRomInclude = !(item as NDS_Rom).IsDemo();
            }

            return languageInclude && titleInclude && demoRomInclude;
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
