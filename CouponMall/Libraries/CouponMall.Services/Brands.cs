using System;
using System.Text;
using System.Data;
using System.Collections.Generic;

using CouponMall.Core;

namespace CouponMall.Services
{
    /// <summary>
    /// 品牌操作管理类
    /// </summary>
    public partial class Brands
    {
        /// <summary>
        /// 获得品牌
        /// </summary>
        /// <param name="brandId">品牌id</param>
        /// <returns></returns>
        public static BrandInfo GetBrandById(int brandId)
        {
            BrandInfo brandInfo = CouponMall.Core.BMACache.Get(CacheKeys.MALL_BRAND_INFO + brandId) as BrandInfo;
            if (brandInfo == null)
            {
                brandInfo = CouponMall.Data.Brands.GetBrandById(brandId);
                CouponMall.Core.BMACache.Insert(CacheKeys.MALL_BRAND_INFO + brandId, brandInfo);
            }

            return brandInfo;
        }

        /// <summary>
        /// 根据品牌名称得到品牌id
        /// </summary>
        /// <param name="brandName">品牌名称</param>
        /// <returns></returns>
        public static int GetBrandIdByName(string brandName)
        {
            return CouponMall.Data.Brands.GetBrandIdByName(brandName);
        }

        /// <summary>
        /// 获得品牌列表
        /// </summary>
        /// <param name="pageSize">每页数</param>
        /// <param name="pageNumber">当前页数</param>
        /// <param name="brandName">品牌名称</param>
        /// <returns></returns>
        public static List<BrandInfo> GetBrandList(int pageSize, int pageNumber, string brandName)
        {
            return CouponMall.Data.Brands.GetBrandList(pageSize, pageNumber, brandName);
        }

        /// <summary>
        /// 获得品牌数量
        /// </summary>
        /// <param name="brandName">品牌名称</param>
        /// <returns></returns>
        public static int GetBrandCount(string brandName)
        {
            return CouponMall.Data.Brands.GetBrandCount(brandName);
        }
    }
}
