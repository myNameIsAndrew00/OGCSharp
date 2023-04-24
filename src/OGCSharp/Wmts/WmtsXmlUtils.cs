using System.Xml;
using System.Xml.Linq;

namespace OGCSharp.Wmts
{
    /// <summary>
    /// Contains extension methods for XElement
    /// </summary>
    internal static class WmtsXmlUtils
    {
        [Obsolete("Avoid using this work around to obtain elements when namespace is wrong")]
        /// <summary>
        /// Get the first (in document order) child element with the specified unprefixed name. This function will not intepret namespace as part of name.
        /// </summary>
        /// <param name="xElement"></param>
        /// <param name="unprefixedName"></param>
        /// <returns></returns>
        public static XElement? ElementUnprefixed(this XElement xElement, string unprefixedName)
        {
            return xElement.Elements().Where(element => element.Name.LocalName == unprefixedName)?.FirstOrDefault();
        }

        [Obsolete("Avoid using this work around to obtain elements when namespace is wrong")]
        /// <summary>
        /// Returns a collection of the child elements of this element or document which have the unprefixed name.
        /// </summary>
        /// <param name="unprefixedName"></param>
        /// <returns></returns>
        public static IEnumerable<XElement> ElementsUnprefixed(this XElement xElement, string unprefixedName)
        {
            return xElement.Elements().Where(element => element.Name.LocalName == unprefixedName);
        }

        /// <summary>
        /// Get the value of the xml element as an integer
        /// </summary>
        /// <param name="xElement"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int ValueAsInt(this XElement xElement, string name, WmtsParsingContext parsingContext)
        {
            int.TryParse(
               xElement.Element(parsingContext.ParsingNamespace + name)?.Value,
               out int result);

            return result;
        }


        /// <summary>
        /// Get the value of the xml element as a bool
        /// </summary>
        /// <param name="xElement"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool ValueAsBool(this XElement xElement, string name, WmtsParsingContext parsingContext)
        {
            bool.TryParse(
               xElement.Element(parsingContext.ParsingNamespace + name)?.Value,
               out bool result);

            return result;
        }


        /// <summary>
        /// Get the value of the xml element as a double
        /// </summary>
        /// <param name="xElement"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static double ValueAsDouble(this XElement xElement, string name, WmtsParsingContext parsingContext)
        {
            double.TryParse(
               xElement.Element(parsingContext.ParsingNamespace + name)?.Value,
               out double result);

            return result;
        }

        /// <summary>
        /// Get the value of the xml element as a datetime
        /// </summary>
        /// <param name="xElement"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static DateTime? ValueAsDateTime(this XElement xElement, string name, WmtsParsingContext parsingContext)
        {
            if (DateTime.TryParse(
               xElement.Element(parsingContext.ParsingNamespace + name)?.Value,
               out DateTime result))
                return result;

            return null;
        }



        /// <summary>
        /// Get the value of the xml element as a float
        /// </summary>
        /// <param name="xElement"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static float ValueAsFloat(this XElement xElement, string name, WmtsParsingContext parsingContext)
        {
            float.TryParse(
               xElement.Element(parsingContext.ParsingNamespace + name)?.Value,
               out float result);

            return result;
        }


        public static int AttributeAsInt(this XElement xElement, string name, WmtsParsingContext parsingContext)
             => xElement.AttributeAsInt(parsingContext.ParsingNamespace + name);


        /// <summary>
        /// Get the value of the xml attribute as an integer
        /// </summary>
        /// <param name="xElement"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int AttributeAsInt(this XElement xElement, XName name)
        {
            int.TryParse(
               xElement.Attribute(name)?.Value,
               out int result);

            return result;
        }

        public static bool AttributeAsBool(this XElement xElement, string name, WmtsParsingContext parsingContext)
            => xElement.AttributeAsBool(parsingContext.ParsingNamespace + name);

        /// <summary>
        /// Get the value of the xml attribute as a bool
        /// </summary>
        /// <param name="xElement"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool AttributeAsBool(this XElement xElement, XName name)
        {
            bool.TryParse(
               xElement.Attribute(name)?.Value,
               out bool result);

            return result;
        }

        public static double? AttributeAsDouble(this XElement xElement, string name, WmtsParsingContext parsingContext)
          => xElement.AttributeAsDouble(parsingContext.ParsingNamespace + name);

        /// <summary>
        /// Get the value of the xml attribute as a double
        /// </summary>
        /// <param name="xElement"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static double? AttributeAsDouble(this XElement xElement, XName name)
        {
            return double.TryParse(
               xElement.Attribute(name)?.Value,
               out double result) ? result : null;
        }

        public static DateTime? AttributeAsDateTime(this XElement xElement, string name, WmtsParsingContext parsingContext)
        => xElement.AttributeAsDateTime(parsingContext.ParsingNamespace + name);


        /// <summary>
        /// Get the value of the xml attribute as a datetime
        /// </summary>
        /// <param name="xElement"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static DateTime? AttributeAsDateTime(this XElement xElement, XName name)
        {
            if (DateTime.TryParse(
               xElement.Attribute(name)?.Value,
               out DateTime result))
                return result;

            return null;
        }

        public static float AttributeAsFloat(this XElement xElement, string name, WmtsParsingContext parsingContext)
             => xElement.AttributeAsFloat(parsingContext.ParsingNamespace + name);


        /// <summary>
        /// Get the value of the xml attribute as a float
        /// </summary>
        /// <param name="xElement"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static float AttributeAsFloat(this XElement xElement, XName name)
        {
            float.TryParse(
               xElement.Attribute(name)?.Value,
               out float result);

            return result;
        }


        public static XElement? ToXElement(this XmlDocument xmlDocument)
        {
            if (xmlDocument is null)
            {
                return null;
            }

            XDocument document = XDocument.Load(xmlDocument.CreateNavigator().ReadSubtree());

            return document.Root;
        }


        public static XElement? GetWmsElement(this XElement node, string name, WmtsParsingContext parsingContext)
         => node.Element(parsingContext.ParsingNamespace + name);

        public static IEnumerable<XElement> GetWmsElements(this XElement node, string name, WmtsParsingContext parsingContext)
         => node.Elements(parsingContext.ParsingNamespace + name);


        public static XAttribute? GetXLinkAttribute(this XElement node, string name)
        => node.Attribute(WmtsConstants.XLink + name);
    }
}
