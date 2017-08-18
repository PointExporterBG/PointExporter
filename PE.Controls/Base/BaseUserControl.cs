using PE.Language;
using MetroFramework.Controls;
using MetroFramework;
using System;
using PE.Common;

namespace PE.Controls.Base
{
    public class BaseUserControl : MetroUserControl, ILocalizable, IStylable
    {
        public IResourceManager ResourceManager { private get; set; }

        public string GetResource(string resourceKey)
        {
            if (ResourceManager == null)
                return resourceKey;

            return ResourceManager.GetResource(resourceKey);
        }

        public string GetResource(string resourceKey, params object[] args)
        {
            if (ResourceManager == null)
                return resourceKey;

            return ResourceManager.GetResource(resourceKey, args);
        }

        public virtual void SetResources()
        {
        }

        public void SetStyle(MetroColorStyle style)
        {
            Style = style;
        }

        public void SetTheme(MetroThemeStyle theme)
        {
            Theme = theme;
        }

        protected override void OnLoad(EventArgs e)
        {
            SetStyle(Constants.DEFAULT_METRO_COLOR);
            SetTheme(Constants.DEFAULT_METRO_THEME);

            base.OnLoad(e);
        }
    }
}
