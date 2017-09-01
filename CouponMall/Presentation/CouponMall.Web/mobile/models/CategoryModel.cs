using System;
using System.Collections.Generic;

using CouponMall.Core;
using CouponMall.Services;
using CouponMall.Web.Framework;

namespace CouponMall.Web.Mobile.Models
{
    /// <summary>
    /// 分类列表模型类
    /// </summary>
    public class CategoryListModel
    {
        public CategoryInfo CategoryInfo { get; set; }
        public List<CategoryInfo> CategoryList { get; set; }
    }
}