//-----------------------------------------------------------------------
// <copyright file="MFControler.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2010
// </copyright>
//-----------------------------------------------------------------------
namespace NdsCRC_III.BusinessService
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Equin.ApplicationFramework;
    using NdsCRC_III.DAL;
    using NdsCRC_III.TO;
    using SevenZip;
    using Utils.Configuration;

    /// <summary>
    /// Controler du Main Form
    /// </summary>
    public class MFControler
    {
        #region Field
        /// <summary>
        /// Database
        /// </summary>
        private BindingListView<NDS_Rom> _advanSceneDataBase;

        /// <summary>
        /// Collection
        /// </summary>
        private BindingListView<NDS_Rom> _collection;

        /// <summary>
        /// Rom missing
        /// </summary>
        private BindingListView<NDS_Rom> _collectionMissing;

        /// <summary>
        /// filters
        /// </summary>
        private Filters<NDS_Rom> _filters = new Filters<NDS_Rom>();

        /// <summary>
        /// Current selected Rom
        /// </summary>
        private NDS_Rom _currentNDSRom;

        /// <summary>
        /// Current selected GridView name
        /// </summary>
        private string _currentGridViewName;

        #endregion

        /// <summary>
        /// Initializes a new instance of the Controler class
        /// </summary>
        public MFControler()
        {
            InitDataBase();
            _currentNDSRom = null;
            _currentGridViewName = string.Empty;
            _filters.ChangeFilter += new ChangeFilterEventHandler(F_ChangeFilter);
        }

        #region Property

        /// <summary>
        /// Date of the creation of the Advanscene database
        /// </summary>
        public string DatCreationDate
        {
            get
            {
                return DataAcessLayer.DatCreationDate;
            }
        }

        /// <summary>
        /// File name of the database to download
        /// </summary>
        public string DatFileName
        {
            get
            {
                return DataAcessLayer.URLs["datFileName"];
            }
        }

        /// <summary>
        /// Urls of the database
        /// </summary>
        public string DatURL
        {
            get
            {
                return DataAcessLayer.URLs["datURL"];
            }
        }

        /// <summary>
        /// Dat Version of the database
        /// </summary>
        public string DatVersion
        {
            get
            {
                return DataAcessLayer.DatVersion;
            }
        }
        
        /// <summary>
        /// URL of the datVersion file
        /// </summary>
        public string DatVersionURL
        {
            get
            {
                return DataAcessLayer.URLs["datVersionURL"];
            }
        }

        #endregion

        #region Current Selected
        
        /// <summary>
        /// Set current selected rom from a release number
        /// </summary>
        /// <param name="romReleaseNumber">Rom Release number</param>
        public void SetCurrentNdsRom(string romReleaseNumber)
        {
            _currentNDSRom = GetRomByReleaseNumber(romReleaseNumber);
        }

        /// <summary>
        /// No current Rom Selected
        /// </summary>
        public void SetNoCurrentRom()
        {
            _currentNDSRom = null;
        }

        /// <summary>
        /// Get the current selected Rom
        /// </summary>
        /// <returns>NDS Rom</returns>
        public NDS_Rom GetCurrentRom()
        {
            return _currentNDSRom;
        }

        /// <summary>
        /// Check if a current rom is selected
        /// </summary>
        /// <returns>True if a rom is currently selected, false otherwise</returns>
        public bool IsRomSelected()
        {
            return _currentNDSRom != null;
        }

        /// <summary>
        /// Set current selected gridView
        /// </summary>
        /// <param name="gridViewName">Rom Release number</param>
        public void SetCurrentGridView(string gridViewName)
        {
            _currentGridViewName = gridViewName;
        }

        /// <summary>
        /// Get the current selected GridView Name
        /// </summary>
        /// <returns>Current GridView Name</returns>
        public string GetCurrentGridView()
        {
            return _currentGridViewName;
        }

        /// <summary>
        /// Check if a GridView is selected
        /// </summary>
        /// <returns>True if a GridView is currently selected, false otherwise</returns>
        public bool IsGridViewSelected()
        {
            return _currentGridViewName != string.Empty;
        }
        #endregion

        #region Accesseurs
        /// <summary>
        /// Get the full database
        /// </summary>
        /// <returns>BindingListView with the full database</returns>
        public BindingListView<NDS_Rom> GetDataBase()
        {
            return _advanSceneDataBase;
        }

        /// <summary>
        /// Get the collection database
        /// </summary>
        /// <returns>BindingListView with the collection</returns>
        public BindingListView<NDS_Rom> GetCollection()
        {
            return _collection;
        }

        /// <summary>
        /// Get the Rom Missing in the Collection
        /// </summary>
        /// <returns>BindingListView with the Missing rom in the Collection</returns>
        public BindingListView<NDS_Rom> GetCollectionMissing()
        {
            return _collectionMissing;
        }

        /// <summary>
        /// Return all Language
        /// </summary>
        /// <returns>All languages</returns>
        public Dictionary<int, string> GetLanguages()
        {
            return LanguageXML.Languages;
        }

        #endregion

        #region DataBase
        /// <summary>
        /// Initialize all data
        /// </summary>
        private void InitDataBase()
        {
            _advanSceneDataBase = new BindingListView<NDS_Rom>(DataAcessLayer.NdsAdvanScene);
            _collection = new BindingListView<NDS_Rom>(DataAcessLayer.NdsCollection);
            _collectionMissing = new BindingListView<NDS_Rom>(DataAcessLayer.NdsCollectionMissing);
        }

        /// <summary>
        /// Reload the AdvanScene Database due to change (update)
        /// </summary>
        public void ReloadAdvanSceneDataBase()
        {
            DataAcessLayer.NdsAdvanSceneReload();
            InitDataBase();
        }

        /// <summary>
        /// Method to Extract New DataBase
        /// </summary>
        public void ExtractNewDataBase()
        {
            if (File.Exists(Directory.GetParent(Parameter.Config.Paths.XmlDataBase) + "\\ADVANsCEne_NDScrc.xml.old"))
            {
                File.Delete(Directory.GetParent(Parameter.Config.Paths.XmlDataBase) + "\\ADVANsCEne_NDScrc.xml.old");
            }

            File.Move(Parameter.Config.Paths.XmlDataBase, Directory.GetParent(Parameter.Config.Paths.XmlDataBase) + "\\ADVANsCEne_NDScrc.xml.old");

            SevenZipExtractor.SetLibraryPath("7z.dll");
            SevenZipExtractor extract = new SevenZipExtractor(this.DatFileName);
            extract.ExtractArchive(Directory.GetParent(Parameter.Config.Paths.XmlDataBase).ToString());

            // ReloadAdvanSceneDataBase();
            File.Delete("ADVANsCEne_NDScrc.zip");
        }

        /// <summary>
        /// Test -> Repair the collection
        /// </summary>
        public void RepairCollection()
        {
            DataAcessLayer.RepairCollection();
        }

        /// <summary>
        /// Get NDS_Rom from its release number
        /// </summary>
        /// <param name="releaseNumber">release number of a rom</param>
        /// <returns>NDS_Rom</returns>
        public NDS_Rom GetRomByReleaseNumber(string releaseNumber)
        {
            NDS_Rom rom = DataAcessLayer.NdsAdvanScene.Single(r => r.ReleaseNumber == releaseNumber);
            return rom;
        }
        #endregion

        #region Filters

        /// <summary>
        /// ChangeFilterEventHandler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void F_ChangeFilter(object sender, EventArgs e)
        {
            _advanSceneDataBase.ApplyFilter(_filters);
            _collection.ApplyFilter(_filters);
            _collectionMissing.ApplyFilter(_filters);
        }

        /// <summary>
        /// Check if duplicate filter is active
        /// </summary>
        /// <returns>True if duplicate filter is active, false otherwise</returns>
        public bool IsDuplicateFilterActive()
        {
            return _filters.DuplicateFilterActive();
        }

        /// <summary>
        /// Set the Duplicate ID Filter
        /// </summary>
        /// <param name="id">duplicate id</param>
        public void SetDuplicateFilter(int id)
        {
            _filters.SetDuplicateIdFilter(id);
        }

        /// <summary>
        /// Set the Duplicate ID Filter from the current rom
        /// </summary>
        public void SetDuplicateFilterFromCurrentRom()
        {
            _filters.SetDuplicateIdFilter(_currentNDSRom.DuplicateID);
        }

        /// <summary>
        /// Set the filter Demo rom  visible
        /// </summary>
        /// <param name="visible">True to see the Demo Rom, false to hide it</param>
        public void SetFilterDemo(bool visible)
        {
            _filters.SetDemoRomFilter(visible);
        }

        /// <summary>
        /// Apply Filter by title
        /// </summary>
        /// <param name="title">Tilte</param>
        public void SetTitleFilter(string title)
        {
            _filters.SetTitleFilter(title);
        }

        /// <summary>
        /// Set language filter on the given code 
        /// </summary>
        /// <param name="languageCode">language code to set the filter on</param>
        public void SetLanguageFilter(int languageCode)
        {
            _filters.SetLanguageFilter(languageCode);
        }

        /// <summary>
        /// Set No/All Language Filter
        /// </summary>
        public void SetNoLanguageFilter()
        {
            _filters.ResetLanguageFilter();
        }

        /// <summary>
        /// Set no duplicate filter
        /// </summary>
        public void SetNoDuplicateFilter()
        {
            _filters.ResetDuplicateID();
        }
        
        /// <summary>
        /// Reset All Filters
        /// </summary>
        /// <param name="keepSorts">Keeping sorts</param>
        public void ResetAllFilters(bool keepSorts)
        {
            if (!keepSorts)
            {
                _advanSceneDataBase.RemoveSort();
                _collection.RemoveSort();
                _collectionMissing.RemoveSort();
            }
            else
            {
                // InitDataBase();
            }

            _filters.ResetLanguageFilter();
            _filters.ResetTitleFilter();

            // HACK : DemoFilter always to True
            _filters.SetDemoRomFilter(true);

            _advanSceneDataBase.RemoveFilter();
            _collection.RemoveFilter();
            _collectionMissing.RemoveFilter();
        }

        #endregion
    }
}
