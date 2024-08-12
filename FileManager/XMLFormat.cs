using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using TextEditor.TaskBar;
using TextEditor.TaskBar.Edit;

namespace TextEditor.FileManager
{
    public class XMLFormat : FileManager
    {
        private string _filePath;
        private string _title;
        private string _content;
        private Font _font;
        private Color _textColor;
        private Color _backgroundColor;


        public XMLFormat(string filePath, string title, string content, Font font,Color textColor, Color backgroundColor)
        {
            _filePath = filePath;
            _title = title;
            _content = content;
            _font = font;
            _textColor = textColor;
            _backgroundColor = backgroundColor;
        }

        public override void WriteToFile()
        {
            using (XmlTextWriter writer = new XmlTextWriter(_filePath, Encoding.UTF8))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("text-editor");
                writer.WriteStartElement("title");
                writer.WriteString(_title);
                writer.WriteEndElement();

                writer.WriteStartElement("font");
                writer.WriteStartElement("family");
                writer.WriteString(_font.FontFamily.Name);
                writer.WriteEndElement();
                writer.WriteStartElement("style");
                writer.WriteString(_font.Style.ToString());
                writer.WriteEndElement();
                writer.WriteStartElement("size");
                writer.WriteString(_font.Size.ToString());
                writer.WriteEndElement();
                writer.WriteStartElement("color");
                writer.WriteStartElement("r");
                writer.WriteString(_textColor.R.ToString());
                writer.WriteEndElement();
                writer.WriteStartElement("g");
                writer.WriteString(_textColor.G.ToString());
                writer.WriteEndElement();
                writer.WriteStartElement("b");
                writer.WriteString(_textColor.B.ToString());
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndElement();

                writer.WriteStartElement("background");
                writer.WriteStartElement("r");
                writer.WriteString(_backgroundColor.R.ToString());
                writer.WriteEndElement();
                writer.WriteStartElement("g");
                writer.WriteString(_backgroundColor.G.ToString());
                writer.WriteEndElement();
                writer.WriteStartElement("b");
                writer.WriteString(_backgroundColor.B.ToString());
                writer.WriteEndElement();
                writer.WriteEndElement();

                writer.WriteStartElement("text");
                writer.WriteString(_content);
                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        public void LoadXML(string filePath, TextBox textBox)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            // Extract and apply the title
            XmlNode titleNode = doc.SelectSingleNode("/text-editor/title");
            string title = string.Empty;
            if (titleNode != null)
            {
                title = titleNode.InnerText;
            }

            // Extract and apply font family
            XmlNode familyNode = doc.SelectSingleNode("/text-editor/font/family");
            string fontFamily = "Microsoft Sans Serif";
            if (familyNode != null)
            {
                fontFamily = familyNode.InnerText;
            }

            // Extract and apply font style
            XmlNode styleNode = doc.SelectSingleNode("/text-editor/font/style");
            FontStyle fontStyle = FontStyle.Regular;
            if (styleNode != null)
            {
                string styleText = styleNode.InnerText;
                if (Enum.TryParse(styleText, out FontStyle parsedStyle))
                {
                    fontStyle = parsedStyle;
                }
            }

            // Extract and apply font size
            XmlNode sizeNode = doc.SelectSingleNode("/text-editor/font/size");
            float fontSize = 8.0f;
            if (sizeNode != null)
            {
                string sizeText = sizeNode.InnerText;
                if (!float.TryParse(sizeText, out fontSize))
                {
                    // Default value is used if parsing fails
                }
            }

            // Extract and apply text color
            XmlNode colorNode = doc.SelectSingleNode("/text-editor/font/color");
            Color textColor = Color.Black;
            if (colorNode != null)
            {
                int r = 0, g = 0, b = 0;
                XmlNode rNode = colorNode.SelectSingleNode("r");
                XmlNode gNode = colorNode.SelectSingleNode("g");
                XmlNode bNode = colorNode.SelectSingleNode("b");

                if (rNode != null && int.TryParse(rNode.InnerText, out r) &&
                    gNode != null && int.TryParse(gNode.InnerText, out g) &&
                    bNode != null && int.TryParse(bNode.InnerText, out b))
                {
                    textColor = Color.FromArgb(r, g, b);
                }
            }

            // Extract and apply background color
            XmlNode backgroundNode = doc.SelectSingleNode("/text-editor/background");
            Color backgroundColor = Color.White;
            if (backgroundNode != null)
            {
                int r = 255, g = 255, b = 255;
                XmlNode rNode = backgroundNode.SelectSingleNode("r");
                XmlNode gNode = backgroundNode.SelectSingleNode("g");
                XmlNode bNode = backgroundNode.SelectSingleNode("b");

                if (rNode != null && int.TryParse(rNode.InnerText, out r) &&
                    gNode != null && int.TryParse(gNode.InnerText, out g) &&
                    bNode != null && int.TryParse(bNode.InnerText, out b))
                {
                    backgroundColor = Color.FromArgb(r, g, b);
                }
            }

            // Extract and apply content
            XmlNode textNode = doc.SelectSingleNode("/text-editor/text");
            string content = string.Empty;
            if (textNode != null)
            {
                content = textNode.InnerText;
            }

            // Apply the extracted values to the TextBox
            textBox.Text = content;
            textBox.Font = new Font(fontFamily, fontSize, fontStyle);
            textBox.ForeColor = textColor;
            textBox.BackColor = backgroundColor;
        }
    }
}