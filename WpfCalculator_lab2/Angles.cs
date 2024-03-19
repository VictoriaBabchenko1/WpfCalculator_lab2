using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCalculator_lab2
{
    public class Angles
    {
        public enum Units
        {
            RADIANS,  // Default unit
            DEGREES,
            GRADIANS
        }

        public class Converter
        {
            /// <summary>
            /// Converts the given angle to degrees
            /// </summary>
            public static double degrees(double angle, Units angleUnit)
            {
                if (angleUnit == Units.RADIANS)
                    return angle * 180 / Math.PI;
                else if (angleUnit == Units.GRADIANS)
                    return angle * 9 / 10;
                else if (angleUnit == Units.DEGREES)
                    return angle;
                else
                {
                    Exception error = new Exception("Invalid parameters");
                    throw error;
                }
            }

            /// <summary>
            /// Converts the given angle to radians
            /// </summary>
            public static double radians(double angle, Units angleUnit)
            {
                if (angleUnit == Units.RADIANS)
                    return angle;

                return degrees(angle, angleUnit) * Math.PI / 180;
            }

            /// <summary>
            /// Converts the given angle to gradians
            /// </summary>
            public static double gradians(double angle, Units angleUnit)
            {
                if (angleUnit == Units.GRADIANS)
                    return angle;
                return degrees(angle, angleUnit) * 10 / 9;
            }
        }
    }
}
