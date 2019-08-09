using CCD_Framework.Controls;
using Cognex.VisionPro;
using Cognex.VisionPro.ImageFile;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CCD_Framework.Helper
{
    public class ImageSaveHerper

    {
        private Queue ImageQueue;

        private Queue ImageQueueBMP;

        private Queue ImageNameQueue;

        private Queue ImageNameQueueBMP;

        private CogImageFileTool myImageFileForSave;

        private bool IsAddingImage;

        private bool IsNeedClose;

        private Thread mythreading;

        private ImageSave mySaveImageUI;

        private Bitmap myNeedSaveBMP;

        private string myNeedSaveBMPPath;

        private int sleeptime;

        private int ErrorTimes;

        private bool UseCognex;

        private bool TooFastSafeguard;

        public bool IsNeedSafeguard
        {
            get
            {
                return this.TooFastSafeguard;
            }
            set
            {
                this.TooFastSafeguard = value;
            }
        }

        public bool IsUseCognexdll
        {
            get
            {
                return this.UseCognex;
            }
            set
            {
                this.UseCognex = value;
            }
        }

        public int QueueCount
        {
            get
            {
                return checked(this.ImageQueue.Count + this.ImageQueueBMP.Count);
            }
        }

        public int SaveImageErrorTimes
        {
            get
            {
                return this.ErrorTimes;
            }
        }

        public int SaveImageTimeInterval
        {
            get
            {
                return this.sleeptime;
            }
            set
            {
                this.sleeptime = value;
            }
        }

        public ImageSave SaveImageUI
        {
            get
            {
                return this.mySaveImageUI;
            }
            set
            {
                this.mySaveImageUI = value;
            }
        }

        public ImageSaveHerper()
        {
            this.ImageQueue = new Queue();
            this.ImageQueueBMP = new Queue();
            this.ImageNameQueue = new Queue();
            this.ImageNameQueueBMP = new Queue();
            this.myImageFileForSave = new CogImageFileTool();
            this.IsAddingImage = false;
            this.IsNeedClose = false;
            this.mySaveImageUI = new ImageSave();
            this.sleeptime = 15;
            this.ErrorTimes = 0;
            this.UseCognex = true;
            this.TooFastSafeguard = false;
            ImageSaveHerper cCImageSave = this;
            this.mythreading = new Thread(new ThreadStart(cCImageSave.SaveImageQueue))
            {
                IsBackground = true,
                Priority = ThreadPriority.Lowest
            };
            this.mythreading.Start();
        }

        private void AddImageQueue(string Name, ICogImage image)
        {
            this.IsAddingImage = true;
            if (this.ImageQueue.Count < 15 | !this.TooFastSafeguard)
            {
                this.ImageQueue.Enqueue(image);
                this.ImageNameQueue.Enqueue(Name);
            }
            this.IsAddingImage = false;
        }

        private void AddImageQueue(string Name, Image image)
        {
            this.IsAddingImage = true;
            if (this.ImageQueueBMP.Count < 15 | !this.TooFastSafeguard)
            {
                this.ImageQueueBMP.Enqueue(image);
                this.ImageNameQueueBMP.Enqueue(Name);
            }
            this.IsAddingImage = false;
        }

        private void CreatDir(string str)
        {
            try
            {
                if (!Directory.Exists(str))
                {
                    Directory.CreateDirectory(str);
                }
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                ProjectData.ClearProjectError();
            }
        }

        private string GetAllPath(string Name, string Format)
        {
            int day;
            int month;
            int year;
            string[] str;
            string str1 = string.Concat(this.mySaveImageUI.ImageSavePathEdit, "\\");
            if (this.mySaveImageUI.AutoCreatDateFolder)
            {
                str = new string[] { str1, null, null, null, null, null, null };
                year = DateAndTime.Now.Year;
                str[1] = year.ToString();
                str[2] = "-";
                month = DateAndTime.Now.Month;
                str[3] = month.ToString();
                str[4] = "-";
                day = DateAndTime.Now.Day;
                str[5] = day.ToString();
                str[6] = "\\";
                str1 = string.Concat(str);
            }
            this.CreatDir(str1);
            string str2 = string.Concat(Name, ".", Format);
            if (this.mySaveImageUI.AutoUseTimeForFileName)
            {
                str = new string[] { DateAndTime.Now.Hour.ToString(), "-", null, null, null, null, null, null, null };
                day = DateAndTime.Now.Minute;
                str[2] = day.ToString();
                str[3] = "-";
                month = DateAndTime.Now.Second;
                str[4] = month.ToString();
                str[5] = "-";
                year = DateAndTime.Now.Millisecond;
                str[6] = year.ToString();
                str[7] = " ";
                str[8] = str2;
                str2 = string.Concat(str);
            }
            return string.Concat(str1, str2);
        }

        private bool IsDiskSpaceEnough(string path, long NeedSpace = 500000000L)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            DriveInfo[] driveInfoArray = drives;
            for (int i = 0; i < checked((int)driveInfoArray.Length); i = checked(i + 1))
            {
                DriveInfo driveInfo = driveInfoArray[i];
                if (path.StartsWith(driveInfo.Name))
                {
                    if (driveInfo.TotalFreeSpace < NeedSpace)
                    {
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }
        string deleteMark = string.Empty;
        public string SaveImage(ICogImage Image, string Name = " ")
        {
            this.UseCognex = !this.SaveImageUI.UseCognex;
            string allPath = "";
            if (!this.UseCognex)
            {
                Bitmap bitmap = (Bitmap)Image.ToBitmap().Clone();
                Rectangle rectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                Bitmap bitmap1 = bitmap.Clone(rectangle, PixelFormat.Format8bppIndexed);
                if (this.mySaveImageUI.ImageFormatJPG & this.IsDiskSpaceEnough(this.GetAllPath(Name, "jpg"), (long)500000000))
                {
                    this.AddImageQueue(this.GetAllPath(Name, "jpg"), bitmap1);
                    this.AddImageQueue(this.GetAllPath(Name, "jpg"), bitmap);
                    allPath = this.GetAllPath(Name, "jpg");
                }
                if (this.mySaveImageUI.ImageFormatBMP & this.IsDiskSpaceEnough(this.GetAllPath(Name, "bmp"), (long)500000000))
                {
                    this.AddImageQueue(this.GetAllPath(Name, "bmp"), bitmap1);
                    this.AddImageQueue(this.GetAllPath(Name, "bmp"), bitmap);
                    allPath = this.GetAllPath(Name, "bmp");
                }
            }
            else
            {
                if (this.mySaveImageUI.ImageFormatJPG & this.IsDiskSpaceEnough(this.GetAllPath(Name, "jpg"), (long)500000000))
                {
                    this.AddImageQueue(this.GetAllPath(Name, "jpg"), Image);
                    allPath = this.GetAllPath(Name, "jpg");
                }
                if (this.mySaveImageUI.ImageFormatBMP & this.IsDiskSpaceEnough(this.GetAllPath(Name, "bmp"), (long)500000000))
                {
                    this.AddImageQueue(this.GetAllPath(Name, "bmp"), Image);
                    allPath = this.GetAllPath(Name, "bmp");
                }
            }
            if (!this.IsDiskSpaceEnough(this.GetAllPath(Name, "bmp"), (long)500000000))
            {
                try
                {
                    var deletePath = Path.Combine(mySaveImageUI.ImageSavePathEdit, GetFirstDay(mySaveImageUI.ImageSavePathEdit));
                    if (Directory.Exists(deletePath))
                    {
                        Directory.Delete(deletePath, true);
                    };
                }
                catch (Exception ex)
                {

                }
                return "Err！磁盘空间不足，未保存图像 Image save Error,Disk free space is not enough";
            }
            if (deleteMark != DateTime.Now.ToString("yyMMdd"))
            {
                try
                {
                    var dayPaths = GetOverSevernDays(mySaveImageUI.ImageSavePathEdit);
                    dayPaths.ForEach(dayPath =>
                    {
                        var deletePath2 = Path.Combine(mySaveImageUI.ImageSavePathEdit, dayPath.Name);
                        if (Directory.Exists(deletePath2))
                        {
                            Directory.Delete(deletePath2, true);
                        };
                    });
                    deleteMark = DateTime.Now.ToString("yyMMdd");
                }
                catch (Exception ex)
                {

                }
            }
            return allPath;
        }
        public string GetFirstDay(string path)
        {
            var result = string.Empty;
            DirectoryInfo root = new DirectoryInfo(path);
            DirectoryInfo[] dics = root.GetDirectories();
            if (dics.Length > 0)
            {
                result = dics.FirstOrDefault(m => m.CreationTime == dics.Min(n => n.CreationTime)).Name;
            }
            return result;
        }

        public List<DirectoryInfo> GetOverSevernDays(string path)
        {
            List<DirectoryInfo> result = new List<DirectoryInfo>();
            DirectoryInfo root = new DirectoryInfo(path);
            DirectoryInfo[] dics = root.GetDirectories();
            if (dics.Length > 0)
            {
                result = dics.Where(m => m.CreationTime < DateTime.Now.AddDays(-7)).ToList();
            }
            return result;
        }
        public string SaveImage(Image Image, string Name = " ")
        {
            string allPath = "";
            if (this.mySaveImageUI.ImageFormatJPG & this.IsDiskSpaceEnough(this.GetAllPath(Name, "jpg"), (long)500000000))
            {
                this.AddImageQueue(this.GetAllPath(Name, "jpg"), Image);
                allPath = this.GetAllPath(Name, "jpg");
            }
            if (this.mySaveImageUI.ImageFormatBMP & this.IsDiskSpaceEnough(this.GetAllPath(Name, "bmp"), (long)500000000))
            {
                this.AddImageQueue(this.GetAllPath(Name, "bmp"), Image);
                allPath = this.GetAllPath(Name, "bmp");
            }
            if (!this.IsDiskSpaceEnough(this.GetAllPath(Name, "bmp"), (long)500000000))
            {
                return "Err！磁盘空间不足，未保存图像 Image save Error,Disk free space is not enough";
            }
            return allPath;
        }

        private void SaveImageQueue()
        {
            while (!this.IsNeedClose)
            {
                Thread.Sleep(1);
                try
                {
                    while (this.ImageQueue.Count > 0 & !this.IsAddingImage)
                    {
                        this.myImageFileForSave.InputImage = (ICogImage)this.ImageQueue.Dequeue();
                        this.myImageFileForSave.Operator.Open(Conversions.ToString(this.ImageNameQueue.Dequeue()), CogImageFileModeConstants.Write);
                        try
                        {
                            this.myImageFileForSave.Run();
                        }
                        catch (Exception exception)
                        {
                            ProjectData.SetProjectError(exception);
                            ProjectData.ClearProjectError();
                        }
                        Thread.Sleep(this.sleeptime);
                    }
                    while (this.ImageQueueBMP.Count > 0 & !this.IsAddingImage)
                    {
                        this.myNeedSaveBMP = (Bitmap)this.ImageQueueBMP.Dequeue();
                        this.myNeedSaveBMPPath = Conversions.ToString(this.ImageNameQueueBMP.Dequeue());
                        try
                        {
                            if (this.myNeedSaveBMPPath.EndsWith("bmp"))
                            {
                                this.myNeedSaveBMP.Save(this.myNeedSaveBMPPath, ImageFormat.Bmp);
                            }
                            else if (this.myNeedSaveBMPPath.EndsWith("jpg"))
                            {
                                this.myNeedSaveBMP.Save(this.myNeedSaveBMPPath, ImageFormat.Jpeg);
                            }
                        }
                        catch (Exception exception1)
                        {
                            ProjectData.SetProjectError(exception1);
                            ProjectData.ClearProjectError();
                        }
                        Thread.Sleep(this.sleeptime);
                    }
                }
                catch (Exception exception2)
                {
                    ProjectData.SetProjectError(exception2);
                    this.ErrorTimes = checked(this.ErrorTimes + 1);
                    ProjectData.ClearProjectError();
                }
            }
        }

        public void Shutdown()
        {
            this.IsNeedClose = true;
            this.mythreading.Abort();
        }
    }
}
