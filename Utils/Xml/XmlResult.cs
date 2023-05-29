using System.Xml;
using Microsoft.AspNetCore.Mvc;

namespace INET410.Utils;

public class XmlResult : ContentResult
{
    public XmlResult(XmlDocument xmlDocument)
    {
        Content = xmlDocument.OuterXml;
        ContentType = "application/xml";
    }
}