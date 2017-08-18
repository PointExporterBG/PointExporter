namespace PE.Language
{
    public interface ILocalizable
    {
        IResourceManager ResourceManager { set; }
        void SetResources();
    }
}
