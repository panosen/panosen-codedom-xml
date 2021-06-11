using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Xml.Engine
{
    /// <summary>
    /// XmlCodeEngine
    /// </summary>
    public partial class XmlCodeEngine
    {
        private const string WHITESPACE = " ";
        private const string LEFT_Parenthesis = "<";
        private const string RIGHT_Parenthesis = ">";
        private const string SLASH = "/";

        /// <summary>
        /// Generate
        /// </summary>
        /// <param name="node"></param>
        /// <param name="codeWriter"></param>
        /// <param name="options"></param>
        public void Generate(XmlNode node, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (node == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            WriteXmlNode(node, codeWriter, options);
        }

        private void WriteXmlNode(XmlNode node, CodeWriter codeWriter, GenerateOptions options)
        {
            if (node == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            if (node.NewLineBeforeNode)
            {
                codeWriter.WriteLine();
            }

            codeWriter.Write(options.IndentString).Write(LEFT_Parenthesis).Write(node.Name ?? string.Empty);

            if (node.Attributes != null && node.Attributes.Count > 0)
            {
                int attribuesPerLine = options.AttribuesPerLine > 0 ? options.AttribuesPerLine : int.MaxValue;
                int attributesCount = 0;
                foreach (var item in node.Attributes)
                {
                    if (attributesCount >= attribuesPerLine)
                    {
                        codeWriter.WriteLine().Write(options.IndentString).Write(options.TabString).Write(options.TabString);
                        attributesCount = 0;
                    }
                    codeWriter.Write($" {item.Key}=\"{item.Value}\"");
                    attributesCount++;
                }
            }

            if ((node.Children == null || node.Children.Count == 0) && string.IsNullOrEmpty(node.Content))
            {
                codeWriter.Write(WHITESPACE).Write(SLASH).WriteLine(RIGHT_Parenthesis);
                return;
            }

            codeWriter.Write(RIGHT_Parenthesis);

            if (node.Children != null && node.Children.Count > 0)
            {
                codeWriter.WriteLine();
                options.PushIndent();

                foreach (var child in node.Children)
                {
                    WriteXmlNode(child, codeWriter, options);
                }

                options.PopIndent();

                if (node.NewLineBeforeEnd)
                {
                    codeWriter.WriteLine();
                }
                codeWriter.Write(options.IndentString).Write(LEFT_Parenthesis).Write(SLASH).Write(node.Name ?? string.Empty).WriteLine(RIGHT_Parenthesis);
                return;
            }

            if (!string.IsNullOrEmpty(node.Content))
            {
                codeWriter.Write(node.Content);
                codeWriter.Write(LEFT_Parenthesis).Write(SLASH).Write(node.Name ?? string.Empty).WriteLine(RIGHT_Parenthesis);
                return;
            }

            codeWriter.Write(options.IndentString).Write(LEFT_Parenthesis).Write(SLASH).Write(node.Name ?? string.Empty).WriteLine(RIGHT_Parenthesis);
        }
    }
}
