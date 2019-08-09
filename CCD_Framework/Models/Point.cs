using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCD_Framework.Models
{
    public class Point
    {
        public float PointX { get; set; }
        public float PointY { get; set; }

        public float GetK(Point P)
        {
            float resultK;
            resultK = P.PointY/ P.PointX;
            return resultK;
        }
    }
}
