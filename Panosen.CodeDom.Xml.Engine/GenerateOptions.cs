using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Xml.Engine
{
    /// <summary>
    /// GenerateOptions
    /// </summary>
    public class GenerateOptions
    {
        /// <summary>
        /// TabString
        /// </summary>
        public string TabString { get; set; } = "    ";

        private Stack<string> indents = new Stack<string>();

        private string indentString = string.Empty;

        /// <summary>
        /// IndentString
        /// </summary>
        public string IndentString
        {
            get { return indentString; }
        }

        /// <summary>
        /// PushIndent
        /// </summary>
        public void PushIndent()
        {
            this.indents.Push(TabString);
            this.indentString = string.Join(string.Empty, this.indents);
        }

        /// <summary>
        /// PopIndent
        /// </summary>
        public void PopIndent()
        {
            this.indents.Pop();
            this.indentString = string.Join(string.Empty, this.indents);
        }

        /// <summary>
        /// [正整数]每行最多容纳的 attribute 的个数。如果不设置，则不主动换行
        /// </summary>
        public int AttribuesPerLine { get; set; }
    }
}
