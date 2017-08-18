using PE.Cache;

namespace PE.Language.Default
{
    public class ResourceManager : IResourceManager
    {
        private ICacheManager cacheManager;

        public ResourceManager(ICacheManager cacheManager)
        {
            this.cacheManager = cacheManager;
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

                stringValue = Resources.ResourceManager.GetString(resourceKey, Resources.Culture);
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
    }
}
