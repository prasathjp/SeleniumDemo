using System;

namespace SeleniumDemo
{
    public class Volume
    {
        public enum Shapes
        {
            Sphere,
            Cylinder,
            Cuboid,
            Sqr_Pyramid,
            Rect_Pyramid,
            Tri_Pyramid,
            Hexa_Pyramid
        }

        private static double volShape;
        private static string volValue;
        private const double volMultiplier = 1.0 / 3.0;
        private const double volHemiMultiplier = 2.0 / 3.0;
        private const double areaSphereMultiplier = 4.0 / 3.0;
        private const double areaRectMultiplier = 1.0 / 2.0;
        public const string strCubic = " cubic.";

        //Method returns Volume of Sphere for the given Radius
        public static string CalcVolSphere(double radSphere, string dimMetrics)
        {
            Shapes enumSphere = Shapes.Sphere;

            volShape = areaSphereMultiplier * CalcArea(radSphere, enumSphere);
            volValue = String.Concat("Volume of Sphere : ", volShape, strCubic, dimMetrics);

            return volValue;
        }

        //Method returns Volume of Cylinder for the given Radius area and Height
        public static string CalcVolCylinder(double baseArea, double height, string dimMetrics)
        {
            Shapes enumCylinder = Shapes.Cylinder;

            volShape = (CalcArea(baseArea, enumCylinder)) * height;
            volValue = String.Concat("Volume of Cylinder : ", volShape, strCubic, dimMetrics);

            return volValue;
        }

        //Method returns Volume of Square Pyramid for the given
        public static string CalcVolSqrPyramid(double baseArea, double pyrHeight, string dimMetrics)
        {
            Shapes enumSprPyramid = Shapes.Sqr_Pyramid;

            volShape = volMultiplier * CalcArea(baseArea, enumSprPyramid) * pyrHeight;
            volValue = String.Concat("Volume of Square Pyramid : ", volShape, strCubic, dimMetrics);

            return volValue;
        }

        //Method returns Volume of Rectangular Pyramid for the given 
        public static string CalcVolRectPyramid(double radLen, double height, double pyrHeight, string dimMetrics)
        {
            Shapes enumRectPyramid = Shapes.Rect_Pyramid;

            volShape = volMultiplier * CalcArea(radLen, enumRectPyramid, height) * pyrHeight;
            volValue = String.Concat("Volume of Rectangular Pyramid : ", volShape, strCubic, dimMetrics);

            return volValue;
        }

        //Method returns Volume of Triangular Pyramid for the given 
        public static string CalcVolTriPyramid(double baseArea, double baseHeight, double pyrHeight, string dimMetrics)
        {
            Shapes enumTriPyramid = Shapes.Tri_Pyramid;

            volShape = volMultiplier * CalcArea(baseArea, enumTriPyramid, baseHeight) * pyrHeight;
            volValue = String.Concat("Volume of Triangular Pyramid : ", volShape, strCubic, dimMetrics);

            return volValue;
        }

        //Method returns Volume of Hexagonals Pyramid for the given 
        public static string CalcVolHexPyramid(double baseArea, double pyrHeight, string dimMetrics)
        {
            Shapes enumHexPyramid = Shapes.Hexa_Pyramid;

            volShape = volMultiplier * CalcArea(baseArea, enumHexPyramid) * pyrHeight;
            volValue = String.Concat("Volume of Hexagonal Pyramid : ", volShape, strCubic, dimMetrics);

            return volValue;
        }

        //Method returns Volume of Cone for the given 
        public static string CalcVolCone(double baseArea, double height, string dimMetrics)
        {
            Shapes enumCone = Shapes.Cylinder;

            volShape = volMultiplier * (CalcArea(baseArea, enumCone)) * height;
            volValue = String.Concat("Volume of Cone : ", volShape, strCubic, dimMetrics);

            return volValue;
        }

        //Method returns Volume of Hemishpere for the given 
        public static string CalcVolHemSphr(double baseArea, string dimMetrics)
        {
            Shapes enumHemSphr = Shapes.Sphere;

            volShape = volHemiMultiplier * CalcArea(baseArea, enumHemSphr);
            volValue = String.Concat("Volume of Hemisphere : ", volShape, strCubic, dimMetrics);

            return volValue;
        }

        //Method returns Volume of Cuboid for the given 
        public static string CalcVolCuboid(double lenght, double height, double width, string dimMetrics)
        {
            Shapes enumCuboid = Shapes.Cuboid;

            volShape = CalcArea(lenght, enumCuboid, lenght, width);
            volValue = String.Concat("Volume of Cuboid : ", volShape, strCubic, dimMetrics);

            return volValue;
        }

        //Method returns Area of shapes for given dimensions
        public static double CalcArea(double radArea, Shapes enumShape, double baseHeight = 1, double baseWidth = 1)
        {
            double baseArea = 0;
            double radCube = 3;
            double radSqr = 2;

            switch (enumShape)
            {
                case Shapes.Sphere:
                    baseArea = Math.PI * Math.Pow(radArea, radCube);
                    break;
                case Shapes.Cylinder:
                    baseArea = Math.PI * Math.Pow(radArea, radSqr);
                    break;
                case Shapes.Sqr_Pyramid:
                    baseArea = radArea * radArea;
                    break;
                case Shapes.Rect_Pyramid:
                    baseArea = radArea * baseHeight;
                    break;
                case Shapes.Tri_Pyramid:
                    baseArea = areaRectMultiplier * radArea * baseHeight;
                    break;
                case Shapes.Hexa_Pyramid:
                    baseArea = (3 * Math.Sqrt(3)) / 2;
                    break;
                case Shapes.Cuboid:
                    baseArea = radArea * baseHeight * baseWidth;
                    break;
            }
            return baseArea;
        }
    }
}