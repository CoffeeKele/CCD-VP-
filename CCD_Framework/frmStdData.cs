using CCD_Framework.Helper;
using CCD_Framework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CCD_Framework
{
    public partial class frmStdData : Form
    {
        List<ProdStdData> lProdStdData;
        iniHelper iniHelper = new iniHelper(Application.StartupPath + @"\Config.ini");

        bool IsAdd = false;
        public frmStdData()
        {
            InitializeComponent();
            rdoLeft.Checked = true;
            //LoadData();
            LoadXMLData();
            BindData();
        }
        private void LoadXMLData()
        {

            lProdStdData = new List<ProdStdData>();
            ProdStdData model = new ProdStdData();
            //将XML文件加载进来
            XDocument document = XDocument.Load(Path.Combine(Application.StartupPath, @"StdData.xml"));
            //获取到XML的根元素进行操作
            XElement root = document.Root;
            //获取根元素下的所有子元素
            IEnumerable<XElement> enumerable = root.Elements();
            foreach (XElement item in enumerable)
            {
                foreach (XElement item1 in item.Elements())
                {
                    if (item1.Name == "Code")
                    {
                        model.Code = item1.Value;

                    }
                    if (item1.Name == "Name")
                    {
                        model.Name = item1.Value;
                    }
                    if (item1.Name == "sMidPoint")
                    {
                        model.sMidPoint = item1.Value;
                    }
                    if (item1.Name == "Angle")
                    {
                        model.Angle = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "StDx")
                    {
                        model.StDx = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "StDy")
                    {
                        model.StDy = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "sMidPoint2")
                    {
                        model.sMidPoint2 = item1.Value;
                    }
                    if (item1.Name == "Angle2")
                    {
                        model.Angle2 = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "StDx2")
                    {
                        model.StDx2 = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "StDy2")
                    {
                        model.StDy2 = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "XOffsetAllowed")
                    {
                        model.XOffsetAllowed = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "YOffsetAllowed")
                    {
                        model.YOffsetAllowed = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "AngleOffsetAllowed")
                    {
                        model.AngleOffsetAllowed = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "YOffsetAllowed")
                    {
                        model.YOffsetAllowed = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "AngleOffsetAllowed")
                    {
                        model.AngleOffsetAllowed = (float)Convert.ToDecimal(item1.Value);
                    }

                    if (item1.Name == "CellLength1")
                    {
                        model.CellLength1 = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "CellLength1Limits")
                    {
                        model.CellLength1Limits = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "CellLength2")
                    {
                        model.CellLength2 = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "CellLength2Limits")
                    {
                        model.CellLength2Limits = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "WidthA1")
                    {
                        model.WidthA1 = (float)Convert.ToDecimal(item1.Value);
                    }

                    if (item1.Name == "WidthA1Limits")
                    {
                        model.WidthA1Limits = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "WidthB1")
                    {
                        model.WidthB1 = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "WidthB1Limits")
                    {
                        model.WidthB1Limits = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "WidthA2")
                    {
                        model.WidthA2 = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "WidthA2Limits")
                    {
                        model.WidthA2Limits = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "WidthB2")
                    {
                        model.WidthB2 = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "WidthB2Limits")
                    {
                        model.WidthB2Limits = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "Note")
                    {
                        model.Note = item1.Value;
                    }
                    if (model.sMidPoint != null)
                    {
                        model.MidPoint = new Models.Point();
                        if (model.sMidPoint.Split(',').Length > 1)
                        {
                            model.MidPoint.PointX = (float)Convert.ToDecimal(model.sMidPoint.Split(',')[0]);
                            model.MidPoint.PointY = (float)Convert.ToDecimal(model.sMidPoint.Split(',')[1]);
                        }
                    }
                    if (model.sMidPoint2 != null)
                    {
                        model.MidPoint2 = new Models.Point();
                        if (model.sMidPoint2.Split(',').Length > 1)
                        {
                            model.MidPoint2.PointX = (float)Convert.ToDecimal(model.sMidPoint2.Split(',')[0]);
                            model.MidPoint2.PointY = (float)Convert.ToDecimal(model.sMidPoint2.Split(',')[1]);
                        }
                    }

                }
                lProdStdData.Add(model);
                model = new ProdStdData();
            }

        }
        private void BindData()
        {
            dgvProdStdData.DataSource = lProdStdData;
            dgvProdStdData.Columns[18].Visible = false;
            dgvProdStdData.Columns[19].Visible = false;
            dgvProdStdData.Columns[20].Visible = false;
            dgvProdStdData.Columns[21].Visible = false;
            dgvProdStdData.Columns[22].Visible = false;
            dgvProdStdData.Columns[23].Visible = false;
            dgvProdStdData.Columns[24].Visible = false;
            dgvProdStdData.Columns[25].Visible = false;
            dgvProdStdData.Columns[26].Visible = false;
            dgvProdStdData.Columns[27].Visible = false;
            dgvProdStdData.Columns[28].Visible = false;
            dgvProdStdData.Columns[29].Visible = false;
            dgvProdStdData.Columns[30].Visible = false;
            dgvProdStdData.Columns[31].Visible = false;
            dgvProdStdData.Columns[4].HeaderText = LanguageHelper.GetString("fsd_PN");
            dgvProdStdData.Columns[5].HeaderText = LanguageHelper.GetString("fsd_Mid1");
            dgvProdStdData.Columns[6].HeaderText = LanguageHelper.GetString("fsd_Angle1");
            dgvProdStdData.Columns[9].HeaderText = LanguageHelper.GetString("fsd_Mid2");
            dgvProdStdData.Columns[10].HeaderText = LanguageHelper.GetString("fsd_Angle2");
            dgvProdStdData.Columns[0].HeaderText = LanguageHelper.GetString("btn_Edit");
            dgvProdStdData.Columns[1].HeaderText = LanguageHelper.GetString("btn_Delete");
            dgvProdStdData.Columns[2].HeaderText = LanguageHelper.GetString("btn_Copy");

            ((DataGridViewLinkColumn)dgvProdStdData.Columns[0]).Text = LanguageHelper.GetString("btn_Edit");
            ((DataGridViewLinkColumn)dgvProdStdData.Columns[1]).Text = LanguageHelper.GetString("btn_Delete");
            ((DataGridViewLinkColumn)dgvProdStdData.Columns[2]).Text = LanguageHelper.GetString("btn_Copy");

        }

        private void dgvProdStdData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;
            if (e.ColumnIndex == 0)
            {
                IsAdd = false;
                var prodStdData = (ProdStdData)dgvProdStdData.Rows[e.RowIndex].DataBoundItem;
                txtCode.Text = prodStdData.Code;
                txtName.Text = prodStdData.Name;
                txtMidPoint.Text = prodStdData.sMidPoint;
                txtAngle.Text = prodStdData.Angle.ToString();
                txtStDx.Text = prodStdData.StDx.ToString();
                txtStDy.Text = prodStdData.StDy.ToString();
                txtMidPoint2.Text = prodStdData.sMidPoint2;
                txtAngle2.Text = prodStdData.Angle2.ToString();
                txtStDx2.Text = prodStdData.StDx2.ToString();
                txtStDy2.Text = prodStdData.StDy2.ToString();
                txtXOffsetAllowed.Text = prodStdData.XOffsetAllowed.ToString();
                txtYOffsetAllowed.Text = prodStdData.YOffsetAllowed.ToString();
                txtAngleOffsetAllowed.Text = prodStdData.AngleOffsetAllowed.ToString();
                txtl1.Text = prodStdData.CellLength1.ToString();
                txtl1Offset.Text = prodStdData.CellLength1Limits.ToString();
                txtl2.Text = prodStdData.CellLength2.ToString();
                txtl2Offset.Text = prodStdData.CellLength2Limits.ToString();
                txtWidthA1.Text = prodStdData.WidthA1.ToString();
                txtWidthA1Offset.Text = prodStdData.WidthA1Limits.ToString();
                txtWidthB1.Text = prodStdData.WidthB1.ToString();
                txtWidthB1Offset.Text = prodStdData.WidthB1Limits.ToString();
                txtWidthA2.Text = prodStdData.WidthA2.ToString();
                txtWidthA2Offset.Text = prodStdData.WidthA2Limits.ToString();
                txtWidthB2.Text = prodStdData.WidthB2.ToString();
                txtWidthB2Offset.Text = prodStdData.WidthB2Limits.ToString();
                txtNote.Text = prodStdData.Note;
            }
            if (e.ColumnIndex == 1)
            {
                var prodStdData = (ProdStdData)dgvProdStdData.Rows[e.RowIndex].DataBoundItem;
                var currentCode = iniHelper.IniReadValue("SysSeting", "CurrentProductCode");
                if (currentCode == prodStdData.Code)
                {
                    MessageBox.Show(LanguageHelper.GetString("fsd_Msg1"), LanguageHelper.GetString("common_Info"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show(LanguageHelper.GetString("fsd_Msg2") + "\r\n" + LanguageHelper.GetString("fsd_Msg3"), LanguageHelper.GetString("common_Info"), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    xmlDelete(prodStdData.Code);
                    LoadXMLData();
                    BindData();
                }

            }
            if (e.ColumnIndex == 2)
            {

                if (MessageBox.Show(LanguageHelper.GetString("fsd_Msg4"), LanguageHelper.GetString("common_Info"), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    var prodStdData = (ProdStdData)dgvProdStdData.Rows[e.RowIndex].DataBoundItem;
                    txtMidPoint.Text = prodStdData.sMidPoint;
                    txtAngle.Text = prodStdData.Angle.ToString();
                    txtStDx.Text = prodStdData.StDx.ToString();
                    txtStDy.Text = prodStdData.StDy.ToString();
                    txtMidPoint2.Text = prodStdData.sMidPoint2;
                    txtAngle2.Text = prodStdData.Angle2.ToString();
                    txtStDx2.Text = prodStdData.StDx2.ToString();
                    txtStDy2.Text = prodStdData.StDy2.ToString();
                    txtAngleOffsetAllowed.Text = prodStdData.AngleOffsetAllowed.ToString();
                    txtXOffsetAllowed.Text = prodStdData.XOffsetAllowed.ToString();
                    txtYOffsetAllowed.Text = prodStdData.YOffsetAllowed.ToString();

                }

            }
        }

        private void dgvProdStdData_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvProdStdData_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show(LanguageHelper.GetString("fsd_Msg5"), LanguageHelper.GetString("common_Info"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bool result;
            CheckTextBoxMethodTwo(out result);
            if (result)
            {

                var prodStdData = new ProdStdData
                {
                    Code = txtCode.Text,
                    Name = txtName.Text,
                    sMidPoint = txtMidPoint.Text,
                    Angle = (float)Convert.ToDecimal(txtAngle.Text),
                    StDy = (float)Convert.ToDecimal(txtStDy.Text),
                    StDx = (float)Convert.ToDecimal(txtStDx.Text),
                    sMidPoint2 = txtMidPoint2.Text,
                    Angle2 = (float)Convert.ToDecimal(txtAngle2.Text),
                    StDy2 = (float)Convert.ToDecimal(txtStDy2.Text),
                    StDx2 = (float)Convert.ToDecimal(txtStDx2.Text),
                    XOffsetAllowed = (float)Convert.ToDecimal(txtXOffsetAllowed.Text),
                    YOffsetAllowed = (float)Convert.ToDecimal(txtYOffsetAllowed.Text),
                    AngleOffsetAllowed = (float)Convert.ToDecimal(txtAngleOffsetAllowed.Text),
                    CellLength1 = (float)Convert.ToDecimal(txtl1.Text),
                    CellLength1Limits = (float)Convert.ToDecimal(txtl1Offset.Text),
                    CellLength2 = (float)Convert.ToDecimal(txtl2.Text),
                    CellLength2Limits = (float)Convert.ToDecimal(txtl2Offset.Text),
                    WidthA1 = (float)Convert.ToDecimal(txtWidthA1.Text),
                    WidthA1Limits = (float)Convert.ToDecimal(txtWidthA1Offset.Text),
                    WidthB1 = (float)Convert.ToDecimal(txtWidthB1.Text),
                    WidthB1Limits = (float)Convert.ToDecimal(txtWidthB1Offset.Text),
                    WidthA2 = (float)Convert.ToDecimal(txtWidthA2.Text),
                    WidthA2Limits = (float)Convert.ToDecimal(txtWidthA2Offset.Text),
                    WidthB2 = (float)Convert.ToDecimal(txtWidthB2.Text),
                    WidthB2Limits = (float)Convert.ToDecimal(txtWidthB2Offset.Text),
                    Note = txtNote.Text,
                };
                if (IsAdd)
                {
                    if (lProdStdData.Where(m => m.Code == txtCode.Text).Count() > 0)
                        xmlEdit(prodStdData);
                    else
                        xmlAdd(prodStdData);

                }
                else xmlEdit(prodStdData);
                LoadXMLData();
                BindData();
                MessageBox.Show(LanguageHelper.GetString("common_SaveSuccess"));
            }
        }

        private void CheckTextBoxMethodOne(out ProdStdData prodStdData, out bool result)
        {
            prodStdData = new ProdStdData() { };
            result = true;
            float angle;
            if (CheckNum(txtAngle.Text, out angle))
            {
                prodStdData.Angle = angle;
            }
            else
            {
                txtAngle.BackColor = Color.LightCoral;
                result = false;
            }

            float angleOffsetAllowed;
            if (CheckNum(txtAngleOffsetAllowed.Text, out angleOffsetAllowed))
            {
                prodStdData.AngleOffsetAllowed = angleOffsetAllowed;
            }
            else
            {
                txtAngleOffsetAllowed.BackColor = Color.LightCoral;
                result = false;
            }

            float xOffsetAllowed;
            if (CheckNum(txtXOffsetAllowed.Text, out xOffsetAllowed))
            {
                prodStdData.XOffsetAllowed = xOffsetAllowed;
            }
            else
            {
                txtXOffsetAllowed.BackColor = Color.LightCoral;
                result = false;
            }

            float yOffsetAllowed;
            if (CheckNum(txtYOffsetAllowed.Text, out yOffsetAllowed))
            {
                prodStdData.YOffsetAllowed = yOffsetAllowed;
            }
            else
            {
                txtYOffsetAllowed.BackColor = Color.LightCoral;
                result = false;
            }

            float cellLength1;
            if (CheckNum(txtl1.Text, out cellLength1))
            {
                prodStdData.CellLength1 = cellLength1;
            }
            else
            {
                txtl1.BackColor = Color.LightCoral;
                result = false;
            }

            float cellLength1Limits;
            if (CheckNum(txtl1Offset.Text, out cellLength1Limits))
            {
                prodStdData.CellLength1Limits = cellLength1Limits;
            }
            else
            {
                txtl1Offset.BackColor = Color.LightCoral;
                result = false;
            }

            float cellLength2;
            if (CheckNum(txtl2.Text, out cellLength2))
            {
                prodStdData.CellLength2 = cellLength2;
            }
            else
            {
                txtl2.BackColor = Color.LightCoral;
                result = false;
            }

            float cellLength2Limits;
            if (CheckNum(txtl2Offset.Text, out cellLength2Limits))
            {
                prodStdData.CellLength2Limits = cellLength2Limits;
            }
            else
            {
                txtl2Offset.BackColor = Color.LightCoral;
                result = false;
            }

            float WidthA1;
            if (CheckNum(txtWidthA1.Text, out WidthA1))
            {
                prodStdData.WidthA1 = WidthA1;
            }
            else
            {
                txtWidthA1.BackColor = Color.LightCoral;
                result = false;
            }
            float WidthA1Limits;
            if (CheckNum(txtWidthA1Offset.Text, out WidthA1Limits))
            {
                prodStdData.WidthA1Limits = WidthA1Limits;
            }
            else
            {
                txtWidthA1Offset.BackColor = Color.LightCoral;
                result = false;
            }
            float WidthB1;
            if (CheckNum(txtWidthB1.Text, out WidthB1))
            {
                prodStdData.WidthB1 = WidthB1;
            }
            else
            {
                txtWidthB1.BackColor = Color.LightCoral;
                result = false;
            }
            float WidthB1Limits;
            if (CheckNum(txtWidthB1Offset.Text, out WidthB1Limits))
            {
                prodStdData.WidthB1Limits = WidthB1Limits;
            }
            else
            {
                txtWidthB1Offset.BackColor = Color.LightCoral;
                result = false;
            }
            float WidthA2;
            if (CheckNum(txtWidthA2.Text, out WidthA2))
            {
                prodStdData.WidthA2 = WidthA2;
            }
            else
            {
                txtWidthA2.BackColor = Color.LightCoral;
                result = false;
            }
            float WidthA2Limits;
            if (CheckNum(txtWidthA2Offset.Text, out WidthA2Limits))
            {
                prodStdData.WidthA2Limits = WidthA2Limits;
            }
            else
            {
                txtWidthA2Offset.BackColor = Color.LightCoral;
                result = false;
            }
            float WidthB2;
            if (CheckNum(txtWidthB2.Text, out WidthB2))
            {
                prodStdData.WidthB2 = WidthB2;
            }
            else
            {
                txtWidthB2.BackColor = Color.LightCoral;
                result = false;
            }

            float WidthB2Limits;
            if (CheckNum(txtWidthB2Offset.Text, out WidthB2Limits))
            {
                prodStdData.WidthB2Limits = WidthB2Limits;
            }
            else
            {
                txtWidthB2Offset.BackColor = Color.LightCoral;
                result = false;
            }
            float X, Y;
            if (CheckPoint(txtMidPoint.Text, out X, out Y))
            {
                prodStdData.MidPoint = new Models.Point();
                prodStdData.MidPoint.PointX = X;
                prodStdData.MidPoint.PointY = Y;
                prodStdData.sMidPoint = txtMidPoint.Text;
            }
            else
            {
                txtMidPoint.BackColor = Color.LightCoral;
                result = false;
            }
        }
        private void CheckTextBoxMethodTwo(out bool result)
        {
            result = true;
            if (!CheckNum(txtAngle.Text))
            {
                txtAngle.BackColor = Color.LightCoral;
                result = false;
            }
            if (!CheckNum(txtAngleOffsetAllowed.Text))
            {
                txtAngleOffsetAllowed.BackColor = Color.LightCoral;
                result = false;
            }
            if (!CheckNum(txtXOffsetAllowed.Text))
            {
                txtXOffsetAllowed.BackColor = Color.LightCoral;
                result = false;
            }
            if (!CheckNum(txtYOffsetAllowed.Text))
            {
                txtYOffsetAllowed.BackColor = Color.LightCoral;
                result = false;
            }

            if (!CheckNum(txtl1.Text))
            {
                txtl1.BackColor = Color.LightCoral;
                result = false;
            }
            if (!CheckNum(txtl1Offset.Text))
            {
                txtl1Offset.BackColor = Color.LightCoral;
                result = false;
            }
            if (!CheckNum(txtl2.Text))
            {
                txtl2.BackColor = Color.LightCoral;
                result = false;
            }
            if (!CheckNum(txtl2Offset.Text))
            {
                txtl2Offset.BackColor = Color.LightCoral;
                result = false;
            }
            if (!CheckNum(txtWidthA1.Text))
            {
                txtWidthA1.BackColor = Color.LightCoral;
                result = false;
            }
            if (!CheckNum(txtWidthA1Offset.Text))
            {
                txtWidthA1Offset.BackColor = Color.LightCoral;
                result = false;
            }
            if (!CheckNum(txtWidthA2.Text))
            {
                txtWidthA2.BackColor = Color.LightCoral;
                result = false;
            }
            if (!CheckNum(txtWidthA2Offset.Text))
            {
                txtWidthA2Offset.BackColor = Color.LightCoral;
                result = false;
            }
            if (!CheckNum(txtWidthB1.Text))
            {
                txtWidthB1.BackColor = Color.LightCoral;
                result = false;
            }
            if (!CheckNum(txtWidthB1Offset.Text))
            {
                txtWidthB1Offset.BackColor = Color.LightCoral;
                result = false;
            }
            if (!CheckNum(txtWidthB2.Text))
            {
                txtWidthB2.BackColor = Color.LightCoral;
                result = false;
            }
            if (!CheckNum(txtWidthB2Offset.Text))
            {
                txtWidthB2Offset.BackColor = Color.LightCoral;
                result = false;
            }
            if (!CheckPoint(txtMidPoint.Text))
            {
                txtMidPoint.BackColor = Color.LightCoral;
                result = false;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            txtCode.Text = string.Empty;
            txtName.Text = string.Empty;
            txtMidPoint.Text = string.Empty;
            txtAngle.Text = string.Empty;
            txtMidPoint2.Text = string.Empty;
            txtAngle2.Text = string.Empty;
            txtXOffsetAllowed.Text = string.Empty;
            txtYOffsetAllowed.Text = string.Empty;
            txtAngleOffsetAllowed.Text = string.Empty;
            txtStDx.Text = string.Empty;
            txtAngle.Text = string.Empty;
            txtStDx2.Text = string.Empty;
            txtAngle2.Text = string.Empty;
            txtNote.Text = string.Empty;
            txtl1.Text = string.Empty;
            txtl1Offset.Text = string.Empty;
            txtl2.Text = string.Empty;
            txtl2Offset.Text = string.Empty;
            txtWidthA1.Text = string.Empty;
            txtWidthA1Offset.Text = string.Empty;
            txtWidthB1.Text = string.Empty;
            txtWidthB1Offset.Text = string.Empty;
            txtWidthA2.Text = string.Empty;
            txtWidthA2Offset.Text = string.Empty;
            txtWidthB2.Text = string.Empty;
            txtWidthB2Offset.Text = string.Empty;
            txtCode.BackColor = Color.White;
            txtName.BackColor = Color.White;
            txtMidPoint.BackColor = Color.White;
            txtAngle.BackColor = Color.White;
            txtXOffsetAllowed.BackColor = Color.White;
            txtYOffsetAllowed.BackColor = Color.White;
            txtAngleOffsetAllowed.BackColor = Color.White;
            txtl1.BackColor = Color.White;
            txtl1Offset.BackColor = Color.White;
            txtl2.BackColor = Color.White;
            txtl2Offset.BackColor = Color.White;
            txtWidthA1.BackColor = Color.White;
            txtWidthA1Offset.BackColor = Color.White;
            txtWidthB1.BackColor = Color.White;
            txtWidthB1Offset.BackColor = Color.White;
            txtWidthA2.BackColor = Color.White;
            txtWidthA2Offset.BackColor = Color.White;
            txtWidthB2.BackColor = Color.White;
            txtWidthB2Offset.BackColor = Color.White;
        }

        private bool CheckNum(string inputVal)
        {
            var result = true;
            try
            {
                var outputVal = (float)Convert.ToDouble(inputVal);
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
        private bool CheckNum(string inputVal, out float outputVal)
        {
            var result = true;
            outputVal = 0;
            try
            {
                outputVal = (float)Convert.ToDouble(inputVal);
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
        private bool CheckPoint(string inputVal)
        {
            var result = true;
            try
            {
                if (inputVal.Split(',').Count() == 2)
                {
                    var outputXVal = (float)Convert.ToDouble(inputVal.Split(',')[0]);
                    var outputYVal = (float)Convert.ToDouble(inputVal.Split(',')[1]);
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
        private bool CheckPoint(string inputVal, out float outputXVal, out float outputYVal)
        {
            var result = true;
            outputXVal = 0;
            outputYVal = 0;
            try
            {
                if (inputVal.Split(',').Count() == 2)
                {
                    outputXVal = (float)Convert.ToDouble(inputVal.Split(',')[0]);
                    outputYVal = (float)Convert.ToDouble(inputVal.Split(',')[1]);
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        private void txtMidPoint_TextChanged(object sender, EventArgs e)
        {
            TextChanged(sender);
        }

        private void txtAngle_TextChanged(object sender, EventArgs e)
        {
            TextChanged(sender);
        }

        private void txtXOffsetAllowed_TextChanged(object sender, EventArgs e)
        {
            TextChanged(sender);
        }

        private void txtYOffsetAllowed_TextChanged(object sender, EventArgs e)
        {
            TextChanged(sender);
        }

        private void txtAngleOffsetAllowed_TextChanged(object sender, EventArgs e)
        {
            TextChanged(sender);
        }

        private new void TextChanged(object sender)
        {
            var txtBox = (TextBox)sender;
            if (txtBox.BackColor == Color.LightCoral)
            {
                if (txtBox.Name == "txtMidPoint")
                {
                    if (CheckPoint(txtBox.Text))
                    {
                        txtBox.BackColor = Color.White;
                    }
                }
                else
                {
                    if (CheckNum(txtBox.Text))
                    {
                        txtBox.BackColor = Color.White;
                    }
                }
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            IsAdd = true;
            Reset();
            var CodeMaxNum = 0;
            if (lProdStdData != null)
            {
                lProdStdData.ForEach(p =>
                {
                    var CodeNum = Convert.ToInt32(p.Code);
                    if (CodeNum > CodeMaxNum)
                    {
                        CodeMaxNum = CodeNum;
                    }
                });
            }
            txtCode.Text = (++CodeMaxNum).ToString("000");
        }

        private string xmlPath = @"StdData.xml";
        private void xmlAdd(ProdStdData item)
        {
            XElement xe = XElement.Load(xmlPath);
            XElement record = new XElement(
                new XElement("ProdStdData", new XAttribute("Guid", Guid.NewGuid()), new XAttribute("Date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                new XElement("Code", item.Code),
                new XElement("Name", item.Name),
                new XElement("sMidPoint", item.sMidPoint),
                new XElement("Angle", item.Angle),
                new XElement("sMidPoint2", item.sMidPoint2),
                new XElement("Angle2", item.Angle2),
                new XElement("XOffsetAllowed", item.XOffsetAllowed),
                new XElement("YOffsetAllowed", item.YOffsetAllowed),
                new XElement("CellLength1", item.CellLength1),
                new XElement("CellLength1Limits", item.CellLength1Limits),
                new XElement("CellLength2", item.CellLength2),
                new XElement("CellLength2Limits", item.CellLength2Limits),
                new XElement("WidthA1", item.WidthA1),
                new XElement("WidthA1Limits", item.WidthA1Limits),
                new XElement("WidthB1", item.WidthB1),
                new XElement("WidthB1Limits", item.WidthB1Limits),
                new XElement("WidthA2", item.WidthA2),
                new XElement("WidthA2Limits", item.WidthA2Limits),
                new XElement("WidthB2", item.WidthB2),
                new XElement("WidthB2Limits", item.WidthB2Limits),
                new XElement("Note", item.Note),
                new XElement("AngleOffsetAllowed", item.AngleOffsetAllowed)));
            xe.Add(record);
            xe.Save(xmlPath);

        }

        private void xmlDelete(string code)
        {
            var path = Path.Combine(Application.StartupPath, @"TBInspectionVpp\" + code);
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
            XElement xe = XElement.Load(xmlPath);
            IEnumerable<XElement> elements = from ele in xe.Elements("ProdStdData")
                                             where (string)ele.Element("Code").Value == code
                                             select ele;
            {
                if (elements.Count() > 0)
                    elements.First().Remove();
            }
            //Process[] pcs = Process.GetProcesses();
            //var path = Path.Combine(Application.StartupPath, xmlPath);

            xe.Save(xmlPath);

        }

        private void xmlEdit(ProdStdData item)
        {
            XElement xe = XElement.Load(xmlPath);
            IEnumerable<XElement> element = from ele in xe.Elements("ProdStdData")
                                            where ele.Element("Code").Value == item.Code
                                            select ele;
            if (element.Count() > 0)
            {
                XElement first = element.First();
                ///设置新的属性
                first.SetAttributeValue("Date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                ///替换新的节点
                first.ReplaceNodes(new XElement("Code", item.Code),
                                   new XElement("Name", item.Name),
                                   new XElement("sMidPoint", item.sMidPoint),
                                   new XElement("Angle", item.Angle),
                                   new XElement("StDx", item.StDx),
                                   new XElement("StDy", item.StDy),
                                   new XElement("sMidPoint2", item.sMidPoint2),
                                   new XElement("Angle2", item.Angle2),
                                   new XElement("StDx2", item.StDx2),
                                   new XElement("StDy2", item.StDy2),
                                   new XElement("XOffsetAllowed", item.XOffsetAllowed),
                                   new XElement("YOffsetAllowed", item.YOffsetAllowed),
                                   new XElement("CellLength1", item.CellLength1),
                                   new XElement("CellLength1Limits", item.CellLength1Limits),
                                   new XElement("CellLength2", item.CellLength2),
                                   new XElement("CellLength2Limits", item.CellLength2Limits),
                                   new XElement("WidthA1", item.WidthA1),
                                   new XElement("WidthA1Limits", item.WidthA1Limits),
                                   new XElement("WidthB1", item.WidthB1),
                                   new XElement("WidthB1Limits", item.WidthB1Limits),
                                   new XElement("WidthA2", item.WidthA2),
                                   new XElement("WidthA2Limits", item.WidthA2Limits),
                                   new XElement("WidthB2", item.WidthB2),
                                   new XElement("WidthB2Limits", item.WidthB2Limits),
                                   new XElement("Note", item.Note),
                                   new XElement("AngleOffsetAllowed", item.AngleOffsetAllowed));
            }
            xe.Save(xmlPath);

        }

        private IEnumerable<XElement> xmlLoadData()
        {
            XElement xe = XElement.Load(xmlPath);
            IEnumerable<XElement> elements = from ele in xe.Elements("ProdStdData")
                                             select ele;
            return elements;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                var Mdx = Convert.ToDouble(txtXOffset.Text);
                var Mdy = Convert.ToDouble(txtYOffset.Text);
                var a = Convert.ToDouble(txtAngleOffset.Text) * Math.PI / 180;
                //StDx = -0.5*(Mdx*(cos(a)-1)+Mdy*sin(a)) / (1-cos(a))
                var StDx = -0.5 * (Mdx * (Math.Cos(a) - 1) + Mdy * Math.Sin(a)) / (1 - Math.Cos(a));
                //StDy = 0.5*(Mdx*sin(a)-Mdy*(cos(a)-1))/(1-cos(a))
                var StDy = 0.5 * (Mdx * Math.Sin(a) - Mdy * (Math.Cos(a) - 1)) / (1 - Math.Cos(a));
                if (rdoLeft.Checked)
                {

                    txtStDx.Text = StDx.ToString();
                    txtStDy.Text = StDy.ToString();
                }
                else if (rdoRight.Checked)
                {
                    txtStDx2.Text = StDx.ToString();
                    txtStDy2.Text = StDy.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(LanguageHelper.GetString("fsd_Msg6"));
            }


        }

        private void frmStdData_Load(object sender, EventArgs e)
        {
            this.Text = LanguageHelper.GetString("fsd_Text");
            label1.Text = LanguageHelper.GetString("fsd_PN");
            label3.Text = LanguageHelper.GetString("fsd_Mid1");
            label4.Text = LanguageHelper.GetString("fsd_Angle1");
            label14.Text = LanguageHelper.GetString("fsd_Mid2");
            label13.Text = LanguageHelper.GetString("fsd_Angle2");
            label7.Text = LanguageHelper.GetString("fsd_AL");
            label5.Text = LanguageHelper.GetString("fsd_XDL");
            label6.Text = LanguageHelper.GetString("fsd_YDL");
            label17.Text = LanguageHelper.GetString("fsd_Note");
            groupBox1.Text = "StDx,StDy " + LanguageHelper.GetString("btn_Calculation");
            rdoLeft.Text = LanguageHelper.GetString("fsd_Constant") + "1";
            rdoRight.Text = LanguageHelper.GetString("fsd_Constant") + "2";
            label11.Text = LanguageHelper.GetString("fsd_XDC");
            label10.Text = LanguageHelper.GetString("fsd_YDC");
            label12.Text = LanguageHelper.GetString("fsd_CRA");
            label18.Text = LanguageHelper.GetString("fsd_CL") + "1";
            label19.Text = LanguageHelper.GetString("fsd_CL") + "1 " + LanguageHelper.GetString("fsd_Lt");
            label20.Text = LanguageHelper.GetString("fsd_CL") + "2";
            label24.Text = LanguageHelper.GetString("fsd_CL") + "2 " + LanguageHelper.GetString("fsd_Lt");
            label22.Text = "WidthA1 " + LanguageHelper.GetString("fsd_Lt");
            label26.Text = "WidthA2 " + LanguageHelper.GetString("fsd_Lt");
            label28.Text = "WidthB1 " + LanguageHelper.GetString("fsd_Lt");
            label29.Text = "WidthB2 " + LanguageHelper.GetString("fsd_Lt");
            btnSave.Text = LanguageHelper.GetString("btn_Save");
            btnReset.Text = LanguageHelper.GetString("btn_Reset");
            btnCalculate.Text = LanguageHelper.GetString("btn_Calculation");

            if (LanguageHelper.CurrenLan == Language.EN_US)
            {
                this.btnCalculate.Width = 74 + 20;

                var x = 40;
                txtCode.Left = 90 + x;
                txtStDx.Left = 90 + x;
                txtStDx2.Left = 90 + x;
                txtYOffsetAllowed.Left = 90 + x;
                txtl2Offset.Left = 90 + x;
                txtWidthB1Offset.Left = 90 + x;
                txtWidthB2Offset.Left = 90 + x;

                x = 40;
                label1.Left = 266 + x;
                label8.Left = 266 + x;
                label15.Left = 266 + x;
                label17.Left = 266 + x;
                label18.Left = 266 + x;
                label21.Left = 266 + x;
                label25.Left = 266 + x;

                x = 40;
                txtName.Left = 353 + x;
                txtStDy.Left = 353 + x;
                txtStDy2.Left = 353 + x;
                txtNote.Left = 353 + x;
                txtl1.Left = 353 + x;
                txtWidthA1.Left = 353 + x;
                txtWidthA2.Left = 353 + x;

                x = 20;
                label3.Left = 545 + x;
                label14.Left = 545 + x;
                label7.Left = 545 + x;
                label19.Left = 545 + x;
                label22.Left = 545 + x;
                label26.Left = 545 + x;

                x = 100;
                txtMidPoint.Left = 616 + x;
                txtMidPoint2.Left = 616 + x;
                txtAngleOffsetAllowed.Left = 616 + x;
                txtl1Offset.Left = 616 + x;
                txtWidthA1Offset.Left = 616 + x;
                txtWidthA2Offset.Left = 616 + x;

                x = 80;
                label4.Left = 813 + x;
                label13.Left = 813 + x;
                label5.Left = 813 + x;
                label20.Left = 813 + x;
                label23.Left = 813 + x;
                label27.Left = 813 + x;

                x = 120;
                txtAngle.Left = 879 + x;
                txtAngle2.Left = 879 + x;
                txtXOffsetAllowed.Left = 879 + x;
                txtl2.Left = 879 + x;
                txtWidthB1.Left = 879 + x;
                txtWidthB2.Left = 879 + x;

                this.Width = 1063 + 120;
                txtNote.Width = 678 + 80;
                btnSave.Left = 854 + 120;
                btnReset.Left = 948 + 120;
                btnReset.Width = 76 + 2;
                groupBox1.Width = 1017 + 120;
                rdoRight.Left = 76 + 30;
                txtXOffset.Left = 124 + 50;
                label10.Left = 300 + 40;
                txtYOffset.Left = 415 + 90;
                label12.Left = 604 + 70;
                txtAngleOffset.Left = 688 + 130;
                btnCalculate.Left = 879 + 110;
                btnCalculate.Width = 74 + 46;

            }
            else if (LanguageHelper.CurrenLan == Language.ZH_CN)
            {
                this.btnCalculate.Width = 74;
                txtCode.Left = 90;
                txtStDx.Left = 90;
                txtStDx2.Left = 90;
                txtYOffsetAllowed.Left = 90;

                label1.Left = 266;
                label8.Left = 266;
                label15.Left = 266;
                label17.Left = 266;

                txtName.Left = 353;
                txtStDy.Left = 353;
                txtStDy2.Left = 353;
                txtNote.Left = 353;

                label3.Left = 530;
                label14.Left = 530;
                label7.Left = 530;

                txtMidPoint.Left = 616;
                txtMidPoint2.Left = 616;
                txtAngleOffsetAllowed.Left = 616;

                label4.Left = 813;
                label13.Left = 813;
                label5.Left = 813;

                txtAngle.Left = 879;
                txtAngle2.Left = 879;
                txtXOffsetAllowed.Left = 879;

                this.Width = 1063;
                txtNote.Width = 678;
                btnSave.Left = 854;
                btnReset.Left = 948;
                btnReset.Width = 76;
                groupBox1.Width = 1017;
                rdoRight.Left = 76;
                txtXOffset.Left = 124;
                label10.Left = 300;
                txtYOffset.Left = 415;
                label12.Left = 604;
                txtAngleOffset.Left = 688;
                btnCalculate.Left = 879;
                btnCalculate.Width = 74;
            }
        }
    }
}
