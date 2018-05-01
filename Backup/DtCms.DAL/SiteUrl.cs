using System;
using System.Collections;
using System.Text;
using System.Xml;

namespace DtCms.DAL
{
    public class SiteUrl
    {
        public Hashtable loadConfig(string urlFilePath)
        {
            Hashtable ht = new Hashtable();

            XmlDocument xml = new XmlDocument();
            xml.Load(urlFilePath);

            XmlNode root = xml.SelectSingleNode("urls");
            foreach (XmlNode n in root.ChildNodes)
            {
                if (n.NodeType != XmlNodeType.Comment && n.Name.ToLower() == "rewrite")
                {
                    XmlAttribute name = n.Attributes["name"];
                    XmlAttribute path = n.Attributes["path"];
                    XmlAttribute page = n.Attributes["page"];
                    XmlAttribute querystring = n.Attributes["querystring"];
                    XmlAttribute pattern = n.Attributes["pattern"];

                    if (name != null && path != null && page != null && querystring != null && pattern != null)
                    {
                        ht.Add(name.Value, new DtCms.Model.SiteUrl(name.Value, path.Value, pattern.Value, page.Value.Replace("^", "&"), querystring.Value.Replace("^", "&")));
                    }
                }
            }
            return ht;
        }
    }
}
