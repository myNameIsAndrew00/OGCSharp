using Microsoft.Extensions.DependencyInjection;
using System.Xml;
using OGCSharp.Geo.Extensions; 
using OGCSharp.Layers.Abstractions;

namespace OGCSharp.Tests
{
    public class WmsLayersTest
    {
        public WmsLayersTest()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddOgc();

            _wmsProvider = serviceCollection.BuildServiceProvider().GetRequiredService<IOgcProvidersFactory>()
                                                                 .Create(Geo.Types.OgcServerType.WMS)!;
        }

        private IOgcProvider _wmsProvider;

        [Fact]
        public async Task Test1()
        {

            string inputPath = "./Input/input_1_wms_1_3_0.xml";

            // Load document from given path.
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(File.ReadAllText(inputPath));

            var layers = await _wmsProvider.GetLayersAsync(doc);

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

            var layers = await _wmsProvider.GetLayersAsync(doc);

            Assert.NotNull(layers);
            Assert.Equal(10, layers.Count);
        }
    }
}