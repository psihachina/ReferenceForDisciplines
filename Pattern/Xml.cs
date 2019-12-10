using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CurrencyConverter.Patterns
{
    public class Xml
    {
        public static XDocument Serelialize<T>(T source)
        {
            var stream = new MemoryStream();
            var ser = new XmlSerializer(typeof(T));
            ser.Serialize(stream, source);
            stream.Position = 0;
            return XDocument.Load(stream);
        }

        public static T Deserelialize<T>(XDocument source)
        {
            var stream = source.CreateReader();
            var ser = new XmlSerializer(typeof(T));
            return (T) ser.Deserialize(stream);
        }

        public static T LoadObjectFromFile<T>(string path)
        {
            var xml = XDocument.Load(path);
            return Deserelialize<T>(xml);
        }


        public static T LoadObjectFromString<T>(string textXml)
        {
            var xml = XDocument.Parse(textXml);
            return Deserelialize<T>(xml);
        }
    }
}