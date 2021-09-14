using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_3_Distance
{
    public class PointClassF
    {
        public float X;
        public float Y;
    }
    public struct PointStructF
    {
        public float X;
        public float Y;
    }
    public struct PointStructD
    {
        public double X;
        public double Y;
    }
    public class MyDistance
    {
        public float PointDistanceClassFloat(ref PointClassF pointOne, ref PointClassF pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));            
        }
        public float PointDistanceStructFloat(PointStructF pointOne, PointStructF pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));            
        }
        public double PointDistanceStructDouble(PointStructD pointOne, PointStructD pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));            
        }
        public float PointDistanceStructFloatShort(PointStructF pointOne, PointStructF pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }
    }
}
