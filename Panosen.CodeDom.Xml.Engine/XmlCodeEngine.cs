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
        /// <summary>
        /// Generate
        /// </summary>
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

            codeWriter.Write(options.IndentString).Write(Marks.LESS_THAN).Write(node.Name ?? string.Empty);

            if (node.Attributes != null && node.Attributes.Count > 0)
            {
                int attribuesPerLine = options.AttribuesPerLine > 0 ? options.AttribuesPerLine : int.MaxValue;
                int attributesCount = 0;
                codeWriter.Write(Marks.WHITESPACE);
                foreach (var item in node.Attributes)
                {
                    if (attributesCount >= attribuesPerLine)
                    {
                        codeWriter.WriteLine().Write(options.IndentString).Write(options.TabString).Write(options.TabString);
                        attributesCount = 0;
                    }
                    if (attributesCount > 0)
                    {
                        codeWriter.Write(Marks.WHITESPACE);
                    }
                    codeWriter.Write($"{item.Key}=\"{item.Value}\"");
                    attributesCount++;
                }
            }

            if ((node.Children == null || node.Children.Count == 0) && string.IsNullOrEmpty(node.Content))
            {
                codeWriter.Write(Marks.WHITESPACE).Write(Marks.SLASH).WriteLine(Marks.LESS_THAN);
                return;
            }

            codeWriter.Write(Marks.GREATER_THAN);

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
                codeWriter.Write(options.IndentString).Write(Marks.LESS_THAN).Write(Marks.SLASH).Write(node.Name ?? string.Empty).WriteLine(Marks.GREATER_THAN);
                return;
            }

            if (!string.IsNullOrEmpty(node.Content))
            {
                codeWriter.Write(node.Content);
                codeWriter.Write(Marks.LESS_THAN).Write(Marks.SLASH).Write(node.Name ?? string.Empty).WriteLine(Marks.GREATER_THAN);
                return;
            }

            codeWriter.Write(options.IndentString).Write(Marks.LESS_THAN).Write(Marks.SLASH).Write(node.Name ?? string.Empty).WriteLine(Marks.GREATER_THAN);
        }
    }
}
