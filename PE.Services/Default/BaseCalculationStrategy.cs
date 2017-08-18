using PE.Entities;
using PE.Language;

namespace PE.Services.Default
{
    public abstract class BaseCalculationStrategy<TCompositePoint, TPoint>
		where TCompositePoint : ICompositePoint<TPoint>, new()
		where TPoint : IPoint
	{
		protected ICompositePointFactory<TCompositePoint, TPoint> compositePointFactory;
        protected IResourceManager resourceManager;

		public BaseCalculationStrategy(ICompositePointFactory<TCompositePoint, TPoint> compositePointFactory,
            IResourceManager resourceManager)
		{
			this.compositePointFactory = compositePointFactory;
            this.resourceManager = resourceManager;
		}
	}
}
