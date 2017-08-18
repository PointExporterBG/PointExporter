using PE.Language;
using System;

namespace PE.Common.Exceptions
{
    public class PEArgumentException : ArgumentException
    {
        public PEArgumentException(IResourceManager resourceManager, string message)
            : base(resourceManager != null ? resourceManager.GetResource(message) : message)
        {
        }
    }
}
