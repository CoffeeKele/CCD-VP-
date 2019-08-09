using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;

namespace CCD_Framework.Helper
{
    public class AppLock
    {


        [DllImport("Rockey2.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern void RY2_Close(int handle);

        [DllImport("Rockey2.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern int RY2_Find();

        [DllImport("Rockey2.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern int RY2_Open(int mode, int uid, ref int hid);

        [DllImport("Rockey2.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern int RY2_Read(int handle, int block_index, ref string buffer512);

        private int block_index;

        private int retcode;

        private int handle_Renamed;

        private int uid;

        private int hid;

        public const short AUTO_MODE = 0;

        public AppLock()
        {
        }

        public int CheckAppLock(int id)
        {
            int CheckAppLock;
            this.uid = id;
            this.retcode = AppLock.RY2_Find();
            if (this.retcode < 0)
            {
                CheckAppLock = 0;
                Interaction.MsgBox("加密设备错误", MsgBoxStyle.OkOnly, null);
            }
            else if (this.retcode != 0)
            {
                this.retcode = AppLock.RY2_Open(1, this.uid, ref this.hid);
                if (this.retcode >= 0)
                {
                    this.handle_Renamed = this.retcode;
                    this.block_index = 0;
                    string buffer = new string('\0', 512);
                    this.retcode = AppLock.RY2_Read(this.handle_Renamed, this.block_index, ref buffer);
                    string tempBuf = new string('\0', 512);
                    AppLock.RY2_Read(this.handle_Renamed, 1, ref tempBuf);
                    if (this.retcode >= 0)
                    {
                        string code = "SCCP";
                        tempBuf = Strings.Mid(buffer, 1, code.Length);
                        if (string.Compare(tempBuf, code) != 0)
                        {
                            Interaction.MsgBox("加密设备型号不匹配", MsgBoxStyle.OkOnly, null);
                        }
                        AppLock.RY2_Close(this.handle_Renamed);
                        CheckAppLock = 1;
                    }
                    else
                    {
                        CheckAppLock = 0;
                        Interaction.MsgBox("加密设备错误", MsgBoxStyle.OkOnly, null);
                    }
                }
                else
                {
                    CheckAppLock = 0;
                    Interaction.MsgBox("加密设备错误", MsgBoxStyle.OkOnly, null);
                }
            }
            else
            {
                CheckAppLock = 0;
                Interaction.MsgBox("未检测到加密设备", MsgBoxStyle.OkOnly, null);
            }
            return CheckAppLock;
        }

    }
}