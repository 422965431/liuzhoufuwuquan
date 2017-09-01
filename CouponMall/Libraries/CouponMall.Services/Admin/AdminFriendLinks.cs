using System;

using CouponMall.Core;

namespace CouponMall.Services
{
    /// <summary>
    /// 后台友情链接操作管理类
    /// </summary>
    public partial class AdminFriendLinks : FriendLinks
    {
        /// <summary>
        /// 创建友情链接
        /// </summary>
        public static void CreateFriendLink(FriendLinkInfo friendLinkInfo)
        {
            CouponMall.Data.FriendLinks.CreateFriendLink(friendLinkInfo);
            CouponMall.Core.BMACache.Remove(CacheKeys.MALL_FRIENDLINK_LIST);
        }

        /// <summary>
        /// 删除友情链接
        /// </summary>
        /// <param name="idList">友情链接id</param>
        public static void DeleteFriendLinkById(int[] idList)
        {
            if (idList != null && idList.Length > 0)
            {
                CouponMall.Data.FriendLinks.DeleteFriendLinkById(CommonHelper.IntArrayToString(idList));
                CouponMall.Core.BMACache.Remove(CacheKeys.MALL_FRIENDLINK_LIST);
            }
        }

        /// <summary>
        /// 更新友情链接
        /// </summary>
        public static void UpdateFriendLink(FriendLinkInfo friendLinkInfo)
        {
            CouponMall.Data.FriendLinks.UpdateFriendLink(friendLinkInfo);
            CouponMall.Core.BMACache.Remove(CacheKeys.MALL_FRIENDLINK_LIST);
        }
    }
}
