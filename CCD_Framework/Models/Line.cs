using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCD_Framework.Models
{
    public class Line
    {
        public Point A { get; set; }

        public Point B { get; set; }

        private Point midPoint; 
        public Point MidPoint
        {
            get
            {
                return midPoint;
            }

            set
            {
                midPoint = value;
            }
        }
        private float k;
        public float K {
            get
            {
                
                return k;
            }

            set
            {
                k = value;
            }
        }

        public Point GetMidPoint(Point A,Point B)
        {
            var resultPoint = new Point();
            resultPoint.PointX = (B.PointX - A.PointX) / 2 + A.PointX;
            resultPoint.PointY = (B.PointY - A.PointY) / 2 + A.PointY;
            return resultPoint;
        }

        public float GetK(Point A, Point B)
        {
            float resultK;
            resultK = (A.PointY - B.PointY) / (A.PointX - B.PointX);
            return resultK;
        }
    }
}
