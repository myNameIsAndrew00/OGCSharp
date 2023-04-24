using Microsoft.Extensions.DependencyInjection;
using System.Xml;
using OGCSharp.Geo.Extensions; 
using OGCSharp.Layers.Abstractions;
using OGCSharp.Geo.WMS;

namespace OGCSharp.Tests
{
    public class WmsParsingTest
    {
        public WmsParsingTest()
        {

            _capabilitiesParser = new WmsCapabilitiesParser();
        }

        private WmsCapabilitiesParser _capabilitiesParser;

        [Fact]
        public void Test1()
        {

            string inputPath = "./Input/input_1_wms_1_3_0.xml";

            // Load document from given path.
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(File.ReadAllText(inputPath));

            var parsingResult = _capabilitiesParser.TryParse(doc, out var document);

            Assert.NotNull(document);
        }

        [Fact]
        public void Test2()
        {
            string inputPath = "./Input/input_2_wms_1_3_0.xml";

            // Load document from given path.
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(File.ReadAllText(inputPath));

            var parsingResult = _capabilitiesParser.TryParse(doc, out var document);

            Assert.NotNull(document);
        }
    }
}