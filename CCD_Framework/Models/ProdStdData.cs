using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCD_Framework.Models
{
    public class ProdStdData
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string sMidPoint { get; set; }
        public float Angle { get; set; }
        public float StDx { get; set; }
        public float StDy { get; set; }
        public string sMidPoint2 { get; set; }
        public float Angle2 { get; set; }
        public float StDx2 { get; set; }
        public float StDy2 { get; set; }
        public float XOffsetAllowed { get; set; }
        public float YOffsetAllowed { get; set; }
        public float AngleOffsetAllowed { get; set; }

        public Point MidPoint { get; set; }

        public Point MidPoint2 { get; set; }
        public bool Enable { get; set; }

        public string Note { get; set; }

        public float CellLength1 { get; set; }
        public float CellLength1Limits { get; set; }
        public float CellLength2 { get; set; }
        public float CellLength2Limits { get; set; }

        public float WidthA1 { get; set; }
        public float WidthA1Limits { get; set; }
        public float WidthB1 { get; set; }
        public float WidthB1Limits { get; set; }
        public float WidthA2 { get; set; }
        public float WidthA2Limits { get; set; }
        public float WidthB2 { get; set; }
        public float WidthB2Limits { get; set; }

        public double GetCellLength1(double d, double l)
        {
            double result = l;
            try
            {
                if (CellLength1 != 0)
                {
                    if (CellLength1 > l)
                    {
                        result = l / Math.Cos(d);
                    }
                    else
                    {
                        result = l * Math.Cos(d);
                    }
                }
            }
            catch
            {

            }
            return result;
        }

        public double GetCellLength2(double d, double l)
        {
            double result = l;
            try
            {
                if (CellLength2 != 0)
                {
                    if (CellLength2 > l)
                    {
                        result = l / Math.Cos(d);
                    }
                    else
                    {
                        result = l * Math.Cos(d);
                    }
                }
            }
            catch
            {

            }
            return result;
        }

        public double GetWidthA1(double d, double w)
        {
            double result = w;
            try
            {
                if (WidthA1 != 0)
                {
                    if (WidthA1 > w)
                    {
                        result = w / Math.Cos(d);
                    }
                    else
                    {
                        result = w * Math.Cos(d);
                    }
                }
            }
            catch
            {

            }
            return result;
        }

        public double GetWidthB1(double d, double w)
        {
            double result = w;
            try
            {
                if (WidthB1 != 0)
                {
                    if (WidthB1 > w)
                    {
                        result = w / Math.Cos(d);
                    }
                    else
                    {
                        result = w * Math.Cos(d);
                    }
                }
            }
            catch
            {

            }
            return result;
        }

        public double GetWidthA2(double d, double w)
        {
            double result = w;
            try
            {
                if (WidthA2 != 0)
                {
                    if (WidthA2 > w)
                    {
                        result = w / Math.Cos(d);
                    }
                    else
                    {
                        result = w * Math.Cos(d);
                    }
                }
            }
            catch
            {

            }
            return result;
        }

        public double GetWidthB2(double d, double w)
        {
            double result = w;
            try
            {
                if (WidthB2 != 0)
                {
                    if (WidthB2 > w)
                    {
                        result = w / Math.Cos(d);
                    }
                    else
                    {
                        result = w * Math.Cos(d);
                    }
                }
            }
            catch
            {

            }
            return result;
        }
    }

    public class PointOffset
    {
        public float dX { get; set; }
        public float dY { get; set; }
        public float dAngle { get; set; }
    }

}
