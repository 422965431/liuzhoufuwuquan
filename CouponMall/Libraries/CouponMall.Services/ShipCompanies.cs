using System;
using System.Collections.Generic;

using CouponMall.Core;

namespace CouponMall.Services
{
    /// <summary>
    /// 配送公司操作管理类
    /// </summary>
    public partial class ShipCompanies
    {
        /// <summary>
        /// 获得配送公司列表
        /// </summary>
        /// <returns></returns>
        public static List<ShipCompanyInfo> GetShipCompanyList()
        {
            List<ShipCompanyInfo> shipCompanyList = CouponMall.Core.BMACache.Get(CacheKeys.MALL_SHIPCOMPANY_LIST) as List<ShipCompanyInfo>;
            if (shipCompanyList == null)
            {
                shipCompanyList = CouponMall.Data.ShipCompanies.GetShipCompanyList();
                CouponMall.Core.BMACache.Insert(CacheKeys.MALL_SHIPCOMPANY_LIST, shipCompanyList);
            }
            return shipCompanyList;
        }

        /// <summary>
        /// 获得配送公司数量
        /// </summary>
        /// <returns></returns>
        public static int GetShipCompanyCount()
        {
            return GetShipCompanyList().Count;
        }

        /// <summary>
        /// 获得配送公司
        /// </summary>
        /// <param name="shipCoId">配送公司id</param>
        /// <returns></returns>
        public static ShipCompanyInfo GetShipCompanyById(int shipCoId)
        {
            foreach (ShipCompanyInfo shipCompanyInfo in GetShipCompanyList())
            {
                if (shipCompanyInfo.ShipCoId == shipCoId)
                    return shipCompanyInfo;
            }
            return null;
        }
    }
}
