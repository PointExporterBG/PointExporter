using PE.Common;
using PE.Common.Exceptions;
using PE.Entities;
using PE.Language;
using System;

namespace PE.Services.Default
{
    public abstract class BaseCalculationStrategy<TCompositePoint, TPoint, TSegment>
        where TCompositePoint : ICompositePoint<TPoint>, new()
        where TPoint : IPoint, new()
        where TSegment : ISegment
    {
        protected ICompositePointFactory<TCompositePoint, TPoint> compositePointFactory;
        protected IPointFactory<TPoint> pointFactory;
        protected IResourceManager resourceManager;

        public BaseCalculationStrategy(ICompositePointFactory<TCompositePoint, TPoint> compositePointFactory,
            IPointFactory<TPoint> pointFactory, IResourceManager resourceManager)
        {
            this.compositePointFactory = compositePointFactory;
            this.pointFactory = pointFactory;
            this.resourceManager = resourceManager;
        }

        public virtual TCompositePoint CalculatePoint(double radius, bool calculatePlanar,
            bool calculateOffsets, double? bearingRadius, bool calculateBearingDepth, double? bearingDepth,
            double offsetZ, Direction directionSign, double middle, double currentPosition, TSegment segment)
        {
            Validate(segment, calculateOffsets, bearingRadius, calculateBearingDepth, bearingDepth);

            TPoint pointPartial = CalculatePartial(segment, directionSign, currentPosition);

            TPoint point = CalculateCentral(pointPartial, segment, radius, offsetZ, currentPosition, middle);

            TPoint pointPlanar = calculatePlanar 
                ? CalculatePlanar(point, radius, calculatePlanar) 
                : default(TPoint);

            (TPoint pointAbove, TPoint pointBelow) = calculateOffsets
                ? CalculateAboveBelow(point, segment, radius, currentPosition, calculateOffsets, bearingRadius, middle)
                : (default(TPoint), default(TPoint));

            TPoint pointAboveInner = calculateBearingDepth
                ? CalculateInner(pointAbove, pointPartial, radius, calculateBearingDepth, bearingDepth)
                : (default(TPoint));
            TPoint pointBelowInner = calculateBearingDepth
                ? CalculateInner(pointBelow, pointPartial, radius, calculateBearingDepth, bearingDepth)
                : (default(TPoint));

            return compositePointFactory.Create(point, pointPlanar, pointAbove, pointBelow, pointAboveInner, pointBelowInner);
        }

        protected virtual void Validate(TSegment segment, bool calculateOffsets, double? bearingRadius,
            bool calculateBearingDepth, double? bearingDepth)
        {
            ValidateStartEndAngle(segment);
            ValidateBearingRadius(calculateOffsets, bearingRadius, true);
            ValidateBearingDepth(calculateBearingDepth, bearingDepth);
        }

        protected virtual void ValidateStartEndAngle(TSegment segment)
        {
            if (segment.EndAngle - segment.StartAngle == 0)
                throw new PEArgumentException(resourceManager, "end_angle_not_equal_start_angle");
        }

        protected virtual void ValidateBearingRadius(bool calculateOffsets, double? bearingRadius, bool checkValue = false)
        {
            if (calculateOffsets && !bearingRadius.HasValue)
                throw new PEArgumentException(resourceManager, "bearing_radius_required_for_offset");

            if (calculateOffsets && bearingRadius.HasValue && checkValue && bearingRadius.Value == 0)
                throw new PEArgumentException(resourceManager, "bearing_radius_0");
        }

        protected virtual void ValidateBearingDepth(bool calculateBearingDepth, double? bearingDepth)
        {
            if (calculateBearingDepth && !bearingDepth.HasValue)
                throw new PEArgumentException(resourceManager, "bearing_depth_required_for_inner_offset");
        }

        protected virtual TPoint CalculatePartial(TSegment segment, Direction directionSign, double currentPosition)
        {
            double xPartial = (int)directionSign * Math.Cos((currentPosition + segment.StartAngle) * Constants.RADIAN);
            double yPartial = (int)directionSign * Math.Sin((currentPosition + segment.StartAngle) * Constants.RADIAN);

            return pointFactory.Create(xPartial, yPartial, 0, 0);
        }

        protected virtual TPoint CalculatePlanar(TPoint point, double radius, bool calculatePlanar)
        {
            double xPlanar = calculatePlanar ? Math.Cos(point.Angle * Constants.RADIAN) * (radius + point.Z) : 0;
            double yPlanar = calculatePlanar ? Math.Sin(point.Angle * Constants.RADIAN) * (radius + point.Z) : 0;

            return pointFactory.Create(xPlanar, yPlanar, 0, point.Angle);
        }

        protected virtual TPoint CalculateInner(TPoint point, TPoint pointPartial,
             double radius, bool calculateBearingDepth, double? bearingDepth)
        {
            double xInner = calculateBearingDepth && bearingDepth.HasValue
                ? pointPartial.X * (radius - bearingDepth.Value) : 0;
            double yInner = calculateBearingDepth && bearingDepth.HasValue
                ? pointPartial.Y * (radius - bearingDepth.Value) : 0;

            return pointFactory.Create(xInner, yInner, point.Z, point.Angle);
        }

        protected virtual TPoint CalculateCentral(TPoint pointPartial, TSegment segment,
            double radius, double offsetZ, double currentPosition, double middle)
        {
            return pointFactory.Create(0, 0, 0, 0);
        }

        protected virtual (TPoint pointAbove, TPoint pointBelow) CalculateAboveBelow(TPoint point, TSegment segment,
            double radius, double currentPosition, bool calculateOffsets, double? bearingRadius, double middle)
        {
            return (pointFactory.Create(0, 0, 0, 0), pointFactory.Create(0, 0, 0, 0));
        }

        protected virtual double CalculateHeight(TSegment segment, double currentPosition, double middle = 0)
        {
            return 0;
        }
    }
}
