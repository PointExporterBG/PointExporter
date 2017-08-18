using PE.Language;
using System;

namespace PE.Common.Exceptions
{
    public class PEException : Exception
    {
        public PEException(IResourceManager resourceManager, string message)
            : base(resourceManager != null ? resourceManager.GetResource(message) : message)
        {
        }
    }
}
