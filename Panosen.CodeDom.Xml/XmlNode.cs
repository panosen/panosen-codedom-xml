using System;
using System.Collections.Generic;

namespace Panosen.CodeDom.Xml
{
    /// <summary>
    /// xml节点
    /// </summary>
    public class XmlNode
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 属性
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }

        /// <summary>
        /// 子节点
        /// </summary>
        public List<XmlNode> Children { get; set; }

        /// <summary>
        /// 在前面插入空行
        /// </summary>
        public bool NewLineBeforeNode { get; set; }

        /// <summary>
        /// 在后面插入空行
        /// </summary>
        public bool NewLineBeforeEnd { get; set; }
    }
}
