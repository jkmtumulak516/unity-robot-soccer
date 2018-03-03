using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Helper
{
    class Angle
    {
        public static double ComputeRelativeAngle(float orientation, float srcX, float srcY, float destX, float destY)
        {
            return Normalize(RadianToDegree(Math.Atan2(destX - srcX, destY - srcY)) - orientation);
        }

        private static double RadianToDegree(double angle)
        {
            return angle * (180.0 / Math.PI);
        }

        private static double Normalize(double angle)
        {
            if (angle < -180)
            {
                angle += 360;
            }
            else if (angle > 180)
            {
                angle -= 360;
            }

            return angle;
        }
    }
}
