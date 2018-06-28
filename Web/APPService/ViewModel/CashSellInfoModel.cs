using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.APPService
{
    public class CashSellInfoListModel
    {
        public List<CashSellInfoModel> list { set; get; }
        public int pageindex { set; get; }  //页码
        public int pagecount { set; get; } //总页数
        public int totalcount { set; get; } //总条数
    }
    public class CashSellInfoModel
    {
        public long OrderID { set; get; }//卖出订单ID
        public string OrderCode { set; get; }//卖出订单编号
        public string UserCode { set; get; }//卖出用户编号
        public decimal Price { set; get; }
        public int Number { set; get; }//总量
        public decimal Amount { set; get; }
        public int SaleNum { set; get; }//已卖
        public int SurplusNum { set; get; }//剩余
        public int Status { set; get; }//状态
        public string StatusText { set; get; }//状态文本
        public string SellDate { set; get; }

    }
}