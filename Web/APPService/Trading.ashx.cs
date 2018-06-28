using Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Web.APPService.Service;
using Web.APPService.ViewModel;

namespace Web.APPService
{
    /// <summary>
    /// Transfer 的摘要说明
    /// </summary>
    public class Trading : ServiceHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string result = string.Empty;

            string act = context.Request["act"];
            if (string.IsNullOrEmpty(act) || act.Trim() == string.Empty)
            {
                return;
            }
            switch (act.ToLower())
            {
                case "house"://交易大厅
                    result = TradingFloor(context);
                    break;
                case "sell"://卖出
                    result = TradingSell(context);
                    break;
                case "selllist"://卖出记录
                    result = TradingSellList(context);
                    break;
                //case "sellorder"://卖出订单
                //    result = TradingSellOrderList(context);
                //    break;
                case "buy"://买入
                    result = TradingBuy(context);
                    break;
                case "buylist"://买入记录
                    result = TradingBuyList(context);
                    break;
                //case "buyorder"://买入订单
                //    result = TradingBuyOrderList(context);
                //    break;
                case "buyandsell"://买入/卖出列表
                    result = TradingBuyAndSell(context);
                    break;
                case "ordercancel"://撤销订单
                    result = TradingOrderCancel(context);
                    break;
                case "tradeorder"://交易订单
                    result = TradingOrderList(context);
                    break;
                default:
                    result = ResultJson(ResultType.error, "参数异常.", "trading");
                    break;
            }
            context.Response.Write(result);
        }
        
        #region 交易大厅列表
        /// <summary>
        /// 交易大厅列表
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string TradingFloor(HttpContext context)
        {
            string struserid = context.Request["userid"] ?? "";
            string strtop = context.Request["top"] ?? "0";
            bool flag = false;
            string message = string.Empty;
            long userid = 0;

            if (string.IsNullOrEmpty(struserid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }
            if (!long.TryParse(struserid, out userid))
            {
                return ResultJson(ResultType.error, "请输入有效的用户ID", "");
            }
            int top = 0;
            if (!int.TryParse(strtop, out top))
            {
                return ResultJson(ResultType.error, "请输入有效的查询数量", "");
            }

            TradingService svc = new TradingService();
            //交易大厅
            TradingHallModel model = svc.TradingHall(top, userid, out flag, out message);
            if (flag)
                return ResultJson(ResultType.success, message, model);
            else
                return ResultJson(ResultType.error, message, model);
        }
        #endregion
        
        #region 挂卖
        private string TradingSell(HttpContext context)
        {
            string struserid = context.Request["userid"] ?? "";
            string strnumber = context.Request["number"] ?? "";
            string strprice = context.Request["price"] ?? "";
            string strpaypassword = context.Request["paypassword"] ?? "";
            string message = string.Empty;
            bool flag = false;

            #region 用户ID
            long userid = 0;
            if (string.IsNullOrEmpty(struserid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }
            if (!long.TryParse(struserid, out userid))
            {
                return ResultJson(ResultType.error, "请输入有效的用户ID", "");
            }
            #endregion

            #region 挂卖数量
            int number = 0;
            if (string.IsNullOrEmpty(strnumber))
            {
                return ResultJson(ResultType.error, "请输入挂卖数量", "");
            }
            if (!int.TryParse(strnumber, out number))
            {
                return ResultJson(ResultType.error, "请输入有效的挂卖数量", "");
            }
            if (number <= 0)
            {
                return ResultJson(ResultType.error, "挂卖数量必须大于0", "");
            }
            #endregion

            #region 挂卖价格
            decimal price = 0;
            if (string.IsNullOrEmpty(strprice))
            {
                return ResultJson(ResultType.error, "请输入挂卖价格", "");
            }
            if (!decimal.TryParse(strprice, out price))
            {
                return ResultJson(ResultType.error, "请输入有效的挂卖价格", "");
            }
            #endregion

            #region 支付密码
            if (string.IsNullOrEmpty(strpaypassword))
            {
                return ResultJson(ResultType.error, "请输入支付密码", "");
            } 
            #endregion

            TradingService svc = new TradingService();
            TradingHallModel model = svc.Sell(userid, price, number, strpaypassword.ToUpper(), out flag, out message);
            if (flag)
            {
                return ResultJson(ResultType.success, message, model);
            }
            else
                return ResultJson(ResultType.error, message, model);
        }
        #endregion

        #region 挂卖记录列表
        private string TradingSellList(HttpContext context)
        {
            string struserid = context.Request["userid"] ?? "";
            string strpageindex = context.Request["pageindex"] ?? "";
            string strpagesize = context.Request["pagesize"] ?? "";
            string fromwhere = context.Request["fromwhere"] ?? "";
            string message = string.Empty;

            #region 用户ID
            long userid = 0;
            if (string.IsNullOrEmpty(struserid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }
            if (!long.TryParse(struserid, out userid))
            {
                return ResultJson(ResultType.error, "请输入有效的用户ID", "");
            }
            #endregion

            #region 查询页码
            int pageindex = 0;
            if (string.IsNullOrEmpty(strpageindex))
            {
                return ResultJson(ResultType.error, "请输入查询页码", "");
            }
            if (!int.TryParse(strpageindex, out pageindex))
            {
                return ResultJson(ResultType.error, "请输入有效的查询页码", "");
            }
            if (pageindex <= 0)
            {
                return ResultJson(ResultType.error, "请输入有效的查询页码", "");
            }
            #endregion

            #region 每页显示的记录数
            int pagesize = 0;
            if (string.IsNullOrEmpty(strpagesize))
            {
                return ResultJson(ResultType.error, "请输入每页显示的记录数", "");
            }
            if (!int.TryParse(strpagesize, out pagesize))
            {
                return ResultJson(ResultType.error, "请输入有效的每页显示的记录数", "");
            }
            if (pagesize <= 0)
            {
                return ResultJson(ResultType.error, "请输入有效的每页显示的记录数", "");
            }
            #endregion

            TradingService svc = new TradingService();
            int pagecount = 0, totalcount = 0;
            CashSellInfoListModel model = new CashSellInfoListModel();
            model.list = svc.SellList(userid, pageindex, pagesize, out pagecount, out totalcount);
            model.pageindex = pageindex;
            model.pagecount = pagecount;
            model.totalcount = totalcount;

            return ResultJson(ResultType.success, message, model);
        }
        #endregion
        
        #region 买入
        private string TradingBuy(HttpContext context)
        {
            string struserid = context.Request["userid"] ?? "";
            string strprice = context.Request["price"] ?? "";
            string strnumber = context.Request["number"] ?? "";
            string strpaypassword = context.Request["paypassword"] ?? "";
            string fromwhere = context.Request["fromwhere"] ?? "";
            string message = string.Empty;
            bool flag = false;

            #region 用户ID
            long userid = 0;
            if (string.IsNullOrEmpty(struserid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }
            if (!long.TryParse(struserid, out userid))
            {
                return ResultJson(ResultType.error, "请输入有效的用户ID", "");
            }
            #endregion

            #region 挂卖价格
            decimal price = 0;
            if (string.IsNullOrEmpty(strprice))
            {
                return ResultJson(ResultType.error, "请输入买入价格", "");
            }
            if (!decimal.TryParse(strprice, out price))
            {
                return ResultJson(ResultType.error, "请输入有效的买入价格", "");
            }
            #endregion

            #region 买入数量
            int number = 0;
            if (string.IsNullOrEmpty(strnumber))
            {
                return ResultJson(ResultType.error, "请输入买入数量", "");
            }
            if (!int.TryParse(strnumber, out number))
            {
                return ResultJson(ResultType.error, "请输入有效的买入数量", "");
            }
            if (number <= 0)
            {
                return ResultJson(ResultType.error, "挂卖数量必须大于0", "");
            }
            #endregion

            #region 支付密码
            if (string.IsNullOrEmpty(strpaypassword))
            {
                return ResultJson(ResultType.error, "请输入支付密码", "");
            }
            #endregion

            TradingService svc = new TradingService();
            TradingHallModel model = svc.Buy(userid, price, number, strpaypassword.ToUpper(), out flag, out message);
            if (flag)
            {
                return ResultJson(ResultType.success, message, model);
            }
            else
                return ResultJson(ResultType.error, message, model);
        }
        #endregion

        #region 买入记录列表
        private string TradingBuyList(HttpContext context)
        {
            string struserid = context.Request["userid"] ?? "";
            string strpageindex = context.Request["pageindex"] ?? "";
            string strpagesize = context.Request["pagesize"] ?? "";
            string fromwhere = context.Request["fromwhere"] ?? "";
            string message = string.Empty;

            #region 用户ID
            long userid = 0;
            if (string.IsNullOrEmpty(struserid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }
            if (!long.TryParse(struserid, out userid))
            {
                return ResultJson(ResultType.error, "请输入有效的用户ID", "");
            }
            #endregion

            #region 查询页码
            int pageindex = 0;
            if (string.IsNullOrEmpty(strpageindex))
            {
                return ResultJson(ResultType.error, "请输入查询页码", "");
            }
            if (!int.TryParse(strpageindex, out pageindex))
            {
                return ResultJson(ResultType.error, "请输入有效的查询页码", "");
            }
            if (pageindex <= 0)
            {
                return ResultJson(ResultType.error, "请输入有效的查询页码", "");
            }
            #endregion

            #region 每页显示的记录数
            int pagesize = 0;
            if (string.IsNullOrEmpty(strpagesize))
            {
                return ResultJson(ResultType.error, "请输入每页显示的记录数", "");
            }
            if (!int.TryParse(strpagesize, out pagesize))
            {
                return ResultJson(ResultType.error, "请输入有效的每页显示的记录数", "");
            }
            if (pagesize <= 0)
            {
                return ResultJson(ResultType.error, "请输入有效的每页显示的记录数", "");
            }
            #endregion

            TradingService svc = new TradingService();
            int pagecount = 0, totalcount = 0;
            CashBuyInfoListModel model = new CashBuyInfoListModel();
            model.list = svc.BuyList(userid, pageindex, pagesize, out pagecount, out totalcount);
            model.pageindex = pageindex;
            model.pagecount = pagecount;
            model.totalcount = totalcount;
            
            return ResultJson(ResultType.success, message, model);
        }
        #endregion

        #region 撤销订单
        private string TradingOrderCancel(HttpContext context)
        {
            string struserid = context.Request["userid"] ?? "";
            string strtypeid = context.Request["typeid"] ?? "";
            string strorderid = context.Request["orderid"] ?? "";
            string fromwhere = context.Request["fromwhere"] ?? "";
            string message = string.Empty;

            #region 用户ID
            long userid = 0;
            if (string.IsNullOrEmpty(struserid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }
            if (!long.TryParse(struserid, out userid))
            {
                return ResultJson(ResultType.error, "请输入有效的用户ID", "");
            }
            #endregion
            
            #region 订单ID
            long orderid = 0;
            if (string.IsNullOrEmpty(strorderid))
            {
                return ResultJson(ResultType.error, "请输入订单ID", "");
            }
            if (!long.TryParse(strorderid, out orderid))
            {
                return ResultJson(ResultType.error, "请输入有效的订单ID", "");
            }
            #endregion

            #region 订单类别
            int typeid = 0;
            if (string.IsNullOrEmpty(strtypeid))
            {
                return ResultJson(ResultType.error, "请输入订单类别", "");
            }
            if (!int.TryParse(strtypeid, out typeid))
            {
                return ResultJson(ResultType.error, "请输入有效的订单类别", "");
            }
            if (typeid != 1 && typeid != 2)
            {
                return ResultJson(ResultType.error, "请输入有效的订单类别", "");
            }
            #endregion

            TradingService svc = new TradingService();
            bool result=false;
            if (typeid == 1)//买入
            {
                result = svc.BuyCancel(userid, orderid, out message);
            }
            else if (typeid == 2)//卖出
            {
                result = svc.SellCancel(userid, orderid, out message);
            }

            if (result==true)
            {
                return ResultJson(ResultType.success, message, "");
            }
            return ResultJson(ResultType.error, message, "");
        } 
        #endregion
        
        #region 交易订单
        private string TradingOrderList(HttpContext context)
        {
            string struserid = context.Request["userid"] ?? "";
            string strtypeid = context.Request["typeid"] ?? "";
            string strorderid = context.Request["orderid"] ?? "";
            string strpageindex = context.Request["pageindex"] ?? "";
            string strpagesize = context.Request["pagesize"] ?? "";
            string fromwhere = context.Request["fromwhere"] ?? "";
            string message = string.Empty;

            #region 用户ID
            long userid = 0;
            if (string.IsNullOrEmpty(struserid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }
            if (!long.TryParse(struserid, out userid))
            {
                return ResultJson(ResultType.error, "请输入有效的用户ID", "");
            }
            #endregion

            long orderid = 0;
            int typeid = 0;
            if (fromwhere != "pc")
            {
                #region 订单ID
                if (string.IsNullOrEmpty(strorderid))
                {
                    return ResultJson(ResultType.error, "请输入订单ID", "");
                }
                if (!long.TryParse(strorderid, out orderid))
                {
                    return ResultJson(ResultType.error, "请输入有效的订单ID", "");
                }
                #endregion

                #region 订单类别
                if (string.IsNullOrEmpty(strtypeid))
                {
                    return ResultJson(ResultType.error, "请输入订单类别", "");
                }
                if (!int.TryParse(strtypeid, out typeid))
                {
                    return ResultJson(ResultType.error, "请输入有效的订单类别", "");
                }
                if (typeid != 1 && typeid != 2)
                {
                    return ResultJson(ResultType.error, "请输入有效的订单类别", "");
                }
                #endregion
            }
            
            #region 查询页码
            int pageindex = 0;
            if (string.IsNullOrEmpty(strpageindex))
            {
                return ResultJson(ResultType.error, "请输入查询页码", "");
            }
            if (!int.TryParse(strpageindex, out pageindex))
            {
                return ResultJson(ResultType.error, "请输入有效的查询页码", "");
            }
            if (pageindex <= 0)
            {
                return ResultJson(ResultType.error, "请输入有效的查询页码", "");
            }
            #endregion

            #region 每页显示的记录数
            int pagesize = 0;
            if (string.IsNullOrEmpty(strpagesize))
            {
                return ResultJson(ResultType.error, "请输入每页显示的记录数", "");
            }
            if (!int.TryParse(strpagesize, out pagesize))
            {
                return ResultJson(ResultType.error, "请输入有效的每页显示的记录数", "");
            }
            if (pagesize <= 0)
            {
                return ResultJson(ResultType.error, "请输入有效的每页显示的记录数", "");
            }
            #endregion

            TradingService svc = new TradingService();
            bool flag = svc.ExistsByUserID(userid);
            if(flag == false)
            {
                return ResultJson(ResultType.error, "用户ID不存在", "");
            }
            int pagecount = 0, totalcount = 0;
            CashOrderListModel model = new CashOrderListModel();
            model.list = svc.TradeOrderList(userid, orderid, typeid, pageindex, pagesize, out pagecount, out totalcount, fromwhere);
            model.pageindex = pageindex;
            model.pagecount = pagecount;
            model.totalcount = totalcount;
            return ResultJson(ResultType.success, message, model);
        }
        #endregion

        #region 买入/卖出列表
        /// <summary>
        /// 买入/卖出列表
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string TradingBuyAndSell(HttpContext context)
        {
            string struserid = context.Request["userid"] ?? "";
            string strpageindex = context.Request["pageindex"] ?? "";
            string strpagesize = context.Request["pagesize"] ?? "";
            bool flag = false;
            string message = string.Empty;

            #region 用户ID
            long userid = 0;
            if (string.IsNullOrEmpty(struserid))
            {
                return ResultJson(ResultType.error, "请输入用户ID", "");
            }
            if (!long.TryParse(struserid, out userid))
            {
                return ResultJson(ResultType.error, "请输入有效的用户ID", "");
            }
            #endregion

            #region 查询页码
            int pageindex = 0;
            if (string.IsNullOrEmpty(strpageindex))
            {
                return ResultJson(ResultType.error, "请输入查询页码", "");
            }
            if (!int.TryParse(strpageindex, out pageindex))
            {
                return ResultJson(ResultType.error, "请输入有效的查询页码", "");
            }
            if (pageindex <= 0)
            {
                return ResultJson(ResultType.error, "请输入有效的查询页码", "");
            }
            #endregion

            #region 每页显示的记录数
            int pagesize = 0;
            if (string.IsNullOrEmpty(strpagesize))
            {
                return ResultJson(ResultType.error, "请输入每页显示的记录数", "");
            }
            if (!int.TryParse(strpagesize, out pagesize))
            {
                return ResultJson(ResultType.error, "请输入有效的每页显示的记录数", "");
            }
            if (pagesize <= 0)
            {
                return ResultJson(ResultType.error, "请输入有效的每页显示的记录数", "");
            }
            #endregion

            TradingService svc = new TradingService();
            //交易大厅
            int pagecount;
            int totalcount;
            TradingBuyAndSellListModel model = new TradingBuyAndSellListModel();
            model.list = svc.TradingBuyAndSellList(userid, pageindex, pagesize,out pagecount, out totalcount, out flag, out message);
            model.pageindex = pageindex;
            model.pagecount = pagecount;
            model.totalcount = totalcount;
            if (flag)
                return ResultJson(ResultType.success, message, model);
            else
                return ResultJson(ResultType.error, message, model);
        } 
        #endregion

    }


}