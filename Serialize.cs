/*******************************************
 * Copyright (c) 2016 ztly107
 * License: MIT
 * Description: Xml序列化与反序列化
 * https://github.com/ztly107/DotNetUtils
 * ******************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace LSlib.Utils
{
    public class Serialize
    {
        /// <summary>
        /// Xml序列化
        /// </summary>
        /// <param name="type"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string XmlSerializer(Type type, object obj)
        {
            using (MemoryStream Stream = new MemoryStream())
            {
                XmlSerializer xml = new XmlSerializer(type);
                try
                {
                    xml.Serialize(Stream, obj);
                }
                catch (InvalidOperationException)
                {
                    throw;
                }
                Stream.Position = 0;
                StreamReader sr = new StreamReader(Stream);
                string str = sr.ReadToEnd();
                sr.Dispose();
                return str;
            }
        }
        /// <summary>
        /// Xml反序列化
        /// </summary>
        /// <param name="type"></param>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static object XmlDeserialize(Type type, string xml)
        {
            object obj;
            try
            {
                using (StringReader sr = new StringReader(xml))
                {
                    XmlSerializer xmlSer = new XmlSerializer(type);
                    obj= xmlSer.Deserialize(sr);
                }
            }
            catch (Exception e)
            {
                obj= null;
            }
            return obj;
        }



    }
}
