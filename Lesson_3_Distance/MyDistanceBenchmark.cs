using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Lesson_3_Distance
{
    [MemoryDiagnoser]
    [RankColumn]

    public class MyDistanceBenchmark
    {
        private static Random rnd = new Random();
        private static double x1 = rnd.NextDouble();
        private static double y1 = rnd.NextDouble();
        private static double x2 = rnd.NextDouble();
        private static double y2 = rnd.NextDouble();
        
        private PointClassF POINT_CLASS_ONE_F = new PointClassF { X = (float)x1, Y = (float)y1 };
        private PointClassF POINT_CLASS_TWO_F = new PointClassF { X = (float)x2, Y = (float)y2 };
        private PointStructF POINT_STRUCT_ONE_F = new PointStructF { X = (float)x1, Y = (float)y1 };
        private PointStructF POINT_STRUCT_TWO_F = new PointStructF { X = (float)x2, Y = (float)y2 };
        private PointStructD POINT_STRUCT_ONE_D = new PointStructD { X = x1, Y = y1 };
        private PointStructD POINT_STRUCT_TWO_D = new PointStructD { X = x2, Y = y2 };

        private static readonly MyDistance _myDistance = new MyDistance();

        [Benchmark]
        public void PointDistanceClassFloatTest()
        {
            float result = _myDistance.PointDistanceClassFloat(ref POINT_CLASS_ONE_F, ref POINT_CLASS_TWO_F);
        }
        [Benchmark]
        public void PointDistanceStructFloatTest()
        {
            float result = _myDistance.PointDistanceStructFloat(POINT_STRUCT_ONE_F, POINT_STRUCT_TWO_F);
        }
        [Benchmark]
        public void PointDistanceStructDoubleTest()
        {
            double result = _myDistance.PointDistanceStructDouble(POINT_STRUCT_ONE_D, POINT_STRUCT_TWO_D);
        }
        [Benchmark]
        public void PointDistanceStructFloatShortTest()
        {
            float result = _myDistance.PointDistanceStructFloatShort(POINT_STRUCT_ONE_F, POINT_STRUCT_TWO_F);
        }
    }
}
