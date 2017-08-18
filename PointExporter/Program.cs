using PE.Cache;
using PE.Cache.Default;
using PE.Entities;
using PE.Entities.Default;
using PE.Language;
using PE.Language.XmlResources;
using PE.Services;
using PE.Services.Default;
using SimpleInjector;
using System;
using System.Windows.Forms;

namespace PointExporter
{
    static class Program
	{
		private static Container container;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Bootstrap();
			Application.Run(container.GetInstance<PEMainForm<CompositePoint<Point>, Point, Segment>>());
		}

		private static void Bootstrap()
		{
			container = new Container();

			container.Register<ISegmentFactory<Segment>, SegmentFactory<Segment>>(Lifestyle.Singleton);
			container.Register<IPointFactory<Point>, PointFactory<Point>>(Lifestyle.Singleton);
			container.Register<ICompositePointFactory<CompositePoint<Point>, Point>,
								CompositePointFactory<CompositePoint<Point>, Point>>(Lifestyle.Singleton);
			container.Register<ICalculateService<CompositePoint<Point>, Point, Segment>,
								CalculateService<CompositePoint<Point>, Point, Segment>>(Lifestyle.Singleton);
			container.Register<IExportService<CompositePoint<Point>, Point>,
								ExcelExportService<CompositePoint<Point>, Point>>(Lifestyle.Singleton);
            container.Register<ISegmentManager<Segment>, SegmentManager<Segment>>(Lifestyle.Singleton);
            container.Register<ICacheManager, CacheManager>(Lifestyle.Singleton);
            container.Register<IResourceManager, XmlResourceManager>(Lifestyle.Singleton);
            container.Register<PEMainForm<CompositePoint<Point>, Point, Segment>>(Lifestyle.Singleton);

			container.Verify();
		}
	}
}
