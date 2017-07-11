using UnityEngine;
using System.Xml;
public class XmlParse
{
    public static XmlElement LoadXml(string _xml)
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(_xml);
        return xmlDocument.DocumentElement;
    }
    public static XmlNodeList FindNodeList(XmlElement _xml, string _name)
    {
        return _xml.SelectNodes(_name);
    }
    public static XmlNode FindSingleNode(XmlNode _xml, string _name)
    {
        return _xml.SelectSingleNode(_name);
    }
}

