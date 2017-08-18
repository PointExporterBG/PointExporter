using PE.Cache;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Xml.Linq;

namespace PE.Language.XmlResources
{
    public class XmlResourceManager : IResourceManager
    {
        private const string FILE_PATH_NAME = "XmlResources\\Resources";
        private const string FILE_EXTENSION = ".xml";
        private const string XE_ATTRIBUTE_NAME = "name";

        private ICacheManager cacheManager;
        private CultureInfo culture;

        public XmlResourceManager(ICacheManager cacheManager)
        {
            this.cacheManager = cacheManager;
            culture = Thread.CurrentThread.CurrentUICulture;
        }

        public string GetResource(string resourceKey)
        {
            try
            {
                object cachedValue = cacheManager.Get(resourceKey);
                if (cachedValue != null
                    && cachedValue is string stringValue
                    && !string.IsNullOrWhiteSpace(stringValue))
                    return stringValue;

                stringValue = GetString(resourceKey, culture);
                cacheManager.Set(resourceKey, stringValue);
                return stringValue;
            }
            catch
            {
                return resourceKey;
            }
        }

        public string GetResource(string resourceKey, params object[] args)
        {
            try
            {
                return string.Format(GetResource(resourceKey), args);
            }
            catch
            {
                return resourceKey;
            }
        }

        private string GetString(string resourceKey, CultureInfo culture)
        {
            try
            {
                string fileName = culture != CultureInfo.InvariantCulture
                    ? string.Format("{0}.{1}{2}", FILE_PATH_NAME, culture.Name, FILE_EXTENSION)
                    : string.Format("{0}{1}", FILE_PATH_NAME, FILE_EXTENSION);

                XDocument xDoc = XDocument.Load(fileName);
                IEnumerable<XElement> xeResources = xDoc.Root.Elements();
                return xeResources.FirstOrDefault(
                    xe => string.Equals(xe.Attribute(XE_ATTRIBUTE_NAME).Value, 
                                        resourceKey, 
                                        StringComparison.InvariantCultureIgnoreCase))
                    .Value;
            }
            catch
            {
                return resourceKey;
            }
        }
    }
}
