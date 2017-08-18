namespace PE.Language
{
    public interface IResourceManager
    {
        string GetResource(string resourceKey);

        string GetResource(string resourceKey, params object[] args);
    }
}
