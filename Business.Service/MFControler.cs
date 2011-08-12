namespace NdsCRC_III.BusinessService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.IO;
    using Equin.ApplicationFramework;
    using NdsCRC_III.BusinessService;
    using SevenZip;
    using NdsCRC_III.DAL;
    

    /// <summary>
    /// Controler du Main Form
    /// </summary>
    public class MFControler
    {
        private BindingListView<NDS_Rom> AdvanSceneDataBase;

        private BindingListView<NDS_Rom> Collection;

        private BindingListView<NDS_Rom> CollectionMissing;

        private Filters<NDS_Rom> f = new Filters<NDS_Rom>();

        public string DatVersion
        {
            get
            {
                return AdvanSceneDataBaseXML.DatVersion;
            }
        }

        public string DatCreationDate
        {
            get
            {
                return AdvanSceneDataBaseXML.DatCreationDate;
            }
        }

        public string PathNewRom
        {
            get
            {
                return NDSDirectories.PathNewRom;
            }
        }

        public string datURL
        {
            get
            {
                return AdvanSceneDataBaseXML.URLs["datURL"];
            }
        }

        public string datFileName
        {
            get
            {
                return AdvanSceneDataBaseXML.URLs["datFileName"];
            }
        }
        
        public string datVersionURL
        {
            get
            {
                return AdvanSceneDataBaseXML.URLs["datVersionURL"];
            }
        }
        
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
            AdvanSceneDataBaseXML.Load(startUpPath);
            //NDSDirectories.SetStartupPath(startUpPath);
            InitDataBase();
            f.ChangeFilter += new ChangeFilterEventHandler(f_ChangeFilter);
        }

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
            AdvanSceneDataBase = new BindingListView<NDS_Rom>(AdvanSceneDataBaseXML.AdvanSceneDataBase);
            Collection = new BindingListView<NDS_Rom>(AdvanSceneDataBaseXML.Collection);
            CollectionMissing = new BindingListView<NDS_Rom>(AdvanSceneDataBaseXML.CollectionMissing);
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
            AdvanSceneDataBaseXML.Reload();
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

        public Dictionary<int, string> GetLanguages()
        {
            return LanguageXML.DicoLanguage;
        }

        public void SetNoLanguageFilter()
        {
            f.ResetLanguageFilter();
        }

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

        public void RepairCollection()
        {
            AdvanSceneDataBaseXML.RepairCollection();
        }
    }
}
