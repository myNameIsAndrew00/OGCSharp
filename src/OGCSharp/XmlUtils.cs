using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OGCSharp
{
    /// <summary>
    /// Contains extension methods for XElement
    /// </summary>
    public static class XmlUtils
    {
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
        public static int ValueAsInt(this XElement xElement, XName name)
        {
            int.TryParse(
               xElement.Element(name)?.Value,
               out int result);

            return result;
        }

        /// <summary>
        /// Get the value of the xml element as an integer
        /// </summary>
        /// <param name="xElement"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int ValueAsIntUnprefixed(this XElement xElement, string name)
        {
            int.TryParse(
               xElement.ElementUnprefixed(name)?.Value,
               out int result);

            return result;
        }

        /// <summary>
        /// Get the value of the xml element as a bool
        /// </summary>
        /// <param name="xElement"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool ValueAsBool(this XElement xElement, XName name)
        {
            bool.TryParse(
               xElement.Element(name)?.Value,
               out bool result);

            return result;
        }

        /// <summary>
        /// Get the value of the xml element as a bool
        /// </summary>
        /// <param name="xElement"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool ValueAsBoolUnprefixed(this XElement xElement, string name)
        {
            bool.TryParse(
               xElement.ElementUnprefixed(name)?.Value,
               out bool result);

            return result;
        }

        /// <summary>
        /// Get the value of the xml element as a double
        /// </summary>
        /// <param name="xElement"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static double ValueAsDouble(this XElement xElement, XName name)
        {
            double.TryParse(
               xElement.Element(name)?.Value,
               out double result);

            return result;
        }

        /// <summary>
        /// Get the value of the xml element as a datetime
        /// </summary>
        /// <param name="xElement"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static DateTime? ValueAsDateTime(this XElement xElement, XName name)
        {
            if (DateTime.TryParse(
               xElement.Element(name)?.Value,
               out DateTime result))
                return result;

            return null;
        }

        /// <summary>
        /// Get the value of the xml element as a double
        /// </summary>
        /// <param name="xElement"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static double ValueAsDoubleUnprefixed(this XElement xElement, string name)
        {
            double.TryParse(
               xElement.ElementUnprefixed(name)?.Value,
               out double result);

            return result;
        }

        /// <summary>
        /// Get the value of the xml element as a float
        /// </summary>
        /// <param name="xElement"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static float ValueAsFloat(this XElement xElement, XName name)
        {
            float.TryParse(
               xElement.Element(name)?.Value,
               out float result);

            return result;
        }

        /// <summary>
        /// Get the value of the xml element as a float
        /// </summary>
        /// <param name="xElement"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static float ValueAsFloatUnprefixed(this XElement xElement, string name)
        {
            float.TryParse(
               xElement.ElementUnprefixed(name)?.Value,
               out float result);

            return result;
        }


        /// <summary>
        /// Get the value of the xml element as a datetime
        /// </summary>
        /// <param name="xElement"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static DateTime? ValueAsDateTimeUnprefixed(this XElement xElement, string name)
        {
            if (DateTime.TryParse(
               xElement.ElementUnprefixed(name)?.Value,
               out DateTime result))
                return result;

            return null;
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
        public static double AttributeAsDouble(this XElement xElement, XName name)
        {
            double.TryParse(
               xElement.Attribute(name)?.Value,
               out double result);

            return result;
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
         
    }
}
