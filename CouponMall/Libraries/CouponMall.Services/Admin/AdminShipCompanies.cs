using System;

using CouponMall.Core;

namespace CouponMall.Services
{
    /// <summary>
    /// 后台配送公司操作管理类
    /// </summary>
    public partial class AdminShipCompanies : ShipCompanies
    {
        /// <summary>
        /// 创建配送公司
        /// </summary>
        public static void CreateShipCompany(ShipCompanyInfo shipCompanyInfo)
        {
            CouponMall.Data.ShipCompanies.CreateShipCompany(shipCompanyInfo);
            CouponMall.Core.BMACache.Remove(CacheKeys.MALL_SHIPCOMPANY_LIST);
        }

        /// <summary>
        /// 更新配送公司
        /// </summary>
        public static void UpdateShipCompany(ShipCompanyInfo shipCompanyInfo)
        {
            CouponMall.Data.ShipCompanies.UpdateShipCompany(shipCompanyInfo);
            CouponMall.Core.BMACache.Remove(CacheKeys.MALL_SHIPCOMPANY_LIST);
        }

        /// <summary>
        /// 删除配送公司
        /// </summary>
        /// <param name="shipCoId">配送公司id</param>
        public static void DeleteShipCompanyById(int shipCoId)
        {
            CouponMall.Data.ShipCompanies.DeleteShipCompanyById(shipCoId);
            CouponMall.Core.BMACache.Remove(CacheKeys.MALL_SHIPCOMPANY_LIST);
        }

        /// <summary>
        /// 根据配送公司名称得到配送公司id
        /// </summary>
        /// <param name="shipCoName">配送公司名称</param>
        /// <returns></returns>
        public static int GetShipCoIdByName(string shipCoName)
        {
            if (string.IsNullOrWhiteSpace(shipCoName))
                return 0;
            foreach (ShipCompanyInfo shipCompanyInfo in GetShipCompanyList())
            {
                if (shipCompanyInfo.Name == shipCoName)
                    return shipCompanyInfo.ShipCoId;
            }
            return 0;
        }
    }
}
