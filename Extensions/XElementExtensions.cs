using RotmgNetworkingLib.Utilities;
using RotmgNetworkingLib.Api;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace RotmgNetworkingLib.Extensions
{
    public static class XElementExtensions
    {
        public static string GetString(this XElement element, string elementName) => element.ForceElement(elementName).Value;
       
        public static string GetStringAttribute(this XElement element, string attributeName) => element.ForceAttribute(attributeName).Value;
       
        public static string GetNullableString(this XElement element, string elementName) => element.Element(elementName)?.Value;
       
        public static string GetNullableStringAttribute(this XElement element, string attributeName) => element.Attribute(attributeName)?.Value;

        public static byte GetByte(this XElement element, string elementName) => element.ForceParseElement(elementName, byte.Parse);
       
        public static byte GetByteAttribute(this XElement element, string attributeName) => element.ForceParseAttribute(attributeName, byte.Parse);
       
        public static byte? GetNullableByte(this XElement element, string elementName)
        {
            (byte result, bool success) = element.SoftParseElement(elementName, byte.Parse);
            if (success)
                return result;
            return null;
        }
      
        public static byte? GetNullableByteAttribute(this XElement element, string attributeName)
        {
            (byte result, bool success) = element.SoftParseAttribute(attributeName, byte.Parse);
            if (success)
                return result;
            return null;
        }
       
        public static byte[] GetByteList(this XElement element, string elementName)
        {
            string val = element.GetNullableString(elementName);

            if (val == null)
                return null;

            if (val.Length == 0)
                return new byte[0];

            try
            {
                return Array.ConvertAll(val.Split(','), byte.Parse);
            }
            catch
            {
                throw new XMLModelException("XML element " + element?.Name + "." + elementName + " is not a byte list");
            }
        }

        public static short GetShort(this XElement element, string elementName) => element.ForceParseElement(elementName, short.Parse);
      
        public static short GetShortAttribute(this XElement element, string attributeName) => element.ForceParseAttribute(attributeName, short.Parse);
        
        public static short? GetNullableShort(this XElement element, string elementName)
        {
            (short result, bool success) = element.SoftParseElement(elementName, short.Parse);
            if (success)
                return result;
            return null;
        }
      
        public static short? GetNullableShortAttribute(this XElement element, string attributeName)
        {
            (short result, bool success) = element.SoftParseAttribute(attributeName, short.Parse);
            if (success)
                return result;
            return null;
        }
      
        public static short[] GetShortList(this XElement element, string elementName)
        {
            string val = element.GetNullableString(elementName);

            if (val == null)
                return null;

            if (val.Length == 0)
                return new short[0];

            try
            {
                return Array.ConvertAll(val.Split(','), short.Parse);
            }
            catch
            {
                throw new XMLModelException("XML element " + element?.Name + "." + elementName + " is not a short list");
            }
        }

        public static ushort GetUShort(this XElement element, string elementName) => element.ForceParseElement(elementName, ushort.Parse);
      
        public static ushort GetUShortAttribute(this XElement element, string attributeName) => element.ForceParseAttribute(attributeName, ushort.Parse);
       
        public static ushort? GetNullableUShort(this XElement element, string elementName)
        {
            (ushort result, bool success) = element.SoftParseElement(elementName, ushort.Parse);
            if (success)
                return result;
            return null;
        }
       
        public static ushort? GetNullableUShortAttribute(this XElement element, string attributeName)
        {
            (ushort result, bool success) = element.SoftParseAttribute(attributeName, ushort.Parse);
            if (success)
                return result;
            return null;
        }
       
        public static ushort[] GetUShortList(this XElement element, string elementName)
        {
            string val = element.GetNullableString(elementName);

            if (val == null)
                return null;

            if (val.Length == 0)
                return new ushort[0];

            try
            {
                return Array.ConvertAll(val.Split(','), ushort.Parse);
            }
            catch
            {
                throw new XMLModelException("XML element " + element?.Name + "." + elementName + " is not a short list");
            }
        }

        
        public static int GetInt(this XElement element, string elementName) => element.ForceParseElement(elementName, int.Parse);
       
        public static int GetIntAttribute(this XElement element, string attributeName) => element.ForceParseAttribute(attributeName, int.Parse);
        
        public static int? GetNullableInt(this XElement element, string elementName)
        {
            (int result, bool success) = element.SoftParseElement(elementName, int.Parse);
            if (success)
                return result;
            return null;
        }
        
        public static int? GetNullableIntAttribute(this XElement element, string attributeName)
        {
            (int result, bool success) = element.SoftParseAttribute(attributeName, int.Parse);
            if (success)
                return result;
            return null;
        }
        
        public static int[] GetIntList(this XElement element, string elementName)
        {
            string val = element.GetNullableString(elementName);

            if (val == null)
                return null;

            if (val.Length == 0)
                return new int[0];

            try
            {
                return Array.ConvertAll(val.Split(','), int.Parse);
            }
            catch
            {
                throw new XMLModelException("XML element " + element?.Name + "." + elementName + " is not an int list");
            }
        }

        public static long GetLong(this XElement element, string elementName) => element.ForceParseElement(elementName, long.Parse);
       
        public static long GetLongAttribute(this XElement element, string attributeName) => element.ForceParseAttribute(attributeName, long.Parse);
       
        public static long? GetNullableLong(this XElement element, string elementName)
        {
            (long result, bool success) = element.SoftParseElement(elementName, short.Parse);
            if (success)
                return result;
            return null;
        }
        
        public static long? GetNullableLongAttribute(this XElement element, string attributeName)
        {
            (long result, bool success) = element.SoftParseAttribute(attributeName, long.Parse);
            if (success)
                return result;
            return null;
        }
        
        public static long[] GetLongList(this XElement element, string elementName)
        {
            string val = element.GetNullableString(elementName);

            if (val == null)
                return null;

            if (val.Length == 0)
                return new long[0];

            try
            {
                return Array.ConvertAll(val.Split(','), long.Parse);
            }
            catch
            {
                throw new XMLModelException("XML element " + element?.Name + "." + elementName + " is not a long list");
            }
        }

        public static double GetDouble(this XElement element, string elementName) => element.ForceParseElement(elementName, double.Parse);
        
        public static double GetDoubleAttribute(this XElement element, string attributeName) => element.ForceParseAttribute(attributeName, double.Parse);
        
        public static double? GetNullableDouble(this XElement element, string elementName)
        {
            (double result, bool success) = element.SoftParseElement(elementName, double.Parse);
            if (success)
                return result;
            return null;
        }
       
        public static double? GetNullableDoubleAttribute(this XElement element, string attributeName)
        {
            (double result, bool success) = element.SoftParseAttribute(attributeName, double.Parse);
            if (success)
                return result;
            return null;
        }
        
        public static double[] GetDoubleList(this XElement element, string elementName)
        {
            string val = element.GetNullableString(elementName);

            if (val == null)
                return null;

            if (val.Length == 0)
                return new double[0];

            try
            {
                return Array.ConvertAll(val.Split(','), double.Parse);
            }
            catch
            {
                throw new XMLModelException("XML element " + element?.Name + "." + elementName + " is not a double list");
            }
        }
        
        public static bool GetBool(this XElement element, string elementName) => element.ForceParseElement(elementName, Conversion.StringToBool);
        
        public static bool GetBoolAttribute(this XElement element, string attributeName) => element.ForceParseAttribute(attributeName, Conversion.StringToBool);
        
        public static bool? GetNullableBool(this XElement element, string elementName)
        {
            (bool result, bool success) = element.SoftParseElement(elementName, Conversion.StringToBool);
            if (success)
                return result;
            return null;
        }

        public static bool? GetNullableBoolAttribute(this XElement element, string attributeName)
        {
            (bool result, bool success) = element.SoftParseAttribute(attributeName, Conversion.StringToBool);
            if (success)
                return result;
            return null;
        }

        public static bool[] GetBoolList(this XElement element, string elementName)
        {
            string val = element.GetNullableString(elementName);

            if (val == null)
                return null;

            if (val.Length == 0)
                return new bool[0];

            try
            {
                return Array.ConvertAll(val.Split(','), Conversion.StringToBool);
            }
            catch
            {
                throw new XMLModelException("XML element " + element?.Name + "." + elementName + " is not a bool list");
            }
        }

        public static T Get<T>(this XElement element, string elementName) where T : IXMLElement, new()
        {
            try
            {
                T result = new T();
                result.Read(element.Element(elementName) ?? throw new XMLModelException("Missing XML element: " + element?.Name + "." + elementName));
                return result;
            }
            catch (XMLModelException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw new XMLModelException("XML element " + element?.Name + "." + elementName + " failed to parse to a " + typeof(T).Name);
            }
        }

        public static T GetNullable<T>(this XElement element, string elementName) where T : IXMLElement, new()
        {
            XElement target = element.Element(elementName);

            if (target is null)
                return default;

            try
            {
                T result = new T();
                result.Read(target);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to parse XML element " + element?.Name + "." + elementName + " into a " + typeof(T).Name);
                Console.WriteLine(e + "\n" + target.ToString());
                return default;
            }
        }

        public static List<T> GetList<T>(this XElement element, string elementName, bool ignoreInvalid = false) where T : IXMLElement, new()
        {
            IEnumerable<XElement> targets = element.Elements(elementName);
            List<T> result = new List<T>();

            foreach (XElement target in targets)
            {
                T model = new T();

                try
                {
                    model.Read(target);
                }
                catch (XMLModelException e)
                {
                    if(!ignoreInvalid)
                        throw e;
                }
                catch (Exception)
                {
                    if (!ignoreInvalid)
                        throw new XMLModelException("XML element " + element?.Name + "." + elementName + " failed to parse to a " + typeof(T).Name);
                }

                result.Add(model);
            }

            return result;
        }

        public static bool GetFlag(this XElement element, string flagName) => element.Element(flagName) != null;

        private static XElement ForceElement(this XElement element, string elementName)
        {
            if (element is null || element.Element(elementName) is null)
                throw new XMLModelException("Missing XML element: " + element?.Name + "." + elementName);
            return element.Element(elementName);
        }

        private static T ForceParseElement<T>(this XElement element, string elementName, Converter<string, T> converter)
        {
            try
            {
                return converter.Invoke(element.GetString(elementName));
            }
            catch (XMLModelException e)
            {
                throw e;
            }
            catch (Exception)
            {
                throw new XMLModelException("XML element " + element?.Name + "." + elementName + " failed to parse to a " + typeof(T).Name);
            }
        }

        private static (T result, bool success) SoftParseElement<T>(this XElement element, string elementName, Converter<string, T> converter)
        {
            string str = element.Element(elementName)?.Value;

            if (str != null)
            {
                try
                {
                    T value = converter.Invoke(str);
                    return (value, true);
                }
                catch
                {
                    //Console.WriteLine("Failed to parse XML element " + element?.Name + "." + elementName + " to a " + typeof(T).Name);
                }
            }

            return (default, false);
        }
        
        private static XAttribute ForceAttribute(this XElement element, string attributeName)
        {
            if (element is null || element.Attribute(attributeName) is null)
                throw new XMLModelException("Missing XML attribute " + element?.Name + "." + attributeName);
            return element.Attribute(attributeName);
        }

        private static T ForceParseAttribute<T>(this XElement element, string attributeName, Converter<string, T> converter)
        {
            try
            {
                return converter.Invoke(element.GetStringAttribute(attributeName));
            }
            catch (XMLModelException e)
            {
                throw e;
            }
            catch (Exception)
            {
                throw new XMLModelException("XML attribute " + element?.Name + "." + attributeName + " failed to parse to a " + typeof(T).Name);
            }
        }

        private static (T result, bool success) SoftParseAttribute<T>(this XElement element, string attributeName, Converter<string, T> converter)
        {
            string str = element.Attribute(attributeName)?.Value;

            if (str != null)
            {
                try
                {
                    T value = converter.Invoke(str);
                    return (value, true);
                }
                catch
                {
                    //Console.WriteLine("Failed to parse XML attribute " + element?.Name + "." + attributeName + " to a " + typeof(T).Name);
                }
            }

            return (default, false);
        }

    }
}
