﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;
using System.Xml;

namespace NdsCRC_III.DAL
{
    public class XMLExplorateur
    {
        protected XPathDocument docNav;
        protected XPathNavigator nav;
        protected XPathNodeIterator xit;
        protected bool initpath = true;

        public string strExpression { get; set; }

        public bool Search(XPathSearch search, string s)
        {
            switch (search)
            {
                case XPathSearch.imageNumber:
                    break;
                case XPathSearch.releaseNumber:
                    return SearchByReleaseNumber(s);
                case XPathSearch.title:
                    break;
                case XPathSearch.saveType:
                    break;
                case XPathSearch.romSize:
                    break;
                case XPathSearch.publisher:
                    break;
                case XPathSearch.location:
                    break;
                case XPathSearch.sourceRom:
                    break;
                case XPathSearch.language:
                    break;
                case XPathSearch.romCRC:
                    return SearchByCRC(s);
                case XPathSearch.im1CRC:
                    break;
                case XPathSearch.im2CRC:
                    break;
                case XPathSearch.icoCRC:
                    break;
                case XPathSearch.nfoCRC:
                    break;
                case XPathSearch.genre:
                    break;
                case XPathSearch.dumpdate:
                    break;
                case XPathSearch.internalname:
                    break;
                case XPathSearch.serial:
                    break;
                case XPathSearch.version:
                    break;
                case XPathSearch.wifi:
                    break;
                case XPathSearch.filename:
                    break;
                case XPathSearch.dirname:
                    break;
                case XPathSearch.duplicateid:
                    break;
                case XPathSearch.comment:
                case XPathSearch.RomNumber:
                    SearchByRomNumberToXmlReader(s);
                    break;
            }
            throw new NotImplementedException();
        }

        private bool SearchByCRC(string s)
        {
            strExpression = string.Format("//games/game/files/romCRC[text()='{0}']/../..", s);
            xit = nav.Select(strExpression);
            if (xit.Count == 1)
            {
                return xit.MoveNext();
            }
            else
            {
                return false;
            }

            //xit.Current.ReadSubtree();

        }
        private bool SearchByReleaseNumber(string s)
        {
            strExpression = string.Format("//games/game/releaseNumber[text()='{0}']/..", s);
            xit = nav.Select(strExpression);
            if (xit.Count == 1)
            {
                return xit.MoveNext();
            }
            else
            {
                return false;
            }
            //xit.Current.ReadSubtree();
        }
        public bool SearchByReleaseNumberHaveDB(string s)
        {
            strExpression = string.Format("//NdsCollection/Rom/ReleaseNumber[text()='{0}']/..", s);
            xit = nav.Select(strExpression);
            if (xit.Count == 1)
            {
                return xit.MoveNext();
            }
            else
            {
                return false;
            }
            //xit.Current.ReadSubtree();
        }
        public bool SearchByCRCHaveDB(string s)
        {
            strExpression = string.Format("//NdsCollection/Rom/RomCRC[text()='{0}']/..", s);
            xit = nav.Select(strExpression);
            if (xit.Count == 1)
            {
                return xit.MoveNext();
            }
            else
            {
                return false;
            }
            //xit.Current.ReadSubtree();
        }
        public XmlReader SearchByRomNumberToXmlReader(string s)
        {
            if (SearchByRomNumber(s))
            {
                return xit.Current.ReadSubtree();
            }
            else
            {
                return null;
            }
        }
        private bool SearchByRomNumber(string s)
        {
            strExpression = string.Format("//games/game/comment[text()='{0}']/..", s);
            xit = nav.Select(strExpression);
            if (xit.Count == 1)
            {
                return xit.MoveNext();
            }
            else
            {
                return false;
            }
            //xit.Current.ReadSubtree();
        }
        public XMLExplorateur() { }

        public XMLExplorateur(String path)
        {
            try
            {
                docNav = new XPathDocument(path);
                nav = docNav.CreateNavigator();
            }
            catch
            {
                docNav = null;
                nav = null;
            }
        }

        public bool Init(String path)
        {
            try
            {
                docNav = new XPathDocument(path);
                nav = docNav.CreateNavigator();
            }
            catch
            {
                docNav = null;
                nav = null;
                return false;
            }
            return true;
        }

        public String ValueOf(String Item)
        {
            if (nav == null) return "Erreur Navigateur null";
            String tmp = "descendant::" + Item;
            try
            {
                xit = nav.Select(tmp);
                if (xit.MoveNext()) tmp = xit.Current.Value;
                else tmp = "null";
            }
            catch
            {
                tmp = "null";
            }
            return tmp;
        }
    }

    public enum XPathSearch
    {
        imageNumber,
        releaseNumber,
        title,
        saveType,
        romSize,
        publisher,
        location,
        sourceRom,
        language,
        romCRC,
        im1CRC,
        im2CRC,
        icoCRC,
        nfoCRC,
        genre,
        dumpdate,
        internalname,
        serial,
        version,
        wifi,
        filename,
        dirname,
        duplicateid,
        comment,
        RomNumber,
    }

}