using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCD_Framework
{
    public partial class frmCalculate : Form
    {
        public frmCalculate()
        {
            InitializeComponent();
        }

        public class CCD
        {
            ///工作距离-物距（mm）=镜头焦距大小(mm)*(1+视野宽边长度（mm)/CCD宽边尺寸（mm）)


            //镜头焦距大小(mm)
            private double focalDistance;
            //CCD宽边尺寸（mm）
            private double width;
            //视野宽边长度（mm)
            private View view;
            //物距（mm）
            private double physicalDistance;

            public double FocalDistance
            {
                get
                {
                    return focalDistance;
                }
                set
                {
                    focalDistance = value;
                }

            }
            public double Width
            {
                get
                {
                    return width;
                }
                set
                {
                    width = value;
                }
            }
            public View View
            {
                get
                {
                    return view;
                }
                set
                {
                    view = value;
                }
            }
            public double PhysicalDistance
            {
                get
                {
                    return physicalDistance;
                }
                set
                {
                    physicalDistance = value;
                }
            }

            public double CalfocalDistance()
            {
                if (width != 0)
                    focalDistance = physicalDistance / (1 + view.Width / width);
                return focalDistance;

            }
            public double CalphysicalDistance()
            {
                if (width != 0)
                    physicalDistance = focalDistance * (1 + view.Width / width);
                return physicalDistance;
            }


        }
        public class View
        {
            public double Length { get; set; }
            public double Width { get; set; }
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            CCD ccdCalculate = new CCD();
            ccdCalculate.FocalDistance = Convert.ToDouble(textBox1.Text);
            ccdCalculate.Width = Convert.ToDouble(textBox2.Text);
            View view = new View();
            view.Width= Convert.ToDouble(textBox3.Text);
            ccdCalculate.View = view;
            textBox4.Text=ccdCalculate.CalphysicalDistance().ToString();
            //ccdCalculate.PhysicalDistance = Convert.ToDouble(textBox4.Text);

        }
    }
}
