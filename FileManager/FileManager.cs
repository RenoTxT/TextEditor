using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TextEditor.FileManager
{
    [XmlRoot("text-editor")]
    public abstract class FileManager
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("font")]
        public FontDetails FontDetails { get; set; }

        [XmlElement("background")]
        public ColorDetails BackgroundDetails { get; set; }

        [XmlElement("text")]
        public string Content { get; set; }

        public abstract void WriteToFile();
    }

    public class FontDetails
    {
        [XmlElement("family")]
        public string Family { get; set; }

        [XmlElement("style")]
        public string Style { get; set; }

        [XmlElement("size")]
        public float Size { get; set; }

        [XmlElement("color")]
        public ColorDetails ColorDetails { get; set; }
    }

    public class ColorDetails
    {
        [XmlElement("r")]
        public int R { get; set; }

        [XmlElement("g")]
        public int G { get; set; }

        [XmlElement("b")]
        public int B { get; set; }
    }
}
