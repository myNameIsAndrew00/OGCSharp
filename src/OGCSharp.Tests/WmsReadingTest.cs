using Microsoft.Extensions.DependencyInjection;
using System.Xml;
using OGCSharp.Geo.Extensions;
using OGCSharp.Geo.Abstractions;
using OGCSharp.Abstractions;

namespace OGCSharp.Tests
{
    public class WmsReadingTest
    {
        public WmsReadingTest()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddOgc();

            _wmsParser = serviceCollection.BuildServiceProvider().GetRequiredService<IOgcCapabilitiesParsersFactory>()
                                                                 .Create(Geo.Types.OgcServerType.WMS)!;
        }

        private IOgcCapabilitiesParser _wmsParser;

        [Fact]
        public async Task Test1()
        {

            string inputPath = "./Input/input_1_wms_1_3_0.xml";

            // Load document from given path.
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(File.ReadAllText(inputPath));

            var layers = await _wmsParser.GetLayersAsync(doc);

            Assert.NotNull(layers);
            Assert.Equal(12, layers.Count);
        }

        [Fact]
        public async Task Test2()
        {
            string inputPath = "./Input/input_2_wms_1_3_0.xml";

            // Load document from given path.
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(File.ReadAllText(inputPath));

            var layers = await _wmsParser.GetLayersAsync(doc);

            Assert.NotNull(layers);
            Assert.Equal(10, layers.Count);
        }
    }
}