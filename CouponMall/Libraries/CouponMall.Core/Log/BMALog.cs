using System;
using System.IO;

namespace CouponMall.Core
{
    /// <summary>
    /// CouponMall日志管理类
    /// </summary>
    public class BMALog
    {
        private static ILogStrategy _ilogstrategy = null;//日志策略

        static BMALog()
        {
            try
            {
                string[] fileNameList = Directory.GetFiles(System.Web.HttpRuntime.BinDirectory, "CouponMall.LogStrategy.*.dll", SearchOption.TopDirectoryOnly);
                _ilogstrategy = (ILogStrategy)Activator.CreateInstance(Type.GetType(string.Format("CouponMall.LogStrategy.{0}.LogStrategy, CouponMall.LogStrategy.{0}", fileNameList[0].Substring(fileNameList[0].IndexOf("LogStrategy.") + 12).Replace(".dll", "")),
                                                                                    false,
                                                                                    true));
            }
            catch
            {
                throw new BMAException("创建'日志策略对象'失败,可能存在的原因:未将'日志策略程序集'添加到bin目录中;'日志策略程序集'文件名不符合'CouponMall.LogStrategy.{策略名称}.dll'格式");
            }
        }

        /// <summary>
        /// 日志策略实例
        /// </summary>
        public static ILogStrategy Instance
        {
            get { return _ilogstrategy; }
        }
    }
}
