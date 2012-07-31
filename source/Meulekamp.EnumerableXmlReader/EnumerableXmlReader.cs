using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Meulekamp.EnumerableXmlReaders
{
    public class EnumerableXmlReader : IDisposable
    {
        public EnumerableXmlReader(XmlReader reader)
        {
            _reader = reader;
        }

        public EnumerableXmlReader(TextReader stream, XmlReaderSettings settings = null)
        {
            _reader = settings == null ? XmlReader.Create(stream) : XmlReader.Create(stream, settings);
        }

        public EnumerableXmlReader(string xmlFileName, XmlReaderSettings settings = null)
        {
            if (string.IsNullOrWhiteSpace(xmlFileName))
                throw new ArgumentException("file can not be null or emtpy", "xmlFileName");

            if (!File.Exists(xmlFileName))
                throw new ArgumentException(string.Format("File {0} does not exists", xmlFileName), "xmlFileName");

            _streamReader = new StreamReader(xmlFileName);
            _reader = settings == null ? XmlReader.Create(_streamReader) : XmlReader.Create(_streamReader, settings);
        }

        private readonly XmlReader _reader;
        private readonly StreamReader _streamReader;

        public IEnumerable<T> Stream<T>()
        {
            string nodeName = typeof(T).Name;

            return Stream<T>(nodeName);
        }

        /// <summary>
        /// Stream Xelement deserialized to instances of T from xml reader 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public IEnumerable<T> Stream<T>(string nodeName)
        {           
            //move to  content
            _reader.MoveToContent();
            // Parse the file and display each of the nodes.
            while (_reader.Read())
            {
                switch (_reader.NodeType)
                {
                    case XmlNodeType.Element:
                        //dont ignore case, xml is case sensitive
                        if (_reader.Name.Equals(nodeName, StringComparison.InvariantCulture))
                        {
                            var el = XNode.ReadFrom(_reader) as XElement;
                            if (el != null)
                                yield return DeSerializer<T>(el);
                        }
                        break;
                }
            }
        }

        private static T DeSerializer<T>(XNode element)
        {
            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(element.CreateReader());
        }

        public void Dispose()
        {
            if (_streamReader != null) _streamReader.Close();
            if (_reader != null) _reader.Close();
        }
    }
}
