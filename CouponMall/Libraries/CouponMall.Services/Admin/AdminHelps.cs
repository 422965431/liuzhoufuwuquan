﻿using System;

using CouponMall.Core;

namespace CouponMall.Services
{
    /// <summary>
    /// 后台帮助操作管理类
    /// </summary>
    public partial class AdminHelps : Helps
    {
        /// <summary>
        /// 创建帮助
        /// </summary>
        public static void CreateHelp(HelpInfo helpInfo)
        {
            CouponMall.Data.Helps.CreateHelp(helpInfo);
            CouponMall.Core.BMACache.Remove(CacheKeys.MALL_HELP_LIST);
        }

        /// <summary>
        /// 删除帮助
        /// </summary>
        /// <param name="id">帮助id</param>
        /// <returns>0代表删除失败，1代表删除成功，-1代表此分类下还存在子分类</returns>
        public static int DeleteHelpById(int id)
        {
            HelpInfo helpInfo = GetHelpById(id);
            if (helpInfo != null)
            {
                if (helpInfo.Pid == 0 && GetChildHelpCount(id) > 0)
                    return -1;

                CouponMall.Data.Helps.DeleteHelpById(id);
                CouponMall.Core.BMACache.Remove(CacheKeys.MALL_HELP_LIST);
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// 更新帮助
        /// </summary>
        public static void UpdateHelp(HelpInfo helpInfo)
        {
            CouponMall.Data.Helps.UpdateHelp(helpInfo);
            CouponMall.Core.BMACache.Remove(CacheKeys.MALL_HELP_LIST);
        }

        /// <summary>
        /// 更新帮助排序
        /// </summary>
        /// <param name="id">帮助id</param>
        /// <param name="displayOrder">排序</param>
        /// <returns></returns>
        public static bool UpdateHelpDisplayOrder(int id, int displayOrder)
        {
            bool result = false;
            if (id > 0)
            {
                result = CouponMall.Data.Helps.UpdateHelpDisplayOrder(id, displayOrder);
                if (result)
                    CouponMall.Core.BMACache.Remove(CacheKeys.MALL_HELP_LIST);
            }

            return result;
        }

    }
}
