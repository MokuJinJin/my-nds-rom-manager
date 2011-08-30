namespace NdsCRC_III.BusinessService
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Equin.ApplicationFramework;
    using NdsCRC_III.DAL;
    using SevenZip;
    

    /// <summary>
    /// Controler du Main Form
    /// </summary>
    public class MFControler
    {
        /// <summary>
        /// Database
        /// </summary>
        private BindingListView<NDS_Rom> AdvanSceneDataBase;

        /// <summary>
        /// Collection
        /// </summary>
        private BindingListView<NDS_Rom> Collection;

        /// <summary>
        /// Rom missing
        /// </summary>
        private BindingListView<NDS_Rom> CollectionMissing;

        /// <summary>
        /// filters
        /// </summary>
        private Filters<NDS_Rom> f = new Filters<NDS_Rom>();

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
        /// Path to the new rom
        /// </summary>
        public string PathNewRom
        {
            get
            {
                return NDSDirectories.PathNewRom;
            }
        }

        /// <summary>
        /// Urls of the database
        /// </summary>
        public string datURL
        {
            get
            {
                return DataAcessLayer.URLs["datURL"];
            }
        }

        /// <summary>
        /// File name of the database to download
        /// </summary>
        public string datFileName
        {
            get
            {
                return DataAcessLayer.URLs["datFileName"];
            }
        }
        
        /// <summary>
        /// URL of the datVersion file
        /// </summary>
        public string datVersionURL
        {
            get
            {
                return DataAcessLayer.URLs["datVersionURL"];
            }
        }
        
        /// <summary>
        /// Path of the Advanscene database of the hardrive
        /// </summary>
        public string PathXmlDB
        {
            get
            {
                return NDSDirectories.PathXmlDB;
            }
        }

        /// <summary>
        /// Initializes a new instance of the Controler class
        /// </summary>
        /// <param name="startUpPath">Application Start Up Path</param>
        public MFControler(string startUpPath)
        {
            // DataAcessLayer.AdvanScene.Load(startUpPath);
            // NDSDirectories.SetStartupPath(startUpPath);
            InitDataBase();
            f.ChangeFilter += new ChangeFilterEventHandler(f_ChangeFilter);
        }

        /// <summary>
        /// ChangeFilterEventHandler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        void f_ChangeFilter(object sender, EventArgs e)
        {
            AdvanSceneDataBase.ApplyFilter(f);
            Collection.ApplyFilter(f);
            CollectionMissing.ApplyFilter(f);
        }

        /// <summary>
        /// Initialize all data
        /// </summary>
        private void InitDataBase()
        {
            AdvanSceneDataBase = new BindingListView<NDS_Rom>(DataAcessLayer.NdsAdvanScene);
            Collection = new BindingListView<NDS_Rom>(DataAcessLayer.NdsCollection);
            CollectionMissing = new BindingListView<NDS_Rom>(DataAcessLayer.NdsCollectionMissing);
        }

        /// <summary>
        /// Reset All Filters
        /// </summary>
        /// <param name="keepSorts">Keeping sorts</param>
        public void ResetAllFilters(bool keepSorts)
        {
            if (!keepSorts)
            {
                //ListSortDescriptionCollection AdvanSceneSorts = AdvanSceneDataBase.SortDescriptions;
                //ListSortDescriptionCollection CollectionSorts = Collection.SortDescriptions;
                //ListSortDescriptionCollection CollectionMissingSorts = CollectionMissing.SortDescriptions;
                //InitDataBase();
                //AdvanSceneDataBase.ApplySort(AdvanSceneSorts);
                //Collection.ApplySort(CollectionSorts);
                //CollectionMissing.ApplySort(CollectionMissingSorts);
                
                AdvanSceneDataBase.RemoveSort();
                Collection.RemoveSort();
                CollectionMissing.RemoveSort();
            }
            else
            {
                //InitDataBase();
            }
            f.ResetLanguageFilter();
            f.ResetTitleFilter();

            AdvanSceneDataBase.RemoveFilter();
            Collection.RemoveFilter();
            CollectionMissing.RemoveFilter();
        }

        /// <summary>
        /// Get the full database
        /// </summary>
        /// <returns>BindingListView with the full database</returns>
        public BindingListView<NDS_Rom> GetDataBase()
        {
            return AdvanSceneDataBase;
        }

        /// <summary>
        /// Get the collection database
        /// </summary>
        /// <returns>BindingListView with the collection</returns>
        public BindingListView<NDS_Rom> GetCollection()
        {
            return Collection;
        }

        /// <summary>
        /// Get the Rom Missing in the Collection
        /// </summary>
        /// <returns>BindingListView with the Missing rom in the Collection</returns>
        public BindingListView<NDS_Rom> GetCollectionMissing()
        {
            return CollectionMissing;
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
            if (File.Exists(Directory.GetParent(NDSDirectories.PathXmlDB) + "\\ADVANsCEne_NDScrc.xml.old"))
            {
                File.Delete(Directory.GetParent(NDSDirectories.PathXmlDB) + "\\ADVANsCEne_NDScrc.xml.old");
            }
            File.Move(NDSDirectories.PathXmlDB, Directory.GetParent(NDSDirectories.PathXmlDB) + "\\ADVANsCEne_NDScrc.xml.old");

            SevenZipExtractor.SetLibraryPath("7z.dll");
            SevenZipExtractor extract = new SevenZipExtractor(this.datFileName);
            extract.ExtractArchive(Directory.GetParent(NDSDirectories.PathXmlDB).ToString());

            //ReloadAdvanSceneDataBase();

            File.Delete("ADVANsCEne_NDScrc.zip");
        }

        /// <summary>
        /// Apply Filter by title
        /// </summary>
        /// <param name="title"></param>
        public void SetTitleFilter(string title)
        {
            f.SetTitleFilter(title);
            
            //ListSortDescriptionCollection sortsAdvanSceneDataBase = AdvanSceneDataBase.SortDescriptions;
            //ListSortDescriptionCollection sortsCollection = Collection.SortDescriptions;
            //ListSortDescriptionCollection sortsCollectionMissing = CollectionMissing.SortDescriptions;
            //AdvanSceneDataBase = new BindingListView<NDS_Rom>(AdvanSceneDataBaseXML.DataBaseFiltreParTitre(title, EnumBase.AdvanScene));
            //Collection = new BindingListView<NDS_Rom>(AdvanSceneDataBaseXML.DataBaseFiltreParTitre(title, EnumBase.Collection));
            //CollectionMissing = new BindingListView<NDS_Rom>(AdvanSceneDataBaseXML.DataBaseFiltreParTitre(title, EnumBase.CollectionMissing));
            //AdvanSceneDataBase.ApplySort(sortsAdvanSceneDataBase);
            //Collection.ApplySort(sortsCollection);
            //CollectionMissing.ApplySort(sortsCollectionMissing);
        }

        /// <summary>
        /// Return all Language
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, string> GetLanguages()
        {
            return LanguageXML.DicoLanguage;
        }

        /// <summary>
        /// Set No/All Language Filter
        /// </summary>
        public void SetNoLanguageFilter()
        {
            f.ResetLanguageFilter();
        }

        /// <summary>
        /// Set language filter on the given code 
        /// </summary>
        /// <param name="languageCode">language code to set the filter on</param>
        public void SetLanguageFilter(int languageCode)
        {
            f.SetLanguageFilter(languageCode);
            
            //ListSortDescriptionCollection sortsAdvanSceneDataBase = AdvanSceneDataBase.SortDescriptions;
            //ListSortDescriptionCollection sortsCollection = Collection.SortDescriptions;
            //ListSortDescriptionCollection sortsCollectionMissing = CollectionMissing.SortDescriptions;
            //AdvanSceneDataBase = new BindingListView<NDS_Rom>(AdvanSceneDataBaseXML.DataBaseFiltreParLangue(languageCode, EnumBase.AdvanScene));
            //Collection = new BindingListView<NDS_Rom>(AdvanSceneDataBaseXML.DataBaseFiltreParLangue(languageCode, EnumBase.Collection));
            //CollectionMissing = new BindingListView<NDS_Rom>(AdvanSceneDataBaseXML.DataBaseFiltreParLangue(languageCode, EnumBase.CollectionMissing));
            //AdvanSceneDataBase.ApplySort(sortsAdvanSceneDataBase);
            //Collection.ApplySort(sortsCollection);
            //CollectionMissing.ApplySort(sortsCollectionMissing);

            
        }

        /// <summary>
        /// Test -> Repair the collection
        /// </summary>
        public void RepairCollection()
        {
            DataAcessLayer.RepairCollection();
        }

        /// <summary>
        /// Set the filter Demo rom  visible
        /// </summary>
        /// <param name="visible">True to see the Demo Rom, false to hide it</param>
        public void SetFilterDemo(bool visible)
        {
            f.SetDemoRomFilter(visible);
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
    }
}
