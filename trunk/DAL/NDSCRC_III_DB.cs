using System.Xml;
using System.Data;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace NdsCRC_III
{
    //static public class NDSCRC_III_DB
    //{
    //    static private XmlReader xmlread;
    //    static private XmlDocument xdoc;
    //    static private string XMLFilePath;
    //    static public DataTable dt { get; private set; }
    //    static public List<NDS_Rom> Collection;
    //    static private DataSet ds;
    //    static NDSCRC_III_DB()
    //    {
    //        Collection = new List<NDS_Rom>();
    //        XmlSerializer xs = new XmlSerializer(typeof(List<NDS_Rom>));
    //        using (StreamReader rd = new StreamReader(string.Format("{0}\\Collection.xml", Path.GetDirectoryName(NDSDirectories.pathXmlHaveDB))))
    //        {
    //            Collection = xs.Deserialize(rd) as List<NDS_Rom>;
    //        }
    //        XMLFilePath = NDSDirectories.pathXmlHaveDB;
    //        ds = new DataSet("NdsCollection");
    //        dt = new DataTable("Rom");
    //        ds.Tables.Add(dt);
    //        xmlread = XmlReader.Create(XMLFilePath);
    //        xdoc = new XmlDocument();
    //        xdoc.Load(xmlread);
    //        LoadDatasource();
    //        xmlread.Close();
    //        xdoc = null;
    //    }
    //    static private bool LoadDatasource()
    //    {
    //        bool ret = false;
    //        XmlNode xnd = xdoc.ChildNodes[1];
    //        InitialiseDataTable();

    //        foreach (XmlNode xndd in xnd.ChildNodes)
    //        {
    //            ChargeRomInfo(xndd);
    //        }

    //        return ret;
    //    }
    //    static private void InitialiseDataTable()
    //    {
    //        if (dt.Columns.Count == 0)
    //        {
    //            dt.Columns.Add("Icon");
    //            dt.Columns.Add("ImageNumber");
    //            dt.Columns.Add("ReleaseNumber");
    //            dt.Columns.Add("Title");
    //            dt.Columns.Add("SaveType");
    //            dt.Columns.Add("RomSize");
    //            dt.Columns.Add("Publisher");
    //            dt.Columns.Add("Location");
    //            dt.Columns.Add("SourceRom");
    //            dt.Columns.Add("Language");
    //            dt.Columns.Add("RomCRC");
    //            dt.Columns.Add("ImgCoverCRC");
    //            dt.Columns.Add("ImgInGameCRC");
    //            dt.Columns.Add("IcoCRC");
    //            dt.Columns.Add("NFO_CRC");
    //            dt.Columns.Add("Genre");
    //            dt.Columns.Add("DumpDate");
    //            dt.Columns.Add("InternalName");
    //            dt.Columns.Add("Serial");
    //            dt.Columns.Add("Version");
    //            dt.Columns.Add("Wifi");
    //            dt.Columns.Add("RomNumber");
    //            dt.Columns.Add("duplicateid");
    //            dt.Columns.Add("Have");
    //        }
    //        else
    //        {
    //            dt.Rows.Clear();
    //        }

    //    }
    //    static private bool ChargeRomInfo(XmlNode xnd)
    //    {
    //        bool ret = true;
    //        DataRow dtr = dt.NewRow();

    //        foreach (XmlNode xndd in xnd.ChildNodes)
    //        {
    //            switch (xndd.Name)
    //            {
    //                case "ImageNumber":
    //                    dtr["ImageNumber"] = xndd.InnerText;
    //                    dtr["Icon"] = dtr["ImageNumber"];
    //                    break;
    //                case "ReleaseNumber": dtr["ReleaseNumber"] = xndd.InnerText; break;
    //                case "Title": dtr["Title"] = xndd.InnerText; break;
    //                case "SaveType": dtr["SaveType"] = xndd.InnerText; break;
    //                case "RomSize": dtr["RomSize"] = xndd.InnerText; break;
    //                case "Publisher": dtr["Publisher"] = xndd.InnerText; break;
    //                case "Location": dtr["Location"] = xndd.InnerText; break;
    //                case "SourceRom": dtr["SourceRom"] = xndd.InnerText; break;
    //                case "Language": dtr["language"] = xndd.InnerText; break;
    //                case "RomCRC": dtr["RomCRC"] = xndd.InnerText; break;
    //                case "ImgCoverCRC": dtr["ImgCoverCRC"] = xndd.InnerText; break;
    //                case "ImgInGameCRC": dtr["ImgInGameCRC"] = xndd.InnerText; break;
    //                case "NFO_CRC": dtr["NFO_CRC"] = xndd.InnerText; break;
    //                case "IcoCRC": dtr["IcoCRC"] = xndd.InnerText; break;
    //                case "Genre": dtr["Genre"] = xndd.InnerText; break;
    //                case "DumpDate": dtr["DumpDate"] = xndd.InnerText; break;
    //                case "InternalName": dtr["InternalName"] = xndd.InnerText; break;
    //                case "Serial": dtr["Serial"] = xndd.InnerText; break;
    //                case "Version": dtr["Version"] = xndd.InnerText; break;
    //                case "Wifi": dtr["Wifi"] = xndd.InnerText; break;
    //                case "RomNumber": dtr["RomNumber"] = xndd.InnerText; break;
    //                case "duplicateid":
    //                    if (xndd.InnerText == "0")
    //                    {
    //                        dtr["duplicateid"] = "None";
    //                    }
    //                    else
    //                    {
    //                        dtr["duplicateid"] = xndd.InnerText;
    //                    }
    //                    break;
    //            }
    //        }
    //        dtr["have"] = true;

    //        dt.Rows.Add(dtr);
    //        Collection.Add(new NDS_Rom(dtr));

    //        return ret;
    //    }
    //    static public bool isInDB(string crc)
    //    {
    //        DataView dv = new DataView(dt);
    //        dv.RowFilter = " RomCRC = '" + crc + "'";
    //        switch (dv.Count)
    //        {
    //            case 1:
    //                return true;
    //            case 0:
    //                return false;
    //            default:
    //                return false;
    //        }
    //    }
    //    static public void WriteXml(bool Full)
    //    {
    //        if (Full)
    //        {
    //            ds.WriteXml(NDSDirectories.pathXmlHaveDB);

    //            XmlSerializer xs = new XmlSerializer(typeof(List<NDS_Rom>));
    //            using (StreamWriter wr = new StreamWriter(string.Format("{0}\\Collection.xml", Path.GetDirectoryName(NDSDirectories.pathXmlHaveDB))))
    //            {
    //                xs.Serialize(wr, Collection);
    //            }
    //        }
    //        else
    //        {
    //            DataSet _ds = new DataSet("NdsCollection");
    //            DataTable _dt = new DataTable("Rom");
    //            _ds.Tables.Add(_dt);
    //            _dt.Columns.Add("");

    //        }

    //    }
    //    //static public void AddRoms(NDS_Rom_Collection newRoms)
    //    //{
    //    //    dt.Merge(newRoms.Table);
    //    //}
    //}
}
