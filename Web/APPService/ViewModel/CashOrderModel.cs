using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.APPService
{
    public class CashOrderListModel
    {
        public List<CashOrderModel> list { set; get; }
        public int pageindex { set; get; }  //页码
        public int pagecount { set; get; } //总页数
        public int totalcount { set; get; } //总条数
    }

    public class CashOrderModel
    {
        public long OrderID { set; get; }
        public string OrderCode { set; get; }
        public string UserCode { set; get; }
        public int Number { set; get; }  //交易数量
        public decimal Price { set; get; }
        public decimal Amount { set; get; }
        public int TypeID { set; get; }  //订单类别
        public string TypeIDName { set; get; }  //类别文本
        public string OrderDate { set; get; }
    }
}