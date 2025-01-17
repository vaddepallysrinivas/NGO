﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

/// <summary>
/// Summary description for Global
/// </summary>
public class XMLdoc
{
	public XMLdoc()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public static XmlDocument CreateXmlHeading(XmlDocument xmlDoc)
    {
        xmlDoc.AppendChild(xmlDoc.CreateNode(System.Xml.XmlNodeType.XmlDeclaration, "", ""));
        xmlDoc.AppendChild(xmlDoc.CreateElement("", "Record", ""));
        return xmlDoc;
    }

   

    public static XmlDocument AddXmlElement(XmlDocument xmlDoc, string str_elemName, string str_elemText)
    {
        System.Xml.XmlElement xmlelem;
        System.Xml.XmlText xmltext;

        xmlelem = xmlDoc.CreateElement(str_elemName);
        xmltext = xmlDoc.CreateTextNode(str_elemText);
        xmlelem.AppendChild(xmltext);
        try
        {
            xmlDoc.ChildNodes.Item(1).AppendChild(xmlelem);
        }
        catch
        {
            xmlDoc.ChildNodes.Item(0).AppendChild(xmlelem);
        }

        return xmlDoc;
    }

    public static XmlNode AddXMLChildNode(XmlDocument xmlDoc, XmlNode xmlnodeRoot, string sElementName)
    {
        XmlNode xmlnodeChild;
        XmlElement xmlElemChild;

        xmlElemChild = xmlDoc.CreateElement("", sElementName, "");
        xmlnodeChild = xmlnodeRoot.AppendChild(xmlElemChild);

        return xmlnodeChild;
    }

    public static XmlNode AddXMLElement(XmlDocument xmlDoc, XmlNode xmlnode, string sElementName, string sElementValue, bool bElementOnly)
    {
        XmlElement xmlelem;
        XmlText xmltext;
        XmlNode newnode;

        xmlelem = xmlDoc.CreateElement("", sElementName, "");
        if (!bElementOnly)
        {
            xmltext = xmlDoc.CreateTextNode(sElementValue);
            xmlelem.AppendChild(xmltext);
        }
        newnode = xmlnode.AppendChild(xmlelem);
        return newnode;
    }



}