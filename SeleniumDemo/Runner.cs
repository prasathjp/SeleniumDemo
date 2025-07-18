using System;

namespace SeleniumDemo
{
    public class Runner
    {
        private const string DimMetrics = "cm";

        public static void Main(string[] args)
        {
            //Calculate volumes of shapes sequentially
            string strVolSphere = Volume.CalcVolSphere(4, DimMetrics);
            Console.WriteLine(strVolSphere);
            string strVolCylinder = Volume.CalcVolCylinder(4, 3, DimMetrics);
            Console.WriteLine(strVolCylinder);
            string strSqrPyramid = Volume.CalcVolSqrPyramid(4, 3, DimMetrics);
            Console.WriteLine(strSqrPyramid);
            string strRectPyramid = Volume.CalcVolRectPyramid(4, 3, 5, DimMetrics);
            Console.WriteLine(strRectPyramid);
            string strTriPyramid = Volume.CalcVolTriPyramid(4, 3, 5, DimMetrics);
            Console.WriteLine(strTriPyramid);
            string strHexPyramid = Volume.CalcVolHexPyramid(4, 3, DimMetrics);
            Console.WriteLine(strHexPyramid);
            string strCone = Volume.CalcVolCone(4, 3, DimMetrics);
            Console.WriteLine(strCone);
            string strHemiSphere = Volume.CalcVolHemSphr(4, DimMetrics);
            Console.WriteLine(strHemiSphere);
            string strCuboid = Volume.CalcVolCuboid(4, 3, 5, DimMetrics);
            Console.WriteLine(strCuboid);
        }
    }
}