using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCD_Framework.Models
{
    /// <summary>
    /// 文件路径
    /// </summary>
    public enum PathType
    {
        /// <summary>
        /// 绝对路径
        /// </summary>
        [Description("绝对路径")]
        Absolute,
        /// <summary>
        /// 相对路径
        /// </summary>
        [Description("相对路径")]
        Relative
    }
    /// <summary>
    /// 运行结果
    /// </summary>
    public enum RunResult
    {
        OK,
        NG
    }
    /// <summary>
    /// 运行模式
    /// </summary>
    public enum RunningMode
    {
        /// <summary>
        /// 拍照
        /// </summary>
        Photo,
        /// <summary>
        /// 本地上传
        /// </summary>
        Upload
    }
    /// <summary>
    /// 拍照模式
    /// </summary>
    public enum PhotoMode
    {
        /// <summary>
        /// 自动
        /// </summary>
        Auto,
        /// <summary>
        /// 手动
        /// </summary>
        Manual
    }


    public enum ImageNeedSave
    {
        SaveAllImage,
        SaveCorrectImage,
        SaveErrorImage,

    }

    public enum Language
    {
        EN_US,
        ZH_CN,
    }
}
