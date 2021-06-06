using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Xml
{
    /// <summary>
    /// XmlNode Extension
    /// </summary>
    public static class XmlNodeExtension
    {
        /// <summary>
        /// set Name
        /// </summary>
        public static TXmlNode SetName<TXmlNode>(this TXmlNode xmlNode, string name) where TXmlNode : XmlNode
        {
            xmlNode.Name = name;

            return xmlNode;
        }

        /// <summary>
        /// set Content
        /// </summary>
        public static TXmlNode SetContent<TXmlNode>(this TXmlNode xmlNode, string content) where TXmlNode : XmlNode
        {
            xmlNode.Content = content;

            return xmlNode;
        }

        /// <summary>
        /// 添加属性
        /// </summary>
        public static TXmlNode AddAttribute<TXmlNode>(this TXmlNode xmlNode, string key, string value) where TXmlNode : XmlNode
        {
            if (xmlNode.Attributes == null)
            {
                xmlNode.Attributes = new Dictionary<string, string>();
            }

            xmlNode.Attributes.Add(key, value);

            return xmlNode;
        }

        /// <summary>
        /// 添加一个子节点
        /// </summary>
        public static void AddChild<TXmlNode>(this TXmlNode xmlNode, XmlNode child) where TXmlNode : XmlNode
        {
            if (xmlNode.Children == null)
            {
                xmlNode.Children = new List<XmlNode>();
            }

            xmlNode.Children.Add(child);
        }

        /// <summary>
        /// 创建一个子节点，添加并返回该子节点
        /// </summary>
        public static TXmlNode AddChild<TXmlNode>(this TXmlNode xmlNode, string childName, bool newLineBeforeNode = false, bool newLineBeforeEnd = false) where TXmlNode : XmlNode, new()
        {
            if (xmlNode.Children == null)
            {
                xmlNode.Children = new List<XmlNode>();
            }

            TXmlNode child = new TXmlNode();
            child.Name = childName;
            child.NewLineBeforeNode = newLineBeforeNode;
            child.NewLineBeforeEnd = newLineBeforeEnd;

            xmlNode.Children.Add(child);

            return child;
        }
    }
}
