using System;
using System.Xml;
using UnityEngine;

public class WardsManager
{
    private TextAsset textAsset;
    private XmlElement xmlRoot;
    private XmlNode xmlNode;
    private string str;
    private static WardsManager instance;
    public static WardsManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WardsManager();
            }
            return instance;
        }
    }
    private WardsManager()
    {
        textAsset = Resources.Load<TextAsset>("Xml/wards");
        xmlRoot = XmlParse.LoadXml(textAsset.text);
    }
    public string GetNodeValue(string name, string language)
    {
        str = String.Format("/Records/Record[@name='{0}' and @language='{1}']", name, language);
        xmlNode = xmlRoot.SelectSingleNode(str);
        return xmlNode.InnerXml;
    }

    public string GetNodeValue(string name, string language, int step)
    {
        str = String.Format("/Records/Record[@name='{0}' and @language='{1}' and @step='{2}']", name, language, step.ToString());
        xmlNode = xmlRoot.SelectSingleNode(str);
        return xmlNode.InnerXml;
    }
}

