﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace OGCSharp.Wms
{
    /// <summary>
    /// Contains extension methods for XElement used internaly by wms paresr. 
    /// </summary>
    internal static class WmsXmlUtils
    {
        /// <summary>
        /// Get the value of the xml element as an integer
        /// </summary>
        /// <param name="xElement"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int ValueAsInt(this XElement xElement, string name, WmsParsingContext parsingContext)
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
        public static bool ValueAsBool(this XElement xElement, string name, WmsParsingContext parsingContext)
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
        public static double ValueAsDouble(this XElement xElement, string name, WmsParsingContext parsingContext)
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
        public static DateTime? ValueAsDateTime(this XElement xElement, string name, WmsParsingContext parsingContext)
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
        public static float ValueAsFloat(this XElement xElement, string name, WmsParsingContext parsingContext)
        {
            float.TryParse(
               xElement.Element(parsingContext.ParsingNamespace + name)?.Value,
               out float result);

            return result;
        }


    
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



        public static XElement? GetWmsElement(this XElement node, string name, WmsParsingContext parsingContext)
         => node.Element(parsingContext.ParsingNamespace + name);

        public static IEnumerable<XElement> GetWmsElements(this XElement node, string name, WmsParsingContext parsingContext)
         => node.Elements(parsingContext.ParsingNamespace + name);

        public static XAttribute? GetXLinkAttribute(this XElement node, string name)
        => node.Attribute(WmsNamespaces.XLink + name);
    }
}
