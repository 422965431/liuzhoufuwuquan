using System;
using System.Collections.Generic;

using CouponMall.Core;
using CouponMall.Services;
using CouponMall.Web.Framework;

namespace CouponMall.Web.Models
{
    /// <summary>
    /// 问题模型类
    /// </summary>
    public class QuestionModel
    {
        public HelpInfo HelpInfo { get; set; }
        public List<HelpInfo> HelpList { get; set; }
    }
}