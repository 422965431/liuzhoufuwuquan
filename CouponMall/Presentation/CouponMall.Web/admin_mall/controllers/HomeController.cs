﻿using System;
using System.Web;
using System.Web.Mvc;

using CouponMall.Core;
using CouponMall.Services;
using CouponMall.Web.Framework;
using CouponMall.Web.MallAdmin.Models;

namespace CouponMall.Web.MallAdmin.Controllers
{
    /// <summary>
    /// 商城后台首页控制器类
    /// </summary>
    public partial class HomeController : BaseMallAdminController
    {
        /// <summary>
        /// 首页
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 导航栏
        /// </summary>
        public ActionResult NavBar()
        {
            return View();
        }

        /// <summary>
        /// 菜单栏
        /// </summary>
        public ActionResult Menu()
        {
            return View();
        }

        /// <summary>
        /// 商城运行信息
        /// </summary>
        public ActionResult MallRunInfo()
        {
            MallRunInfoModel model = new MallRunInfoModel();

            model.WaitConfirmCount = AdminOrders.GetOrderCountByCondition(0, (int)OrderState.Confirming, "", "");
            model.WaitPreProductCount = AdminOrders.GetOrderCountByCondition(0, (int)OrderState.Confirmed, "", "");
            model.WaitSendCount = AdminOrders.GetOrderCountByCondition(0, (int)OrderState.PreProducting, "", "");
            model.WaitPayCount = AdminOrders.GetOrderCountByCondition(0, (int)OrderState.WaitPaying, "", "");

            model.OnlineUserCount = OnlineUsers.GetOnlineUserCount();
            model.OnlineGuestCount = OnlineUsers.GetOnlineGuestCount();
            model.OnlineMemberCount = model.OnlineUserCount - model.OnlineGuestCount;

            model.MallVersion = BMAVersion.MALL_VERSION;
            model.NetVersion = Environment.Version.ToString();
            model.OSVersion = Environment.OSVersion.ToString();
            model.TickCount = (Environment.TickCount / 1000 / 60).ToString();
            model.ProcessorCount = Environment.ProcessorCount.ToString();
            model.WorkingSet = (Environment.WorkingSet / 1024 / 1024).ToString();

            MallUtils.SetAdminRefererCookie(Url.Action("mallruninfo"));
            return View(model);
        }
    }
}
